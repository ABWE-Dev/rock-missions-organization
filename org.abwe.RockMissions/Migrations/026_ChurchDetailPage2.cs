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
    [MigrationNumber(26, "1.12.0")]
    class ChurchDetailPage2 : Migration
    {
        public override void Up()
        {
            // Add Block Pledge List to Page: Church Details, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "75C9536A-C984-48AB-B7D4-E036C0AD59A1".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "7011E792-A75F-4F22-B17E-D3A58C0EDB6D".AsGuid(), "Pledge List", "Main", @"", @"", 1, "BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA");

            // Update Order for Page: Church Details,  Zone: Main,  Block: Church Detail
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '71ED6334-5038-4F48-9CA2-C7D45A63BF99'");

            // Update Order for Page: Church Details,  Zone: Main,  Block: Pledge List
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = 'BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA'");

            // Update Order for Page: Church Details,  Zone: Main,  Block: Transaction List
            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '2FCF0A04-D008-44A3-83C3-B8115D5B0FB2'");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Detail Page
            //   Attribute Value: ef7aa296-ca69-49bc-a28b-901a8aaa9466
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "3E26B7DF-7A7F-4829-987F-47304C0F845E", @"ef7aa296-ca69-49bc-a28b-901a8aaa9466");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Entity Type
            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "E9245CFD-4B11-4CE2-A120-BB3AC47C0974", @"72657ed8-d16e-492e-ac12-144c5e7567e7");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Group Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "F2476138-7C16-404C-A4B6-600E39602601", @"False");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Last Modified Filter
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "550E6B86-98BF-4DA7-9B54-634ADE0EE466", @"True");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Limit Pledges To Current Person
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "6A056518-3E38-4E78-AF6F-16D5C23A057D", @"False");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Last Modified Date Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "B27608E5-E5BF-4AC4-8C7E-C2A26456480B", @"True");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Account Filter
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "B16A3F35-C8A4-47B3-BA7A-E20098E7B028", @"False");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Account Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "63A83579-C73A-4387-B317-D9852F6647F3", @"True");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Person Filter
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "807B41A4-4286-434C-918A-FE3942A75F7B", @"False");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Date Range Filter
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "0049EC69-9814-4322-833F-BD82F92C64E9", @"True");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Account Summary
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "B9594D47-4E75-4336-9F92-6C96B8CBEB42", @"False");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: core.EnableDefaultWorkflowLauncher
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "EB314955-A5AE-492F-B350-A2E4046B6DDA", @"True");

            // Add Block Attribute Value
            //   Block: Pledge List
            //   BlockType: Pledge List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA", "B4FA6674-B736-42E2-AE0E-1DE6FA7A185F", @"False");

        }

        public override void Down()
        {
            // Remove Block: Pledge List, from Page: Church Details, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("BA91FDB4-BE6B-48C4-8AC1-217C0AAA64BA");

        }
    }
}
