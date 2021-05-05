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
    [MigrationNumber(12, "1.12.0")]
    public class SecurityRoles : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddSecurityRoleGroup("RSR - HR Worker", "Missions org HR workers. This allows editing appointment and employment timelines, as well as viewing restricted employment information.",SystemGuid.Group.GROUP_HR);
            RockMigrationHelper.AddSecurityRoleGroup("RSR - Missionary Worker", "Missions org missionary workers. This allows editing field assignments, appointments, and partner information.", SystemGuid.Group.GROUP_MISSIONARY_WORKER);
            RockMigrationHelper.AddSecurityRoleGroup("RSR - Application Worker", "Missions org application workers. This allows viewing and managing applicants and their applications.", SystemGuid.Group.GROUP_APPLICATION_WORKER);
            RockMigrationHelper.AddSecurityRoleGroup("RSR - Training Worker", "Missions org training workers. This allows administrating trainings, dates, courses, and providers.", SystemGuid.Group.GROUP_TRAINING_WORKER);
            RockMigrationHelper.AddSecurityRoleGroup("RSR - Missionary Finance Worker", "Missions org missionary finance workers. This allows the user to manage account associations, view missionary finances and support commitments.", SystemGuid.Group.GROUP_MISS_FINN_WORKER);
            RockMigrationHelper.AddSecurityRoleGroup("RSR - Medical Administrator", "Missions org missionary medical administrators-. This allows the user to edit medical clearances.", SystemGuid.Group.GROUP_MEDICAL_ADMIN);

            // Primary Account attribute
            RockMigrationHelper.AddSecurityAuthForAttribute("996ED11A-1CA3-4980-BE94-58B7B41E2D1F", 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISS_FINN_WORKER, 0, "c2bb132b-e8e3-43c8-8e75-15c75ae26cec");
            RockMigrationHelper.AddSecurityAuthForAttribute("996ED11A-1CA3-4980-BE94-58B7B41E2D1F", 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "0a14d285-2255-4250-88ce-4679381ac816");
            RockMigrationHelper.AddSecurityAuthForAttribute("996ED11A-1CA3-4980-BE94-58B7B41E2D1F", 2, Authorization.EDIT, false, null, (int)Rock.Model.SpecialRole.AllUsers, "53b297a1-d442-4a1c-8958-393dacf6bcbd");

            // Secondary Accounts attribute
            RockMigrationHelper.AddSecurityAuthForAttribute("C8DA4BC5-8B0B-4DD4-9C0A-92EF72B7F126", 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISS_FINN_WORKER, 0, "37495a87-7984-46d8-8511-e99c9954cb15");
            RockMigrationHelper.AddSecurityAuthForAttribute("C8DA4BC5-8B0B-4DD4-9C0A-92EF72B7F126", 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "91903241-bfe9-4584-a000-b165a3245896");
            RockMigrationHelper.AddSecurityAuthForAttribute("C8DA4BC5-8B0B-4DD4-9C0A-92EF72B7F126", 2, Authorization.EDIT, false, null, (int)Rock.Model.SpecialRole.AllUsers, "7c08242f-dbbb-45d2-82dc-8e2c2e8bee79");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_HR);
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_MISSIONARY_WORKER);
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_APPLICATION_WORKER);
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_TRAINING_WORKER);
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_MISS_FINN_WORKER);
            RockMigrationHelper.DeleteSecurityRoleGroup(SystemGuid.Group.GROUP_MEDICAL_ADMIN);
        }
    }
}
