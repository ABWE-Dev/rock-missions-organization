using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Rock;
using Rock.Plugin;


namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(21, "1.12.0")]
    class TeamsGroups : Migration
    {
        public override void Up()
        {
            // Delete DefinedType for departments. Use GroupType of Department instead.
            RockMigrationHelper.DeleteDefinedType(SystemGuid.DefinedType.DEPARTMENTS);

            // Change Employment timeline Department attribute to Group of Type Department
            // Entity: Rock.Model.Step Attribute: Department
            RockMigrationHelper.DeleteAttribute("06B15698-F962-4A78-A54C-10F0732DF0CF");
            Sql(@"INSERT INTO [Attribute] ([IsSystem],[FieldTypeId],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Key],[Name],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid],[CreatedDateTime],[ModifiedDateTime],[ForeignKey],[IconCssClass],[AllowSearch],[ForeignGuid],[ForeignId],[IsIndexEnabled],[IsAnalytic],[IsAnalyticHistory],[IsActive],[EnableHistory],[PreHtml],[PostHtml],[AbbreviatedName],[ShowOnBulk],[IsPublic])
                VALUES
                (0, 6, 478, N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Department',N'Department',N'',1,1,N'',0,1,'{06B15698-F962-4A78-A54C-10F0732DF0CF}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Department',0,0)
            ");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "fieldtype", @"ddl", "6A4F8137-AC40-4F28-8168-4D453C1A6188");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "repeatColumns", @"", "34B28D0C-8842-461C-B6CF-647360BB02F8");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "values", @"SELECT [Id] [Value], [Name] [Text]
            FROM [Group]
            WHERE GroupTypeId IN (SELECT [Id] FROM [GroupType] WHERE [Guid] = 'fd8961e2-49da-4538-a847-7093fd05d484')
            ORDER BY [Name] ASC", "46C8B1B0-9D5D-42F4-A66C-2C3E7783C842");

            // Disallow children of Missionaries Groups
            Sql("DELETE FROM GroupTypeAssociation WHERE [GroupTypeId] = (SELECT [Id] FROM [GroupType] WHERE [Guid] = 'b1602ac6-7f14-4ac2-88ca-ebfa780d3c38')");
            // Do not allow Departments to have any child Group Type
            Sql(@"UPDATE [GroupType] SET [AllowAnyChildGroupType] = 0 WHERE [Guid] = '" + SystemGuid.GroupType.GROUPTYPE_DEPARTMENT + "'");
            // Allow Team groups to have Area, Region, or Team children
            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_AREA}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_REGION}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_TEAM}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_TEAM}'");

            
            // Create Staff GroupType
            RockMigrationHelper.AddGroupType("Staff", "A missions organization staff group", "Staff", "Staff", false, true, true, "", 0, null, 0, null, SystemGuid.GroupType.GROUPTYPE_STAFF);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_STAFF, "Staff", "", 0, null, null, "741d4dc5-f142-409d-8086-cd815ed511dc");
            // Allow GroupSync
            Sql($"UPDATE [GroupType] SET [AllowGroupSync] = 1 WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_STAFF}'");

            // Allow GroupSync for Missionaries GroupType
            Sql($"UPDATE [GroupType] SET [AllowGroupSync] = 1 WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_MISSIONARIES}'");


            // Create Communication Risk Override Attribute
            RockMigrationHelper.AddGroupTypeGroupAttribute(SystemGuid.GroupType.GROUPTYPE_TEAM, "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Communication Risk Override", @"", 1, "", "8C97E53F-621B-446D-8020-0C0F3EB58F39", "Communication Risk");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "AllowAddingNewValues", @"False", "D3568401-95C9-4FCA-B929-953A32F50DBA");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "allowmultiple", @"False", "BBAC68C7-430E-4B49-A4CD-FECF11687689");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "definedtype", SqlScalar("SELECT [Id] FROM DefinedType WHERE [Guid] = 'A4EFF1B9-E66E-4197-BCCD-104423399580'").ToString(), "AF995F69-EC0F-4B9B-80B9-3015E93A9B90");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "displaydescription", @"True", "1474F525-BEEB-4ADF-A6AC-1447253E0EA2");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "enhancedselection", @"False", "5F47D896-3C1B-402A-830D-17FC435F8306");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "includeInactive", @"False", "36F1125D-A75F-4BD2-91BB-687FBB438379");
            // Qualifier for attribute: CommunicationRiskOverride
            RockMigrationHelper.UpdateAttributeQualifier("8C97E53F-621B-446D-8020-0C0F3EB58F39", "RepeatColumns", @"", "AABB1E2D-B7BC-47F6-AA2F-31C8F6AAC6A3");

            // Turn on Group History for Teams, Missionaries, and Staff
            Sql($"UPDATE GroupType SET EnableGroupHistory = 1 WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_TEAM}'");
            Sql($"UPDATE GroupType SET EnableGroupHistory = 1 WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_STAFF}'");
            Sql($"UPDATE GroupType SET EnableGroupHistory = 1 WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_MISSIONARIES}'");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("034ea0ea-bcf5-4248-adf9-fc87cfd7dabf"); // Rock.Model.Step: Department
            RockMigrationHelper.DeleteAttribute("8C97E53F-621B-446D-8020-0C0F3EB58F39"); // CommunicationRiskOverride

            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_STAFF);
        }
    }
}
