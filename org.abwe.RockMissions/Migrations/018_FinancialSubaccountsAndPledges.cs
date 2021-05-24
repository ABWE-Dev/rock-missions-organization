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
    [MigrationNumber(18, "1.12.0")]
    class FinancialSubaccountsAndPledges : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddDefinedType("Financial", "Subaccounts", "Financial Subaccounts", "33a79452-c7e6-4977-910a-55cf228ffffc");

            RockMigrationHelper.UpdateEntityAttribute("Rock.Model.FinancialTransaction", "9C204CD0-1233-41C5-818A-C5DA439445AA", null, null, "Journal Reference", "The Journal Reference number", 0, "", "a4fb1e4a-af78-4e84-bfa6-06cfeea5a4cf");
            RockMigrationHelper.UpdateEntityAttribute("Rock.Model.FinancialPledge", "9C204CD0-1233-41C5-818A-C5DA439445AA", null, null, "Recurring Amount", "The recurring amount of this pledge", 0, "", "c3d80aba-52b9-4587-a10f-337eeef4faa0");

            // Entity: Rock.Model.FinancialAccount Attribute: Subaccounts
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialAccount", "73B02051-0D38-4AD9-BF81-A2D477DE4F70", "", "", "Subaccounts", "Subaccounts", @"", 31054, @"", "FA704212-996A-4D72-BEFF-F6895F6D6D2F", "Subaccounts");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "allowhtml", @"False", "89F2A14B-AB8D-495B-B2B3-10D7A7EA800D");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "customvalues", @"", "B4C9BEBD-CCC8-4576-97A5-F4CEB61B62D6");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "definedtype", SqlScalar("SELECT [Id] FROM DefinedType WHERE [Guid] = '33a79452-c7e6-4977-910a-55cf228ffffc'").ToString(), "F113F855-23CC-4699-B0D8-C9B5269F8896");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "displayvaluefirst", @"True", "91BF52F1-8400-4548-BF0F-FF9BF48A7B0D");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "keyprompt", @"Subaccount", "C33A0B29-E672-4231-8568-B6B75D03575A");
            // Qualifier for attribute: Subaccounts
            RockMigrationHelper.UpdateAttributeQualifier("FA704212-996A-4D72-BEFF-F6895F6D6D2F", "valueprompt", @"Override", "147AA738-8952-49B9-AF3F-1E3C2F8BCE25");

            // Entity: Rock.Model.FinancialTransactionDetail Attribute: Subaccount
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialTransactionDetail", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "", "", "Subaccount", "Subaccount", @"", 0, @"", "B93DE0A0-0208-4BC2-B758-12B2F06729E9", "Subaccount");
            Sql("UPDATE [Attribute] SET IsGridColumn = 1 WHERE [Guid] = 'B93DE0A0-0208-4BC2-B758-12B2F06729E9'");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "AllowAddingNewValues", @"False", "9D773B9A-8F4B-4287-82D6-9B72DF29A2D4");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "allowmultiple", @"False", "A4E3AB6E-F6CF-497F-B527-EC7FCAA84848");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "definedtype", SqlScalar("SELECT [Id] FROM DefinedType WHERE [Guid] = '33a79452-c7e6-4977-910a-55cf228ffffc'").ToString(), "9EE51FFA-F07A-4481-8772-18C4DA177C2D");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "displaydescription", @"True", "EB651B24-1947-468D-998D-E03F81477C3D");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "enhancedselection", @"True", "34D3F7D8-0B81-4921-8295-E8E38B57F6CD");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "includeInactive", @"False", "53C4CAC3-C5C8-47C2-A00E-0A72AF210C8D");
            // Qualifier for attribute: Subaccount
            RockMigrationHelper.UpdateAttributeQualifier("B93DE0A0-0208-4BC2-B758-12B2F06729E9", "RepeatColumns", @"", "08CE3334-B229-475D-9388-197C594E6319");

        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("FA704212-996A-4D72-BEFF-F6895F6D6D2F"); // Rock.Model.FinancialAccount: Subaccounts
            RockMigrationHelper.DeleteDefinedType("33a79452-c7e6-4977-910a-55cf228ffffc");
            RockMigrationHelper.DeleteAttribute("a4fb1e4a-af78-4e84-bfa6-06cfeea5a4cf");
            RockMigrationHelper.DeleteAttribute("c3d80aba-52b9-4587-a10f-337eeef4faa0");
            RockMigrationHelper.DeleteAttribute("B93DE0A0-0208-4BC2-B758-12B2F06729E9"); // Rock.Model.FinancialTransactionDetail: Subaccount

        }
    }
}
