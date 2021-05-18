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
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using org.abwe.RockMissions.UI.Controls;
using Rock;
using Rock.Data;
using Rock.Field;
using Rock.Model;
using Rock.Reporting;
using Rock.Web.UI.Controls;

namespace org.abwe.RockMissions.Field.Types
{
    /// <summary>
    /// Field used to save and display a person. Stored as PersonAlias.Guid
    /// </summary>
    [Serializable]
    public class ABWEPersonAndFamilyFieldType : Rock.Field.FieldType
    {
        #region configuration

        private const string ENABLE_SELF_SELECTION_KEY = "EnableSelfSelection";

        /// <summary>
        /// Returns a list of the configuration keys
        /// </summary>
        /// <returns></returns>
        public override List<string> ConfigurationKeys()
        {
            var configKeys = base.ConfigurationKeys();
            configKeys.Add( ENABLE_SELF_SELECTION_KEY );
            return configKeys;
        }

        /// <summary>
        /// Creates the HTML controls required to configure this type of field
        /// </summary>
        /// <returns></returns>
        public override List<Control> ConfigurationControls()
        {
            var controls = base.ConfigurationControls();

            var cbEnableSelfSelection = new RockCheckBox();
            controls.Add( cbEnableSelfSelection );
            cbEnableSelfSelection.Label = "Enable Self Selection";
            cbEnableSelfSelection.Text = "Yes";
            cbEnableSelfSelection.Help = "When using Person Picker, show the self selection option";
            return controls;
        }

        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public override Dictionary<string, ConfigurationValue> ConfigurationValues( List<Control> controls )
        {
            Dictionary<string, ConfigurationValue> configurationValues = new Dictionary<string, ConfigurationValue>();
            configurationValues.Add( ENABLE_SELF_SELECTION_KEY, new ConfigurationValue( "Enable Self Selection", "When using Person Picker, show the self selection option", string.Empty ) );

            if ( controls != null && controls.Count > 0 )
            {
                var cbEnableSelfSelection = controls[0] as RockCheckBox;
                if ( cbEnableSelfSelection != null )
                {
                    configurationValues[ENABLE_SELF_SELECTION_KEY].Value = cbEnableSelfSelection.Checked.ToString();
                }

            }

            return configurationValues;
        }

        /// <summary>
        /// Sets the configuration value.
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="configurationValues"></param>
        public override void SetConfigurationValues( List<Control> controls, Dictionary<string, ConfigurationValue> configurationValues )
        {
            if ( controls != null && configurationValues != null && controls.Count > 0 )
            {
                var cbEnableSelfSelection = controls[0] as RockCheckBox;

                if ( cbEnableSelfSelection != null && configurationValues.ContainsKey( ENABLE_SELF_SELECTION_KEY ) )
                {
                    cbEnableSelfSelection.Checked = configurationValues[ENABLE_SELF_SELECTION_KEY].Value.AsBoolean();
                }
            }
        }

        #endregion

        #region Formatting

        /// <summary>
        /// Returns the field's current value(s)
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="value">Information about the value</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="condensed">Flag indicating if the value should be condensed (i.e. for use in a grid column)</param>
        /// <returns></returns>
        public override string FormatValue( System.Web.UI.Control parentControl, string value, Dictionary<string, ConfigurationValue> configurationValues, bool condensed )
        {
            string formattedValue = string.Empty;

            if ( !string.IsNullOrWhiteSpace( value ) )
            {
                List<Guid> guid = value.Split(',').AsGuidList();
                using ( var rockContext = new RockContext() )
                {
                    formattedValue = new PersonAliasService( rockContext ).Queryable()
                    .AsNoTracking()
                    .Where( a => guid.Contains(a.Guid) )
                    .Select( a => a.Person.NickName + " " + a.Person.LastName )
                    .JoinStrings(", ");
                }
            }

            return base.FormatValue( parentControl, formattedValue, null, condensed );
        }

        #endregion

        #region Edit Control

        /// <summary>
        /// Creates the control(s) necessary for prompting user for a new value
        /// </summary>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="id"></param>
        /// <returns>
        /// The control
        /// </returns>
        public override System.Web.UI.Control EditControl( Dictionary<string, ConfigurationValue> configurationValues, string id )
        {
            var personPicker = new ABWEPersonAndFamilyPicker { ID = id };
            //personPicker.ValueChanged += OnQualifierUpdated;
            if ( configurationValues.ContainsKey( ENABLE_SELF_SELECTION_KEY ) )
            {
                personPicker.EnableSelfSelection = configurationValues[ENABLE_SELF_SELECTION_KEY].Value.AsBoolean();
            }

            return personPicker;
        }

        /// <summary>
        /// Reads new values entered by the user for the field (as PersonAlias.Guid)
        /// </summary>
        /// <param name="control">Parent control that controls were added to in the CreateEditControl() method</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <returns></returns>
        public override string GetEditValue( System.Web.UI.Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            ABWEPersonAndFamilyPicker ppPerson = control as ABWEPersonAndFamilyPicker;
            string result = string.Empty;

            if ( ppPerson != null )
            {
                List<int> personIds = ppPerson.PersonIds;
                List<string> guids = new List<string>();

                if ( personIds != null )
                {
                    using ( var rockContext = new RockContext() )
                    {
                        var personAliasService = new PersonAliasService(rockContext);
                        
                        // Loop because it's important that the results return in order.
                        // The first person will be the primary person selected.
                        foreach (int personId in personIds)
                        {
                            var personAlias = personAliasService.GetByAliasId(personId);
                            if (personAlias != null)
                            {
                                guids.Add(personAlias.Guid.ToString());
                            }
                        }
                    }
                }

                return guids.JoinStrings(",");
            }

            return null;
        }

        /// <summary>
        /// Sets the value (as PersonAlias.Guid)
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="value">The value.</param>
        public override void SetEditValue( System.Web.UI.Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            ABWEPersonAndFamilyPicker ppPerson = control as ABWEPersonAndFamilyPicker;
            if ( ppPerson != null )
            {
                List<Guid> familyPersonAliasGuids = value.Split(',').AsGuidList();
                List<Person> people = new List<Person>();
                if ( familyPersonAliasGuids != null && familyPersonAliasGuids.Count > 0)
                {
                    using ( var rockContext = new RockContext() )
                    {
                        foreach (Guid personGuid in familyPersonAliasGuids)
                        {
                            people.Add(new PersonAliasService( rockContext ).Queryable()
                                .Where( a => a.Guid == personGuid )
                                .Select( a => a.Person )
                                .FirstOrDefault());
                        }
                    }
                }

                ppPerson.SetValue( people );
            }
        }

        #endregion

    }
}