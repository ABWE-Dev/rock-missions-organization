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
    [MigrationNumber(30, "1.12.0")]
    class ChurchRedirect : Migration
    {
        public override void Up()
        {
            // Add Block Redirect Churches to Page: Business Detail, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "D2B43273-C64F-4F57-9AAE-9571E1982BAC".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "19B61D65-37E3-459F-A44F-DEF0089118A3".AsGuid(), "Redirect Churches", "Feature", @"", @"", 0, "F465304A-1CBA-436C-8E05-B0AD0D2A9B07");

            // Update Order for Page: Business Detail,  Zone: Feature,  Block: Redirect Churches
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = 'F465304A-1CBA-436C-8E05-B0AD0D2A9B07'");

            // Add/Update HtmlContent for Block: Redirect Churches
            RockMigrationHelper.UpdateHtmlContentBlock("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", @"{% assign churchmemberships = Context.Person | Groups:'"+SqlScalar($"SELECT [Id] FROM GroupType WHERE [Guid] = '{SystemGuid.GroupType.GROUPTYPE_CHURCH}'").ToString()+@"' | Where:'GroupRoleId', '"+SqlScalar($"SELECT [Id] FROM GroupTypeRole WHERE [Guid] = '{SystemGuid.GroupTypeRole.GROUPROLE_CHURCH}'")+@"'  %}
{% if churchmemberships != empty %}
    {% assign newUrl = '/page/"+SqlScalar("SELECT [Id] FROM Page WHERE [Guid] = '75C9536A-C984-48AB-B7D4-E036C0AD59A1'").ToString()+@"?ChurchId=' | Append:Context.Person.Id %}
    {{ newUrl | PageRedirect }}
{% endif %}", "14EDE0A5-AAFB-498F-B6FA-17C814472528");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Cache Duration
            //   Attribute Value: 0
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "4DFDB295-6D0F-40A1-BEF9-7B70C56F66C4", @"0");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Require Approval
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "EC2B701B-4C1D-4F3F-9C77-A73C75D7FF7A", @"False");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Enable Versioning
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "7C1CE199-86CF-4EAE-8AB3-848416A72C58", @"False");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Start in Code Editor mode
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "0673E015-F8DD-4A52-B380-C758011331B2", @"True");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Image Root Folder
            //   Attribute Value: ~/Content
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "26F3AFC6-C05B-44A4-8593-AFE1D9969B0E", @"~/Content");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: User Specific Folders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "9D3E4ED9-1BEF-4547-B6B0-CE29FE3835EE", @"False");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Document Root Folder
            //   Attribute Value: ~/Content
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "3BDB8AED-32C5-4879-B1CB-8FC7C8336534", @"~/Content");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Entity Type
            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "6783D47D-92F9-4F48-93C0-16111D675A0F", @"72657ed8-d16e-492e-ac12-144c5e7567e7");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Enabled Lava Commands
            //   Attribute Value: RockEntity
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "7146AC24-9250-4FC4-9DF2-9803B9A84299", @"RockEntity");

            // Add Block Attribute Value
            //   Block: Redirect Churches
            //   BlockType: HTML Content
            //   Block Location: Page=Business Detail, Site=Rock RMS
            //   Attribute: Is Secondary Block
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("F465304A-1CBA-436C-8E05-B0AD0D2A9B07", "04C15DC1-DFB6-4D63-A7BC-0507D0E33EF4", @"False");

        }

        public override void Down()
        {

        }
    }
}
