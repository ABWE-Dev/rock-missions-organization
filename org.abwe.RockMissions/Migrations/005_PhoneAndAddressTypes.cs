using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(5, "1.12.0")]
    public class PhoneAndAddressTypes : Migration
    {
        public override void Up()
        {
            // Phone Types
            RockMigrationHelper.UpdateDefinedValue("8345DD45-73C6-4F5E-BEBD-B77FC83F18FD", "Field", "A missionary's field phone number", "35FADC75-9C52-4861-9AFA-02722E308360", false);

            // Address Types
            RockMigrationHelper.UpdateDefinedValue("2E68D37C-FB7B-4AA5-9E09-3785D52156CB", "Field", "A missionary's field address", "F5C1BD2D-4D2D-461B-8CF4-922104460E97", false);
            RockMigrationHelper.AddDefinedValueAttributeValue("F5C1BD2D-4D2D-461B-8CF4-922104460E97", "4BDBBE2F-6ECC-4C08-971D-7518C217A67B", @"True");
            RockMigrationHelper.AddDefinedValueAttributeValue("F5C1BD2D-4D2D-461B-8CF4-922104460E97", "7C1271EC-E809-42FD-8CF1-F61CE02AEBC2", @"True");
            RockMigrationHelper.AddDefinedValueAttributeValue("F5C1BD2D-4D2D-461B-8CF4-922104460E97", "85ED6E0F-9087-4F0F-993B-4BD5FCA9DCB9", @"True");
        }

        public override void Down()
        {
            // Phone Types
            RockMigrationHelper.DeleteDefinedValue("35FADC75-9C52-4861-9AFA-02722E308360"); // Field

            // Address Types
            RockMigrationHelper.DeleteDefinedValue("F5C1BD2D-4D2D-461B-8CF4-922104460E97"); // Field
        }
    }
}
