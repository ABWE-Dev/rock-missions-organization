﻿// <copyright>
// Copyright by ABWE
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock;
using Rock.Attribute;
using Rock.Constants;
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.Web;
using Rock.Web.Cache;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Plugins.org_abwe.RockMissions.Churches
{
    [DisplayName( "Church Detail" )]
    [Category( "org_abwe > RockMissions > Churches" )]
    [Description( "Displays the details of the given church." )]

    [LinkedPage( "Person Profile Page", "The page used to view the details of a church contact", order: 0 )]
    [LinkedPage( "Communication Page", "The communication page to use for when the church email address is clicked. Leave this blank to use the default.", false, "", "", 1 )]
    public partial class ChurchDetail : Rock.Web.UI.RockBlock, IDetailBlock
    {
        #region Base Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            dvpRecordStatus.DefinedTypeId = DefinedTypeCache.Get( new Guid( Rock.SystemGuid.DefinedType.PERSON_RECORD_STATUS ) ).Id;
            dvpReason.DefinedTypeId = DefinedTypeCache.Get( new Guid( Rock.SystemGuid.DefinedType.PERSON_RECORD_STATUS_REASON ) ).Id;

            bool canEdit = IsUserAuthorized( Authorization.EDIT );

            gContactList.DataKeyNames = new string[] { "Id" };
            gContactList.Actions.ShowAdd = canEdit;
            gContactList.Actions.AddClick += gContactList_AddClick;
            gContactList.GridRebind += gContactList_GridRebind;
            gContactList.IsDeleteEnabled = canEdit;

            mdAddContact.SaveClick += mdAddContact_SaveClick;
            mdAddContact.OnCancelScript = string.Format( "$('#{0}').val('');", hfModalOpen.ClientID );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                ShowDetail( PageParameter( "ChurchId" ).AsInteger() );
            }

            if ( !string.IsNullOrWhiteSpace( hfModalOpen.Value ) )
            {
                mdAddContact.Show();
            }
        }

        #endregion Control Methods

        #region Events

        /// <summary>
        /// Handles the Click event of the lbEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbEdit_Click( object sender, EventArgs e )
        {
            var rockContext = new RockContext();
            var church = new PersonService( rockContext ).Get( int.Parse( hfChurchId.Value ) );
            ShowEditDetails( church );
        }

        /// <summary>
        /// Handles the Click event of the lbSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbSave_Click( object sender, EventArgs e )
        {
            var rockContext = new RockContext();

            var personService = new PersonService( rockContext );
            Person church = null;

            if ( int.Parse( hfChurchId.Value ) != 0 )
            {
                church = personService.Get( int.Parse( hfChurchId.Value ) );
            }

            if ( church == null )
            {
                church = new Person();
                personService.Add( church );
                tbChurchName.Text = tbChurchName.Text.FixCase();
            }

            // Church Name
            church.LastName = tbChurchName.Text;

            // Phone Number
            var churchPhoneTypeId = new DefinedValueService( rockContext ).GetByGuid( new Guid( Rock.SystemGuid.DefinedValue.PERSON_PHONE_TYPE_WORK ) ).Id;

            var phoneNumber = church.PhoneNumbers.FirstOrDefault( n => n.NumberTypeValueId == churchPhoneTypeId );

            if ( !string.IsNullOrWhiteSpace( PhoneNumber.CleanNumber( pnbPhone.Number ) ) )
            {
                if ( phoneNumber == null )
                {
                    phoneNumber = new PhoneNumber { NumberTypeValueId = churchPhoneTypeId };
                    church.PhoneNumbers.Add( phoneNumber );
                }
                phoneNumber.CountryCode = PhoneNumber.CleanNumber( pnbPhone.CountryCode );
                phoneNumber.Number = PhoneNumber.CleanNumber( pnbPhone.Number );
                phoneNumber.IsMessagingEnabled = cbSms.Checked;
                phoneNumber.IsUnlisted = cbUnlisted.Checked;
            }
            else
            {
                if ( phoneNumber != null )
                {
                    church.PhoneNumbers.Remove( phoneNumber );
                    new PhoneNumberService( rockContext ).Delete( phoneNumber );
                }
            }

            // Record Type - this is always "church". it will never change.
            church.RecordTypeValueId = DefinedValueCache.Get(org.abwe.RockMissions.Churches.SystemGuid.DefinedValue.PERSON_RECORD_TYPE_CHURCH.AsGuid() ).Id;

            // Record Status
            church.RecordStatusValueId = dvpRecordStatus.SelectedValueAsInt(); ;

            // Record Status Reason
            int? newRecordStatusReasonId = null;
            if ( church.RecordStatusValueId.HasValue && church.RecordStatusValueId.Value == DefinedValueCache.Get( new Guid( Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_INACTIVE ) ).Id )
            {
                newRecordStatusReasonId = dvpReason.SelectedValueAsInt();
            }
            church.RecordStatusReasonValueId = newRecordStatusReasonId;

            // Email
            church.IsEmailActive = true;
            church.Email = tbEmail.Text.Trim();
            church.EmailPreference = rblEmailPreference.SelectedValue.ConvertToEnum<EmailPreference>();

            if ( !church.IsValid )
            {
                // Controls will render the error messages
                return;
            }

            rockContext.WrapTransaction( () =>
            {
                rockContext.SaveChanges();

                // TODO is the family group necessary?
                // Add/Update Family Group
                var familyGroupType = GroupTypeCache.GetFamilyGroupType();
                int adultRoleId = familyGroupType.Roles
                    .Where( r => r.Guid.Equals( Rock.SystemGuid.GroupRole.GROUPROLE_FAMILY_MEMBER_ADULT.AsGuid() ) )
                    .Select( r => r.Id )
                    .FirstOrDefault();
                var adultFamilyMember = UpdateGroupMember( church.Id, familyGroupType, church.LastName + " Church", adultRoleId, rockContext );
                church.GivingGroup = adultFamilyMember.Group;

                // Add/Update Church Group Type


                // Add/Update Known Relationship Group Type
                var knownRelationshipGroupType = GroupTypeCache.Get( Rock.SystemGuid.GroupType.GROUPTYPE_KNOWN_RELATIONSHIPS.AsGuid() );
                int knownRelationshipOwnerRoleId = knownRelationshipGroupType.Roles
                    .Where( r => r.Guid.Equals( Rock.SystemGuid.GroupRole.GROUPROLE_KNOWN_RELATIONSHIPS_OWNER.AsGuid() ) )
                    .Select( r => r.Id )
                    .FirstOrDefault();
                var knownRelationshipOwner = UpdateGroupMember( church.Id, knownRelationshipGroupType, "Known Relationship", knownRelationshipOwnerRoleId, rockContext );

                // Add/Update Implied Relationship Group Type
                var impliedRelationshipGroupType = GroupTypeCache.Get( Rock.SystemGuid.GroupType.GROUPTYPE_PEER_NETWORK.AsGuid() );
                int impliedRelationshipOwnerRoleId = impliedRelationshipGroupType.Roles
                    .Where( r => r.Guid.Equals( Rock.SystemGuid.GroupRole.GROUPROLE_PEER_NETWORK_OWNER.AsGuid() ) )
                    .Select( r => r.Id )
                    .FirstOrDefault();
                var impliedRelationshipOwner = UpdateGroupMember( church.Id, impliedRelationshipGroupType, "Implied Relationship", impliedRelationshipOwnerRoleId, rockContext );

                rockContext.SaveChanges();

                // Location
                int workLocationTypeId = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_WORK ).Id;

                var groupLocationService = new GroupLocationService( rockContext );
                var workLocation = groupLocationService.Queryable( "Location" )
                    .Where( gl =>
                        gl.GroupId == adultFamilyMember.Group.Id &&
                        gl.GroupLocationTypeValueId == workLocationTypeId )
                    .FirstOrDefault();

                if ( string.IsNullOrWhiteSpace( acAddress.Street1 ) )
                {
                    if ( workLocation != null )
                    {
                        groupLocationService.Delete( workLocation );
                    }
                }
                else
                {
                    var newLocation = new LocationService( rockContext ).Get(
                        acAddress.Street1, acAddress.Street2, acAddress.City, acAddress.State, acAddress.PostalCode, acAddress.Country );
                    if ( workLocation == null )
                    {
                        workLocation = new GroupLocation();
                        groupLocationService.Add( workLocation );
                        workLocation.GroupId = adultFamilyMember.Group.Id;
                        workLocation.GroupLocationTypeValueId = workLocationTypeId;
                    }
                    workLocation.Location = newLocation;
                    workLocation.IsMailingLocation = true;
                }

                rockContext.SaveChanges();

                hfChurchId.Value = church.Id.ToString();
            } );

            var queryParams = new Dictionary<string, string>();
            queryParams.Add( "ChurchId", hfChurchId.Value );
            NavigateToCurrentPage( queryParams );
        }

        /// <summary>
        /// Handles the Click event of the lbCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lbCancel_Click( object sender, EventArgs e )
        {
            int? churchId = hfChurchId.Value.AsIntegerOrNull();
            if ( churchId.HasValue && churchId > 0 )
            {
                ShowSummary( churchId.Value );
            }
            else
            {
                NavigateToParentPage();
            }
        }

        /// <summary>
        /// Handles the RowSelected event of the gContactList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Rock.Web.UI.Controls.RowEventArgs"/> instance containing the event data.</param>
        protected void gContactList_RowSelected( object sender, Rock.Web.UI.Controls.RowEventArgs e )
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add( "PersonId", e.RowKeyId.ToString() );
            NavigateToLinkedPage( "PersonProfilePage", queryParams );
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlRecordStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlRecordStatus_SelectedIndexChanged( object sender, EventArgs e )
        {
            dvpReason.Visible = dvpRecordStatus.SelectedValueAsInt() == DefinedValueCache.Get( new Guid( Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_INACTIVE ) ).Id;
        }

        /// <summary>
        /// Handles the AddClick event of the gContactList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gContactList_AddClick( object sender, EventArgs e )
        {
            ppContact.SetValue( null );
            hfModalOpen.Value = "Yes";
            mdAddContact.Show();
        }

        /// <summary>
        /// Handles the Delete event of the gContactList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Rock.Web.UI.Controls.RowEventArgs"/> instance containing the event data.</param>
        protected void gContactList_Delete( object sender, Rock.Web.UI.Controls.RowEventArgs e )
        {
            int? churchId = hfChurchId.Value.AsIntegerOrNull();
            if ( churchId.HasValue )
            {
                var churchContactId = e.RowKeyId;

                var rockContext = new RockContext();
                var groupMemberService = new GroupMemberService( rockContext );

                Guid churchContact = Rock.SystemGuid.GroupRole.GROUPROLE_KNOWN_RELATIONSHIPS_BUSINESS_CONTACT.AsGuid();
                Guid church = Rock.SystemGuid.GroupRole.GROUPROLE_KNOWN_RELATIONSHIPS_BUSINESS.AsGuid();
                Guid ownerGuid = Rock.SystemGuid.GroupRole.GROUPROLE_KNOWN_RELATIONSHIPS_OWNER.AsGuid();
                foreach ( var groupMember in groupMemberService.Queryable()
                    .Where( m =>
                        (
                            // The contact person in the church's known relationships
                            m.PersonId == churchContactId &&
                            m.GroupRole.Guid.Equals( churchContact ) &&
                            m.Group.Members.Any( o =>
                                o.PersonId == churchId &&
                                o.GroupRole.Guid.Equals( ownerGuid ) )
                        ) ||
                        (
                            // The church in the person's know relationships
                            m.PersonId == churchId &&
                            m.GroupRole.Guid.Equals( church ) &&
                            m.Group.Members.Any( o =>
                                o.PersonId == churchContactId &&
                                o.GroupRole.Guid.Equals( ownerGuid ) )
                        )
                        ) )
                {
                    groupMemberService.Delete( groupMember );
                }

                rockContext.SaveChanges();

                BindContactListGrid( new PersonService( rockContext ).Get( churchId.Value ) );
            }

        }

        /// <summary>
        /// Handles the SaveClick event of the mdAddContact control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mdAddContact_SaveClick( object sender, EventArgs e )
        {
            var rockContext = new RockContext();
            var personService = new PersonService( rockContext );
            var groupService = new GroupService( rockContext );
            var groupMemberService = new GroupMemberService( rockContext );
            var church = personService.Get( int.Parse( hfChurchId.Value ) );
            int? contactId = ppContact.PersonId;
            
            if ( contactId.HasValue && contactId.Value > 0 )
            {
                // TODO figure out how to add a contact to a church
                // personService.AddContactToChurch( church.Id, contactId.Value );
                // rockContext.SaveChanges();
            }

            mdAddContact.Hide();
            hfModalOpen.Value = string.Empty;
            BindContactListGrid( church );
        }

        /// <summary>
        /// Handles the GridRebind event of the gContactList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gContactList_GridRebind( object sender, EventArgs e )
        {
            var rockContext = new RockContext();
            var church = new PersonService( rockContext ).Get( int.Parse( hfChurchId.Value ) );
            BindContactListGrid( church );
        }

        #endregion Events

        #region Internal Methods

        /// <summary>
        /// Shows the detail.
        /// </summary>
        /// <param name="churchId">The church identifier.</param>
        public void ShowDetail( int churchId )
        {
            var rockContext = new RockContext();

            Person church = null;     // A church is a person

            if ( !churchId.Equals( 0 ) )
            {
                church = new PersonService( rockContext ).Get( churchId );
                pdAuditDetails.SetEntity( church, ResolveRockUrl( "~" ) );
            }

            if ( church == null )
            {
                church = new Person { Id = 0, Guid = Guid.NewGuid() };
                // hide the panel drawer that show created and last modified dates
                pdAuditDetails.Visible = false;
            }

            bool editAllowed = church.IsAuthorized( Authorization.EDIT, CurrentPerson );

            hfChurchId.Value = church.Id.ToString();

            bool readOnly = false;

            nbEditModeMessage.Text = string.Empty;
            if ( !editAllowed || !IsUserAuthorized( Authorization.EDIT ) )
            {
                readOnly = true;
                nbEditModeMessage.Text = EditModeMessage.ReadOnlyEditActionNotAllowed( Person.FriendlyTypeName );
            }

            if ( readOnly )
            {
                ShowSummary( churchId );
            }
            else
            {
                if ( church.Id > 0 )
                {
                    ShowSummary( church.Id );
                }
                else
                {
                    ShowEditDetails( church );
                }
            }

            BindContactListGrid( church );
        }

        /// <summary>
        /// Shows the summary.
        /// </summary>
        /// <param name="church">The church.</param>
        private void ShowSummary( int churchId )
        {
            SetEditMode( false );
            hfChurchId.SetValue( churchId );
            lTitle.Text = "View Church".FormatAsHtmlTitle();

            var church = new PersonService( new RockContext() ).Get( churchId );
            if ( church != null )
            {
                SetHeadingStatusInfo( church );
                var detailsLeft = new DescriptionList();
                detailsLeft.Add( "Church Name", church.LastName );

                if ( church.RecordStatusReasonValue != null )
                {
                    detailsLeft.Add( "Record Status Reason", church.RecordStatusReasonValue );
                }

                lDetailsLeft.Text = detailsLeft.Html;

                var detailsRight = new DescriptionList();

                // Get address
                var workLocationType = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_WORK.AsGuid() );
                if ( workLocationType != null )
                {
                    if ( church.GivingGroup != null ) // Giving Group is a shortcut to Family Group for church
                    {
                        var location = church.GivingGroup.GroupLocations
                            .Where( gl => gl.GroupLocationTypeValueId == workLocationType.Id )
                            .Select( gl => gl.Location )
                            .FirstOrDefault();
                        if ( location != null )
                        {
                            detailsRight.Add( "Address", location.GetFullStreetAddress().ConvertCrLfToHtmlBr() );
                        }
                    }
                }

                var workPhoneType = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.PERSON_PHONE_TYPE_WORK.AsGuid() );
                if ( workPhoneType != null )
                {
                    var phoneNumber = church.PhoneNumbers.FirstOrDefault( n => n.NumberTypeValueId == workPhoneType.Id );
                    if ( phoneNumber != null )
                    {
                        detailsRight.Add( "Phone Number", phoneNumber.ToString() );
                    }
                }

                var communicationLinkedPageValue = this.GetAttributeValue( "CommunicationPage" );
                Rock.Web.PageReference communicationPageReference;
                if ( communicationLinkedPageValue.IsNotNullOrWhiteSpace() )
                {
                    communicationPageReference = new Rock.Web.PageReference( communicationLinkedPageValue );
                }
                else
                {
                    communicationPageReference = null;
                }

                detailsRight.Add( "Email Address", church.GetEmailTag( ResolveRockUrl( "/" ), communicationPageReference ) );

                lDetailsRight.Text = detailsRight.Html;
            }
        }

        /// <summary>
        /// Sets the heading Status information.
        /// </summary>
        /// <param name="church">The church.</param>
        private void SetHeadingStatusInfo( Person church )
        {
            if ( church.RecordStatusValue != null )
            {
                hlStatus.Text = church.RecordStatusValue.Value;
                if ( church.RecordStatusValue.Guid == Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_PENDING.AsGuid() )
                {
                    hlStatus.LabelType = LabelType.Warning;
                }
                else if ( church.RecordStatusValue.Guid == Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_INACTIVE.AsGuid() )
                {
                    hlStatus.LabelType = LabelType.Danger;
                }
                else
                {
                    hlStatus.LabelType = LabelType.Success;
                }
            }
        }

        /// <summary>
        /// Shows the edit details.
        /// </summary>
        /// <param name="church">The church.</param>
        private void ShowEditDetails( Person church )
        {
            if ( church.Id > 0 )
            {
                var rockContext = new RockContext();

                lTitle.Text = ActionTitle.Edit( church.FullName ).FormatAsHtmlTitle();
                tbChurchName.Text = church.LastName;

                // address
                Location location = null;
                var workLocationType = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_WORK.AsGuid() );
                if ( church.GivingGroup != null )     // Giving group is a shortcut to the family group for church
                {
                    location = church.GivingGroup.GroupLocations
                        .Where( gl => gl.GroupLocationTypeValueId == workLocationType.Id )
                        .Select( gl => gl.Location )
                        .FirstOrDefault();
                }
                acAddress.SetValues( location );

                // Phone Number
                var workPhoneType = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.PERSON_PHONE_TYPE_WORK.AsGuid() );
                PhoneNumber phoneNumber = null;
                if ( workPhoneType != null )
                {
                    phoneNumber = church.PhoneNumbers.FirstOrDefault( n => n.NumberTypeValueId == workPhoneType.Id );
                }
                if ( phoneNumber != null )
                {
                    pnbPhone.Text = phoneNumber.NumberFormatted;
                    cbSms.Checked = phoneNumber.IsMessagingEnabled;
                    cbUnlisted.Checked = phoneNumber.IsUnlisted;
                }
                else
                {
                    pnbPhone.Text = string.Empty;
                    cbSms.Checked = false;
                    cbUnlisted.Checked = false;
                }

                tbEmail.Text = church.Email;
                rblEmailPreference.SelectedValue = church.EmailPreference.ToString();

                dvpRecordStatus.SelectedValue = church.RecordStatusValueId.HasValue ? church.RecordStatusValueId.Value.ToString() : string.Empty;
                dvpReason.SelectedValue = church.RecordStatusReasonValueId.HasValue ? church.RecordStatusReasonValueId.Value.ToString() : string.Empty;
                dvpReason.Visible = church.RecordStatusReasonValueId.HasValue &&
                    church.RecordStatusValueId.Value == DefinedValueCache.Get( new Guid( Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_INACTIVE ) ).Id;
            }
            else
            {
                lTitle.Text = ActionTitle.Add( "Church" ).FormatAsHtmlTitle();
            }

            SetEditMode( true );
        }

        /// <summary>
        /// Sets the edit mode.
        /// </summary>
        /// <param name="editable">if set to <c>true</c> [editable].</param>
        private void SetEditMode( bool editable )
        {
            pnlEditDetails.Visible = editable;
            fieldsetViewSummary.Visible = !editable;
            gContactList.Visible = !editable;
            pnlContactList.Visible = !editable;
            this.HideSecondaryBlocks( editable );
        }

        /// <summary>
        /// Binds the contact list grid.
        /// </summary>
        /// <param name="church">The church.</param>
        private void BindContactListGrid( Person church )
        {
            var personList = new GroupMemberService( new RockContext() ).Queryable()
                .Where( g =>
                    g.GroupRole.Guid.Equals( new Guid(org.abwe.RockMissions.Churches.SystemGuid.GroupTypeRole.GROUPROLE_CHURCH) ) &&
                    g.PersonId == church.Id )
                .SelectMany( g => g.Group.Members
                    .Where( m => !m.GroupRole.Guid.Equals( new Guid(org.abwe.RockMissions.Churches.SystemGuid.GroupTypeRole.GROUPROLE_CHURCH) ) )
                    .Select( m => m.Person ) )
                .ToList();

            gContactList.DataSource = personList;
            gContactList.DataBind();
        }

        /// <summary>
        /// Updates the group member.
        /// </summary>
        /// <param name="churchId">The church identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="groupRoleId">The group role identifier.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <returns></returns>
        private GroupMember UpdateGroupMember( int churchId, GroupTypeCache groupType, string groupName, int groupRoleId, RockContext rockContext )
        {
            var groupMemberService = new GroupMemberService( rockContext );

            GroupMember groupMember = groupMemberService.Queryable( "Group" )
                .Where( m =>
                    m.PersonId == churchId &&
                    m.GroupRoleId == groupRoleId )
                .FirstOrDefault();

            if ( groupMember == null )
            {
                groupMember = new GroupMember();
                groupMember.Group = new Group();
            }

            groupMember.PersonId = churchId;
            groupMember.GroupRoleId = groupRoleId;
            groupMember.GroupMemberStatus = GroupMemberStatus.Active;

            groupMember.Group.GroupTypeId = groupType.Id;
            groupMember.Group.Name = groupName;

            if ( groupMember.Id == 0)
            {
                groupMemberService.Add( groupMember );
            }

            return groupMember;
        }

        #endregion Internal Methods

    }
}