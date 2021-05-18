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
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace org.abwe.RockMissions.UI.Controls
{
    /// <summary>
    /// Control that can be used to select a group and role for a selected group type
    /// </summary>
    public class ABWEPersonAndFamilyPicker : CompositeControl, IRockControl, IDisplayRequiredIndicator
    {
        #region IRockControl implementation (Custom implementation)

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        /// <value>
        /// The label text.
        /// </value>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text for the label.")
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
        Bindable(true),
        Category("Appearance"),
        Description("The CSS class to add to the form-group div.")
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
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The help block.")
        ]
        public string Help
        {
            get
            {
                return HelpBlock != null ? HelpBlock.Text : string.Empty;
            }

            set
            {
                if (HelpBlock != null)
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
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The warning block.")
        ]
        public string Warning
        {
            get
            {
                return WarningBlock != null ? WarningBlock.Text : string.Empty;
            }

            set
            {
                if (WarningBlock != null)
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
        Bindable(true),
        Category("Behavior"),
        DefaultValue("false"),
        Description("Is the value required?")
        ]
        public bool Required
        {
            get
            {
                EnsureChildControls();
                return _ppPerson.Required;
            }
            set
            {
                EnsureChildControls();
                _ppPerson.Required = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the Required indicator when Required=true
        /// </summary>
        /// <value>
        /// <c>true</c> if [display required indicator]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayRequiredIndicator
        {
            get
            {
                // NOTE: Always return false since we only want the child controls (Person Picker) to show the required indicator
                return false;
            }
            set
            {
                // Ignore since we always return false
            }
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
                if (RequiredFieldValidator != null)
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
            set { ViewState["ValidationGroup"] = value; this.RequiredFieldValidator.ValidationGroup = value; }
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
                return _ppPerson.IsValid;
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

        private HiddenFieldWithClass _hfPerson;
        private PersonPicker _ppPerson;
        private RockCheckBoxList _cblFamily;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int? PersonId
        {
            get
            {
                EnsureChildControls();
                return _ppPerson.PersonId.Value;
            }

            set
            {
                EnsureChildControls();
                int personId = value ?? 0;
                if (_ppPerson.PersonId != personId)
                {
                    _ppPerson.PersonId = personId;

                    LoadFamily(personId);
                }
            }
        }

        public bool EnableSelfSelection
        {
            get
            {
                EnsureChildControls();
                return _ppPerson.EnableSelfSelection;
            }

            set
            {
                EnsureChildControls();
                _ppPerson.EnableSelfSelection = value;
            }
        }

        /// <summary>
        /// Gets or sets the group control label.
        /// </summary>
        /// <value>
        /// The group control label.
        /// </value>
        public string GroupControlLabel
        {
            get
            {
                return (ViewState["GroupControlLabel"] as string) ?? "Group";
            }

            set
            {
                ViewState["GroupControlLabel"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the group role identifier.
        /// </summary>
        /// <value>
        /// The group role identifier.
        /// </value>
        public List<int> FamilyIds
        {
            get
            {
                EnsureChildControls();
                return _cblFamily.SelectedValuesAsInt;
            }

            set
            {
                EnsureChildControls();
                List<int> familyIds = value ?? null;
                _cblFamily.SetValues(familyIds);
            }
        }

        public List<int> PersonIds
        {
            get
            {
                if (!_ppPerson.SelectedValue.HasValue)
                {
                    return null;
                }
                var familyIds = new List<int>();
                familyIds.Add(_ppPerson.SelectedValue.Value);
                familyIds.AddRange(_cblFamily.SelectedValuesAsInt);
                return familyIds;
            }
        }

        public void SetValue(List<Person> people)
        {
            if (people != null && people.Count > 0)
            {
                var primaryPerson = people.First();

                _ppPerson.SetValue(primaryPerson);

                LoadFamily(primaryPerson.Id);

                foreach (ListItem item in _cblFamily.Items)
                {
                    if (people.Any( p => p.Id == item.Value.AsInteger()))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTypeGroupPicker"/> class.
        /// </summary>
        public ABWEPersonAndFamilyPicker()
            : base()
        {
            HelpBlock = new HelpBlock();
            WarningBlock = new WarningBlock();
            RequiredFieldValidator = new RequiredFieldValidator();
            RequiredFieldValidator.ValidationGroup = this.ValidationGroup;
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Clear();

            _hfPerson = new HiddenFieldWithClass();
            _hfPerson.ID = "hfPersonId";
            _hfPerson.Value = "0";

            _ppPerson = new PersonPicker();
            _ppPerson.EnableSelfSelection = true;
            _ppPerson.Required = true;
            _ppPerson.Style[HtmlTextWriterStyle.MarginBottom] = "10px;";

            _cblFamily = new RockCheckBoxList();
            _cblFamily.RepeatDirection = RepeatDirection.Horizontal;
            _cblFamily.RepeatColumns = 4;

            RockControlHelper.CreateChildControls(this, Controls);

            _ppPerson.ID = this.ID + "_ppPerson";
            _ppPerson.ValueChanged += _ppPerson_ValueChanged;
            Controls.Add(_ppPerson);


            _cblFamily.ID = this.ID + "_cblFamily";
            Controls.Add(_cblFamily);

            Controls.Add(_hfPerson);

            this.RequiredFieldValidator.ControlToValidate = _hfPerson.ID;
        }

        /// <summary>
        /// Handles the ValueChanged event of the _ppPerson control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void _ppPerson_ValueChanged(object sender, EventArgs e)
        {
            int personId = _ppPerson.SelectedValue.Value;
            _hfPerson.Value = personId.ToString();

            LoadFamily(personId);
        }

        /// <summary>
        /// Outputs server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object and stores tracing information about the control if tracing is enabled.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the control content.</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            if (this.Visible)
            {
                RockControlHelper.RenderControl(this, writer);
            }
        }

        /// <summary>
        /// Renders the base control.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void RenderBaseControl(HtmlTextWriter writer)
        {
            _ppPerson.RenderControl(writer);
            _cblFamily.RenderControl(writer);
        }

        /// <summary>
        /// Loads the groups.
        /// </summary>
        /// <param name="groupTypeId">The group type identifier.</param>
        private void LoadFamily(int? personId)
        {
            _cblFamily.SelectedValue = null;
            _cblFamily.Items.Clear();
            if (personId.HasValue)
            {
                var rockContext = new RockContext();

                var familyMembers = new PersonService(rockContext).GetFamilyMembers(personId.Value);

                foreach (var fm in familyMembers)
                {
                    var item = new ListItem(fm.Person.FullName, fm.Person.Id.ToString().ToUpper());
                    _cblFamily.Items.Add(item);
                }
            }
        }
    }
}