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
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, "Member", "", 0, null, null, "320adaba-7f14-4057-a439-8450990fbfca");
            RockMigrationHelper.AddGroupType("Partners", "A missions organization group of partners", "Group", "Partner", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_PARTNERS);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_PARTNERS, "Partner", "", 0, null, null, "9a783d4b-00de-4955-8325-cfc817a2162c");
            RockMigrationHelper.AddGroupType("Leads", "A missions organization group of leads", "Group", "Lead", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_LEADS);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_LEADS, "Lead", "", 0, null, null, "a2f2288b-c1a6-48a0-a576-07f9a1acb235");
            RockMigrationHelper.AddGroupType("Volunteers", "A missions organization group of volunteers", "Group", "Volunteer", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS, "Volunteer", "", 0, null, null, "ba361f6a-a60e-48b5-ac35-c7e24256c52c");
            RockMigrationHelper.AddGroupType("Applicants", "A missions organization group of applicants", "Group", "Applicant", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_APPLICANTS);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_APPLICANTS, "Applicant", "", 0, null, null, "0ab525b1-d0a6-4bd2-a8c9-ae1f708bb60b");
            RockMigrationHelper.AddGroupType("Missionaries", "A missions organization group of missionaries", "Group", "Member", false, true, true, "", 0, SystemGuid.GroupType.GROUPTYPE_DEPARTMENT, 0, null, SystemGuid.GroupType.GROUPTYPE_MISSIONARIES);
            RockMigrationHelper.AddGroupTypeRole(SystemGuid.GroupType.GROUPTYPE_MISSIONARIES, "Missionary", "", 0, null, null, "f32abb84-991c-4cc1-9375-b404d2916d34");
            Sql(@"UPDATE [GroupType] SET [AllowAnyChildGroupType] = 1 WHERE [Guid] = '" + SystemGuid.GroupType.GROUPTYPE_DEPARTMENT + "'");

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
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_MISSIONARIES}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_AREA}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_REGION}' OR [Guid] = '{SystemGuid.GroupType.GROUPTYPE_TEAM}' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '{SystemGuid.GroupType.GROUPTYPE_MISSIONARIES}'");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("283C606C-C2A7-4FF8-B245-81AC5B900129");    // GroupType - Group Attribute, Department: Department

            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_PARTNERS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_LEADS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_APPLICANTS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_VOLUNTEERS);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_MISSIONARIES);
            RockMigrationHelper.DeleteGroupType(SystemGuid.GroupType.GROUPTYPE_DEPARTMENT);

            RockMigrationHelper.DeleteDefinedType(SystemGuid.DefinedType.DEPARTMENTS);
        }
    }
}
