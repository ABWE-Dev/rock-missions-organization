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
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Rock;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace org.abwe.RockMissions.UI.Controls
{
    /// <summary>
    /// This control will create a Google map with drawring tools that
    /// allows the user to define a single point or a polygon which forms a geo-fence
    /// depending on the <see cref="Rock.Web.UI.Controls.GeoPicker.ManagerDrawingMode.Point"/>.
    /// 
    /// To use on a page or usercontrol:
    /// <example>
    /// <code>
    ///     <![CDATA[<Rock:GeoPicker ID="gpGeoPoint" runat="server" Required="false" Label="Geo Point" DrawingMode="Point" />]]>
    /// </code>
    /// </example>
    /// To set an initial value:
    /// <example>
    /// <code>
    ///     gpGeoPoint.SetValue( DbGeography.FromText("POINT(-122.335197 47.646711)") );
    /// </code>
    /// </example>
    /// To access the value after it's been set use the <see cref="SelectedValue"/> property:
    /// <example>
    /// <code>
    ///    DbGeography point = gpGeoPoint.SelectedValue;
    /// </code>
    /// </example>
    /// 
    /// If you wish to set an appropriate, initial center point you can use the <see cref="CenterPoint"/> property.
    /// </summary>
    public class ABWEPlacePicker : CompositeControl, IRockControl
    {
        #region IRockControl implementation

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        /// <value>
        /// The label text.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The text for the label." )
        ]
        public string Label
        {
            get { return ViewState["Label"] as string ?? string.Empty; }
            set { ViewState["Label"] = value; }
        }

        /// <summary>
        /// Gets or sets the form group class.
        /// </summary>
        /// <value>
        /// The form group class.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        Description( "The CSS class to add to the form-group div." )
        ]
        public string FormGroupCssClass
        {
            get { return ViewState["FormGroupCssClass"] as string ?? string.Empty; }
            set { ViewState["FormGroupCssClass"] = value; }
        }

        /// <summary>
        /// Gets or sets the help text.
        /// </summary>
        /// <value>
        /// The help text.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The help block." )
        ]
        public string Help
        {
            get
            {
                return HelpBlock != null ? HelpBlock.Text : string.Empty;
            }
            set
            {
                if ( HelpBlock != null )
                {
                    HelpBlock.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the warning text.
        /// </summary>
        /// <value>
        /// The warning text.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The warning block." )
        ]
        public string Warning
        {
            get
            {
                return WarningBlock != null ? WarningBlock.Text : string.Empty;
            }
            set
            {
                if ( WarningBlock != null )
                {
                    WarningBlock.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RockTextBox"/> is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if required; otherwise, <c>false</c>.
        /// </value>
        [
        Bindable( true ),
        Category( "Behavior" ),
        DefaultValue( "false" ),
        Description( "Is the value required?" )
        ]
        public bool Required
        {
            get { return ViewState["Required"] as bool? ?? false; }
            set { ViewState["Required"] = value; }
        }

        /// <summary>
        /// Gets or sets the required error message.  If blank, the LabelName name will be used
        /// </summary>
        /// <value>
        /// The required error message.
        /// </value>
        public string RequiredErrorMessage
        {
            get
            {
                return RequiredFieldValidator != null ? RequiredFieldValidator.ErrorMessage : string.Empty;
            }
            set
            {
                if ( RequiredFieldValidator != null )
                {
                    RequiredFieldValidator.ErrorMessage = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets an optional validation group to use.
        /// </summary>
        /// <value>
        /// The validation group.
        /// </value>
        public string ValidationGroup
        {
            get { return ViewState["ValidationGroup"] as string; }
            set { ViewState["ValidationGroup"] = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsValid
        {
            get
            {
                return !Required || RequiredFieldValidator == null || RequiredFieldValidator.IsValid;
            }
        }

        /// <summary>
        /// Gets or sets the help block.
        /// </summary>
        /// <value>
        /// The help block.
        /// </value>
        public HelpBlock HelpBlock { get; set; }

        /// <summary>
        /// Gets or sets the warning block.
        /// </summary>
        /// <value>
        /// The warning block.
        /// </value>
        public WarningBlock WarningBlock { get; set; }

        /// <summary>
        /// Gets or sets the required field validator.
        /// </summary>
        /// <value>
        /// The required field validator.
        /// </value>
        public RequiredFieldValidator RequiredFieldValidator { get; set; }

        #endregion

        #region Controls

        private HiddenField _hfGeoDisplayName;
        private HiddenField _hfGeoPath;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the control should be displayed Full-Width
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable full width]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableFullWidth
        {
            get
            {
                return ViewState["EnableFullWidth"] as bool? ?? false;
            }

            set
            {
                ViewState["EnableFullWidth"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value.
        /// </value>
        public string SelectedValue
        {
            get
            {
                return Point;
            }

            set
            {
                Point = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the Geography's display name.  This is what's shown
        /// to the user before they actually edit the GeoPicker to change its value.
        /// </summary>
        /// <value>
        /// The name of the geography.
        /// </value>
        public string GeoDisplayName
        {
            get
            {
                EnsureChildControls();
                if ( string.IsNullOrWhiteSpace( _hfGeoDisplayName.Value ) )
                {
                    _hfGeoDisplayName.Value = Rock.Constants.None.TextHtml;
                }

                return _hfGeoDisplayName.Value;
            }

            set
            {
                EnsureChildControls();
                _hfGeoDisplayName.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the point of the Geography.
        /// </summary>
        /// <value>
        /// The path/fence of the geography.
        /// </value>
        public string Point
        {
            get
            {
                EnsureChildControls();
                if ( string.IsNullOrWhiteSpace( _hfGeoPath.Value ) )
                {
                    return "";
                }
                else
                {
                    return _hfGeoPath.Value;
                }
            }

            set
            {
                EnsureChildControls();
                _hfGeoPath.Value = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPicker" /> class.
        /// </summary>
        public ABWEPlacePicker()
        {
            RequiredFieldValidator = new HiddenFieldValidator();
            HelpBlock = new HelpBlock();
            WarningBlock = new WarningBlock();
        }

        #endregion

        public void LoadGoogleMapsApi()
        {
            var googleAPIKey = GlobalAttributesCache.Get().GetValue("GoogleAPIKey");
            string keyParameter = string.IsNullOrWhiteSpace(googleAPIKey) ? "" : string.Format("key={0}&", googleAPIKey);
            string scriptUrl = string.Format("https://maps.googleapis.com/maps/api/js?{0}libraries=drawing,visualization,places,geometry", keyParameter);

            // first, add it to the page to handle cases where the api is needed on first page load
            if (this.Page != null && this.Page.Header != null)
            {
                var control = new LiteralControl();
                control.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                // note: ID must match the what it is called in \RockWeb\Scripts\Rock\Controls\util.js
                control.ID = "googleMapsApi";
                control.Text = string.Format("<script id=\"googleMapsApi\" src=\"{0}\" ></script>", scriptUrl);
                var existingAPI = this.Page.Header.Controls.OfType<LiteralControl>().Where(a => a.ID == control.ID).FirstOrDefault();
                if (existingAPI != null)
                {
                    this.Page.Header.Controls.Remove(existingAPI);
                }
                this.Page.Header.Controls.Add(control);
            }

            // also, do this in cases where the api is added on a postback, and the above didn't end up getting rendered
            if (!this.Page.ClientScript.IsStartupScriptRegistered("googleMapsApiScript"))
            {
                string script = string.Format(@"Rock.controls.util.loadGoogleMapsApi('{0}');", scriptUrl);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "googleMapsApiScript", script, true);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            var sm = ScriptManager.GetCurrent( this.Page );

            //HtmlGenericControl Include = new HtmlGenericControl("script");
            //Include.Attributes.Add("type", "text/javascript");
            //Include.Attributes.Add("src", "/Plugins/org_abwe/RockMissions/Scripts/place-picker.js");
            //this.Page.Header.Controls.Add(Include);
            ScriptManager.RegisterClientScriptInclude(this, this.GetType(), "place_picker_library", ResolveClientUrl("/Plugins/org_abwe/RockMissions/Scripts/place-picker.js"));
            this.LoadGoogleMapsApi();
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Clear();
            RockControlHelper.CreateChildControls( this, Controls );

            // TBD TODO -- do I need this hfGeoDisplayName_???
            _hfGeoDisplayName = new HiddenField();
            _hfGeoDisplayName.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            _hfGeoDisplayName.ID = string.Format( "hfGeoDisplayName_{0}", this.ClientID );
            _hfGeoPath = new HiddenField();
            _hfGeoPath.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            _hfGeoPath.ID = string.Format( "hfGeoPath_{0}", this.ClientID );

            Controls.Add( _hfGeoDisplayName );
            Controls.Add( _hfGeoPath );

            RequiredFieldValidator.InitialValue = "0";
            RequiredFieldValidator.ControlToValidate = _hfGeoPath.ID;
        }

        /// <summary>
        /// Outputs server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object and stores tracing information about the control if tracing is enabled.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the control content.</param>
        public override void RenderControl( HtmlTextWriter writer )
        {
            if ( this.Visible )
            {
                RockControlHelper.RenderControl( this, writer );
            }
        }

        /// <summary>
        /// Renders the base control.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void RenderBaseControl( HtmlTextWriter writer )
        {
            RegisterJavaScript();

            // controls div
            writer.AddAttribute( "class", "controls" );
            writer.RenderBeginTag( HtmlTextWriterTag.Div );

            _hfGeoDisplayName.RenderControl( writer );
            _hfGeoPath.RenderControl( writer );

            if ( this.Enabled )
            {
                writer.AddAttribute( "id", this.ClientID.ToString() );

                List<string> pickerClasses = new List<string>();
                pickerClasses.Add( "picker" );
                if ( EnableFullWidth )
                {
                    pickerClasses.Add( "picker-fullwidth" );
                }

                writer.AddAttribute( "class", pickerClasses.AsDelimited( " " ) );

                writer.RenderBeginTag( HtmlTextWriterTag.Div );

                writer.Write( string.Format( @"
                    <input type='text' class='form-control' placeholder='Choose a location' id='autocomplete_{0}' value='{1}'></input>", this.ClientID, this.GeoDisplayName ) );
                writer.WriteLine();

                // closing div of picker
                writer.RenderEndTag();
            }
            else
            {
                // this picker is not enabled (readonly), so just render a readonly version
                List<string> pickerClasses = new List<string>();
                pickerClasses.Add( "picker" );
                if ( EnableFullWidth )
                {
                    pickerClasses.Add( "picker-fullwidth" );
                }

                pickerClasses.Add( "picker-select" );

                writer.AddAttribute( "class", pickerClasses.AsDelimited( " " ) );
                writer.RenderBeginTag( HtmlTextWriterTag.Div );
                LinkButton linkButton = new LinkButton();
                linkButton.CssClass = "picker-label";
                linkButton.Text = string.Format( "<i class='{1}'></i><span>{0}</span>", this.GeoDisplayName, "fa fa-map-marker" );
                linkButton.Enabled = false;
                linkButton.RenderControl( writer );
                writer.WriteLine();
                writer.RenderEndTag();
            }

            // controls div
            writer.RenderEndTag();

        }

        /// <summary>
        /// Sets the value. Necessary to preload the geo fence or geo point.
        /// </summary>
        /// <param name="dbGeography">The db geography.</param>
        public void SetValue( string point )
        {
            if ( point != null )
            {
                SelectedValue = point;
            }
            else
            {
                GeoDisplayName = Rock.Constants.None.TextHtml;
            }
        }
        
        /// <summary>
        /// Registers the java script.
        /// </summary>
        protected virtual void RegisterJavaScript()
        {
            string options = string.Format( "controlId: '{0}'", this.ClientID);

            string script = string.Format( @"
// if the placePicker was rendered, initialize it
if ($('#{1}').length > 0)
{{
    org_abwe.placePicker.initialize({{ {0} }});
}}

", options, this.ClientID );
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "place_picker-" + this.ClientID, script, true );
        }
    }
}