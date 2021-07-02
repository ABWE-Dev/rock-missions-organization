using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Rock;
using Rock.Plugin;
using Rock.Security;
using Rock.Model;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(28, "1.12.0")]
    class TripPlanning : ABWEMigration
    {
        public override void Up()
        {
            RockMigrationHelper.UpdateEntityType("org.abwe.RockMissions.Filters.Person.DistanceFromWithBusinessFilter", "Distance From With Business Filter", "org.abwe.RockMissions.Filters.Person.DistanceFromWithBusinessFilter, org.abwe.RockMissions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", false, true, "C55F7118-48E3-4929-B5DA-C156EB3404C5");
            RockMigrationHelper.UpdateEntityType("org.abwe.RockMissions.DataSelect.LastInteractionSelect", "Last Interaction Select", "org.abwe.RockMissions.DataSelect.LastInteractionSelect, org.abwe.RockMissions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", false, true, "36402B27-BA8B-494F-B569-A091410669A9");

            RockMigrationHelper.AddGroupType("Trip", "A missions org administrative trip", "Trip", "Person", false, true, true, "", 0, "", 0, "", "3AFAC96C-5E38-4461-A7D7-D359D168D7CE");

            RockMigrationHelper.AddGroupTypeGroupAttribute("3AFAC96C-5E38-4461-A7D7-D359D168D7CE", "9C7D431C-875C-4792-9E76-93F3A32BB850", "Dates", @"", 0, "", "A8BD90B8-DC52-4A64-BDC7-42AC10E87305", "Dates");
            RockMigrationHelper.AddGroupTypeGroupMemberAttribute("3AFAC96C-5E38-4461-A7D7-D359D168D7CE", "FE95430C-322D-4B67-9C77-DFD1D4408725", "Meeting Time", @"", 0, "", "58AF4A0A-EFD7-4DFD-98AC-686D347B2660");
            RockMigrationHelper.AddGroupTypeGroupMemberAttribute("3AFAC96C-5E38-4461-A7D7-D359D168D7CE", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Priority", @"", 1, "", "B089354F-48A3-49CC-B718-79DFE2B54E72");

            // Allow child groups of the same type
            Sql($@"INSERT [GroupTypeAssociation]
	            ([GroupTypeId], [ChildGroupTypeId])
              SELECT [GroupType].[Id], [ChildGroupType].Id
              FROM [GroupType]
              OUTER APPLY ( SELECT Id FROM GroupType WHERE [Guid] = '3AFAC96C-5E38-4461-A7D7-D359D168D7CE' ) [ChildGroupType]
              WHERE [GroupType].[Guid] = '3AFAC96C-5E38-4461-A7D7-D359D168D7CE'");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("A8BD90B8-DC52-4A64-BDC7-42AC10E87305");    // GroupType - Group Attribute, Trip: Dates
            RockMigrationHelper.DeleteAttribute("58AF4A0A-EFD7-4DFD-98AC-686D347B2660");    // GroupType - Group Member Attribute, Trip: Meeting Time
            RockMigrationHelper.DeleteAttribute("B089354F-48A3-49CC-B718-79DFE2B54E72");    // GroupType - Group Member Attribute, Trip: Priority

            RockMigrationHelper.DeleteGroupType("3AFAC96C-5E38-4461-A7D7-D359D168D7CE");
        }
    }
}
