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
    [MigrationNumber(17, "1.12.0")]
    class Interactions : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddSecurityRoleGroup("MSO - Interaction Worker", "People who can view all interactions", SystemGuid.Group.GROUP_INTERACTION_WORKER);

            RockMigrationHelper.UpdateFieldType("ABWE Person And Family", "", "org.abwe.RockMissions", "org.abwe.RockMissions.Field.Types.ABWEPersonAndFamilyFieldType", SystemGuid.FieldType.FIELD_TYPE_PERSON_AND_FAMILY);
            RockMigrationHelper.UpdateFieldType("Interaction Channel Components", "", "org.abwe.RockMissions", "org.abwe.RockMissions.Field.Types.InteractionChannelComponentsFieldType", SystemGuid.FieldType.FIELD_TYPE_INTERACTION_CHANNEL_COMPONENTS);

            // Add new "Contacts" interaction channel and one "General" component
            Sql(@"
                INSERT INTO [dbo].[InteractionChannel]
                       ([Name]
                       ,[InteractionEntityTypeId]
                       ,[ChannelTypeMediumValueId]
                       ,[CreatedDateTime]
                       ,[ModifiedDateTime]
                       ,[Guid]
                       ,[IsActive])
                 VALUES
                       ('Contacts'
                       ,15
                       ,669
                       ,GETDATE()
                       ,GETDATE()
                       ,'D1853AE1-145F-4AE1-84CF-E7F62024B121'
                       ,1)

            INSERT INTO [dbo].InteractionComponent
	            ([Name]
	            ,InteractionChannelId
	            ,[CreatedDateTime]
	            ,[ModifiedDateTime]
	            ,[Guid])
	            VALUES (
	            'General'
	            ,(SELECT [Id] FROM [InteractionChannel] WHERE [Guid] = 'D1853AE1-145F-4AE1-84CF-E7F62024B121')
	            ,GETDATE()
	            ,GETDATE()
	            ,'41D3B3BC-E03C-4282-871A-0FC87AD12982')
            ");

            // Add category for interactions
            RockMigrationHelper.UpdateCategory("3BB4B095-2DE4-4009-8FA2-705BF284F7B7", "General", "", "General interactions", "463e4941-c87d-4dda-b296-a4d799f438e7");
            RockMigrationHelper.UpdateCategory("3BB4B095-2DE4-4009-8FA2-705BF284F7B7", "Bereavement", "", "An interaction on the occasion of bereavement", Guid.NewGuid().ToString());
            RockMigrationHelper.UpdateCategory("3BB4B095-2DE4-4009-8FA2-705BF284F7B7", "Thanks", "", "An interaction on the occasion of thanksgiving", Guid.NewGuid().ToString());


            // Add Page Interactions to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "BF04BB7E-BE3A-4A38-A37C-386B55496303", "F66758C6-3E3D-4598-AF4C-B317047B5987", "Interactions", "", "1AB75D63-412C-4732-B34F-AE821804F952", "", "1C737278-4CBA-404B-B6B3-E3F0E05AB5FE");


            // Add Page Route for Interactions
            RockMigrationHelper.AddPageRoute("1AB75D63-412C-4732-B34F-AE821804F952", "Person/{PersonId}/Interactions", "18B3665E-76EA-4F6C-8AFA-A98602386C64");

            // Add Block Dynamic Data to Page: Interactions, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "1AB75D63-412C-4732-B34F-AE821804F952".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "E31E02E9-73F6-4B3E-98BA-E0E4F86CA126".AsGuid(), "Dynamic Data", "SectionC1", @"", @"", 0, "9E3DADC0-7FBC-4FBC-8F22-351242BD922A");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Enabled Lava Commands
            //   Attribute Value: RockEntity
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "824634D6-7F75-465B-A2D2-BA3CE1662CAC", @"RockEntity");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Formatted Output
            //   Attribute Value: 
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "6A233402-446C-47E9-94A5-6A247C29BC21", @"");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Merge Fields
            //   Attribute Value: 
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "8EB882CE-5BB1-4844-9C28-10190903EECD", @"");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Person Report
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "8104CE53-FDB3-4E9F-B8E7-FD9E06E7551C", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Communication Recipient Person Id Columns
            //   Attribute Value: 
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "75DDB977-9E71-44E8-924B-27134659D3A4", @"");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Excel Export
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "E11B57E5-EC7D-4C42-9ADA-37594D71F145", @"True");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Communicate
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "5B2C115A-C187-4AB3-93AE-7010644B39DA", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Bulk Update
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "D01510AA-1B8D-467C-AFC6-F7554CB7CF78", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Merge Person
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "8762ABE3-726E-4629-BD4D-3E42E1FBCC9E", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Stored Procedure
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "A4439703-5432-489A-9C14-155903D6A43E", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Merge Template
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "6697B0A2-C8FE-497A-B5B4-A9D459474338", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Paneled Grid
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "5449CB61-2DFC-4B55-A697-38F1C2AF128B", @"False");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Show Grid Filter
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "E582FD3C-9990-47D1-A57F-A3DB753B1D0C", @"True");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Timeout
            //   Attribute Value: 30
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "BEEE38DD-2791-4242-84B6-0495904143CC", @"30");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Update Page
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "230EDFE8-33CA-478D-8C9A-572323AF3466", @"True");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Query Params
            //   Attribute Value: 
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "B0EC41B9-37C0-48FD-8E4E-37A8CA305012", @"");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Columns
            //   Attribute Value: 
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "90B0E6AF-B2F4-4397-953B-737A40D4023B", @"");


            // Add Block Attribute Value
            //   Block: Dynamic Data
            //   BlockType: Dynamic Data
            //   Block Location: Page=Interactions, Site=Rock RMS
            //   Attribute: Query
            //   Attribute Value:     Template
            RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A","71C8BA4E-8EF2-416B-BFE9-D1D88D9AA356", @"{% interactionchannel where:'Guid == ""D1853AE1-145F-4AE1-84CF-E7F62024B121""' %}
                {% assign interactionchannel = interactionchannelItems | First %}
                {% endinteractionchannel %}


                {% interactioncomponent where:'InteractionChannelId == {{interactionchannel.Id}}' %}
                {% assign ids = interactioncomponentItems | Select:'Id' %}
                {% endinteractioncomponent %}

                {% assign person = PageParameter:'PersonId' | PersonById %}

                SELECT
                    [InteractionDateTime] [Date]
                    ,[Operation] [Type]
                    ,[InteractionSummary] [Summary]
                    ,[InteractionComponent].Name [Department]
                    ,ISNULL([Category].[Name], '') [Category]
                    ,[Person].NickName + ' ' + Person.LastName [By]
                FROM [Interaction]
                LEFT JOIN [InteractionComponent] ON [Interaction].InteractionComponentId = [InteractionComponent].Id
                INNER JOIN [PersonAlias] ON [PersonAlias].Id = [PersonAliasId]
                INNER JOIN [Person] ON [Person].Id = [PersonAlias].[PersonId]
                LEFT JOIN [Category] ON [Category].Id = [Interaction].[ChannelCustomIndexed1]
                WHERE
                    (
                        InteractionComponentId IN ({{ ids | Join:',' }}) OR
                        [Interaction].[Id] IN (SELECT [Id] FROM [Interaction] WHERE InteractionComponentId IN ({{ ids | Join:',' }}) AND RelatedEntityTypeId = 576 )
                    )
                    AND Interaction.EntityId IN ({{ person.Aliases | Select:'Id' | Join:','}})
                    AND Interaction.Operation IS NOT NULL
                ORDER BY InteractionDateTime DESC");


                // Add Block Attribute Value
                //   Block: Dynamic Data
                //   BlockType: Dynamic Data
                //   Block Location: Page=Interactions, Site=Rock RMS
                //   Attribute: Url Mask
                //   Attribute Value: 
                RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A","B9163A35-E09C-466D-8A2D-4ED81DF0114C",@"");


                // Add Block Attribute Value
                //   Block: Dynamic Data
                //   BlockType: Dynamic Data
                //   Block Location: Page=Interactions, Site=Rock RMS
                //   Attribute: Show Columns
                //   Attribute Value: False
                RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A","202A82BF-7772-481C-8419-600012607972",@"False");



            /*
             * 
             * Workflows
             * 
             */

            // Add Block Attribute Value
            //   Block: Data View Results
            //   BlockType: Data View Results
            //   Block Location: Page=Data Views, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("59B70442-91A8-4538-9508-14F596C3798E", "2B48781D-C7D0-46EC-8FB2-B7FAF76C0571", @"False");


            // Add Block Attribute Value
            //   Block: Group Member List
            //   BlockType: Group Member List
            //   Block Location: Page=Group Viewer, Site=Rock RMS
            //   Attribute: core.CustomGridEnableStickyHeaders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("BA0F3E7D-1C3A-47CB-9058-893DBAA35B89", "D6685CD4-023A-4B0C-A569-E4C6711D7400", @"False");

            #region Categories

            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Missions", "", "", "D3EA0403-2070-4833-8384-E11F21594900", 0); // Missions

            #endregion

            #region Log an Interaction

            RockMigrationHelper.UpdateWorkflowType(false, true, "Log an Interaction", "", "D3EA0403-2070-4833-8384-E11F21594900", "Interaction", "fa fa-list-ol", 28800, true, 0, "5C9ADC23-5721-4B80-9336-49D024D42CDA", 0); // Log an Interaction
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "D12E0CD4-4123-4425-9061-2DBC831B3756", "Person and Family", "PersonandFamily", "", 0, @"", "24CB1492-6A9E-4C2F-B765-FCA93DC6A9C5", false); // Log an Interaction:Person and Family
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Completed By", "CompletedBy", "", 1, @"", "50F2598B-4FA8-4FD6-8682-4B5AB0EA4FBD", false); // Log an Interaction:Completed By
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "6B6AA175-4758-453F-8D83-FCD8044B5F36", "Completed On", "CompletedOn", "", 2, @"", "8172E8FA-237F-426C-8FBC-CF37680F1637", false); // Log an Interaction:Completed On
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Type", "Type", "", 3, @"", "642A18BC-F025-45AB-8750-08F40C47611E", false); // Log an Interaction:Type
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Summary", "Summary", "", 4, @"", "703AA0F9-0D66-4832-A39D-C8A2E3C357FD", false); // Log an Interaction:Summary
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Communication Body (optional)", "EmailBodyifany", "", 5, @"", "E590AE76-08B0-4E08-BDE4-E07ECF787A19", false); // Log an Interaction:Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "AC0C8C60-1392-4870-A2D9-EABE17541940", "Visible To", "VisibleTo", "", 6, @"41d3b3bc-e03c-4282-871a-0fc87ad12982", "43C176A0-AEB8-4B45-BB71-07997FCC7813", true); // Log an Interaction:Visible To
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "309460EF-0CC5-41C6-9161-B3837BA3D374", "Category", "Category", "", 7, @"463e4941-c87d-4dda-b296-a4d799f438e7", "37685DC9-0738-465F-8B00-817E0DD55EF2", false); // Log an Interaction:Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Source", "Source", "", 8, @"", "CFCED480-6D74-42A0-A103-C810AEB5D91E", false); // Log an Interaction:Source
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Medium", "Medium", "", 9, @"", "52F3C1F6-5041-451A-8F30-765FF057B730", false); // Log an Interaction:Medium
            RockMigrationHelper.UpdateWorkflowTypeAttribute("5C9ADC23-5721-4B80-9336-49D024D42CDA", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Campaign", "Campaign", "", 10, @"", "DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", false); // Log an Interaction:Campaign
            RockMigrationHelper.AddAttributeQualifier("24CB1492-6A9E-4C2F-B765-FCA93DC6A9C5", "EnableSelfSelection", @"False", "2FE39A0C-87FD-44B7-AB33-A1A08B0531A3"); // Log an Interaction:Person and Family:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("50F2598B-4FA8-4FD6-8682-4B5AB0EA4FBD", "EnableSelfSelection", @"True", "F5480BAB-B405-445B-95EB-6EF4BBB82644"); // Log an Interaction:Completed By:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "datePickerControlType", @"Date Picker", "E0731993-B7CF-441A-9F3A-FB1059744545"); // Log an Interaction:Completed On:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "displayCurrentOption", @"False", "22A67088-2410-4993-A189-FB78FB3EFE8F"); // Log an Interaction:Completed On:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "displayDiff", @"False", "8420725A-5F85-46AF-BED0-F844546F6880"); // Log an Interaction:Completed On:displayDiff
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "format", @"", "A7EE4167-4396-46E2-AAFF-26938AA2D538"); // Log an Interaction:Completed On:format
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "futureYearCount", @"", "7F1A4B35-4FBB-4400-A918-D511890C2503"); // Log an Interaction:Completed On:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "fieldtype", @"ddl", "442ADA29-C783-486E-9066-EECE285D9071"); // Log an Interaction:Type:fieldtype
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "repeatColumns", @"", "A36B72B9-F88A-4893-931B-70FCC1C37C99"); // Log an Interaction:Type:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "values", @"Card,Email,Letter,Meeting,Phone Call,Text", "A6CEBB30-2976-4B85-A89D-14085CBADEE1"); // Log an Interaction:Type:values
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "allowhtml", @"False", "2EA0CB81-BF69-4EAE-8B3B-BB4EF69A44D6"); // Log an Interaction:Summary:allowhtml
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "maxcharacters", @"500", "73CF952C-17AE-4954-BDE7-6C15A1FB31C0"); // Log an Interaction:Summary:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "numberofrows", @"", "E271DA15-2162-4237-A10F-2DA31CA95C19"); // Log an Interaction:Summary:numberofrows
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "showcountdown", @"False", "90496428-DFE8-4B8B-98ED-D6445CF2ABF9"); // Log an Interaction:Summary:showcountdown
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "allowhtml", @"True", "9954680F-410D-4A38-95A7-1545EB789124"); // Log an Interaction:Communication Body (optional):allowhtml
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "maxcharacters", @"", "0E52449E-D05A-4BB5-844B-EF10B36AFB45"); // Log an Interaction:Communication Body (optional):maxcharacters
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "numberofrows", @"10", "7F84802D-1316-46CB-878B-EA1B4A7C982D"); // Log an Interaction:Communication Body (optional):numberofrows
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "showcountdown", @"False", "D18BEC0F-7319-4456-AC78-4BFD764DA4DB"); // Log an Interaction:Communication Body (optional):showcountdown
            RockMigrationHelper.AddAttributeQualifier("43C176A0-AEB8-4B45-BB71-07997FCC7813", "interactionChannel", SqlScalar("SELECT [Id] FROM InteractionChannel WHERE [Guid] = 'D1853AE1-145F-4AE1-84CF-E7F62024B121'").ToString(), "358B1BDF-3B8D-4772-8550-CC49235D7B41"); // Log an Interaction:Visible To:interactionChannel
            RockMigrationHelper.AddAttributeQualifier("43C176A0-AEB8-4B45-BB71-07997FCC7813", "repeatColumns", @"", "7D4609F6-FF19-4874-B84F-400749E420C9"); // Log an Interaction:Visible To:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "entityTypeName", @"Rock.Model.Interaction", "5D5D1FC4-3753-4C7F-9B4F-4D853BCD69AF"); // Log an Interaction:Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "qualifierColumn", @"", "09482210-941B-4539-8E30-6006776B6FEA"); // Log an Interaction:Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "qualifierValue", @"", "E8F11519-E7AA-4090-B9F7-79A6C9C03DC7"); // Log an Interaction:Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "ispassword", @"False", "85FF9500-E6BB-4302-968F-E57B1FBF6CA3"); // Log an Interaction:Source:ispassword
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "maxcharacters", @"", "B597EAE4-EB0D-42E6-8256-78A564E911AC"); // Log an Interaction:Source:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "showcountdown", @"False", "CBDFC046-6C3B-4E22-804B-8255950B2E1B"); // Log an Interaction:Source:showcountdown
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "ispassword", @"False", "8DBD697F-D29D-4A0E-9DB1-54EB354BF076"); // Log an Interaction:Medium:ispassword
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "maxcharacters", @"", "4D655CF3-0058-445B-B6DF-C1CBF3940F59"); // Log an Interaction:Medium:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "showcountdown", @"False", "442E7E83-5CAF-4332-A78D-1C03D38F6050"); // Log an Interaction:Medium:showcountdown
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "ispassword", @"False", "3BBEE81D-82FA-430B-B164-5DBBA1A6C372"); // Log an Interaction:Campaign:ispassword
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "maxcharacters", @"", "EF9E6C27-DF3E-4407-AFF3-4CBFD73B1C9F"); // Log an Interaction:Campaign:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "showcountdown", @"False", "B956953B-3ED7-433F-8E2D-A6895AD0D9F6"); // Log an Interaction:Campaign:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("5C9ADC23-5721-4B80-9336-49D024D42CDA", true, "Start", "", true, 0, "9982A30F-3557-4475-B955-E3C7B473CC4E"); // Log an Interaction:Start
            RockMigrationHelper.UpdateWorkflowActionForm(@"<style>
                @media (max-width: 728px) {
                    .actions .btn {
                        display: block;
                        margin-top: 5px;
                    }
                }
    
                .collapser {
                    color: black;
                    display: block;
                }
                .collapser:hover, .collapser:focus {
                    color: black;
                }
                .collapser i {
                    margin-right: 10px;
                }
                .collapser.collapsed i {
                    transform: rotate(-90deg);
                }
                .collapse+*:not(.collapser) {
                    margin-top: 15px;
                }
            </style>", @"<div style=""height: 15px;""></div>
            <script>
                function updateText(el) {
                    $(el).children('span').text($.map($(el).next().find(""input:checked+.label-text,.picker-label""), function (element) { return $(element).text() }).join("", ""));
                }
    
                $('.collapser').each(function () {
                    updateText(this);
                });

                $('.collapser+.collapse').find('input[type=""checkbox""]').on('click',function() { updateText($(this).parents('.collapse').prev()); });
            </script>", "Save^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|+ Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^^|+ Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^^|", "", true, "", "36E7D928-887A-4E4E-A50A-6EC51B615FD7"); // Log an Interaction:Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "24CB1492-6A9E-4C2F-B765-FCA93DC6A9C5", 0, true, false, true, false, @"", @"", "6A384C47-88AD-4ED0-A802-CCCE671A10CC"); // Log an Interaction:Start:Gather Input:Person and Family
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "50F2598B-4FA8-4FD6-8682-4B5AB0EA4FBD", 1, true, false, true, false, @"", @"", "3AADD745-C3D8-41A6-87CE-BF1F0DF73E68"); // Log an Interaction:Start:Gather Input:Completed By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "8172E8FA-237F-426C-8FBC-CF37680F1637", 3, true, false, true, false, @"", @"", "5AD443E2-CB3E-4EE2-B395-74EE7B18CF78"); // Log an Interaction:Start:Gather Input:Completed On
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "642A18BC-F025-45AB-8750-08F40C47611E", 4, true, false, true, false, @"", @"", "8F693D4E-8F58-4FA8-9C2B-96128BFC58C7"); // Log an Interaction:Start:Gather Input:Type
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "703AA0F9-0D66-4832-A39D-C8A2E3C357FD", 5, true, false, true, false, @"", @"", "70DBEFE8-EEE5-448C-B6F2-CA5B2B98E4EF"); // Log an Interaction:Start:Gather Input:Summary
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "E590AE76-08B0-4E08-BDE4-E07ECF787A19", 7, true, false, false, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseBody""><i class=""fa fa-caret-down""></i>Communication Body</a>
<div class=""collapse"" id=""collapseBody"">", @"</div>", "AB8A4244-9D86-4A48-852D-FA757CAF3892"); // Log an Interaction:Start:Gather Input:Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "43C176A0-AEB8-4B45-BB71-07997FCC7813", 2, true, false, true, false, @"<!--<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseDepartments""><i class=""fa fa-caret-down""></i>Visible To: <span>All Departments</span></a>
<div class=""collapse"" id=""collapseDepartments"">-->", @"<!--</div>-->", "F38A23EF-B89C-45B0-BEA0-3617EA26F325"); // Log an Interaction:Start:Gather Input:Visible To
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "37685DC9-0738-465F-8B00-817E0DD55EF2", 6, true, false, true, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseCategories""><i class=""fa fa-caret-down""></i>Category: <span>General</span></a>
<div class=""collapse"" id=""collapseCategories"">", @"</div>", "F75DBB3B-2B84-4F7B-9A86-D23B75208812"); // Log an Interaction:Start:Gather Input:Category
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "CFCED480-6D74-42A0-A103-C810AEB5D91E", 8, true, false, false, false, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseSourceCode""><i class=""fa fa-caret-down""></i>UTM</a>
<div class=""collapse"" id=""collapseSourceCode"">", @"", "CEAC847E-AEC2-447C-9BE3-0AC2AD010482"); // Log an Interaction:Start:Gather Input:Source
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "52F3C1F6-5041-451A-8F30-765FF057B730", 9, true, false, false, false, @"", @"", "C3D5E1F8-FCFA-438F-9494-6FF6BBF89276"); // Log an Interaction:Start:Gather Input:Medium
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", 10, true, false, false, false, @"", @"</div>", "67CD55DF-B0FF-4CCE-984C-DB46BE4E0A77"); // Log an Interaction:Start:Gather Input:Campaign
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Set Current Person", 0, "24B7D5E6-C30F-48F4-9D7E-AF45A342CF3A", true, false, "", "", 1, "", "E4574E42-9453-43AA-BD83-30529E6075E2"); // Log an Interaction:Start:Set Current Person
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Set Person", 1, "972F19B9-598B-474B-97A4-50E56E7B59D2", true, false, "", "", 1, "", "FD1128AF-3E57-445A-A801-2CB6FBFDE635"); // Log an Interaction:Start:Set Person
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Set CompletedOn to Current Date", 2, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "99112EBA-0CFE-41CE-B131-795885A1A35D"); // Log an Interaction:Start:Set CompletedOn to Current Date
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Gather Input", 3, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "36E7D928-887A-4E4E-A50A-6EC51B615FD7", "", 1, "", "AE85804B-E2BB-42A9-8674-E2415604A6E6"); // Log an Interaction:Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Log Interactions", 4, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "901782E9-944B-4EE9-BD07-DE816941CC15"); // Log an Interaction:Start:Log Interactions
            RockMigrationHelper.AddActionTypeAttributeValue("E4574E42-9453-43AA-BD83-30529E6075E2", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"50f2598b-4fa8-4fd6-8682-4b5ab0ea4fbd"); // Log an Interaction:Start:Set Current Person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("E4574E42-9453-43AA-BD83-30529E6075E2", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Log an Interaction:Start:Set Current Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "9392E3D7-A28B-4CD8-8B03-5E147B102EF1", @"False"); // Log an Interaction:Start:Set Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "61E6E1BC-E657-4F00-B2E9-769AAA25B9F7", @"24cb1492-6a9e-4c2f-b765-fca93dc6a9c5"); // Log an Interaction:Start:Set Person:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "DDEFB300-0A4F-4086-99BE-A32761928F5E", @"True"); // Log an Interaction:Start:Set Person:Entity Is Required
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "1246C53A-FD92-4E08-ABDE-9A6C37E70C7B", @"False"); // Log an Interaction:Start:Set Person:Use Id instead of Guid
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "00D8331D-3055-4531-B374-6B98A9A71D70", @"{{ Entity.PrimaryAlias.Guid }}"); // Log an Interaction:Start:Set Person:Lava Template
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Log an Interaction:Start:Set CompletedOn to Current Date:Active
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"8172e8fa-237f-426c-8fbc-cf37680f1637"); // Log an Interaction:Start:Set CompletedOn to Current Date:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ 'Now' | Date:'MM/dd/yyyy' }}"); // Log an Interaction:Start:Set CompletedOn to Current Date:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("AE85804B-E2BB-42A9-8674-E2415604A6E6", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Log an Interaction:Start:Gather Input:Active
            RockMigrationHelper.AddActionTypeAttributeValue("901782E9-944B-4EE9-BD07-DE816941CC15", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Log an Interaction:Start:Log Interactions:Active
            RockMigrationHelper.AddActionTypeAttributeValue("901782E9-944B-4EE9-BD07-DE816941CC15", "F3B9908B-096F-460B-8320-122CF046D1F9", @"-- Get list of channels to log interaction to
            DECLARE @componentsToPostIn TABLE (ChannelGuid uniqueidentifier)

            INSERT INTO @componentsToPostIn (ChannelGuid)
            SELECT value [Guid] FROM string_split('{{ Workflow | Attribute:'VisibleTo','RawValue' }}',',')

            -- If general visiblity is checked, only log it to the General component, not others
            DECLARE @GeneralVisibility bit = (SELECT 1 FROM @componentsToPostIn WHERE [ChannelGuid] = '41D3B3BC-E03C-4282-871A-0FC87AD12982')
            IF @GeneralVisibility = 1 DELETE FROM @componentsToPostIn WHERE [ChannelGuid] != '41D3B3BC-E03C-4282-871A-0FC87AD12982';

            DECLARE @FirstResult uniqueidentifier = (SELECT TOP (1) [ChannelGuid] FROM @componentsToPostIn)

            -- Create an interaction session for our bulk insert
            INSERT INTO [InteractionSession] (CreatedDateTime, CreatedByPersonAliasId, [Guid])
            VALUES (GETDATE(), {{ Workflow | Attribute:'CompletedBy','PrimaryAliasId' }}, NEWID())
            DECLARE @SessionId int = SCOPE_IDENTITY()

            -- Log the first components interactions. If we are logging to multiple interaction channel components, log subsequent channel interactions as a link to the first.

            -- For People:
            INSERT INTO [Interaction]
	            (InteractionDateTime
	            ,Operation
	            ,InteractionComponentId
	            ,InteractionSessionId
	            ,EntityId
	            ,PersonAliasId
	            ,InteractionSummary
	            ,InteractionData
	            ,CreatedDateTime
	            ,[Guid]
	            ,[Source]
	            ,[Medium]
	            ,[Campaign]
	            ,[ChannelCustomIndexed1]
	            )
	            SELECT 
		            GETDATE()
		            ,'{{ Workflow | Attribute:'Type' }}'
		            ,(SELECT [Id] FROM InteractionComponent WHERE [Guid] = @FirstResult) [InteractionComponentId]
		            ,@SessionId
		            ,PersonAlias.Id
		            ,{{ Workflow | Attribute:'CompletedBy','PrimaryAliasId' }}
		            ,'{{ Workflow | Attribute:'Summary' | SanitizeSql }}'
		            ,'{{ Workflow | Attribute:'CommunicationBody' | SanitizeSql }}'
		            ,GETDATE()
		            ,NEWID()
		            ,'{{ Workflow | Attribute:'Source' | SanitizeSql }}'
		            ,'{{ Workflow | Attribute:'Medium' | SanitizeSql }}'
		            ,'{{ Workflow | Attribute:'Campaign' | SanitizeSql }}'
		            ,(SELECT [Id] FROM Category WHERE [Guid] = '{{ Workflow | Attribute:'Category','RawValue' }}')
		            FROM [PersonAlias]
		            WHERE [PersonAlias].[Guid] IN STRING_SPLIT('{{ Workflow | Attribute:'PersonandFamily','RawValue' }}', ',')

            -- Also log in other interaction channel components
            IF @GeneralVisibility IS NULL OR @GeneralVisibility != 1
	            INSERT INTO [Interaction]
		            (InteractionDateTime
		            ,InteractionComponentId
		            ,InteractionSessionId
		            ,EntityId
		            ,PersonAliasId
		            ,[RelatedEntityTypeId]
		            ,[RelatedEntityId]
		            ,[Guid]
		            )
	            SELECT
		            InteractionDateTime
		            ,[ChannelComponents].Id
		            ,@SessionId
		            ,Interaction.EntityId
		            ,Interaction.PersonAliasId
		            ,576
		            ,Interaction.Id
		            ,NEWID()
	            FROM [Interaction]
	            CROSS JOIN (SELECT [Id], [Guid] FROM [InteractionComponent] WHERE [Guid] IN (SELECT ChannelGuid FROM @componentsToPostIn)) [ChannelComponents]
	            WHERE [ChannelComponents].[Guid] != @FirstResult AND [Interaction].InteractionSessionId = @SessionId"); // Log an Interaction:Start:Log Interactions:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("901782E9-944B-4EE9-BD07-DE816941CC15", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Log an Interaction:Start:Log Interactions:Continue On Error

            #endregion

            #region DefinedValue AttributeType qualifier helper

            Sql(@"
			UPDATE [aq] SET [key] = 'definedtype', [Value] = CAST( [dt].[Id] as varchar(5) )
			FROM [AttributeQualifier] [aq]
			INNER JOIN [Attribute] [a] ON [a].[Id] = [aq].[AttributeId]
			INNER JOIN [FieldType] [ft] ON [ft].[Id] = [a].[FieldTypeId]
			INNER JOIN [DefinedType] [dt] ON CAST([dt].[guid] AS varchar(50) ) = [aq].[value]
			WHERE [ft].[class] = 'Rock.Field.Types.DefinedValueFieldType'
			AND [aq].[key] = 'definedtypeguid'
		");

            #endregion

            // Bulk Interaction

            #region Categories

            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Missions", "", "", "D3EA0403-2070-4833-8384-E11F21594900", 0); // Missions

            #endregion

            #region Log an Interaction (Bulk)

            RockMigrationHelper.UpdateWorkflowType(false, true, "Log an Interaction (Bulk)", "", "D3EA0403-2070-4833-8384-E11F21594900", "Interaction", "fa fa-list-ol", 28800, true, 0, "592AAE6F-EE1A-4752-A20C-C94D607A4621", 0); // Log an Interaction (Bulk, Updated)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Completed By", "CompletedBy", "", 0, @"", "BA39B511-AB5E-4400-B8F0-E673CEC4E427", false); // Log an Interaction (Bulk, Updated):Completed By
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "6B6AA175-4758-453F-8D83-FCD8044B5F36", "Completed On", "CompletedOn", "", 1, @"", "A2569BEF-456A-4124-B294-8FF4B019D14B", false); // Log an Interaction (Bulk, Updated):Completed On
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Type", "Type", "", 2, @"", "36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", false); // Log an Interaction (Bulk, Updated):Type
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Summary", "Summary", "", 3, @"", "7D0DCC9F-59D7-4EF1-8151-30105082CB4C", false); // Log an Interaction (Bulk, Updated):Summary
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Communication Body (optional)", "EmailBodyifany", "", 4, @"", "E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", false); // Log an Interaction (Bulk, Updated):Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "AC0C8C60-1392-4870-A2D9-EABE17541940", "Visible To", "VisibleTo", "", 5, @"41d3b3bc-e03c-4282-871a-0fc87ad12982", "1A42A499-6EAC-4F0A-B6CF-25B33B84569A", true); // Log an Interaction (Bulk, Updated):Visible To
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "309460EF-0CC5-41C6-9161-B3837BA3D374", "Category", "Category", "", 6, @"463e4941-c87d-4dda-b296-a4d799f438e7", "1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", false); // Log an Interaction (Bulk, Updated):Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Source", "Source", "", 7, @"", "CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", false); // Log an Interaction (Bulk, Updated):Source
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Medium", "Medium", "", 8, @"", "DA76E800-224E-451E-8C5E-154C88AC34BC", false); // Log an Interaction (Bulk, Updated):Medium
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Campaign", "Campaign", "", 9, @"", "C97E98AA-4804-4F53-8259-48F46F985A0D", false); // Log an Interaction (Bulk, Updated):Campaign
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "EntitySetId", "EntitySetId", "", 10, @"", "3812F91C-D9AB-4AA1-B460-4890E4165516", false); // Log an Interaction (Bulk, Updated):EntitySetId
            RockMigrationHelper.AddAttributeQualifier("BA39B511-AB5E-4400-B8F0-E673CEC4E427", "EnableSelfSelection", @"True", "5BF1BD39-6E32-4C5D-BEBC-0EEE57765452"); // Log an Interaction (Bulk, Updated):Completed By:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "datePickerControlType", @"Date Picker", "CD9CE32D-AFEB-473F-B6B5-C828AB90A2CE"); // Log an Interaction (Bulk, Updated):Completed On:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "displayCurrentOption", @"False", "61E97D6B-CE01-4034-A053-0C4D81F881C0"); // Log an Interaction (Bulk, Updated):Completed On:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "displayDiff", @"False", "40BB64BC-5D60-4D74-8F45-FE76378B6A45"); // Log an Interaction (Bulk, Updated):Completed On:displayDiff
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "format", @"", "8B93803B-9F9D-416F-9532-17CD2B8464A4"); // Log an Interaction (Bulk, Updated):Completed On:format
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "futureYearCount", @"", "FAA90798-8928-4091-A0CC-21CEB9B15D10"); // Log an Interaction (Bulk, Updated):Completed On:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "fieldtype", @"ddl", "26F57F9F-9AC3-48CB-886D-0E1E9880BFBD"); // Log an Interaction (Bulk, Updated):Type:fieldtype
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "repeatColumns", @"", "C943CAFF-0D85-4D33-A119-2A5C0B5E06C4"); // Log an Interaction (Bulk, Updated):Type:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "values", @"Phone Call,Email,Text,Meeting,Card", "55D493EA-7A8A-46DB-A0EE-BE707CC3DF2D"); // Log an Interaction (Bulk, Updated):Type:values
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "allowhtml", @"False", "707CBA99-9F68-4D75-A7E7-BBB14DD3430A"); // Log an Interaction (Bulk, Updated):Summary:allowhtml
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "maxcharacters", @"500", "982D09B1-E765-4C10-8FAD-522A84C43103"); // Log an Interaction (Bulk, Updated):Summary:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "numberofrows", @"", "804EDF92-A895-49B8-B158-063B510EDE6B"); // Log an Interaction (Bulk, Updated):Summary:numberofrows
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "showcountdown", @"False", "EDC16D49-1C00-4C4E-8DEE-966DDA8C6C08"); // Log an Interaction (Bulk, Updated):Summary:showcountdown
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "allowhtml", @"True", "F9308F47-0675-4FE1-B777-413EFE2C53AB"); // Log an Interaction (Bulk, Updated):Communication Body (optional):allowhtml
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "maxcharacters", @"", "92F08065-1B27-4C7F-BCB5-1BE73FB15A76"); // Log an Interaction (Bulk, Updated):Communication Body (optional):maxcharacters
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "numberofrows", @"10", "1AFA08E5-B275-4774-926F-45710A20EE40"); // Log an Interaction (Bulk, Updated):Communication Body (optional):numberofrows
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "showcountdown", @"False", "B2BAFD36-A06A-4D25-A502-E531A98BC86A"); // Log an Interaction (Bulk, Updated):Communication Body (optional):showcountdown
            RockMigrationHelper.AddAttributeQualifier("1A42A499-6EAC-4F0A-B6CF-25B33B84569A", "interactionChannel", SqlScalar("SELECT [Id] FROM InteractionChannel WHERE [Guid] = 'D1853AE1-145F-4AE1-84CF-E7F62024B121'").ToString(), "B1F25BFF-8543-4590-BF23-394BE0349830"); // Log an Interaction (Bulk, Updated):Visible To:interactionChannel
            RockMigrationHelper.AddAttributeQualifier("1A42A499-6EAC-4F0A-B6CF-25B33B84569A", "repeatColumns", @"", "18CCA55A-89AF-43D0-959C-A8FB469939FA"); // Log an Interaction (Bulk, Updated):Visible To:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "entityTypeName", @"Rock.Model.Interaction", "D10DF227-4BBA-4625-B22D-F554EBFECAA2"); // Log an Interaction (Bulk, Updated):Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "qualifierColumn", @"", "41CFF221-4E93-46DC-AE5D-AFCC62668075"); // Log an Interaction (Bulk, Updated):Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "qualifierValue", @"", "196A7535-FE28-4710-B136-224EC03FF075"); // Log an Interaction (Bulk, Updated):Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "ispassword", @"False", "6FB0B10A-F4AA-44EF-BCA5-7884817BA851"); // Log an Interaction (Bulk, Updated):Source:ispassword
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "maxcharacters", @"", "BDCB8C7A-3C70-4818-9EDC-F785A0FDE3FE"); // Log an Interaction (Bulk, Updated):Source:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "showcountdown", @"False", "DECA3BBB-F01A-4E3F-AA5C-5D4E5251BDC6"); // Log an Interaction (Bulk, Updated):Source:showcountdown
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "ispassword", @"False", "446B0359-F846-4B9F-9A0D-BD874C0DD1D0"); // Log an Interaction (Bulk, Updated):Medium:ispassword
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "maxcharacters", @"", "30CBB64B-CDFA-40F3-92AB-90282A536719"); // Log an Interaction (Bulk, Updated):Medium:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "showcountdown", @"False", "C1CC51C9-C313-4E46-9015-62E83745CB30"); // Log an Interaction (Bulk, Updated):Medium:showcountdown
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "ispassword", @"False", "270F80C4-F79A-43C8-824D-35514D67E882"); // Log an Interaction (Bulk, Updated):Campaign:ispassword
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "maxcharacters", @"", "2370F1A6-3A5A-4350-B956-FF2F03A20367"); // Log an Interaction (Bulk, Updated):Campaign:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "showcountdown", @"False", "A83AEAB8-B300-4D2E-9370-49F9E4494C63"); // Log an Interaction (Bulk, Updated):Campaign:showcountdown
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "ispassword", @"False", "19178C09-F63A-4210-AA36-947971F50932"); // Log an Interaction (Bulk, Updated):EntitySetId:ispassword
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "maxcharacters", @"", "F67FFA5C-32BF-4FBA-AFB9-DA89F1EF9864"); // Log an Interaction (Bulk, Updated):EntitySetId:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "showcountdown", @"False", "6CDB278B-B291-4F36-BBC8-FF6C18A78DA7"); // Log an Interaction (Bulk, Updated):EntitySetId:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("592AAE6F-EE1A-4752-A20C-C94D607A4621", true, "Start", "", true, 0, "E32D4B55-6E0F-44C6-9182-4577B05FF650"); // Log an Interaction (Bulk, Updated):Start
            RockMigrationHelper.UpdateWorkflowActionForm(@"<style>
    @media (max-width: 728px) {
        .actions .btn {
            display: block;
            margin-top: 5px;
        }
    }
    
    .collapser {
        color: black;
        display: block;
    }
    .collapser:hover, .collapser:focus {
        color: black;
    }
    .collapser i {
        margin-right: 10px;
    }
    .collapser.collapsed i {
        transform: rotate(-90deg);
    }
    .collapse+*:not(.collapser) {
        margin-top: 15px;
    }
</style>", @"<div style=""height: 15px;""></div>
<script>
    function updateText(el) {
        $(el).children('span').text($.map($(el).next().find(""input:checked+.label-text,.picker-label""), function (element) { return $(element).text() }).join("", ""));
    }
    
    $('.collapser').each(function () {
        updateText(this);
    });

    $('.collapser+.collapse').find('input[type=""checkbox""]').on('click',function() { updateText($(this).parents('.collapse').prev()); });
</script>", "Save^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|+ Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^^|+ Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^^", "", true, "", "46E336DD-8A8F-4403-A496-03438C709AB7"); // Log an Interaction (Bulk, Updated):Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "BA39B511-AB5E-4400-B8F0-E673CEC4E427", 0, true, false, true, false, @"", @"", "1CEC080C-AC71-4E91-9E92-788880B21378"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Completed By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "A2569BEF-456A-4124-B294-8FF4B019D14B", 2, true, false, true, false, @"", @"", "E87F6DE2-834F-41F9-BBB8-8AAB7DD54D42"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Completed On
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", 3, true, false, true, false, @"", @"", "91F0739F-EC54-4FBC-AD5C-8D7C984BFF8F"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Type
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "7D0DCC9F-59D7-4EF1-8151-30105082CB4C", 4, true, false, true, false, @"", @"", "F260609B-4F42-4273-9BEE-9F5B13026F70"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Summary
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", 6, true, false, false, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseBody""><i class=""fa fa-caret-down""></i>Communication Body</a>
<div class=""collapse"" id=""collapseBody"">", @"</div>", "A35258D3-3506-4CD4-96F7-32D3AA01DFDC"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "1A42A499-6EAC-4F0A-B6CF-25B33B84569A", 1, true, false, true, false, @"<!--<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseDepartments""><i class=""fa fa-caret-down""></i>Visible To: <span>All Departments</span></a>
<div class=""collapse"" id=""collapseDepartments"">-->", @"<!--</div>-->", "693A60E4-45C1-46E0-A5A7-97A8433ED211"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Visible To
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", 5, true, false, true, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseCategories""><i class=""fa fa-caret-down""></i>Category: <span>General</span></a>
<div class=""collapse"" id=""collapseCategories"">", @"</div>", "110A4FAA-1421-4050-BA59-732E2E4AA8E7"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Category
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", 7, true, false, false, false, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseSourceCode""><i class=""fa fa-caret-down""></i>UTM</a>
<div class=""collapse"" id=""collapseSourceCode"">", @"", "1804D4C4-5E19-4C6C-9433-FB37B3287A8E"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Source
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "DA76E800-224E-451E-8C5E-154C88AC34BC", 8, true, false, false, false, @"", @"", "D87D7586-C6C1-4030-8472-E22B36C69002"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Medium
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "C97E98AA-4804-4F53-8259-48F46F985A0D", 9, true, false, false, false, @"", @"</div>", "1ED49C31-4C16-489C-972D-C6B51FF8345E"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Campaign
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "3812F91C-D9AB-4AA1-B460-4890E4165516", 10, false, true, false, false, @"", @"", "2FF13BB0-7E80-4B90-AA19-7BA05ABDE683"); // Log an Interaction (Bulk, Updated):Start:Gather Input:EntitySetId
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Set Current Person", 0, "24B7D5E6-C30F-48F4-9D7E-AF45A342CF3A", true, false, "", "", 1, "", "CC262870-6E1D-4A38-96E1-A8C2F8E862BA"); // Log an Interaction (Bulk, Updated):Start:Set Current Person
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Set CompletedOn to Current Date", 1, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "51FED126-27A1-44EA-97B9-BB9EE05194B2"); // Log an Interaction (Bulk, Updated):Start:Set CompletedOn to Current Date
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Gather Input", 2, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "46E336DD-8A8F-4403-A496-03438C709AB7", "", 1, "", "9800F253-719F-4023-B2EB-4090082CE6B1"); // Log an Interaction (Bulk, Updated):Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Insert Interactions", 3, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "2C954467-3F4C-467E-8819-7E2948614655"); // Log an Interaction (Bulk, Updated):Start:Insert Interactions
            RockMigrationHelper.AddActionTypeAttributeValue("CC262870-6E1D-4A38-96E1-A8C2F8E862BA", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"ba39b511-ab5e-4400-b8f0-e673cec4e427"); // Log an Interaction (Bulk, Updated):Start:Set Current Person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("CC262870-6E1D-4A38-96E1-A8C2F8E862BA", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Log an Interaction (Bulk, Updated):Start:Set Current Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Log an Interaction (Bulk, Updated):Start:Set CompletedOn to Current Date:Active
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"a2569bef-456a-4124-b294-8ff4b019d14b"); // Log an Interaction (Bulk, Updated):Start:Set CompletedOn to Current Date:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ 'Now' | Date:'MM/dd/yyyy' }}"); // Log an Interaction (Bulk, Updated):Start:Set CompletedOn to Current Date:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("9800F253-719F-4023-B2EB-4090082CE6B1", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Log an Interaction (Bulk, Updated):Start:Gather Input:Active
            RockMigrationHelper.AddActionTypeAttributeValue("2C954467-3F4C-467E-8819-7E2948614655", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Log an Interaction (Bulk, Updated):Start:Insert Interactions:Active
            RockMigrationHelper.AddActionTypeAttributeValue("2C954467-3F4C-467E-8819-7E2948614655", "F3B9908B-096F-460B-8320-122CF046D1F9", @"-- Get list of channels to log interaction to
DECLARE @componentsToPostIn TABLE (ChannelGuid uniqueidentifier)

INSERT INTO @componentsToPostIn (ChannelGuid)
SELECT value [Guid] FROM string_split('{{ Workflow | Attribute:'VisibleTo','RawValue' }}',',')

-- If general visiblity is checked, only log it to the General component, not others
DECLARE @GeneralVisibility bit = (SELECT 1 FROM @componentsToPostIn WHERE [ChannelGuid] = '41D3B3BC-E03C-4282-871A-0FC87AD12982')
IF @GeneralVisibility = 1 DELETE FROM @componentsToPostIn WHERE [ChannelGuid] != '41D3B3BC-E03C-4282-871A-0FC87AD12982';

DECLARE @FirstResult uniqueidentifier = (SELECT TOP (1) [ChannelGuid] FROM @componentsToPostIn)
DECLARE @EntitySetEntityTypeId int = (SELECT [EntityTypeId] FROM [EntitySet] WHERE [EntitySet].Id = {{ Workflow | Attribute:'EntitySetId' | AsInteger }})

-- Create an interaction session for our bulk insert
INSERT INTO [InteractionSession] (CreatedDateTime, CreatedByPersonAliasId, [Guid])
VALUES (GETDATE(), {{ Workflow | Attribute:'CompletedBy','PrimaryAliasId' }}, NEWID())
DECLARE @SessionId int = SCOPE_IDENTITY()

-- Log the first components interactions. If we are logging to multiple interaction channel components, log subsequent channel interactions as a link to the first.

-- Allow for EntitySets of different types. For GroupMembers:
IF @EntitySetEntityTypeId = 90
	INSERT INTO [Interaction]
		(InteractionDateTime
		,Operation
		,InteractionComponentId
		,InteractionSessionId
		,EntityId
		,PersonAliasId
		,InteractionSummary
		,InteractionData
		,CreatedDateTime
		,[Guid]
		,[Source]
		,[Medium]
		,[Campaign]
		,[ChannelCustomIndexed1]
		)
		SELECT 
			GETDATE()
			,'{{ Workflow | Attribute:'Type' }}'
			,(SELECT [Id] FROM InteractionComponent WHERE [Guid] = @FirstResult) [InteractionComponentId]
			,@SessionId
			,PersonAlias.Id
			,{{ Workflow | Attribute:'CompletedBy','PrimaryAliasId' }}
			,'{{ Workflow | Attribute:'Summary' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'CommunicationBody' | SanitizeSql }}'
			,GETDATE()
			,NEWID()
			,'{{ Workflow | Attribute:'Source' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'Medium' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'Campaign' | SanitizeSql }}'
			,(SELECT [Id] FROM Category WHERE [Guid] = '{{ Workflow | Attribute:'Category','RawValue' }}')
		 FROM [EntitySetItem]
		 INNER JOIN [GroupMember] ON [EntitySetItem].EntityId = [GroupMember].Id
		 OUTER APPLY (SELECT TOP (1) [Id] FROM [PersonAlias] WHERE [PersonAlias].PersonId = [GroupMember].PersonId) [PersonAlias]
		 WHERE [EntitySetItem].EntitySetId = {{ Workflow | Attribute:'EntitySetId' | AsInteger }}
ELSE -- For People:
	INSERT INTO [Interaction]
		(InteractionDateTime
		,Operation
		,InteractionComponentId
		,InteractionSessionId
		,EntityId
		,PersonAliasId
		,InteractionSummary
		,InteractionData
		,CreatedDateTime
		,[Guid]
		,[Source]
		,[Medium]
		,[Campaign]
		,[ChannelCustomIndexed1]
		)
		SELECT 
			GETDATE()
			,'{{ Workflow | Attribute:'Type' }}'
			,(SELECT [Id] FROM InteractionComponent WHERE [Guid] = @FirstResult) [InteractionComponentId]
			,@SessionId
			,PersonAlias.Id
			,{{ Workflow | Attribute:'CompletedBy','PrimaryAliasId' }}
			,'{{ Workflow | Attribute:'Summary' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'CommunicationBody' | SanitizeSql }}'
			,GETDATE()
			,NEWID()
			,'{{ Workflow | Attribute:'Source' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'Medium' | SanitizeSql }}'
			,'{{ Workflow | Attribute:'Campaign' | SanitizeSql }}'
			,(SELECT [Id] FROM Category WHERE [Guid] = '{{ Workflow | Attribute:'Category','RawValue' }}')
		 FROM [EntitySetItem]
		 INNER JOIN [Person] ON [EntitySetItem].EntityId = [Person].Id
		 OUTER APPLY (SELECT TOP (1) [Id] FROM [PersonAlias] WHERE [PersonAlias].PersonId = [Person].Id) [PersonAlias]
		 WHERE [EntitySetItem].EntitySetId = {{ Workflow | Attribute:'EntitySetId' | AsInteger }}

-- Also log in other interaction channel components
IF @GeneralVisibility IS NULL OR @GeneralVisibility != 1
	INSERT INTO [Interaction]
		(InteractionDateTime
		,InteractionComponentId
		,InteractionSessionId
		,EntityId
		,PersonAliasId
		,[RelatedEntityTypeId]
		,[RelatedEntityId]
		,[Guid]
		)
	SELECT
		InteractionDateTime
		,[ChannelComponents].Id
		,@SessionId
		,Interaction.EntityId
		,Interaction.PersonAliasId
		,576
		,Interaction.Id
		,NEWID()
	FROM [Interaction]
	CROSS JOIN (SELECT [Id], [Guid] FROM [InteractionComponent] WHERE [Guid] IN (SELECT ChannelGuid FROM @componentsToPostIn)) [ChannelComponents]
	WHERE [ChannelComponents].[Guid] != @FirstResult AND [Interaction].InteractionSessionId = @SessionId"); // Log an Interaction (Bulk, Updated):Start:Insert Interactions:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("2C954467-3F4C-467E-8819-7E2948614655", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Log an Interaction (Bulk, Updated):Start:Insert Interactions:Continue On Error

            #endregion

            #region DefinedValue AttributeType qualifier helper

            Sql(@"
			UPDATE [aq] SET [key] = 'definedtype', [Value] = CAST( [dt].[Id] as varchar(5) )
			FROM [AttributeQualifier] [aq]
			INNER JOIN [Attribute] [a] ON [a].[Id] = [aq].[AttributeId]
			INNER JOIN [FieldType] [ft] ON [ft].[Id] = [a].[FieldTypeId]
			INNER JOIN [DefinedType] [dt] ON CAST([dt].[guid] AS varchar(50) ) = [aq].[value]
			WHERE [ft].[class] = 'Rock.Field.Types.DefinedValueFieldType'
			AND [aq].[key] = 'definedtypeguid'
		");

            #endregion


            // Custom Grid Actions on Group Viewer and Data View results
            RockMigrationHelper.AddBlockAttributeValue("59B70442-91A8-4538-9508-14F596C3798E", "F7418932-8570-41CA-84A1-37F93DD7A6A2", @"[{""Route"":""/page/289?WorkflowTypeId="+SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = '592AAE6F-EE1A-4752-A20C-C94D607A4621'").ToString()+@""",""IconCssClass"":""fa fa-pen"",""HelpText"":""Log an interaction with these individuals""}]");
            RockMigrationHelper.AddBlockAttributeValue("BA0F3E7D-1C3A-47CB-9058-893DBAA35B89", "D4D7DCB4-F481-48F2-9992-E35C6F4E8C0B", @"[{""Route"":""/page/289?WorkflowTypeId="+ SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = '592AAE6F-EE1A-4752-A20C-C94D607A4621'").ToString()+@""",""IconCssClass"":""fa fa-pen"",""HelpText"":""Log an interaction with these individuals""}]");
        }

        public override void Down()
        {

            // Remove Block: Dynamic Data, from Page: Interactions, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("9E3DADC0-7FBC-4FBC-8F22-351242BD922A");
            // Delete Page Interactions from Site:Rock RMS
            RockMigrationHelper.DeletePage("1AB75D63-412C-4732-B34F-AE821804F952"); //  Page: Interactions, Layout: PersonDetail, Site: Rock RMS
        }
    }
}
