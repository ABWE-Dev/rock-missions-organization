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
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using org.abwe.RockMissions.UI.Controls;
using Rock;
using Rock.Data;
using Rock.Model;
using Rock.Reporting;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace org.abwe.RockMissions.Filters.Person
{
    /// <summary>
    /// 
    /// </summary>
    [Description("Filter people on home address and business on work address within a specified distance from a location")]
    [Export(typeof(DataFilterComponent))]
    [ExportMetadata("ComponentName", "Person (and Business) Distance From Filter")]
    public class DistanceFromWithBusinessFilter : DataFilterComponent
    {
        #region Properties

        /// <summary>
        /// Gets the entity type that filter applies to.
        /// </summary>
        /// <value>
        /// The entity that filter applies to.
        /// </value>
        public override string AppliesToEntityType
        {
            get { return typeof(Rock.Model.Person).FullName; }
        }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public override string Section
        {
            get { return "Additional Filters"; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        /// <value>
        /// The title.
        /// </value>
        public override string GetTitle(Type entityType)
        {
            return "Distance From (inc. Businesses)";
        }

        /// <summary>
        /// Formats the selection on the client-side.  When the filter is collapsed by the user, the Filterfield control
        /// will set the description of the filter to whatever is returned by this property.  If including script, the
        /// controls parent container can be referenced through a '$content' variable that is set by the control before 
        /// referencing this property.
        /// </summary>
        /// <value>
        /// The client format script.
        /// </value>
        public override string GetClientFormatSelection(Type entityType)
        {
            return @"
function() {
  var locationName = $('.picker-label', $content).find('span').text();
  var miles = $('.number-box', $content).find('input').val();

  return 'Within ' + miles + ' from location: ' + locationName;
}
";
        }

        /// <summary>
        /// Formats the selection.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public override string FormatSelection(Type entityType, string selection)
        {
            string result = "Distance From";
            string[] selectionValues = selection.Split('|');

            if (selectionValues.Length >= 3)
            {
                string locationName = selectionValues[0];
                double miles = selectionValues[2].AsDoubleOrNull() ?? 0;

                result = string.Format("Within {0} miles from location: {1}", miles, locationName);
            }

            return result;
        }

        /// <summary>
        /// Creates the child controls.
        /// </summary>
        /// <returns></returns>
        public override Control[] CreateChildControls(Type entityType, FilterField filterControl)
        {
            ABWEPlacePicker locationPicker = new ABWEPlacePicker();
            locationPicker.ID = filterControl.ID + "_0";
            locationPicker.Label = "Location";

            filterControl.Controls.Add(locationPicker);

            NumberBox numberBox = new NumberBox();
            numberBox.ID = filterControl.ID + "_1";
            numberBox.NumberType = ValidationDataType.Double;
            numberBox.Label = "Miles";
            numberBox.AddCssClass("number-box-miles");
            filterControl.Controls.Add(numberBox);

            return new Control[2] { locationPicker, numberBox };
        }

        /// <summary>
        /// Renders the controls.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="filterControl">The filter control.</param>
        /// <param name="writer">The writer.</param>
        /// <param name="controls">The controls.</param>
        public override void RenderControls(Type entityType, FilterField filterControl, HtmlTextWriter writer, Control[] controls)
        {
            base.RenderControls(entityType, filterControl, writer, controls);
        }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public override string GetSelection(Type entityType, Control[] controls)
        {
            var control = (controls[0] as ABWEPlacePicker);
            var value1 = control.GeoDisplayName;
            var value2 = control.Point;
            var value3 = (controls[1] as NumberBox).Text;
            return value1 + "|" + value2 + "|" + value3;
        }

        /// <summary>
        /// Sets the selection.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="controls">The controls.</param>
        /// <param name="selection">The selection.</param>
        public override void SetSelection(Type entityType, Control[] controls, string selection)
        {
            string[] selectionValues = selection.Split('|');
            if (selectionValues.Length >= 3)
            {
                var locationPicker = controls[0] as ABWEPlacePicker;
                locationPicker.GeoDisplayName = selectionValues[0];
                locationPicker.Point = selectionValues[1];
                var numberBox = controls[1] as NumberBox;
                numberBox.Text = selectionValues[2];
            }
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="parameterExpression">The parameter expression.</param>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public override Expression GetExpression(Type entityType, IService serviceInstance, ParameterExpression parameterExpression, string selection)
        {
            var rockContext = (RockContext)serviceInstance.Context;

            string[] selectionValues = selection.Split('|');
            if (selectionValues.Length >= 3)
            {
                // Convert long,lat to POINT
                string wkt = String.Format("POINT({1} {0})", selectionValues[1].Split(',')[0], selectionValues[1].Split(',')[1]);
                
                // Get location by POINT
                Location location = new LocationService(new RockContext()).GetByGeoPoint(DbGeography.PointFromText(wkt, 4326));

                if (location == null)
                {
                    return null;
                }

                GroupMemberService groupMemberService = new GroupMemberService(rockContext);
                var groupTypeFamilyId = GroupTypeCache.GetFamilyGroupType().Id;

                // limit to Family's Home Addresses that have are a real location (not a PO Box)
                var groupMemberServiceQry = groupMemberService.Queryable(true)
                    .Where(xx => xx.Group.GroupTypeId == groupTypeFamilyId);

                int groupLocationTypeHomeId = DefinedValueCache.Get(Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_HOME.AsGuid()).Id;
                int groupLocationTypeWorkId = DefinedValueCache.Get(Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_WORK.AsGuid()).Id;
                int businessTypeId = DefinedValueCache.Get(Rock.SystemGuid.DefinedValue.PERSON_RECORD_TYPE_BUSINESS).Id;

                // if a specific point was selected (whether a marker, or an address), we'll do a radial search
                if (location.GeoPoint != null)
                {
                    // limit to distance LessThan specified distance (dbGeography uses meters for distance units)
                    double miles = selectionValues[2].AsDoubleOrNull() ?? 0;
                    double meters = miles * Location.MetersPerMile;

                    groupMemberServiceQry = groupMemberServiceQry
                        .Where(xx =>
                           xx.Group.GroupLocations.Any(l =>
                              (l.GroupLocationTypeValue.Id == groupLocationTypeHomeId || (xx.Person.RecordTypeValueId == businessTypeId && l.GroupLocationTypeValue.Id == groupLocationTypeWorkId))
                              && l.IsMappedLocation
                              && location.GeoPoint.Buffer(meters).Intersects(l.Location.GeoPoint)
                               ));
                }

                var qry = new PersonService(rockContext).Queryable()
                    .Where(p => groupMemberServiceQry.Any(xx => xx.PersonId == p.Id));

                Expression extractedFilterExpression = FilterExpressionExtractor.Extract<Rock.Model.Person>(qry, parameterExpression, "p");

                return extractedFilterExpression;
            }

            return null;
        }

        #endregion
    }
}