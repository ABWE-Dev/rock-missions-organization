using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock;
using Rock.Model;
using Rock.Plugin;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(11, "1.12.0")]
    public class AreaRegionFieldGroups : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddGroupType("Area", "A missions organization operational area", "Area", "Member", false, true, true, "", 0, null, 0, null, SystemGuid.GroupType.GROUPTYPE_AREA);
            RockMigrationHelper.AddGroupType("Region", "A missions organization operational region", "Region", "Member", false, true, true, "", 0, null, 0, null, SystemGuid.GroupType.GROUPTYPE_REGION);
            RockMigrationHelper.AddGroupType("Team", "A missions organization operational team", "Team", "Member", false, true, true, "", 0, null, 0, null, SystemGuid.GroupType.GROUPTYPE_TEAM);

            // Area Roles
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_AREA, "Director", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_AREA_LEADER, true, true);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_AREA, "Missionary", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_AREA_MISSIONARY);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_AREA, "Applicant", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_AREA_APPLICANT);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_AREA, "Volunteer", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_AREA_VOLUNTEER);

            // Region Roles
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_REGION, "Director", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_REGIONAL_LEADER, true, true);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_REGION, "Missionary", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_REGIONAL_MISSIONARY);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_REGION, "Applicant", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_REGIONAL_APPLICANT);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_REGION, "Volunteer", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_REGIONAL_VOLUNTEER);

            // Field Roles
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_TEAM, "Leader", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_FIELDTEAM_LEADER, true, true);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_TEAM, "Missionary", "",0,null, null, SystemGuid.GroupTypeRole.GROUPROLE_MISSIONARY);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_TEAM, "Volunteer", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_VOLUNTEER);
            RockMigrationHelper.UpdateGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_TEAM, "Applicant", "", 0, null, null, SystemGuid.GroupTypeRole.GROUPROLE_APPLICANT);

            RockMigrationHelper.AddGroupTypeGroupAttribute(SystemGuid.GroupType.GROUPTYPE_TEAM, "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Country", @"", 0, "", "B23BD07D-F132-447C-8146-A1A7827BEDC4", "Country");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "definedtype", @"45", "FF3C9364-654A-45A2-8A7D-D9A96B97112E");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "allowmultiple", @"False", "D088742F-5F4B-4387-9FAF-A43584981BD4");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "displaydescription", @"True", "952CE2BB-A9F5-4F13-AD33-63ED38B561FA");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "enhancedselection", @"True", "150CB677-53EE-41B5-BFE0-0D589AD71779");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "includeInactive", @"False", "85F00A88-5F4B-43C9-9689-AA1424DCC783");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "AllowAddingNewValues", @"False", "794AB35C-2004-4E8F-8DB7-868992DAC59B");
            // Qualifier for attribute: Country
            RockMigrationHelper.UpdateAttributeQualifier("B23BD07D-F132-447C-8146-A1A7827BEDC4", "RepeatColumns", @"", "8C177FE2-7018-49A5-8A31-30661C25B6E1");

            // Regions as children of Areas, Fields as children of Regions
            Sql(@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = 'E6E87D4D-9108-495B-A4F5-EDA30AACD54F' OR [Guid] = '61C0C238-8789-4236-ABB6-92B92A0B2CB6' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = 'A14BA4F7-801D-4934-AE7B-ECF532F24A6F'");

            Sql(@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '61C0C238-8789-4236-ABB6-92B92A0B2CB6' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = 'E6E87D4D-9108-495B-A4F5-EDA30AACD54F'");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("B23BD07D-F132-447C-8146-A1A7827BEDC4");    // GroupType - Group Attribute, Field: Country
        }
    }
}
