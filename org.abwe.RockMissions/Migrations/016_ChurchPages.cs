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
    [MigrationNumber(16, "1.12.0")]
    class ChurchPages : Migration
    {
        public override void Up()
        {
            Debug.WriteLine("starting ChurchPages migration");

            // Add Page Churches to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "B0F4B33D-DD11-4CCC-B79D-9342831B8701", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Churches", "", "28DAC404-FB2E-4312-9370-0E9579506485", "");

            // Add Page Church Details to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "28DAC404-FB2E-4312-9370-0E9579506485", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Church Details", "", "75C9536A-C984-48AB-B7D4-E036C0AD59A1", "");

            // Add Page Churches to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "BF04BB7E-BE3A-4A38-A37C-386B55496303", "F66758C6-3E3D-4598-AF4C-B317047B5987", "Churches", "", "E87CC2CE-A744-4311-A54A-C62CD7470B91", "", "CB9ABA3B-6962-4A42-BDA1-EA71B7309232");

            // Add Page Route for Churches
            RockMigrationHelper.AddPageRoute("E87CC2CE-A744-4311-A54A-C62CD7470B91", "Person/{PersonId}/Churches", "987048F6-19B7-4D72-9A1C-EEED3D9DAD53");

            // Add/Update BlockType Church Detail
            RockMigrationHelper.UpdateBlockType("Church Detail", "Displays the details of the given church.", "~/Plugins/org_abwe/RockMissions/Churches/ChurchDetail.ascx", "org_abwe > RockMissions > Churches", "F5248567-A78E-4B92-92CD-14B2860FFADF");

            // Add/Update BlockType Church List
            RockMigrationHelper.UpdateBlockType("Church List", "Lists all churches and provides name, location, and sending/supporting filters", "~/Plugins/org_abwe/RockMissions/Churches/ChurchList.ascx", "org_abwe > RockMissions > Churches", "9F410F59-9007-45E9-8FD0-BBB2E28624DD");


            // TODO:  fix this AddBlock once the PersonDetail SubNav is completely setup 
            // Add Block Page Menu to Layout: PersonDetail, Site: Rock RMS
            //RockMigrationHelper.AddBlock(true, null, "F66758C6-3E3D-4598-AF4C-B317047B5987".AsGuid(), "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "CACB9D1A-A820-4587-986A-D66A69EE9948".AsGuid(), "Page Menu", "SubNavigation", @"", @"", 0, "4056094C-FE8C-4E1B-A827-D678C5D94777");


            // Add Block Church List to Page: Churches, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "28DAC404-FB2E-4312-9370-0E9579506485".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "9F410F59-9007-45E9-8FD0-BBB2E28624DD".AsGuid(), "Church List", "Main", @"", @"", 0, "CF24C629-F020-497D-BCC6-7C5D1632635C");

            // Add Block Church Detail to Page: Church Details, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "75C9536A-C984-48AB-B7D4-E036C0AD59A1".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "F5248567-A78E-4B92-92CD-14B2860FFADF".AsGuid(), "Church Detail", "Main", @"", @"", 0, "71ED6334-5038-4F48-9CA2-C7D45A63BF99");

            // Add Block Transaction List to Page: Church Details, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "75C9536A-C984-48AB-B7D4-E036C0AD59A1".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E04320BC-67C3-452D-9EF6-D74D8C177154".AsGuid(), "Transaction List", "Main", @"", @"", 2, "2FCF0A04-D008-44A3-83C3-B8115D5B0FB2");

            // Add Block Group List to Page: Churches, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "E87CC2CE-A744-4311-A54A-C62CD7470B91".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "3D7FB6BE-6BBD-49F7-96B4-96310AF3048A".AsGuid(), "Group List", "SubNavigation", @"", @"", 0, "2EFF9D23-1670-43EA-B484-FD9B0545B33A");


            // update block order for pages with new blocks if the page,zone has multiple blocks

            // Update Order for Page: Church Details,  Zone: Main,  Block: Church Detail
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '71ED6334-5038-4F48-9CA2-C7D45A63BF99'");

            // Update Order for Page: Church Details,  Zone: Main,  Block: Transaction List
            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '2FCF0A04-D008-44A3-83C3-B8115D5B0FB2'");

            // Attribute for BlockType: Church Detail:Person Profile Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("F5248567-A78E-4B92-92CD-14B2860FFADF", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Person Profile Page", "PersonProfilePage", "Person Profile Page", @"The page used to view the details of a church contact", 0, @"", "FD6F4226-85AD-44EA-84AF-1D64D81987BF");

            // Attribute for BlockType: Church Detail:Communication Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("F5248567-A78E-4B92-92CD-14B2860FFADF", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Communication Page", "CommunicationPage", "Communication Page", @"The communication page to use for when the church email address is clicked. Leave this blank to use the default.", 1, @"", "A7CCC087-9273-4E5D-914D-DC84887C5990");

            // Attribute for BlockType: Church List:Detail Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 0, @"", "B7FBAF11-5EC4-44D1-946F-6C0D2297ED4A");

            // Attribute for BlockType: Church List:core.EnableDefaultWorkflowLauncher
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "core.EnableDefaultWorkflowLauncher", "core.EnableDefaultWorkflowLauncher", "core.EnableDefaultWorkflowLauncher", @"", 0, @"True", "0F7576C4-3723-42C9-96F2-E51142678AA2");

            // Attribute for BlockType: Church List:core.CustomActionsConfigs
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "9C204CD0-1233-41C5-818A-C5DA439445AA", "core.CustomActionsConfigs", "core.CustomActionsConfigs", "core.CustomActionsConfigs", @"", 0, @"", "79D9369A-9723-4281-9526-63BA48ABFA5D");

            // Add Block Attribute Value
            //   Block: Church List
            //   BlockType: Church List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Detail Page
            //   Attribute Value: 75c9536a-c984-48ab-b7d4-e036c0ad59a1
            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "B7FBAF11-5EC4-44D1-946F-6C0D2297ED4A", @"75c9536a-c984-48ab-b7d4-e036c0ad59a1");

            // Add Block Attribute Value
            //   Block: Church List
            //   BlockType: Church List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "CBB2F34B-31D2-4D33-B25A-758275E6F5AC", @"False");

            // Add Block Attribute Value
            //   Block: Church List
            //   BlockType: Church List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: core.EnableDefaultWorkflowLauncher
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "0F7576C4-3723-42C9-96F2-E51142678AA2", @"True");

            // Add Block Attribute Value
            //   Block: Church Detail
            //   BlockType: Church Detail
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Person Profile Page
            //   Attribute Value: 08dbd8a5-2c35-4146-b4a8-0f7652348b25
            RockMigrationHelper.AddBlockAttributeValue("71ED6334-5038-4F48-9CA2-C7D45A63BF99", "FD6F4226-85AD-44EA-84AF-1D64D81987BF", @"08dbd8a5-2c35-4146-b4a8-0f7652348b25");

            // Add Block Attribute Value
            //   Block: Church Detail
            //   BlockType: Church Detail
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Communication Page
            //   Attribute Value: 7e8408b2-354c-4a5a-8707-36754ae80b9a
            RockMigrationHelper.AddBlockAttributeValue("71ED6334-5038-4F48-9CA2-C7D45A63BF99", "A7CCC087-9273-4E5D-914D-DC84887C5990", @"7e8408b2-354c-4a5a-8707-36754ae80b9a");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Future Transactions
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "7C455827-00ED-4800-BDBC-41FE04A58C2D", @"False");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: core.EnableDefaultWorkflowLauncher
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "12749FBF-9A92-40FA-A7A4-85BECA1ED52A", @"True");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Default Transaction View
            //   Attribute Value: Transactions
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "8D067930-6355-4DC7-98E1-3619C871AC83", @"Transactions");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Foreign Key
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "58288BD2-C9FB-4A25-B41E-24C7416C8C6F", @"False");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Only Active Accounts on Filter
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "81AD58EA-F94B-42A1-AC57-16902B717092", @"False");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Account Summary
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "4C92974B-FB99-4E89-B215-A457646D77E1", @"False");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Image Height
            //   Attribute Value: 200
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "00EBFDFE-C6AE-48F2-B284-809D1765D489", @"200");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Show Options
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "0227D124-D207-4F68-8B77-4A4A88CBBE6F", @"False");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: Entity Type
            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "29A6C37A-EFB3-41CC-A522-9CEFAAEEA910", @"72657ed8-d16e-492e-ac12-144c5e7567e7");

            // Add Block Attribute Value
            //   Block: Transaction List
            //   BlockType: Transaction List
            //   Block Location: Page=Church Details, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "A3744205-BA7C-45AD-81B7-407FA51BC9C0", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Group Picker Type
            //   Attribute Value: Dropdown
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "77307E9F-CE10-4285-A0A5-418D324A4576", @"Dropdown");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: core.EnableDefaultWorkflowLauncher
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "D7AE5225-28BF-4954-9D04-782AC76CBF4E", @"True");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Allow Add
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FD470B89-C053-411E-BB22-C064E2C15E43", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Entity Type
            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "A32C7EFE-2E5F-4E99-9867-DD562407B72E", @"72657ed8-d16e-492e-ac12-144c5e7567e7");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Filter
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "7E0EDF09-9374-4AC4-8591-30C08D7F1E1F", @"True");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Include Group Types
            //   Attribute Value: be7a89fa-4815-4258-a9c6-c08c058ee933
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "5164FF88-A53B-4982-BE50-D56F1FE13FC6", @"be7a89fa-4815-4258-a9c6-c08c058ee933");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Group Type Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "951D268A-B2A8-42A2-B1C1-3B854070DDF9", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Description Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "A0E1B2A4-9D86-4F57-B608-FC7CC498EAC3", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display System Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "766A4BFA-D2D1-4744-B30D-637A7E3B9D8F", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Active Status Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FCB5F8B3-9C0E-46A8-974A-15353447FCD7", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Security Column
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "2DDD4FD0-5E03-4271-B8EF-728DECA10018", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Set Panel Title
            //   Attribute Value: Churches
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "E861BE97-59F3-4A9C-8F9E-8F45798DF26C", @"Churches");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Member Count Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FDD84597-E3E8-4E91-A72F-C6538B085310", @"True");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Limit to Active Status
            //   Attribute Value: all
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "B4133552-42B6-4053-90B9-33B882B72D2D", @"all");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Display Group Path
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "6F229535-B44E-44C2-A9AF-28244600E244", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Limit to Security Role Groups
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "1DAD66E3-8859-487E-8200-483C98DE2E07", @"False");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: Detail Page
            //   Attribute Value: 75c9536a-c984-48ab-b7d4-e036c0ad59a1
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "8E57EC42-ABEE-4D35-B7FA-D8513880E8E4", @"75c9536a-c984-48ab-b7d4-e036c0ad59a1");

            // Add Block Attribute Value
            //   Block: Group List
            //   BlockType: Group List
            //   Block Location: Page=Churches, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FB20EF5B-95DC-4EEE-8FEC-870D9EE59043", @"False");

            // Add/Update PageContext for Page:Church Details, Entity: Rock.Model.Person, Parameter: ChurchId
            RockMigrationHelper.UpdatePageContext("75C9536A-C984-48AB-B7D4-E036C0AD59A1", "Rock.Model.Person", "ChurchId", "9696E6C1-D947-4357-8964-CE8934A200F8");

            // Add/Update PageContext for Page:Churches, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.UpdatePageContext("E87CC2CE-A744-4311-A54A-C62CD7470B91", "Rock.Model.Person", "PersonId", "F11FB50B-0EDA-4264-B9D5-1871459E70D3");


        }

        public override void Down()
        {

            // core.EnableDefaultWorkflowLauncher Attribute for BlockType: Church List
            RockMigrationHelper.DeleteAttribute("0F7576C4-3723-42C9-96F2-E51142678AA2");

            // core.CustomActionsConfigs Attribute for BlockType: Church List
            RockMigrationHelper.DeleteAttribute("79D9369A-9723-4281-9526-63BA48ABFA5D");

            // Detail Page Attribute for BlockType: Church List
            RockMigrationHelper.DeleteAttribute("B7FBAF11-5EC4-44D1-946F-6C0D2297ED4A");

            // Communication Page Attribute for BlockType: Church Detail
            RockMigrationHelper.DeleteAttribute("A7CCC087-9273-4E5D-914D-DC84887C5990");

            // Person Profile Page Attribute for BlockType: Church Detail
            RockMigrationHelper.DeleteAttribute("FD6F4226-85AD-44EA-84AF-1D64D81987BF");


            // Remove Block: Group List, from Page: Churches, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("2EFF9D23-1670-43EA-B484-FD9B0545B33A");


            // Remove Block: Transaction List, from Page: Church Details, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2");

            // Remove Block: Church Detail, from Page: Church Details, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("71ED6334-5038-4F48-9CA2-C7D45A63BF99");

            // Remove Block: Church List, from Page: Churches, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("CF24C629-F020-497D-BCC6-7C5D1632635C");

            // Delete BlockType Church List
            RockMigrationHelper.DeleteBlockType("9F410F59-9007-45E9-8FD0-BBB2E28624DD"); // Church List

            // Delete BlockType Church Detail
            RockMigrationHelper.DeleteBlockType("F5248567-A78E-4B92-92CD-14B2860FFADF"); // Church Detail

            // Delete Page Churches from Site:Rock RMS
            RockMigrationHelper.DeletePage("E87CC2CE-A744-4311-A54A-C62CD7470B91"); //  Page: Churches, Layout: PersonDetail, Site: Rock RMS

            // Delete Page Church Details from Site:Rock RMS
            RockMigrationHelper.DeletePage("75C9536A-C984-48AB-B7D4-E036C0AD59A1"); //  Page: Church Details, Layout: Full Width, Site: Rock RMS

            // Delete Page Churches from Site:Rock RMS
            RockMigrationHelper.DeletePage("28DAC404-FB2E-4312-9370-0E9579506485"); //  Page: Churches, Layout: Full Width, Site: Rock RMS

            // Delete PageContext for Page:Church Details, Entity: Rock.Model.Person, Parameter: ChurchId
            RockMigrationHelper.DeletePageContext("9696E6C1-D947-4357-8964-CE8934A200F8");

            // Delete PageContext for Page:Churches, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.DeletePageContext("F11FB50B-0EDA-4264-B9D5-1871459E70D3");



        }
    }
}
