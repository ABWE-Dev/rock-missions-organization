using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(9, "1.12.0")]
    public class ChurchGroup : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.UpdateDefinedValue("26BE73A6-A9C5-4E94-AE00-3AFDCF8C9275", "Church", "A church record", "D982A508-F991-4F85-993B-DD487A748897", true);

            RockMigrationHelper.UpdateCategory("5997c8d3-8840-4591-99a5-552919f90cbd", "Church", "fa fa-church", "", "507a81e4-07ae-4983-a8f2-689757b28a32");

            RockMigrationHelper.UpdateGroupType("Church", "the structure representing a church person record and other actual persons with a relationship to the church",
                "Church Group", "Contact", "8bf35114-0d72-4d3d-b15d-0ffe241ae81d", false, false, false, "fa fa-church", 0, null, 1, "", "be7a89fa-4815-4258-a9c6-c08c058ee933");

            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Admin Contact", "", 0, null, null, "8bf35114-0d72-4d3d-b15d-0ffe241ae81d", true, false, true);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Sent Missionary", "", 1, null, null, "1084eb40-3166-46c6-b0b6-1ac9abc6f6e2", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Supported Missionary", "", 2, null, null, "2c923974-af7f-47a3-bc37-74f76d9ff2f7", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Missions Pastor", "", 3, null, null, "bd3fda15-fbc3-4e64-a873-4c5cce7cbe69", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Pastor", "", 4, null, null, "0afb8d1e-e4bd-47cd-911f-3fa6d4a1bee4", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Senior Pastor", "", 5, null, null, "62fd300c-46f3-4c5f-a0f2-07c345477670", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Member", "", 6, null, null, "f000790b-fbee-428a-803d-1f879729ce98", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Attendee", "", 7, null, null, "732edacb-c282-45cd-831f-eec7aa8be961", true, false, false);
            RockMigrationHelper.UpdateGroupTypeRole("be7a89fa-4815-4258-a9c6-c08c058ee933", "Church", "The person entity representing the church with the church record type", 8, null, null, "304598f2-fef0-44d3-ae10-5c5b1bfce29d", true, false, false);

 
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedValue("D982A508-F991-4F85-993B-DD487A748897"); // Church
            RockMigrationHelper.DeleteCategory("507a81e4-07ae-4983-a8f2-689757b28a32");
            RockMigrationHelper.DeleteGroupType("be7a89fa-4815-4258-a9c6-c08c058ee933");
            RockMigrationHelper.DeleteGroupTypeRole("8bf35114-0d72-4d3d-b15d-0ffe241ae81d");
            RockMigrationHelper.DeleteGroupTypeRole("1084eb40-3166-46c6-b0b6-1ac9abc6f6e2");
            RockMigrationHelper.DeleteGroupTypeRole("2c923974-af7f-47a3-bc37-74f76d9ff2f7");
            RockMigrationHelper.DeleteGroupTypeRole("bd3fda15-fbc3-4e64-a873-4c5cce7cbe69");
            RockMigrationHelper.DeleteGroupTypeRole("0afb8d1e-e4bd-47cd-911f-3fa6d4a1bee4");
            RockMigrationHelper.DeleteGroupTypeRole("62fd300c-46f3-4c5f-a0f2-07c345477670");
            RockMigrationHelper.DeleteGroupTypeRole("f000790b-fbee-428a-803d-1f879729ce98");
            RockMigrationHelper.DeleteGroupTypeRole("732edacb-c282-45cd-831f-eec7aa8be961");
            RockMigrationHelper.DeleteGroupTypeRole("304598f2-fef0-44d3-ae10-5c5b1bfce29d");
        }
    }
}
