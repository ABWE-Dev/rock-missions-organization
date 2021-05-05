//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Rock;
//using Rock.Model;
//using Rock.Plugin;
//using Rock.Security;

//namespace org.abwe.RockMissions.Migrations
//{
//    [MigrationNumber(16, "1.12.0")]
//    public class churchPages : Migration
//    {
//        public override void Up()
//        {

//            // Add Page Churches to Site:Rock RMS
//            RockMigrationHelper.AddPage(true, "BF04BB7E-BE3A-4A38-A37C-386B55496303", "F66758C6-3E3D-4598-AF4C-B317047B5987", "Churches", "", "E87CC2CE-A744-4311-A54A-C62CD7470B91", "");

//            // Add Page Church Details to Site:Rock RMS
//            RockMigrationHelper.AddPage(true, "28DAC404-FB2E-4312-9370-0E9579506485", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Church Details", "", "75C9536A-C984-48AB-B7D4-E036C0AD59A1", "");

//            // Add Page Churches to Site:Rock RMS
//            RockMigrationHelper.AddPage(true, "B0F4B33D-DD11-4CCC-B79D-9342831B8701", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Churches", "", "28DAC404-FB2E-4312-9370-0E9579506485", "");

//            // Add Page Route for Churches
//            RockMigrationHelper.AddPageRoute("E87CC2CE-A744-4311-A54A-C62CD7470B91", "Person/{PersonId}/Churches", "987048F6-19B7-4D72-9A1C-EEED3D9DAD53");

//            // Add Page Financials to Site:Rock RMS
//            RockMigrationHelper.AddPage(true, "BF04BB7E-BE3A-4A38-A37C-386B55496303", "F66758C6-3E3D-4598-AF4C-B317047B5987", "Financials", "", "8E087057-0761-4BCE-89DC-B235C18DFE68", "");


//            // Add/Update BlockType Church Detail
//            RockMigrationHelper.UpdateBlockType("Church Detail", "Displays the details of the given church.", "~/Plugins/org_abwe/RockMissions/Churches/ChurchDetail.ascx", "org_abwe > RockMissions > Churches", "F5248567-A78E-4B92-92CD-14B2860FFADF");

//            // Add/Update BlockType Church List
//            RockMigrationHelper.UpdateBlockType("Church List", "Lists all churches and provides name, location, and sending/supporting filters", "~/Plugins/org_abwe/RockMissions/Churches/ChurchList.ascx", "org_abwe > RockMissions > Churches", "9F410F59-9007-45E9-8FD0-BBB2E28624DD");

//            // Add Block Church List to Page: Churches, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "28DAC404-FB2E-4312-9370-0E9579506485".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "9F410F59-9007-45E9-8FD0-BBB2E28624DD".AsGuid(), "Church List", "Main", @"", @"", 0, "CF24C629-F020-497D-BCC6-7C5D1632635C");


//            // Add Block Church Detail to Page: Church Details, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "75C9536A-C984-48AB-B7D4-E036C0AD59A1".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "F5248567-A78E-4B92-92CD-14B2860FFADF".AsGuid(), "Church Detail", "Main", @"", @"", 0, "71ED6334-5038-4F48-9CA2-C7D45A63BF99");


//            // Add Block Transaction List to Page: Church Details, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "75C9536A-C984-48AB-B7D4-E036C0AD59A1".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E04320BC-67C3-452D-9EF6-D74D8C177154".AsGuid(), "Transaction List", "Main", @"", @"", 2, "2FCF0A04-D008-44A3-83C3-B8115D5B0FB2");


//            // Add Block Dynamic Data to Page: Donors, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "E584115C-9C37-4CCC-B696-8DE23A14C9EC".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E31E02E9-73F6-4B3E-98BA-E0E4F86CA126".AsGuid(), "Dynamic Data", "SubNavigation", @"<div class=""panel panel-default"">
//    <div class=""panel-heading"">
//        <h3 class=""panel-title"">Donors</h3>
//    </div>", @"</div>", 0, "15EDACF7-9EF1-42A5-9677-FF270BC74F5E");


//            // Add Block Group List to Page: Churches, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "E87CC2CE-A744-4311-A54A-C62CD7470B91".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "3D7FB6BE-6BBD-49F7-96B4-96310AF3048A".AsGuid(), "Group List", "SubNavigation", @"", @"", 0, "2EFF9D23-1670-43EA-B484-FD9B0545B33A");


//            // Add Block Balances to Page: Financials, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "8E087057-0761-4BCE-89DC-B235C18DFE68".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E31E02E9-73F6-4B3E-98BA-E0E4F86CA126".AsGuid(), "Balances", "SubNavigation", @"<div class=""panel panel-default"">
//    <div class=""panel-heading"">
//        <h3 class=""panel-title"">Total Donations By Financial Account</h3>
//    </div>", @"</div>", 1, "CBC740ED-121D-4A2C-94C9-3A2846EEE9A9");


//            // Add Block Transactions to Page: Financials, Site: Rock RMS
//            RockMigrationHelper.AddBlock(true, "8E087057-0761-4BCE-89DC-B235C18DFE68".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E31E02E9-73F6-4B3E-98BA-E0E4F86CA126".AsGuid(), "Transactions", "SubNavigation", @"", @"", 2, "446C1D84-2441-47CD-B619-42BCF9D28AC1");


//            // Update Order for Page: Church Details,  Zone: Main,  Block: Church Detail
//            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '71ED6334-5038-4F48-9CA2-C7D45A63BF99'");

//            // update block order for pages with new blocks if the page,zone has multiple blocks

//            // Update Order for Page: Church Details,  Zone: Main,  Block: Transaction List
//            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '2FCF0A04-D008-44A3-83C3-B8115D5B0FB2'");

//            // Update Order for Page: Financials,  Zone: SubNavigation,  Block: Balances
//            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = 'CBC740ED-121D-4A2C-94C9-3A2846EEE9A9'");

//            // Update Order for Page: Financials,  Zone: SubNavigation,  Block: Transactions
//            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '446C1D84-2441-47CD-B619-42BCF9D28AC1'");

//            // Attribute for BlockType: Church Detail:Person Profile Page
//            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("F5248567-A78E-4B92-92CD-14B2860FFADF", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Person Profile Page", "PersonProfilePage", "Person Profile Page", @"The page used to view the details of a church contact", 0, @"", "FD6F4226-85AD-44EA-84AF-1D64D81987BF");


//            // Attribute for BlockType: Church Detail:Communication Page
//            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("F5248567-A78E-4B92-92CD-14B2860FFADF", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Communication Page", "CommunicationPage", "Communication Page", @"The communication page to use for when the church email address is clicked. Leave this blank to use the default.", 1, @"", "A7CCC087-9273-4E5D-914D-DC84887C5990");


//            // Attribute for BlockType: Church List:Detail Page
//            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Detail Page", "DetailPage", "Detail Page", @"", 0, @"", "B7FBAF11-5EC4-44D1-946F-6C0D2297ED4A");


//            // Attribute for BlockType: Church List:core.EnableDefaultWorkflowLauncher
//            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "core.EnableDefaultWorkflowLauncher", "core.EnableDefaultWorkflowLauncher", "core.EnableDefaultWorkflowLauncher", @"", 0, @"True", "0F7576C4-3723-42C9-96F2-E51142678AA2");


//            // Attribute for BlockType: Church List:core.CustomActionsConfigs
//            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("9F410F59-9007-45E9-8FD0-BBB2E28624DD", "9C204CD0-1233-41C5-818A-C5DA439445AA", "core.CustomActionsConfigs", "core.CustomActionsConfigs", "core.CustomActionsConfigs", @"", 0, @"", "79D9369A-9723-4281-9526-63BA48ABFA5D");


//            // Add Block Attribute Value
//            //   Block: Church List
//            //   BlockType: Church List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Detail Page
//            //   Attribute Value: 75c9536a-c984-48ab-b7d4-e036c0ad59a1
//            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "B7FBAF11-5EC4-44D1-946F-6C0D2297ED4A", @"75c9536a-c984-48ab-b7d4-e036c0ad59a1");


//            // Add Block Attribute Value
//            //   Block: Church List
//            //   BlockType: Church List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: core.CustomGridEnableStickyHeaders
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "CBB2F34B-31D2-4D33-B25A-758275E6F5AC", @"False");


//            // Add Block Attribute Value
//            //   Block: Church List
//            //   BlockType: Church List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: core.EnableDefaultWorkflowLauncher
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("CF24C629-F020-497D-BCC6-7C5D1632635C", "0F7576C4-3723-42C9-96F2-E51142678AA2", @"True");


//            // Add Block Attribute Value
//            //   Block: Church Detail
//            //   BlockType: Church Detail
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Person Profile Page
//            //   Attribute Value: 08dbd8a5-2c35-4146-b4a8-0f7652348b25
//            RockMigrationHelper.AddBlockAttributeValue("71ED6334-5038-4F48-9CA2-C7D45A63BF99", "FD6F4226-85AD-44EA-84AF-1D64D81987BF", @"08dbd8a5-2c35-4146-b4a8-0f7652348b25");


//            // Add Block Attribute Value
//            //   Block: Church Detail
//            //   BlockType: Church Detail
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Communication Page
//            //   Attribute Value: 7e8408b2-354c-4a5a-8707-36754ae80b9a
//            RockMigrationHelper.AddBlockAttributeValue("71ED6334-5038-4F48-9CA2-C7D45A63BF99", "A7CCC087-9273-4E5D-914D-DC84887C5990", @"7e8408b2-354c-4a5a-8707-36754ae80b9a");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Show Future Transactions
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "7C455827-00ED-4800-BDBC-41FE04A58C2D", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: core.EnableDefaultWorkflowLauncher
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "12749FBF-9A92-40FA-A7A4-85BECA1ED52A", @"True");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Default Transaction View
//            //   Attribute Value: Transactions
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "8D067930-6355-4DC7-98E1-3619C871AC83", @"Transactions");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Show Foreign Key
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "58288BD2-C9FB-4A25-B41E-24C7416C8C6F", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Show Only Active Accounts on Filter
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "81AD58EA-F94B-42A1-AC57-16902B717092", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Show Account Summary
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "4C92974B-FB99-4E89-B215-A457646D77E1", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Image Height
//            //   Attribute Value: 200
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "00EBFDFE-C6AE-48F2-B284-809D1765D489", @"200");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Show Options
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "0227D124-D207-4F68-8B77-4A4A88CBBE6F", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: core.CustomGridEnableStickyHeaders
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "A3744205-BA7C-45AD-81B7-407FA51BC9C0", @"False");


//            // Add Block Attribute Value
//            //   Block: Transaction List
//            //   BlockType: Transaction List
//            //   Block Location: Page=Church Details, Site=Rock RMS
//            //   Attribute: Entity Type
//            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
//            RockMigrationHelper.AddBlockAttributeValue("2FCF0A04-D008-44A3-83C3-B8115D5B0FB2", "29A6C37A-EFB3-41CC-A522-9CEFAAEEA910", @"72657ed8-d16e-492e-ac12-144c5e7567e7");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Query
//            //   Attribute Value: {% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//            {% if PrimaryProject != empty %}

//            SELECT
//    Person.Id
//    , CASE
//        WHEN Person.NickName = '' OR Person.NickName IS NULL THEN Person.LastName
//        ELSE Person.LastName + ', ' + ISNULL(Person.NickName, '')
//     END[Donor]
//    ,FORMAT(SUM(Amount), 'C')[Total]
//    --,SUM(Amount)[Total]
//    ,MAX(TransactionDateTime)[LastGift]
//FROM[FinancialTransactionDetail]
//LEFT JOIN FinancialTransaction ON FinancialTransactionDetail.TransactionId = FinancialTransaction.Id
//LEFT JOIN PersonAlias ON PersonAlias.Id = AuthorizedPersonAliasId
//LEFT JOIN Person ON PersonAlias.PersonId = Person.Id
//WHERE AccountId = { { PrimaryProject.Id } } OR AccountId IN(SELECT Id FROM FinancialAccount WHERE ParentAccountId = { { PrimaryProject.Id } })--AND Person.RecordTypeValueId = 1-- AND DATEDIFF(yy, FinancialTransaction.TransactionDateTime, GETDATE()) < 10
//GROUP BY Person.Id, CASE
//        WHEN Person.NickName = '' OR Person.NickName IS NULL THEN Person.LastName
//        ELSE Person.LastName + ', ' + ISNULL(Person.NickName, '')
//     END
//ORDER BY SUM(Amount) DESC

//{% endif %}
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "71C8BA4E-8EF2-416B-BFE9-D1D88D9AA356", @"{% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//{% if PrimaryProject != empty %}

//SELECT
//    Person.Id
//    ,CASE
//        WHEN Person.NickName = '' OR Person.NickName IS NULL THEN Person.LastName
//        ELSE Person.LastName+', '+ISNULL(Person.NickName,'')
//     END [Donor]
//    ,FORMAT(SUM(Amount), 'C') [Total]
//    --,SUM(Amount) [Total]
//    ,MAX(TransactionDateTime) [LastGift]
//FROM [FinancialTransactionDetail]
//LEFT JOIN FinancialTransaction ON FinancialTransactionDetail.TransactionId = FinancialTransaction.Id
//LEFT JOIN PersonAlias ON PersonAlias.Id = AuthorizedPersonAliasId
//LEFT JOIN Person ON PersonAlias.PersonId = Person.Id
//WHERE AccountId = {{ PrimaryProject.Id }} OR AccountId IN (SELECT Id FROM FinancialAccount WHERE ParentAccountId = {{ PrimaryProject.Id }})-- AND Person.RecordTypeValueId = 1-- AND DATEDIFF(yy, FinancialTransaction.TransactionDateTime, GETDATE()) < 10
//GROUP BY Person.Id, CASE
//        WHEN Person.NickName = '' OR Person.NickName IS NULL THEN Person.LastName
//        ELSE Person.LastName+', '+ISNULL(Person.NickName,'')
//     END
//ORDER BY SUM(Amount) DESC

//{% endif %}");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Url Mask
//            //   Attribute Value: /Person/{Id}
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "B9163A35-E09C-466D-8A2D-4ED81DF0114C", @"/Person/{Id}");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Columns
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "202A82BF-7772-481C-8419-600012607972", @"False");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Update Page
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "230EDFE8-33CA-478D-8C9A-572323AF3466", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Query Params
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "B0EC41B9-37C0-48FD-8E4E-37A8CA305012", @"");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Columns
//            //   Attribute Value: Id
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "90B0E6AF-B2F4-4397-953B-737A40D4023B", @"Id");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Person Report
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "8104CE53-FDB3-4E9F-B8E7-FD9E06E7551C", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Merge Fields
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "8EB882CE-5BB1-4844-9C28-10190903EECD", @"");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Merge Template
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "6697B0A2-C8FE-497A-B5B4-A9D459474338", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Formatted Output
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "6A233402-446C-47E9-94A5-6A247C29BC21", @"");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Paneled Grid
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "5449CB61-2DFC-4B55-A697-38F1C2AF128B", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Communication Recipient Person Id Columns
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "75DDB977-9E71-44E8-924B-27134659D3A4", @"");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Excel Export
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "E11B57E5-EC7D-4C42-9ADA-37594D71F145", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Communicate
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "5B2C115A-C187-4AB3-93AE-7010644B39DA", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Merge Person
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "8762ABE3-726E-4629-BD4D-3E42E1FBCC9E", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Bulk Update
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "D01510AA-1B8D-467C-AFC6-F7554CB7CF78", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Stored Procedure
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "A4439703-5432-489A-9C14-155903D6A43E", @"False");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Show Grid Filter
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "E582FD3C-9990-47D1-A57F-A3DB753B1D0C", @"True");


//            // Add Block Attribute Value
//            //   Block: Dynamic Data
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Donors, Site=Rock RMS
//            //   Attribute: Timeout
//            //   Attribute Value: 30
//            RockMigrationHelper.AddBlockAttributeValue("15EDACF7-9EF1-42A5-9677-FF270BC74F5E", "BEEE38DD-2791-4242-84B6-0495904143CC", @"30");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Group Picker Type
//            //   Attribute Value: Dropdown
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "77307E9F-CE10-4285-A0A5-418D324A4576", @"Dropdown");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: core.EnableDefaultWorkflowLauncher
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "D7AE5225-28BF-4954-9D04-782AC76CBF4E", @"True");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Allow Add
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FD470B89-C053-411E-BB22-C064E2C15E43", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Entity Type
//            //   Attribute Value: 72657ed8-d16e-492e-ac12-144c5e7567e7
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "A32C7EFE-2E5F-4E99-9867-DD562407B72E", @"72657ed8-d16e-492e-ac12-144c5e7567e7");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Include Group Types
//            //   Attribute Value: be7a89fa-4815-4258-a9c6-c08c058ee933
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "5164FF88-A53B-4982-BE50-D56F1FE13FC6", @"be7a89fa-4815-4258-a9c6-c08c058ee933");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Filter
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "7E0EDF09-9374-4AC4-8591-30C08D7F1E1F", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Group Type Column
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "951D268A-B2A8-42A2-B1C1-3B854070DDF9", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Description Column
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "A0E1B2A4-9D86-4F57-B608-FC7CC498EAC3", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display System Column
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "766A4BFA-D2D1-4744-B30D-637A7E3B9D8F", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Security Column
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "2DDD4FD0-5E03-4271-B8EF-728DECA10018", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Active Status Column
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FCB5F8B3-9C0E-46A8-974A-15353447FCD7", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Set Panel Title
//            //   Attribute Value: Churches
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "E861BE97-59F3-4A9C-8F9E-8F45798DF26C", @"Churches");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Member Count Column
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FDD84597-E3E8-4E91-A72F-C6538B085310", @"True");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Limit to Active Status
//            //   Attribute Value: all
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "B4133552-42B6-4053-90B9-33B882B72D2D", @"all");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Limit to Security Role Groups
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "1DAD66E3-8859-487E-8200-483C98DE2E07", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Display Group Path
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "6F229535-B44E-44C2-A9AF-28244600E244", @"False");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: Detail Page
//            //   Attribute Value: 75c9536a-c984-48ab-b7d4-e036c0ad59a1
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "8E57EC42-ABEE-4D35-B7FA-D8513880E8E4", @"75c9536a-c984-48ab-b7d4-e036c0ad59a1");


//            // Add Block Attribute Value
//            //   Block: Group List
//            //   BlockType: Group List
//            //   Block Location: Page=Churches, Site=Rock RMS
//            //   Attribute: core.CustomGridEnableStickyHeaders
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("2EFF9D23-1670-43EA-B484-FD9B0545B33A", "FB20EF5B-95DC-4EEE-8FEC-870D9EE59043", @"False");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Query Params
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "B0EC41B9-37C0-48FD-8E4E-37A8CA305012", @"");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Query
//            //   Attribute Value: {% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//            {% if PrimaryProject != empty %}

//            SELECT
//   FA.[Id]

//   , FA.[GlCode] AccountCode
//   , FA.[PublicDescription] AccountName
//   , FORMAT(ISNULL(BA.Balance, 0), 'C') Balance
//   FROM[FinancialAccount] FA

//    WITH(NOLOCK)
//LEFT JOIN
//(
//   SELECT
//     FA.[Id]

//    , SUM(FT.[Amount]) Balance
//  FROM[FinancialAccount] FA

//    WITH (NOLOCK)
//  LEFT JOIN[AnalyticsSourceFinancialTransaction] FT

//    WITH (NOLOCK)
//    ON FA.[Id] = FT.[AccountId]
// WHERE FA.[Id] = { { PrimaryProject.Id } }
//            OR FA.[Id] IN(SELECT Id FROM[FinancialAccount] WHERE ParentAccountId = { { PrimaryProject.Id } })
//  GROUP BY  FA.[Id]
// ) BA
// ON FA.[Id] = BA.[Id]
// WHERE FA.[Id] = { { PrimaryProject.Id } }
//            OR FA.[Id] IN(SELECT Id FROM[FinancialAccount] WHERE ParentAccountId = { { PrimaryProject.Id } })
// ORDER BY GlCode

//{% endif %}
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "71C8BA4E-8EF2-416B-BFE9-D1D88D9AA356", @"{% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//{% if PrimaryProject != empty %}

// SELECT
//    FA.[Id]
//	,FA.[GlCode] AccountCode
//	,FA.[PublicDescription] AccountName
//	,FORMAT(ISNULL(BA.Balance,0),'C') Balance
// FROM [FinancialAccount] FA
//	WITH (NOLOCK)
//LEFT JOIN
//(
//   SELECT
//	 FA.[Id]
//	,SUM(FT.[Amount]) Balance
//  FROM [FinancialAccount] FA
//	WITH (NOLOCK)
//  LEFT JOIN [AnalyticsSourceFinancialTransaction] FT
//	WITH (NOLOCK)
//	ON FA.[Id] =  FT.[AccountId]
// WHERE  FA.[Id] = {{ PrimaryProject.Id }} OR FA.[Id] IN (SELECT Id FROM [FinancialAccount] WHERE ParentAccountId = {{ PrimaryProject.Id }})
//  GROUP BY  FA.[Id]
// ) BA
// ON FA.[Id] = BA.[Id]
// WHERE FA.[Id] = {{ PrimaryProject.Id }} OR FA.[Id] IN (SELECT Id FROM [FinancialAccount] WHERE ParentAccountId = {{ PrimaryProject.Id }})
// ORDER BY GlCode

//{% endif %}");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Columns
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "202A82BF-7772-481C-8419-600012607972", @"False");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Url Mask
//            //   Attribute Value: /page/190?AccountId={Id}
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "B9163A35-E09C-466D-8A2D-4ED81DF0114C", @"/page/190?AccountId={Id}");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Columns
//            //   Attribute Value: Id
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "90B0E6AF-B2F4-4397-953B-737A40D4023B", @"Id");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Update Page
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "230EDFE8-33CA-478D-8C9A-572323AF3466", @"True");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Excel Export
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "E11B57E5-EC7D-4C42-9ADA-37594D71F145", @"True");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Bulk Update
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "D01510AA-1B8D-467C-AFC6-F7554CB7CF78", @"False");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Formatted Output
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "6A233402-446C-47E9-94A5-6A247C29BC21", @"");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Person Report
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "8104CE53-FDB3-4E9F-B8E7-FD9E06E7551C", @"False");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Communication Recipient Person Id Columns
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "75DDB977-9E71-44E8-924B-27134659D3A4", @"");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Merge Fields
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "8EB882CE-5BB1-4844-9C28-10190903EECD", @"");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Grid Filter
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "E582FD3C-9990-47D1-A57F-A3DB753B1D0C", @"True");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Timeout
//            //   Attribute Value: 30
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "BEEE38DD-2791-4242-84B6-0495904143CC", @"30");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Stored Procedure
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "A4439703-5432-489A-9C14-155903D6A43E", @"False");


//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Merge Person
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "8762ABE3-726E-4629-BD4D-3E42E1FBCC9E", @"False");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Communicate
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "5B2C115A-C187-4AB3-93AE-7010644B39DA", @"False");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Paneled Grid
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "5449CB61-2DFC-4B55-A697-38F1C2AF128B", @"True");

//            // Add Block Attribute Value
//            //   Block: Balances
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Merge Template
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("CBC740ED-121D-4A2C-94C9-3A2846EEE9A9", "6697B0A2-C8FE-497A-B5B4-A9D459474338", @"False");


//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Paneled Grid
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "5449CB61-2DFC-4B55-A697-38F1C2AF128B", @"False");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Bulk Update
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "D01510AA-1B8D-467C-AFC6-F7554CB7CF78", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Merge Person
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "8762ABE3-726E-4629-BD4D-3E42E1FBCC9E", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Stored Procedure
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "A4439703-5432-489A-9C14-155903D6A43E", @"False");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Timeout
//            //   Attribute Value: 60
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "BEEE38DD-2791-4242-84B6-0495904143CC", @"60");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Formatted Output
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "6A233402-446C-47E9-94A5-6A247C29BC21", @"");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Grid Filter
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "E582FD3C-9990-47D1-A57F-A3DB753B1D0C", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Person Report
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "8104CE53-FDB3-4E9F-B8E7-FD9E06E7551C", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Communication Recipient Person Id Columns
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "75DDB977-9E71-44E8-924B-27134659D3A4", @"");


//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Merge Template
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "6697B0A2-C8FE-497A-B5B4-A9D459474338", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Excel Export
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "E11B57E5-EC7D-4C42-9ADA-37594D71F145", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Communicate
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "5B2C115A-C187-4AB3-93AE-7010644B39DA", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Merge Fields
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "8EB882CE-5BB1-4844-9C28-10190903EECD", @"");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Columns
//            //   Attribute Value: PersonId
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "90B0E6AF-B2F4-4397-953B-737A40D4023B", @"PersonId");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Query
//            //   Attribute Value: {% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//            {% if PrimaryProject != empty %}

//            SELECT TOP 10

//    PA.[PersonId]
//	,FA.[GlCode] AccountCode
//	,FA.[Description] AccountName
//	,FORMAT(AFT.[TransactionDateTime], 'MM/dd/yyyy') Date
//	,FORMAT(AFT.[Amount], 'C') Amount
//	,REPLACE(LTRIM(LTRIM(ISNULL(P.[NickName], '') + ' ' +
//    ISNULL(P.[MiddleName], '') + ' ' +
//    ISNULL(P.[LastName], ''))), '  ', ' ') DonorName
//   --  ,FTD.[Summary] DonationComment
//   FROM[AnalyticsSourceFinancialTransaction] AFT

//    WITH(NOLOCK)
//INNER JOIN[PersonAlias] PA

//    WITH(NOLOCK)
//ON AFT.[AuthorizedPersonAliasId] = PA.[Id]
//INNER JOIN[Person] P
//    WITH(NOLOCK)
//ON PA.[PersonId] = P.[Id]
//INNER JOIN[FinancialAccount] FA
//    WITH(NOLOCK)
//ON AFT.[AccountId] = FA.[Id]
//--LEFT JOIN[FinancialTransactionDetail] FTD
//--  WITH(NOLOCK)
//--ON AFT.[TransactionDetailId] = FTD.[Id]
//WHERE FA.[Id] = { { PrimaryProject.Id } }
//            OR FA.[Id] IN(SELECT Id FROM[FinancialAccount] WHERE ParentAccountId = { { PrimaryProject.Id } })
//ORDER BY AFT.[TransactionDateTime] DESC

//{% endif %}
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "71C8BA4E-8EF2-416B-BFE9-D1D88D9AA356", @"{% assign PrimaryProject = PageParameter['PersonId'] | PersonById | Attribute:'PrimaryAccount','Object' %}

//{% if PrimaryProject != empty %}

//SELECT TOP 10
//	PA.[PersonId]
//	,FA.[GlCode] AccountCode
//	,FA.[Description] AccountName
//	,FORMAT(AFT.[TransactionDateTime],'MM/dd/yyyy') Date
//	,FORMAT(AFT.[Amount],'C') Amount
//	,REPLACE(LTRIM(LTRIM(ISNULL(P.[NickName],'')+' '+
//    ISNULL(P.[MiddleName],'')+' '+
//    ISNULL(P.[LastName],''))),'  ',' ') DonorName
//--	,FTD.[Summary] DonationComment
//FROM [AnalyticsSourceFinancialTransaction] AFT
//	WITH (NOLOCK)
//INNER JOIN [PersonAlias] PA
//	WITH (NOLOCK)
//ON AFT.[AuthorizedPersonAliasId] = PA.[Id]
//INNER JOIN [Person] P
//	WITH (NOLOCK)
//ON PA.[PersonId] = P.[Id]
//INNER JOIN [FinancialAccount] FA
//	WITH (NOLOCK)
//ON AFT.[AccountId] = FA.[Id]
//--LEFT JOIN [FinancialTransactionDetail] FTD
//--	WITH (NOLOCK)
//--ON AFT.[TransactionDetailId] = FTD.[Id]
//WHERE FA.[Id] = {{ PrimaryProject.Id }} OR FA.[Id] IN (SELECT Id FROM [FinancialAccount] WHERE ParentAccountId = {{ PrimaryProject.Id }})
//ORDER BY AFT.[TransactionDateTime] DESC

//{% endif %}");


//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Url Mask
//            //   Attribute Value: /Person/{PersonId}
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "B9163A35-E09C-466D-8A2D-4ED81DF0114C", @"/Person/{PersonId}");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Show Columns
//            //   Attribute Value: False
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "202A82BF-7772-481C-8419-600012607972", @"False");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Update Page
//            //   Attribute Value: True
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "230EDFE8-33CA-478D-8C9A-572323AF3466", @"True");

//            // Add Block Attribute Value
//            //   Block: Transactions
//            //   BlockType: Dynamic Data
//            //   Block Location: Page=Financials, Site=Rock RMS
//            //   Attribute: Query Params
//            //   Attribute Value: 
//            RockMigrationHelper.AddBlockAttributeValue("446C1D84-2441-47CD-B619-42BCF9D28AC1", "B0EC41B9-37C0-48FD-8E4E-37A8CA305012", @"");


//            // Add/Update PageContext for Page:Church Details, Entity: Rock.Model.Person, Parameter: ChurchId
//            RockMigrationHelper.UpdatePageContext("75C9536A-C984-48AB-B7D4-E036C0AD59A1", "Rock.Model.Person", "ChurchId", "9696E6C1-D947-4357-8964-CE8934A200F8");


//            // Add/Update PageContext for Page:Churches, Entity: Rock.Model.Person, Parameter: PersonId
//            RockMigrationHelper.UpdatePageContext("E87CC2CE-A744-4311-A54A-C62CD7470B91", "Rock.Model.Person", "PersonId", "F11FB50B-0EDA-4264-B9D5-1871459E70D3");


//            // Add/Update PageContext for Page:Donors, Entity: Rock.Model.Person, Parameter: PersonId
//            RockMigrationHelper.UpdatePageContext("E584115C-9C37-4CCC-B696-8DE23A14C9EC", "Rock.Model.Person", "PersonId", "C9EC0B53-8C41-4222-B40A-F9C5C63C9701");

//        }

//        public override void Down()
//        {
//        }
//    }
//}