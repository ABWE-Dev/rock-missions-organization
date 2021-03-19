// <copyright>
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
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.Utility;
using Rock.Web.Cache;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Plugins.org_abwe.RockMissions
{
    [DisplayName( "Church List" )]
    [Category( "org_abwe > RockMissions > Churches" )]
    [Description( "Lists all churches and provides name, location, and sending/supporting filters" )]

    #region Block Attributes

    [LinkedPage(
        "Detail Page",
        Key = AttributeKey.DetailPage,
        Order = 0 )]

    #endregion Block Attributes
    public partial class ChurchList : RockBlock, ICustomGridColumns
    {
        #region Attribute Keys

        private static class AttributeKey
        {
            public const string DetailPage = "DetailPage";
        }

        #endregion Attribute Keys

        #region Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            bool canEdit = IsUserAuthorized( Authorization.EDIT );

            gfChurchFilter.ApplyFilterClick += gfChurchFilter_ApplyFilterClick;
            gfChurchFilter.DisplayFilterValue += gfChurchFilter_DisplayFilterValue;

            gChurchList.DataKeyNames = new string[] { "Id" };
            gChurchList.Actions.ShowAdd = canEdit;
            gChurchList.Actions.AddClick += gChurchList_AddClick;
            gChurchList.GridRebind += gChurchList_GridRebind;
            gChurchList.IsDeleteEnabled = canEdit;
            gChurchList.PersonIdField = "Id";
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
                BindFilter();
                BindGrid();
            }
        }

        #endregion Control Methods

        #region Events

        /// <summary>
        /// Handles the DisplayFilterValue event of the gfChurchFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Rock.Web.UI.Controls.GridFilter.DisplayFilterValueArgs"/> instance containing the event data.</param>
        private void gfChurchFilter_DisplayFilterValue( object sender, Rock.Web.UI.Controls.GridFilter.DisplayFilterValueArgs e )
        {
            switch ( e.Key )
            {
                case "Church Name":
                    break;
            }
        }

        /// <summary>
        /// Handles the ApplyFilterClick event of the gfChurchFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gfChurchFilter_ApplyFilterClick( object sender, EventArgs e )
        {
            gfChurchFilter.SaveUserPreference( "Church Name", tbChurchName.Text );
            if ( ddlActiveFilter.SelectedValue == "all" )
            {
                gfChurchFilter.SaveUserPreference( "Active Status", string.Empty );
            }
            else
            {
                gfChurchFilter.SaveUserPreference( "Active Status", ddlActiveFilter.SelectedValue );
            }

            // If it's there, strip the SearchTerm parameter from the query string and reload.
            if ( !string.IsNullOrWhiteSpace( PageParameter( "SearchTerm" ) ) )
            {
                var parameters = System.Web.HttpUtility.ParseQueryString( Request.Url.Query );
                parameters.Remove( "SearchTerm" );
                string url = Request.Url.AbsolutePath + ( parameters.Count > 0 ? "?" + parameters.ToString() : string.Empty );
                Response.Redirect( url );
            }
            else
            {
                BindGrid();
            }
        }

        /// <summary>
        /// Handles the GridRebind event of the gChurchList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gChurchList_GridRebind( object sender, EventArgs e )
        {
            BindGrid();
        }

        /// <summary>
        /// Handles the AddClick event of the gChurchList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gChurchList_AddClick( object sender, EventArgs e )
        {
            var parms = new Dictionary<string, string>();
            parms.Add( "ChurchId", "0" );
            NavigateToLinkedPage( AttributeKey.DetailPage, parms );
        }

        /// <summary>
        /// Handles the RowSelected event of the gChurchList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Rock.Web.UI.Controls.RowEventArgs"/> instance containing the event data.</param>
        protected void gChurchList_RowSelected( object sender, Rock.Web.UI.Controls.RowEventArgs e )
        {
            var parms = new Dictionary<string, string>();
            var churchId = e.RowKeyId;
            parms.Add( "ChurchId", churchId.ToString() );
            NavigateToLinkedPage( AttributeKey.DetailPage, parms );
        }

        #endregion Events

        #region Internal Methods

        /// <summary>
        /// Binds the filter.
        /// </summary>
        private void BindFilter()
        {
            var rockContext = new RockContext();

            // Church Name Filter
            tbChurchName.Text = gfChurchFilter.GetUserPreference( "Church Name" );

            // Set the Active Status
            var itemActiveStatus = ddlActiveFilter.Items.FindByValue( gfChurchFilter.GetUserPreference( "Active Status" ) );
            if ( itemActiveStatus != null )
            {
                itemActiveStatus.Selected = true;
            }
        }

        /// <summary>
        /// Binds the grid.
        /// </summary>
        private void BindGrid()
        {
            var rockContext = new RockContext();
            var recordTypeValueId = DefinedValueCache.Get(org.abwe.RockMissions.SystemGuid.DefinedValue.PERSON_RECORD_TYPE_CHURCH.AsGuid() ).Id;

            var churchQueryable = new PersonService( rockContext ).Queryable()
                .Where( q => q.RecordTypeValueId == recordTypeValueId );

            var churchName = string.Empty;
            bool viaSearch = false;

            // Use the name passed in the page parameter if given
            if ( !string.IsNullOrWhiteSpace( PageParameter( "SearchTerm" ) ) )
            {
                viaSearch = true;
                gfChurchFilter.Visible = false;
                churchName = PageParameter( "SearchTerm" );
            }
            else
            {
                // Church Name Filter
                churchName = gfChurchFilter.GetUserPreference( "Church Name" );
            }

            if ( !string.IsNullOrWhiteSpace( churchName ) )
            {
                churchQueryable = churchQueryable.Where( a => a.LastName.Contains( churchName ) );
            }

            if ( !viaSearch )
            {
                var activeRecordStatusValueId = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_ACTIVE.AsGuid() ).Id;
                string activeFilterValue = gfChurchFilter.GetUserPreference( "Active Status" );
                if ( activeFilterValue == "inactive" )
                {
                    churchQueryable = churchQueryable.Where( b => b.RecordStatusValueId != activeRecordStatusValueId );
                }
                else if ( activeFilterValue == "active" )
                {
                    churchQueryable = churchQueryable.Where( b => b.RecordStatusValueId == activeRecordStatusValueId );
                }
            }

            bool showChurchDetail = false;
            if ( viaSearch )
            {
                // if we got here from Church Search, and there is exactly one church that matches the search, continue in ShowChurchDetail mode and don't do any of the grid related stuff
                showChurchDetail = churchQueryable.Count() == 1;
            }

            if ( showChurchDetail )
            {
                var churchId = churchQueryable.Select( a => a.Id ).FirstOrDefault();
                ShowDetailForm( churchId );
            }
            else
            {
                var workLocationTypeId = DefinedValueCache.Get( Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_WORK.AsGuid() ).Id;

                int churchGroupTypeId = 0;
                int sentMissionaryChurchGroupTypeRoleId = 0;
                int supportedMissionaryChurchGroupTypeRoleId = 0;

                var churchGroupType = GroupTypeCache.Get(org.abwe.RockMissions.SystemGuid.GroupType.GROUPTYPE_CHURCH.AsGuid());

                if ( churchGroupType != null)
                {
                    churchGroupTypeId = churchGroupType.Id;
                    sentMissionaryChurchGroupTypeRoleId = churchGroupType.Roles.Where(r => r.Guid == org.abwe.RockMissions.SystemGuid.GroupTypeRole.GROUPROLE_SENT_MISSIONARY.AsGuid()).Select(a => a.Id).FirstOrDefault();
                    supportedMissionaryChurchGroupTypeRoleId = churchGroupType.Roles.Where(r => r.Guid == org.abwe.RockMissions.SystemGuid.GroupTypeRole.GROUPROLE_SUPPORTED_MISSIONARY.AsGuid()).Select(a => a.Id).FirstOrDefault();
                }


                var churchSelectQry = churchQueryable
                    .Select( b => new ChurchSelectInfo
                    {
                        Id = b.Id,
                        LastName = b.LastName,
                        ChurchName = b.LastName,
                        City = b.GivingGroup.GroupLocations
                                            .Where(gl => gl.GroupLocationTypeValueId == workLocationTypeId)
                                            .FirstOrDefault()
                                            .Location.City,
                        State = b.GivingGroup.GroupLocations
                                            .Where(gl => gl.GroupLocationTypeValueId == workLocationTypeId)
                                            .FirstOrDefault()
                                            .Location.State,
                        SentMissionaryCount = b.Members
                                            .Where(m => m.Group.GroupTypeId == churchGroupTypeId)
                                            .SelectMany(m => m.Group.Members)
                                            .Where(p => p.GroupRoleId == sentMissionaryChurchGroupTypeRoleId && p.PersonId != b.Id)
                                            .Count(),
                        SupportedMissionaryCount = b.Members
                                            .Where(m => m.Group.GroupTypeId == churchGroupTypeId)
                                            .SelectMany(m => m.Group.Members)
                                            .Where(p => p.GroupRoleId == supportedMissionaryChurchGroupTypeRoleId && p.PersonId != b.Id)
                                            .Count()
                    } );

                SortProperty sortProperty = gChurchList.SortProperty;
                if ( sortProperty != null )
                {
                    churchSelectQry = churchSelectQry.Sort( sortProperty );
                }
                else
                {
                    churchSelectQry = churchSelectQry.OrderBy( q => q.LastName );
                }

                gChurchList.EntityTypeId = EntityTypeCache.Get<Person>().Id;
                gChurchList.SetLinqDataSource( churchSelectQry );
                gChurchList.DataBind();
            }
        }

        /// <summary>
        /// Shows the detail form.
        /// </summary>
        /// <param name="id">The id.</param>
        protected void ShowDetailForm( int id )
        {
            NavigateToLinkedPage( "DetailPage", "churchId", id );
        }

        protected string FormatContactInfo( string phone, string address )
        {
            var values = new List<string> { phone, address, "&nbsp;", "&nbsp;" };
            return values.Where( v => v.IsNotNullOrWhiteSpace() ).Take( 2 ).ToList().AsDelimited( "<br/>" );
        }

        #endregion Internal Methods

        /// </summary>
        /// <seealso cref="Rock.Utility.RockDynamic" />
        private class ChurchSelectInfo : RockDynamic
        {
            public int Id { get; set; }
            public string LastName { get; set; }
            public string ChurchName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int SentMissionaryCount { get; set; }
            public int SupportedMissionaryCount { get; set; }

        }
    }
}
