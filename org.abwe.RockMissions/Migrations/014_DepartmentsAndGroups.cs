using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock;
using Rock.Model;
using Rock.Plugin;
using Rock.Security;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(14, "1.12.0")]
    public class DepartmentsAndGroups : Migration
    {
        public override void Up()
        {
            // Departments Defined Type
            RockMigrationHelper.AddDefinedType("Missions Orgs", "Departments", "Missions Organization departments", "a577b859-6c37-4150-bfd8-ffdb5eb2fc71");

            RockMigrationHelper.AddGroupType("Department", "A missions organization department", "Department", "Member", false, true, true, "", 0, null, 0, null, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT);
            RockMigrationHelper.AddGroupType("Partners", "A missions organization group of partners", "Group", "Partner", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_PARTNERS);
            RockMigrationHelper.AddGroupType("Leads", "A missions organization group of leads", "Group", "Lead", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_LEADS);
            RockMigrationHelper.AddGroupType("Volunteers", "A missions organization group of volunteers", "Group", "Volunteer", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS);
            RockMigrationHelper.AddGroupType("Applicants", "A missions organization group of applicants", "Group", "Applicant", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_APPLICANTS);
            RockMigrationHelper.AddGroupType("Missionaries", "A missions organization group of missionaries", "Group", "Member", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_MiSSIONARIES);
            Sql(@"UPDATE [GroupType] SET [AllowAnyChildGroupType] = 1 WHERE [Guid] = '" + SystemGuid.GroupType.GROUPTYPE_DEPARTMENT + "'");

            // Entity: Rock.Model.Group Attribute: Department
            RockMigrationHelper.AddGroupTypeGroupAttribute("39A89FD9-27F0-469F-9F8D-8CC362454C9B", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "Department", @"", 0, "", "283C606C-C2A7-4FF8-B245-81AC5B900129", "Department");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "AllowAddingNewValues", @"False", "B0B092E3-0A38-4ED8-BC81-42761A41951F");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "allowmultiple", @"False", "A8349D84-7435-4DCC-8318-E0F76194A640");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "definedtype", SqlScalar("SELECT [Id] FROM [DefinedType] WHERE [Guid] = '"+SystemGuid.DefinedType.DEPARTMENTS+"'").ToString(), "FADFBC21-C7D1-45F5-A133-0B48B0E29CC0");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "displaydescription", @"False", "A8E71DDE-AC44-4CB5-B268-4EA1848C4D4C");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "enhancedselection", @"True", "3AB62926-F08C-4F0A-9BCD-29D6ACA0C84C");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "includeInactive", @"False", "3310F931-DCCB-4D9D-9868-AA51335D51F8");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("283C606C-C2A7-4FF8-B245-81AC5B900129", "RepeatColumns", @"", "CEC88364-CA22-44DB-AA8A-893FD3FBC68C");


            // Allow child groups of the same type
            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_PARTNERS}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_PARTNERS}'");

            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_LEADS}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_LEADS}'");

            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_APPLICANTS}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_APPLICANTS}'");

            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS}'");

            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_MiSSIONARIES}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_AREA}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_REGION}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_TEAM}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_MiSSIONARIES}'");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("283C606C-C2A7-4FF8-B245-81AC5B900129");    // GroupType - Group Attribute, Department: Department

            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_PARTNERS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_LEADS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_APPLICANTS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_MiSSIONARIES);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_DEPARTMENT);

            RockMigrationHelper.DeleteDefinedType(SystemGuid.DefinedType.DEPARTMENTS);
        }
    }
}
