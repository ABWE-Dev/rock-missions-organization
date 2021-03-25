using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(10, "1.12.0")]
    public class AccountAssociations : Migration
    {
        public override void Up()
        {
            // Add Category
            RockMigrationHelper.UpdatePersonAttributeCategory("Financial", "fa fa-money", "", SystemGuid.Category.CATEGORY_ATTRIBUTES_FINANCE);

            // Person Attribute "Primary Account"
            RockMigrationHelper.AddOrUpdatePersonAttributeByGuid(@"434D7B6F-F8DD-45B7-8C3E-C76EF10BE56A", new List<string> { SystemGuid.Category.CATEGORY_ATTRIBUTES_FINANCE }, @"Primary Account", @"Primary Account", @"PrimaryAccount", @"", @"", 31036, @"", @"996ED11A-1CA3-4980-BE94-58B7B41E2D1F");
            RockMigrationHelper.AddAttributeQualifier(@"996ED11A-1CA3-4980-BE94-58B7B41E2D1F", @"displaypublicname", @"True", @"E86E7944-2EAA-4BF3-BCCE-4ECFC7854B33");

            // Person Attribute "Secondary Accounts"
            RockMigrationHelper.AddOrUpdatePersonAttributeByGuid(@"17033CDD-EF97-4413-A483-7B85A787A87F", new List<string> { SystemGuid.Category.CATEGORY_ATTRIBUTES_FINANCE }, @"Secondary Accounts", @"Secondary Accounts", @"SecondaryAccounts", @"", @"", 31037, @"", @"C8DA4BC5-8B0B-4DD4-9C0A-92EF72B7F126");
            RockMigrationHelper.AddAttributeQualifier(@"C8DA4BC5-8B0B-4DD4-9C0A-92EF72B7F126", @"displaypublicname", @"True", @"AD14188D-8C72-4C2B-8F2B-287F67C9C1AF");
        }

        public override void Down()
        {

        }
    }
}
