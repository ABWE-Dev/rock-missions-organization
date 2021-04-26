// <copyright>
// Copyright by the Spark Development Network
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;
using Rock.Attribute;
using Rock.Web.Cache;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Plugins.org_abwe.RockMissions
{
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "Steps Timeline" )]
    [Category( "org_abwe > Rock Missions > Steps Timeline" )]
    [Description( "Displays a timeline of a person's steps" )]

    #region Block Attributes

    [LinkedPage(
        name: "Step Entry Page",
        description: "The page where step records can be edited or added",
        key: AttributeKey.StepPage)]

    [CustomCheckboxListField("StepTypes", "", "SELECT [Id] [Value], [Name] [Text] FROM [StepType]", true, key: AttributeKey.StepTypes)]

    #endregion Block Attributes

    public partial class StepsTimeline : PersonBlock
    {
        #region Attribute Keys
        private static class AttributeKey
        {
            public const string StepTypes = "StepTypes";
            public const string StepPage = "StepPage";
        }
        #endregion Attribute Keys

        private List<int> _blockSettingsStepTypeIds = null;

        #region Base Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger( upnlContent );

            ApplyBlockSettings();
        }

        /// <summary>
        /// Applies the block settings.
        /// </summary>
        private void ApplyBlockSettings()
        {
            _blockSettingsStepTypeIds = this.GetAttributeValue(AttributeKey.StepTypes).SplitDelimitedValues().AsIntegerList();//.Select( a => GroupTypeCache.Get( a ) ).Where( a => a != null ).Select( a => a.Id ).ToList();

            IEnumerable<StepTypeCache> stepTypes = StepTypeCache.All();

            if (_blockSettingsStepTypeIds.Any() )
            {
                stepTypes = stepTypes.Where( a => _blockSettingsStepTypeIds.Contains( a.Id ) );
            }

            cblStepTypes.DataSource = stepTypes;
            cblStepTypes.DataTextField = "Name";
            cblStepTypes.DataValueField = "Id";
            cblStepTypes.DataBind();

            ddAddStep.DataSource = stepTypes;
            ddAddStep.DataBind();
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
                // first page load, so set the selected group types from user preferences
                var userStepTypes = this.GetBlockUserPreference( AttributeKey.StepTypes ).SplitDelimitedValues().AsIntegerList();
                cblStepTypes.SetValues(userStepTypes);

                int? personId = this.Person != null ? this.Person.PrimaryAliasId : ( int? ) null;
                if ( personId.HasValue )
                {
                    ShowDetail( personId.Value );
                }
                else
                {
                    // don't show the block if a GroupId isn't in the URL
                    this.Visible = false;
                }
            } else
            {
                if (Request.Form["__EVENTTARGET"] == "LoadStepDetails")
                {
                    var stepInfo = Request.Form["__EVENTARGUMENT"].Split(',');
                    NavigateToLinkedPage(AttributeKey.StepPage, new Dictionary<string, string> {
                        { "PersonId",  this.Person != null ? this.Person.Id.ToString() : ""  },
                        { "StepTypeId", stepInfo[0] },
                        { "StepId", stepInfo.Length > 1 ? stepInfo[1] : "0" }
                    });
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the BlockUpdated event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated( object sender, EventArgs e )
        {
            ApplyBlockSettings();
            ShowDetail( hfPersonId.Value.AsInteger() );
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows the detail.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        public void ShowDetail( int personId )
        {
            hfPersonId.Value = personId.ToString();
                
            List<int> stepTypeIds;
            if ( cblStepTypes.SelectedValuesAsInt.Any() )
            {
                // if group types are filtered on the user filter, use that
                stepTypeIds = cblStepTypes.SelectedValuesAsInt;
            }
            else
            {
                // if no group types are selected in the user filter, restrict grouptypes to the ones in the block settings (if any)
                stepTypeIds = _blockSettingsStepTypeIds;
            }

            hfStepTypeIds.Value = stepTypeIds.AsDelimited( "," );

            var legendGroupTypes = StepTypeCache.All().AsEnumerable();
            if (stepTypeIds.Any() )
            {
                legendGroupTypes = legendGroupTypes.Where( a => stepTypeIds.Contains( a.Id ) );
            }

            rptStepTypeLegend.DataSource = legendGroupTypes.OrderBy( a => a.Name );
            rptStepTypeLegend.DataBind();
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btnApplyOptions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnApplyOptions_Click( object sender, EventArgs e )
        {
            this.SetBlockUserPreference( AttributeKey.StepTypes, cblStepTypes.SelectedValuesAsInt.AsDelimited( "," ) );
            ShowDetail( hfPersonId.Value.AsInteger() );
        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptGroupTypeLegend control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptStepTypeLegend_ItemDataBound( object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e )
        {
            StepTypeCache stepTypeCache = e.Item.DataItem as StepTypeCache;
            Literal lStepTypeBadgeHtml = e.Item.FindControl("lStepTypeBadgeHtml") as Literal;
            if ( stepTypeCache != null )
            {
                var style = string.Empty;
                if (!string.IsNullOrEmpty(stepTypeCache.HighlightColor))
                {
                    style = "background-color:" + stepTypeCache.HighlightColor;
                }

                lStepTypeBadgeHtml.Text = string.Format( "<span class='label label-default' style='{0}'>{1}</span>", style, stepTypeCache.Name );
            }
        }
    }
}