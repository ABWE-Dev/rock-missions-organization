using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Rock;
using Rock.Plugin;
using Rock.Security;
using Rock.Model;

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
            RockMigrationHelper.UpdateCategory("3BB4B095-2DE4-4009-8FA2-705BF284F7B7", "Bereavement", "", "An interaction on the occasion of bereavement", "221e5573-a713-4b6c-850c-446f060cad08");
            RockMigrationHelper.UpdateCategory("3BB4B095-2DE4-4009-8FA2-705BF284F7B7", "Thanks", "", "An interaction on the occasion of thanksgiving", "50939401-c496-4a5e-995c-d9af470f7084");


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
                    [Interaction].[Id]
                    ,[InteractionDateTime] [Date]
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
                RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A","B9163A35-E09C-466D-8A2D-4ED81DF0114C", @"Interactions/{Id}");

                // Add Block Attribute Value
                //   Block: Dynamic Data
                //   BlockType: Dynamic Data
                //   Block Location: Page=Interactions, Site=Rock RMS
                //   Attribute: Hide Columns
                //   Attribute Value: 
                RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A", "90B0E6AF-B2F4-4397-953B-737A40D4023B", @"Id");


                // Add Block Attribute Value
                //   Block: Dynamic Data
                //   BlockType: Dynamic Data
                //   Block Location: Page=Interactions, Site=Rock RMS
                //   Attribute: Show Columns
                //   Attribute Value: False
                RockMigrationHelper.AddBlockAttributeValue("9E3DADC0-7FBC-4FBC-8F22-351242BD922A","202A82BF-7772-481C-8419-600012607972",@"False");


            // Add Page Interaction Details to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "1AB75D63-412C-4732-B34F-AE821804F952", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Interaction Details", "", "7796B670-CA8D-4DDA-AF36-1AF036E5A2AE", "");

            // Add Page Route for Interaction Details
            RockMigrationHelper.AddPageRoute("7796B670-CA8D-4DDA-AF36-1AF036E5A2AE", "Person/{PersonId}/Interactions/{InteractionId}", "73019ED2-39B8-42B9-AC11-FE75F10661B3");

            // Add Block Interaction Detail to Page: Interaction Details, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "7796B670-CA8D-4DDA-AF36-1AF036E5A2AE".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "B6AD2D98-0DF3-4DFB-AE2B-A8CF6E21E5C0".AsGuid(), "Interaction Detail", "SubNavigation", @"", @"", 0, "A50A7A10-E689-443D-B166-973153B7B891");


            // Add Block Attribute Value
            //   Block: Interaction Detail
            //   BlockType: Interaction Detail
            //   Block Location: Page=Interaction Details, Site=Rock RMS
            //   Attribute: Default Template
            //   Attribute Value: Template
            RockMigrationHelper.AddBlockAttributeValue("A50A7A10-E689-443D-B166-973153B7B891", "3C71A209-E094-4DED-A786-0435E61CA885", @"<div class='panel panel-block'>
                <div class='panel-heading'>
	                <h1 class='panel-title'>
                        <i class='fa fa-user'></i>
                        Interaction Detail
                    </h1>
                </div>
                <div class='panel-body'>
                    <div class='row'>
                        <div class='col-md-6'>
                            <dl>
                                <dt>Channel</dt><dd>{{ InteractionChannel.Name }}<dd/>
                                <dt>Date / Time</dt><dd>{{ Interaction.InteractionDateTime }}<dd/>
                                <dt>Operation</dt><dd>{{ Interaction.Operation }}<dd/>
                        
                                {% if InteractionEntityName != '' %}
                                    <dt>Entity Name</dt><dd>{{ InteractionEntityName }}<dd/>
                                {% endif %}
                            </dl>
                        </div>
                        <div class='col-md-6'>
                            <dl>
                                <dt> Department</dt><dd>{{ InteractionComponent.Name }}<dd/>
                                {% if Interaction.PersonAlias.Person.FullName != '' %}
                                    <dt>Person</dt><dd>{{ Interaction.PersonAlias.Person.FullName }}<dd/>
                                {% endif %}
                        
                                {% if Interaction.InteractionSummary && Interaction.InteractionSummary != '' %}
                                    <dt>Interaction Summary</dt><dd>{{ Interaction.InteractionSummary }}<dd/>
                                {% endif %}
                        
                                {% if Interaction.InteractionData && Interaction.InteractionData != '' %}
                                    <dt>Interaction Data</dt><dd>{{ Interaction.InteractionData }}<dd/>
                                {% endif %}
                            </dl>
                        </div>
                    </div>
                </div>
            </div>");


            // Add/Update PageContext for Page:Interactions, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.UpdatePageContext("1AB75D63-412C-4732-B34F-AE821804F952", "Rock.Model.Person", "PersonId", "50344A52-4568-485A-9CE4-9BEFF3EB95A6");
            // Add/Update PageContext for Page:Timelines, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.UpdatePageContext("18E2C178-DD5D-4031-960A-71994057FDE4", "Rock.Model.Person", "PersonId", "BD684CA1-DDE0-4C79-8B45-2F4E09189FF5");
            // Add/Update PageContext for Page:Interaction Details, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.UpdatePageContext("7796B670-CA8D-4DDA-AF36-1AF036E5A2AE", "Rock.Model.Person", "PersonId", "E6D080D1-111B-4AB9-BE1C-7FCDBDA2C55B");


            // Update Communication blocks to allow adding interactions at end
            Sql(@"UPDATE [Block]  SET
	            PreHtml = '<link rel=""stylesheet"" href=""/Plugins/org_abwe/RockMissions/Scripts/collapser.css"" />',
                PostHtml = '<script src=""/Plugins/org_abwe/RockMissions/Scripts/communicationInteractions.js""></script>'
            WHERE [Guid] = '82D5B1A0-1C17-464E-9EC5-414549FB44C7' OR [Guid] = 'BD9B2F32-AB18-4761-80C9-FDA4DBEEA9EC'");


            // Hide interactions page from staff
            RockMigrationHelper.AddSecurityAuthForPage("A9661D86-83B6-4AC1-B988-B5CC942A9ED6", 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "1d73581d-a417-49e6-aed2-7f28790c1d04");
            RockMigrationHelper.AddSecurityAuthForPage("A9661D86-83B6-4AC1-B988-B5CC942A9ED6", 1, Authorization.VIEW, false, null, (int)SpecialRole.AllUsers, "acc8e8f4-fc06-496a-a7f0-752d482814ff");


            /*
             * 
             * Workflows
             * 
             */

            #region Categories

            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Missions", "", "", "D3EA0403-2070-4833-8384-E11F21594900", 0); // Missions

            #endregion

            #region Assign a Follow-Up

            RockMigrationHelper.UpdateWorkflowType(false, true, "Assign a Follow-Up", "", "D3EA0403-2070-4833-8384-E11F21594900", "Follow-Up", "fa fa-list-ol", 28800, true, 0, "EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", 0); // Assign a Follow-Up
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Follow-Up With", "FollowUpWith", "", 0, @"", "0D9E4180-62A5-46FF-A6BC-5804C6ED8623", true); // Assign a Follow-Up:Follow-Up With
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "6B6AA175-4758-453F-8D83-FCD8044B5F36", "Due After", "DueAfter", "", 1, @"", "A065B9DE-36BB-4E21-973C-7CE7233C5EDD", false); // Assign a Follow-Up:Due After
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "6B6AA175-4758-453F-8D83-FCD8044B5F36", "Due By", "DueBy", "", 2, @"", "AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", false); // Assign a Follow-Up:Due By
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Assigned To:", "AssignedTo", "", 3, @"", "1B97BB6B-A118-4927-B92E-32FDF66656C1", false); // Assign a Follow-Up:Assigned To:
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Notes", "Notes", "", 4, @"", "13300198-44CA-4B3B-8868-413F971CDBE7", false); // Assign a Follow-Up:Notes
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Assigned By", "AssignedBy", "", 5, @"", "F4F7126B-8F7C-4273-84CE-0E0DC42F2A8A", false); // Assign a Follow-Up:Assigned By
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Result", "Result", "", 6, @"", "6B55FE12-2B08-457C-A3CC-CABE60B60AAF", false); // Assign a Follow-Up:Result
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Form Result", "FormResult", "", 7, @"", "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", false); // Assign a Follow-Up:Form Result
            RockMigrationHelper.AddAttributeQualifier("0D9E4180-62A5-46FF-A6BC-5804C6ED8623", "EnableSelfSelection", @"False", "990881FB-8777-444B-A68C-5F1515EA5256"); // Assign a Follow-Up:Follow-Up With:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("A065B9DE-36BB-4E21-973C-7CE7233C5EDD", "datePickerControlType", @"Date Picker", "D0EAA17F-37D0-41D6-9FA5-FACAD487CE95"); // Assign a Follow-Up:Due After:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("A065B9DE-36BB-4E21-973C-7CE7233C5EDD", "displayCurrentOption", @"False", "8327673B-2EFB-466B-A200-D70362222D6D"); // Assign a Follow-Up:Due After:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("A065B9DE-36BB-4E21-973C-7CE7233C5EDD", "displayDiff", @"False", "F536F417-9663-4895-95D7-23C574ED3AAF"); // Assign a Follow-Up:Due After:displayDiff
            RockMigrationHelper.AddAttributeQualifier("A065B9DE-36BB-4E21-973C-7CE7233C5EDD", "format", @"", "AA13BC1B-6664-4D6C-974F-07FA2EEAA96A"); // Assign a Follow-Up:Due After:format
            RockMigrationHelper.AddAttributeQualifier("A065B9DE-36BB-4E21-973C-7CE7233C5EDD", "futureYearCount", @"", "2212E5CB-D8A1-480E-AC37-1A3CBD8F67CB"); // Assign a Follow-Up:Due After:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", "datePickerControlType", @"Date Picker", "22551F30-15A7-421E-9886-546AC6251DC0"); // Assign a Follow-Up:Due By:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", "displayCurrentOption", @"False", "FFFDC09E-B7A7-49A9-8110-686820037394"); // Assign a Follow-Up:Due By:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", "displayDiff", @"False", "2EB54474-8D21-4711-9B3D-8C32B70EACA0"); // Assign a Follow-Up:Due By:displayDiff
            RockMigrationHelper.AddAttributeQualifier("AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", "format", @"", "03CCA77E-45C7-4A19-8B36-D90F3E9F30F2"); // Assign a Follow-Up:Due By:format
            RockMigrationHelper.AddAttributeQualifier("AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", "futureYearCount", @"", "1EB1B72D-8568-478C-9D2D-1F9EF98E0D64"); // Assign a Follow-Up:Due By:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("1B97BB6B-A118-4927-B92E-32FDF66656C1", "EnableSelfSelection", @"False", "B0A3519B-9C82-4AC4-8E25-436EAF232EB9"); // Assign a Follow-Up:Assigned To::EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("13300198-44CA-4B3B-8868-413F971CDBE7", "allowhtml", @"False", "92828ADF-3B5A-46F1-A6A7-A0DCB8B71F90"); // Assign a Follow-Up:Notes:allowhtml
            RockMigrationHelper.AddAttributeQualifier("13300198-44CA-4B3B-8868-413F971CDBE7", "maxcharacters", @"", "971F25C0-EC35-4BC1-9662-E1ACA4E9A09A"); // Assign a Follow-Up:Notes:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("13300198-44CA-4B3B-8868-413F971CDBE7", "numberofrows", @"", "99569B67-66BF-4731-BEB5-7FDACC58FFE3"); // Assign a Follow-Up:Notes:numberofrows
            RockMigrationHelper.AddAttributeQualifier("13300198-44CA-4B3B-8868-413F971CDBE7", "showcountdown", @"False", "EC467C7F-6D22-4D41-A106-477DCFCA0F9C"); // Assign a Follow-Up:Notes:showcountdown
            RockMigrationHelper.AddAttributeQualifier("F4F7126B-8F7C-4273-84CE-0E0DC42F2A8A", "EnableSelfSelection", @"False", "E667798F-6109-43CB-AE79-372D67697D86"); // Assign a Follow-Up:Assigned By:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("6B55FE12-2B08-457C-A3CC-CABE60B60AAF", "allowhtml", @"False", "C797B382-FF68-4F54-92EE-D494D7B95170"); // Assign a Follow-Up:Result:allowhtml
            RockMigrationHelper.AddAttributeQualifier("6B55FE12-2B08-457C-A3CC-CABE60B60AAF", "maxcharacters", @"", "DC6C8B31-700F-4EFE-88C5-2BFFE4B6D32E"); // Assign a Follow-Up:Result:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("6B55FE12-2B08-457C-A3CC-CABE60B60AAF", "numberofrows", @"", "B567CBCE-ADE1-4627-872E-C7E04F07DF52"); // Assign a Follow-Up:Result:numberofrows
            RockMigrationHelper.AddAttributeQualifier("6B55FE12-2B08-457C-A3CC-CABE60B60AAF", "showcountdown", @"False", "700E8684-B9E6-488A-A63A-3FA4E18252D1"); // Assign a Follow-Up:Result:showcountdown
            RockMigrationHelper.AddAttributeQualifier("7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", "ispassword", @"False", "B7D37AAD-3F9A-48CC-A622-4FDCCF232D57"); // Assign a Follow-Up:Form Result:ispassword
            RockMigrationHelper.AddAttributeQualifier("7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", "maxcharacters", @"", "663737EA-421C-4F56-B229-F33C8843F36F"); // Assign a Follow-Up:Form Result:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", "showcountdown", @"False", "E6CFD232-77EB-4300-8A20-27F5883A8BE0"); // Assign a Follow-Up:Form Result:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", true, "Start", "", true, 0, "EDAD98B9-58E6-4190-B84C-F97ACCA3A4FA"); // Assign a Follow-Up:Start
            RockMigrationHelper.UpdateWorkflowActivityType("EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01", true, "Await Follow-Up", "", false, 1, "4FC3F057-00C7-4D11-9A93-972A6D9021D7"); // Assign a Follow-Up:Await Follow-Up
            RockMigrationHelper.UpdateWorkflowActionForm(@"", @"", "Assign^fdc397cd-8b4a-436e-bea1-bce2e6717c03^4FC3F057-00C7-4D11-9A93-972A6D9021D7^Your information has been submitted successfully.|Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^4FC3F057-00C7-4D11-9A93-972A6D9021D7^|Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^4FC3F057-00C7-4D11-9A93-972A6D9021D7^|", "", true, "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", "593829C4-73F1-4A80-BDCD-BCFDA2441512"); // Assign a Follow-Up:Start:Gather Info
            RockMigrationHelper.UpdateWorkflowActionForm(@"", @"", "Complete^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|", "", true, "", "7292E55F-C668-4256-8E3C-5812D09020B9"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "0D9E4180-62A5-46FF-A6BC-5804C6ED8623", 0, true, false, true, false, @"", @"", "B1F998E5-C42D-40FA-9762-D0E2974F5C4D"); // Assign a Follow-Up:Start:Gather Info:Follow-Up With
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "A065B9DE-36BB-4E21-973C-7CE7233C5EDD", 2, true, false, false, false, @"", @"", "D6785D88-06E9-417F-B1CD-89F39CF50EFE"); // Assign a Follow-Up:Start:Gather Info:Due After
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", 3, true, false, false, false, @"", @"", "1A6D4D2A-AAC9-434E-AD03-F963BA29019A"); // Assign a Follow-Up:Start:Gather Info:Due By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "1B97BB6B-A118-4927-B92E-32FDF66656C1", 1, true, false, true, false, @"", @"", "E4F2B2A7-C48C-4159-A2C6-2CC8511C37A5"); // Assign a Follow-Up:Start:Gather Info:Assigned To:
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "13300198-44CA-4B3B-8868-413F971CDBE7", 4, true, false, false, false, @"", @"", "F7CBBCA7-7944-45A9-BACC-F4B852E812EA"); // Assign a Follow-Up:Start:Gather Info:Notes
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "F4F7126B-8F7C-4273-84CE-0E0DC42F2A8A", 5, false, true, false, false, @"", @"", "3C62453E-4B2B-4F0F-A56B-E60D1CAFF268"); // Assign a Follow-Up:Start:Gather Info:Assigned By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "6B55FE12-2B08-457C-A3CC-CABE60B60AAF", 6, false, true, false, false, @"", @"", "A9D4369E-9A60-4D67-B47E-1C9BDF055F52"); // Assign a Follow-Up:Start:Gather Info:Result
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("593829C4-73F1-4A80-BDCD-BCFDA2441512", "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", 7, false, true, false, false, @"", @"", "452384C3-DE45-4638-A958-08F0869C3CD2"); // Assign a Follow-Up:Start:Gather Info:Form Result
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "0D9E4180-62A5-46FF-A6BC-5804C6ED8623", 1, true, true, false, false, @"", @"", "26B342A6-6730-44F7-A0F0-8D9D83D49A94"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Follow-Up With
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "A065B9DE-36BB-4E21-973C-7CE7233C5EDD", 2, true, true, false, false, @"", @"", "C23ED798-C1F2-48A5-B6CE-FE8CAFAF78C6"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Due After
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "AFA3EB17-1CFE-4F7D-98C3-7A4B5CD81D3E", 3, true, true, false, false, @"", @"", "4E1F1BCF-2691-4650-9FC0-1F13B75A18CC"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Due By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "1B97BB6B-A118-4927-B92E-32FDF66656C1", 4, true, true, false, false, @"", @"", "8F8018EF-4B8E-45BA-B9C6-A7C4DDF91A2A"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Assigned To:
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "13300198-44CA-4B3B-8868-413F971CDBE7", 5, true, true, false, false, @"", @"", "6F1BAC98-5460-46A6-8271-D9AED8C42DEC"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Notes
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "F4F7126B-8F7C-4273-84CE-0E0DC42F2A8A", 0, true, true, false, false, @"", @"", "96829832-FED6-496D-BA8F-C675E048639E"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Assigned By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "6B55FE12-2B08-457C-A3CC-CABE60B60AAF", 6, true, false, true, false, @"", @"", "5CF8861A-6012-4290-87C6-39EE16EFF951"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Result
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("7292E55F-C668-4256-8E3C-5812D09020B9", "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", 7, false, true, false, false, @"", @"", "4F7ED20C-56FE-4487-A405-3DA2DC9F9F4C"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Form Result
            RockMigrationHelper.UpdateWorkflowActionType("EDAD98B9-58E6-4190-B84C-F97ACCA3A4FA", "Set Assigned By", 0, "24B7D5E6-C30F-48F4-9D7E-AF45A342CF3A", true, false, "", "", 1, "", "4794C09C-0692-4EB4-BBB0-4A101818B397"); // Assign a Follow-Up:Start:Set Assigned By
            RockMigrationHelper.UpdateWorkflowActionType("EDAD98B9-58E6-4190-B84C-F97ACCA3A4FA", "Gather Info", 1, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "593829C4-73F1-4A80-BDCD-BCFDA2441512", "", 1, "", "AB455684-ED79-4C6F-8A2F-7953DB1EBD50"); // Assign a Follow-Up:Start:Gather Info
            RockMigrationHelper.UpdateWorkflowActionType("EDAD98B9-58E6-4190-B84C-F97ACCA3A4FA", "Redirect to Share a Lead", 2, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", 1, "Share a Lead", "F8D1D9A0-999A-4BB1-899D-782148A7BDB5"); // Assign a Follow-Up:Start:Redirect to Share a Lead
            RockMigrationHelper.UpdateWorkflowActionType("EDAD98B9-58E6-4190-B84C-F97ACCA3A4FA", "Redirect to Assign Follow-Up", 3, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "7AAB57F0-076F-4BEA-83B1-43D49E7CDBF8", 1, "Assign Follow-Up", "09EA91DF-B71C-4FB2-AEC8-ECC4723DDA1F"); // Assign a Follow-Up:Start:Redirect to Assign Follow-Up
            RockMigrationHelper.UpdateWorkflowActionType("4FC3F057-00C7-4D11-9A93-972A6D9021D7", "Set Title", 0, "36005473-BD5D-470B-B28D-98E6D7ED808D", true, false, "", "", 1, "", "06719589-8873-4B18-9C42-DE2D42A96052"); // Assign a Follow-Up:Await Follow-Up:Set Title
            RockMigrationHelper.UpdateWorkflowActionType("4FC3F057-00C7-4D11-9A93-972A6D9021D7", "Assign to Assignee", 1, "F100A31F-E93A-4C7A-9E55-0FAF41A101C4", true, false, "", "", 1, "", "33A5271B-3840-4352-94B9-5A5D1FA6880F"); // Assign a Follow-Up:Await Follow-Up:Assign to Assignee
            RockMigrationHelper.UpdateWorkflowActionType("4FC3F057-00C7-4D11-9A93-972A6D9021D7", "Gather Follow-Up", 2, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "7292E55F-C668-4256-8E3C-5812D09020B9", "", 1, "", "9D3776E8-5DF1-4601-89C1-492A99759138"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up
            RockMigrationHelper.UpdateWorkflowActionType("4FC3F057-00C7-4D11-9A93-972A6D9021D7", "Email Assigner", 3, "66197B01-D1F0-4924-A315-47AD54E030DE", true, true, "", "", 1, "", "BD4B3522-1D34-4845-AE4C-37344521509A"); // Assign a Follow-Up:Await Follow-Up:Email Assigner
            RockMigrationHelper.AddActionTypeAttributeValue("4794C09C-0692-4EB4-BBB0-4A101818B397", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Assign a Follow-Up:Start:Set Assigned By:Active
            RockMigrationHelper.AddActionTypeAttributeValue("4794C09C-0692-4EB4-BBB0-4A101818B397", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"f4f7126b-8f7c-4273-84ce-0e0dc42f2a8a"); // Assign a Follow-Up:Start:Set Assigned By:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("AB455684-ED79-4C6F-8A2F-7953DB1EBD50", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Assign a Follow-Up:Start:Gather Info:Active
            RockMigrationHelper.AddActionTypeAttributeValue("06719589-8873-4B18-9C42-DE2D42A96052", "0A800013-51F7-4902-885A-5BE215D67D3D", @"False"); // Assign a Follow-Up:Await Follow-Up:Set Title:Active
            RockMigrationHelper.AddActionTypeAttributeValue("06719589-8873-4B18-9C42-DE2D42A96052", "93852244-A667-4749-961A-D47F88675BE4", @"Follow-Up with {{ Workflow | Attribute:'FollowUpWith' }}"); // Assign a Follow-Up:Await Follow-Up:Set Title:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("33A5271B-3840-4352-94B9-5A5D1FA6880F", "E0F7AB7E-7761-4600-A099-CB14ACDBF6EF", @"False"); // Assign a Follow-Up:Await Follow-Up:Assign to Assignee:Active
            RockMigrationHelper.AddActionTypeAttributeValue("33A5271B-3840-4352-94B9-5A5D1FA6880F", "FBADD25F-D309-4512-8430-3CC8615DD60E", @"1b97bb6b-a118-4927-b92e-32fdf66656c1"); // Assign a Follow-Up:Await Follow-Up:Assign to Assignee:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("9D3776E8-5DF1-4601-89C1-492A99759138", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Assign a Follow-Up:Await Follow-Up:Gather Follow-Up:Active
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "36197160-7D3D-490D-AB42-7E29105AFE91", @"False"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:Active
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "9F5F7CEC-F369-4FDF-802A-99074CE7A7FC", @"1b97bb6b-a118-4927-b92e-32fdf66656c1"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:From Email Address|From Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "0C4C13B8-7076-4872-925A-F950886B5E16", @"f4f7126b-8f7c-4273-84ce-0e0dc42f2a8a"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:Send To Email Addresses|To Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "5D9B13B6-CD96-4C7C-86FA-4512B9D28386", @"Follow-Up with {{ Workflow | Attribute:'FollowupWith' }} Complete"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:Subject
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "4D245B9E-6B03-46E7-8482-A51FBA190E4D", @"You assigned me a follow-up with {{ Workflow | Attribute:'FollowupWith' }} on {{ Workflow.CreatedDateTime | Date:'M/d/yyyy' }}. Here are my notes:<br><br>

{{ Workflow | Attribute:'Result' }}<br><br>

{{ Workflow | Attribute:'AssignedTo','Nickname' }}"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:Body
            RockMigrationHelper.AddActionTypeAttributeValue("BD4B3522-1D34-4845-AE4C-37344521509A", "65E69B78-37D8-4A88-B8AC-71893D2F75EF", @"False"); // Assign a Follow-Up:Await Follow-Up:Email Assigner:Save Communication History

            #endregion


            #region Share a Lead

            RockMigrationHelper.UpdateWorkflowType(false, true, "Share a Lead", "", "D3EA0403-2070-4833-8384-E11F21594900", "Lead", "fa fa-list-ol", 28800, true, 0, "65BE4770-FF21-492B-B17C-E6050AF44091", 0); // Share a Lead
            RockMigrationHelper.UpdateWorkflowTypeAttribute("65BE4770-FF21-492B-B17C-E6050AF44091", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Share with", "Sharewith", "", 0, @"", "1EEC53F5-A63F-4F75-B30E-3C74745EE165", false); // Share a Lead:Share with
            RockMigrationHelper.UpdateWorkflowTypeAttribute("65BE4770-FF21-492B-B17C-E6050AF44091", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Notes", "Notes", "", 1, @"", "9B461C07-C753-4616-8808-B16DC28B7047", false); // Share a Lead:Notes
            RockMigrationHelper.UpdateWorkflowTypeAttribute("65BE4770-FF21-492B-B17C-E6050AF44091", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Current Person", "CurrentPerson", "", 2, @"", "2CB62C12-70E9-4D51-96E0-0C061F620F65", false); // Share a Lead:Current Person
            RockMigrationHelper.UpdateWorkflowTypeAttribute("65BE4770-FF21-492B-B17C-E6050AF44091", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Lead", "Lead", "", 3, @"", "A0BD5F6E-C53E-4243-9202-431D4551C02B", false); // Share a Lead:Lead
            RockMigrationHelper.UpdateWorkflowTypeAttribute("65BE4770-FF21-492B-B17C-E6050AF44091", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Form Result", "FormResult", "", 4, @"", "0B615C39-AF91-4AF5-AC66-9630C52AF322", false); // Share a Lead:Form Result
            RockMigrationHelper.AddAttributeQualifier("1EEC53F5-A63F-4F75-B30E-3C74745EE165", "EnableSelfSelection", @"False", "E1A511C2-57C0-4468-9D45-B4CDABF992AC"); // Share a Lead:Share with:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("9B461C07-C753-4616-8808-B16DC28B7047", "allowhtml", @"False", "3E7ED084-B2F3-4224-B408-35AF13442096"); // Share a Lead:Notes:allowhtml
            RockMigrationHelper.AddAttributeQualifier("9B461C07-C753-4616-8808-B16DC28B7047", "maxcharacters", @"", "08CD7C1B-088D-443C-B17C-06C11BC978AF"); // Share a Lead:Notes:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("9B461C07-C753-4616-8808-B16DC28B7047", "numberofrows", @"", "ED4F2FD1-F6EC-4F48-A4D2-DC038AFBB025"); // Share a Lead:Notes:numberofrows
            RockMigrationHelper.AddAttributeQualifier("9B461C07-C753-4616-8808-B16DC28B7047", "showcountdown", @"False", "8BA629FD-2ACF-4D9F-BA58-6AD76B5D0C9A"); // Share a Lead:Notes:showcountdown
            RockMigrationHelper.AddAttributeQualifier("2CB62C12-70E9-4D51-96E0-0C061F620F65", "EnableSelfSelection", @"False", "D558D0DF-93ED-4B5F-BC6E-0C4EF05651BB"); // Share a Lead:Current Person:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("A0BD5F6E-C53E-4243-9202-431D4551C02B", "EnableSelfSelection", @"False", "7C859C15-2A77-49AA-B940-7359E9724294"); // Share a Lead:Lead:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("0B615C39-AF91-4AF5-AC66-9630C52AF322", "ispassword", @"False", "E3AF0935-B593-40B5-B87D-3F923EAE1795"); // Share a Lead:Form Result:ispassword
            RockMigrationHelper.AddAttributeQualifier("0B615C39-AF91-4AF5-AC66-9630C52AF322", "maxcharacters", @"", "98F90423-0DCD-4E59-B70C-611940C81221"); // Share a Lead:Form Result:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("0B615C39-AF91-4AF5-AC66-9630C52AF322", "showcountdown", @"False", "EF77E6AA-3EB1-4366-A0D3-B48DEB7CDAAA"); // Share a Lead:Form Result:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("65BE4770-FF21-492B-B17C-E6050AF44091", true, "Start", "", true, 0, "68535442-3C7B-4E87-8433-1F145F178EE4"); // Share a Lead:Start
            RockMigrationHelper.UpdateWorkflowActionForm(@"", @"", "Submit^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^^|Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^^|", "", true, "0B615C39-AF91-4AF5-AC66-9630C52AF322", "3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C"); // Share a Lead:Start:Gather Information
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "1EEC53F5-A63F-4F75-B30E-3C74745EE165", 1, true, false, true, false, @"", @"", "D22B0567-2EFD-4002-A154-793F5407D540"); // Share a Lead:Start:Gather Information:Share with
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "9B461C07-C753-4616-8808-B16DC28B7047", 2, true, false, true, false, @"", @"", "3E76EABC-1719-4969-B667-53549A1F4049"); // Share a Lead:Start:Gather Information:Notes
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "2CB62C12-70E9-4D51-96E0-0C061F620F65", 3, false, true, false, false, @"", @"", "93A4A09E-A968-48BB-8D5B-F74B73B31E32"); // Share a Lead:Start:Gather Information:Current Person
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "A0BD5F6E-C53E-4243-9202-431D4551C02B", 0, true, false, true, false, @"", @"", "5FC4A016-F369-4268-9F0C-6A3978F79CA1"); // Share a Lead:Start:Gather Information:Lead
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "0B615C39-AF91-4AF5-AC66-9630C52AF322", 4, false, true, false, false, @"", @"", "DB456210-B607-46A8-B0DD-BFBC64DC3C31"); // Share a Lead:Start:Gather Information:Form Result
            RockMigrationHelper.UpdateWorkflowActionType("68535442-3C7B-4E87-8433-1F145F178EE4", "Gather Information", 0, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "3B061F63-BBEA-47A5-8FE1-9D356EE9DA1C", "", 1, "", "9858A203-FF85-409A-86AA-2ED2E1DA60F6"); // Share a Lead:Start:Gather Information
            RockMigrationHelper.UpdateWorkflowActionType("68535442-3C7B-4E87-8433-1F145F178EE4", "Assign Current Person", 1, "24B7D5E6-C30F-48F4-9D7E-AF45A342CF3A", true, false, "", "", 1, "", "56326162-602B-4CC0-A944-61D7F0FFAFB0"); // Share a Lead:Start:Assign Current Person
            RockMigrationHelper.UpdateWorkflowActionType("68535442-3C7B-4E87-8433-1F145F178EE4", "Send Email", 2, "66197B01-D1F0-4924-A315-47AD54E030DE", true, false, "", "", 1, "", "57459B62-231F-49E7-84FC-0CA31B53476E"); // Share a Lead:Start:Send Email
            RockMigrationHelper.UpdateWorkflowActionType("68535442-3C7B-4E87-8433-1F145F178EE4", "Redirect to another lead", 3, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "0B615C39-AF91-4AF5-AC66-9630C52AF322", 1, "Share a Lead", "E1FE2811-645B-4071-B338-5D90DCDA7310"); // Share a Lead:Start:Redirect to another lead
            RockMigrationHelper.UpdateWorkflowActionType("68535442-3C7B-4E87-8433-1F145F178EE4", "Redirect to Assign Follow-Up", 4, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "0B615C39-AF91-4AF5-AC66-9630C52AF322", 1, "Assign Follow-Up", "27446048-74DC-4DBC-A6C1-8D4AA0182BBC"); // Share a Lead:Start:Redirect to Assign Follow-Up
            RockMigrationHelper.AddActionTypeAttributeValue("9858A203-FF85-409A-86AA-2ED2E1DA60F6", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Share a Lead:Start:Gather Information:Active
            RockMigrationHelper.AddActionTypeAttributeValue("56326162-602B-4CC0-A944-61D7F0FFAFB0", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Share a Lead:Start:Assign Current Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("56326162-602B-4CC0-A944-61D7F0FFAFB0", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"2cb62c12-70e9-4d51-96e0-0c061f620f65"); // Share a Lead:Start:Assign Current Person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "36197160-7D3D-490D-AB42-7E29105AFE91", @"False"); // Share a Lead:Start:Send Email:Active
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "9F5F7CEC-F369-4FDF-802A-99074CE7A7FC", @"2cb62c12-70e9-4d51-96e0-0c061f620f65"); // Share a Lead:Start:Send Email:From Email Address|From Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "0C4C13B8-7076-4872-925A-F950886B5E16", @"1eec53f5-a63f-4f75-b30e-3c74745ee165"); // Share a Lead:Start:Send Email:Send To Email Addresses|To Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "5D9B13B6-CD96-4C7C-86FA-4512B9D28386", @"I wanted to share a lead"); // Share a Lead:Start:Send Email:Subject
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "4D245B9E-6B03-46E7-8482-A51FBA190E4D", @"Lead name: {{ Workflow | Attribute:'Lead','Url' }}<br>
Notes: {{ Workflow | Attribute:'Notes' }}<br>

{{ Workflow | Attribute:'CurrentPerson','Nickname' }}"); // Share a Lead:Start:Send Email:Body
            RockMigrationHelper.AddActionTypeAttributeValue("57459B62-231F-49E7-84FC-0CA31B53476E", "65E69B78-37D8-4A88-B8AC-71893D2F75EF", @"False"); // Share a Lead:Start:Send Email:Save Communication History
            RockMigrationHelper.AddActionTypeAttributeValue("E1FE2811-645B-4071-B338-5D90DCDA7310", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Share a Lead:Start:Redirect to another lead:Active
            RockMigrationHelper.AddActionTypeAttributeValue("E1FE2811-645B-4071-B338-5D90DCDA7310", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/"+SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = '65BE4770-FF21-492B-B17C-E6050AF44091'").ToString()+"?Lead={{ Workflow | Attribute:'Lead','RawValue' }}&Notes={{ Workflow | Attribute:'Notes','RawValue' }}"); // Share a Lead:Start:Redirect to another lead:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("E1FE2811-645B-4071-B338-5D90DCDA7310", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Share a Lead:Start:Redirect to another lead:Processing Options
            RockMigrationHelper.AddActionTypeAttributeValue("27446048-74DC-4DBC-A6C1-8D4AA0182BBC", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Share a Lead:Start:Redirect to Assign Follow-Up:Active
            RockMigrationHelper.AddActionTypeAttributeValue("27446048-74DC-4DBC-A6C1-8D4AA0182BBC", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/" + SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = 'EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01'").ToString() + "?FollowUpWith={{ Workflow | Attribute:'Lead','RawValue' }}"); // Share a Lead:Start:Redirect to Assign Follow-Up:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("27446048-74DC-4DBC-A6C1-8D4AA0182BBC", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Share a Lead:Start:Redirect to Assign Follow-Up:Processing Options

            // Attributes from Assign Follow-Up workflow - actions to go to Share a Lead
            RockMigrationHelper.AddActionTypeAttributeValue("F8D1D9A0-999A-4BB1-899D-782148A7BDB5", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Assign a Follow-Up:Start:Redirect to Share a Lead:Active
            RockMigrationHelper.AddActionTypeAttributeValue("F8D1D9A0-999A-4BB1-899D-782148A7BDB5", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/" + SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = '65BE4770-FF21-492B-B17C-E6050AF44091'").ToString() + "?Lead={{ Workflow | Attribute:'FollowUpWith','RawValue' }}&Notes={{ Workflow | Attribute:'Notes' }}"); // Assign a Follow-Up:Start:Redirect to Share a Lead:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("F8D1D9A0-999A-4BB1-899D-782148A7BDB5", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Assign a Follow-Up:Start:Redirect to Share a Lead:Processing Options
            RockMigrationHelper.AddActionTypeAttributeValue("09EA91DF-B71C-4FB2-AEC8-ECC4723DDA1F", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Assign a Follow-Up:Start:Redirect to Assign Follow-Up:Active
            RockMigrationHelper.AddActionTypeAttributeValue("09EA91DF-B71C-4FB2-AEC8-ECC4723DDA1F", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/" + SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = 'EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01'").ToString() + "?FollowUpWith={{ Workflow | Attribute:'FollowUpWith','RawValue' }}&Notes={{ Workflow | Attribute:'Notes' }}"); // Assign a Follow-Up:Start:Redirect to Assign Follow-Up:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("09EA91DF-B71C-4FB2-AEC8-ECC4723DDA1F", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Assign a Follow-Up:Start:Redirect to Assign Follow-Up:Processing Options
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
            RockMigrationHelper.AddAttributeQualifier("24CB1492-6A9E-4C2F-B765-FCA93DC6A9C5", "EnableSelfSelection", @"False", "FC6FEA54-9DC3-4EAA-A115-DFC825D50DCB"); // Log an Interaction:Person and Family:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("50F2598B-4FA8-4FD6-8682-4B5AB0EA4FBD", "EnableSelfSelection", @"True", "2DC755A7-EF29-4F19-A14D-DCC5AE5D4D36"); // Log an Interaction:Completed By:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "datePickerControlType", @"Date Picker", "34317E7C-1BE4-48D5-A9FD-1EDAFE2C775E"); // Log an Interaction:Completed On:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "displayCurrentOption", @"False", "1BF769C6-8286-49E8-9C3B-8EC5B3CEE5F7"); // Log an Interaction:Completed On:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "displayDiff", @"False", "A0BB37F6-2A86-4DB7-8120-9D51A84D6F50"); // Log an Interaction:Completed On:displayDiff
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "format", @"", "E9F545EC-A637-4DD3-9246-63528215D405"); // Log an Interaction:Completed On:format
            RockMigrationHelper.AddAttributeQualifier("8172E8FA-237F-426C-8FBC-CF37680F1637", "futureYearCount", @"", "3110643E-629D-475D-8B2E-59FAE3859A3A"); // Log an Interaction:Completed On:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "fieldtype", @"ddl", "9A4DF8A2-7405-44DB-8EC9-E18E2C94DFDF"); // Log an Interaction:Type:fieldtype
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "repeatColumns", @"", "CD317548-F524-4540-878A-AD80F12D0825"); // Log an Interaction:Type:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("642A18BC-F025-45AB-8750-08F40C47611E", "values", @"Card,Email,Letter,Meeting,Phone Call,Text", "B97F5F86-0A9F-42C8-9886-E00B820F386A"); // Log an Interaction:Type:values
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "allowhtml", @"False", "401628CF-ECD3-480A-81EF-3588C9C8EE5E"); // Log an Interaction:Summary:allowhtml
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "maxcharacters", @"500", "27FA6B5B-B964-41E8-827D-11A1464593A7"); // Log an Interaction:Summary:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "numberofrows", @"", "F0AFEF33-2498-49C8-9A9D-AEEF765742E5"); // Log an Interaction:Summary:numberofrows
            RockMigrationHelper.AddAttributeQualifier("703AA0F9-0D66-4832-A39D-C8A2E3C357FD", "showcountdown", @"False", "CB427A0E-C3D9-4400-8D99-8E3C8677B5C2"); // Log an Interaction:Summary:showcountdown
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "allowhtml", @"True", "EF38EF30-1A86-401D-A9C7-9BF339A27AE9"); // Log an Interaction:Communication Body (optional):allowhtml
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "maxcharacters", @"", "AF8F4ADD-754C-464D-83B5-710937D4C8C8"); // Log an Interaction:Communication Body (optional):maxcharacters
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "numberofrows", @"10", "BE16A189-CB87-496F-8E75-D96969ADC56D"); // Log an Interaction:Communication Body (optional):numberofrows
            RockMigrationHelper.AddAttributeQualifier("E590AE76-08B0-4E08-BDE4-E07ECF787A19", "showcountdown", @"False", "538A7DF7-E3FF-4222-9A30-4BAC9673A434"); // Log an Interaction:Communication Body (optional):showcountdown
            RockMigrationHelper.AddAttributeQualifier("43C176A0-AEB8-4B45-BB71-07997FCC7813", "interactionChannel", SqlScalar("SELECT Id FROM InteractionChannel WHERE [Guid] ='D1853AE1-145F-4AE1-84CF-E7F62024B121'").ToString(), "473BF2FC-04E6-4050-A753-F3543A9771E6") ; // Log an Interaction:Visible To:interactionChannel
            RockMigrationHelper.AddAttributeQualifier("43C176A0-AEB8-4B45-BB71-07997FCC7813", "repeatColumns", @"", "3419C7A5-0729-43AE-B8ED-F04BA38982C5"); // Log an Interaction:Visible To:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "entityTypeName", @"Rock.Model.Interaction", "E23990E4-78E2-42F0-A113-A179D5636784"); // Log an Interaction:Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "qualifierColumn", @"", "773320BD-CA4E-4A27-A8A8-B828E3361ECF"); // Log an Interaction:Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("37685DC9-0738-465F-8B00-817E0DD55EF2", "qualifierValue", @"", "8115F87E-A9D4-447A-9F60-1830EEFF0A4F"); // Log an Interaction:Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "ispassword", @"False", "C0B8284A-FC67-415A-BE35-5EEEC3C0D28E"); // Log an Interaction:Source:ispassword
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "maxcharacters", @"", "A3CC81AA-BF2F-472A-962E-BDE4E4F7A128"); // Log an Interaction:Source:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("CFCED480-6D74-42A0-A103-C810AEB5D91E", "showcountdown", @"False", "D32F7CA2-DF2C-47C8-9B01-9894C5871816"); // Log an Interaction:Source:showcountdown
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "ispassword", @"False", "657A1DAD-B671-475C-B633-21BC14A8327A"); // Log an Interaction:Medium:ispassword
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "maxcharacters", @"", "AF476BBD-F687-4BB4-832A-AE0DA5789839"); // Log an Interaction:Medium:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("52F3C1F6-5041-451A-8F30-765FF057B730", "showcountdown", @"False", "928F78DF-A2E1-4DA0-92E2-3A576A259DE0"); // Log an Interaction:Medium:showcountdown
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "ispassword", @"False", "E99E1779-7653-4B1B-A624-563ADFA30014"); // Log an Interaction:Campaign:ispassword
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "maxcharacters", @"", "97584B47-79AD-478B-9F71-C0429E71F0B6"); // Log an Interaction:Campaign:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("DC99A20F-2BB9-4637-AEFC-DD3B44F8C8CE", "showcountdown", @"False", "3132B714-C81E-434F-9933-3CBBEB7C3DBB"); // Log an Interaction:Campaign:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("5C9ADC23-5721-4B80-9336-49D024D42CDA", true, "Start", "", true, 0, "9982A30F-3557-4475-B955-E3C7B473CC4E"); // Log an Interaction:Start
            RockMigrationHelper.UpdateWorkflowActivityTypeAttribute("9982A30F-3557-4475-B955-E3C7B473CC4E", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Form Action", "FormAction", "", 0, @"", "0224BC85-7F42-4097-8053-E552891D71E9"); // Log an Interaction:Start:Form Action
            RockMigrationHelper.AddAttributeQualifier("0224BC85-7F42-4097-8053-E552891D71E9", "ispassword", @"False", "2BA707C0-953E-449A-A406-9F1890FC4517"); // Log an Interaction:Form Action:ispassword
            RockMigrationHelper.AddAttributeQualifier("0224BC85-7F42-4097-8053-E552891D71E9", "maxcharacters", @"", "CBEC4F5F-3922-4153-9F42-102FC2637295"); // Log an Interaction:Form Action:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("0224BC85-7F42-4097-8053-E552891D71E9", "showcountdown", @"False", "4F70409E-82B3-41E4-ABE5-A6C38CF84B17"); // Log an Interaction:Form Action:showcountdown
            RockMigrationHelper.UpdateWorkflowActionForm(@"<style>
    @media (max-width: 728px) {
        .actions .btn {
            display: block;
            margin-top: 5px;
        }
    }
</style>

<link rel=""stylesheet"" href=""/Plugins/org_abwe/RockMissions/Scripts/collapser.css"" />", @"<div style=""height: 15px;""></div>
            <script>
                function updateText(el) {
                    $(el).children('span').text($.map($(el).next().find(""input:checked+.label-text,.picker-label""), function (element) { return $(element).text() }).join("", ""));
                }
    
                $('.collapser').each(function () {
                    updateText(this);
                });

                $('.collapser+.collapse').find('input[type=""checkbox""]').on('click',function() { updateText($(this).parents('.collapse').prev()); });
            </script>", "Save^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^^|Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^^|", "", true, "0224BC85-7F42-4097-8053-E552891D71E9", "36E7D928-887A-4E4E-A50A-6EC51B615FD7"); // Log an Interaction:Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "24CB1492-6A9E-4C2F-B765-FCA93DC6A9C5", 0, true, false, true, false, @"", @"", "6A384C47-88AD-4ED0-A802-CCCE671A10CC"); // Log an Interaction:Start:Gather Input:Person and Family
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("36E7D928-887A-4E4E-A50A-6EC51B615FD7", "0224BC85-7F42-4097-8053-E552891D71E9", 11, false, true, false, false, @"", @"", "57C6A4AD-D859-47F7-BCED-8BCCEF46449D"); // Log an Interaction:Start:Gather Input:Form Action
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
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Share a Lead", 5, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "0224BC85-7F42-4097-8053-E552891D71E9", 1, "Share a Lead", "6F0DEF86-B4FF-4A55-A797-40F4FB1261FA"); // Log an Interaction:Start:Share a Lead
            RockMigrationHelper.UpdateWorkflowActionType("9982A30F-3557-4475-B955-E3C7B473CC4E", "Assign a Follow-Up", 6, "E2F3DFC1-415D-45C9-B84E-D91562139FDA", true, true, "", "0224BC85-7F42-4097-8053-E552891D71E9", 1, "Assign Follow-Up", "B7D0EBB3-888F-46B0-86B3-6478B7AB2AD8"); // Log an Interaction:Start:Assign a Follow-Up
            RockMigrationHelper.AddActionTypeAttributeValue("E4574E42-9453-43AA-BD83-30529E6075E2", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Log an Interaction:Start:Set Current Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("E4574E42-9453-43AA-BD83-30529E6075E2", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"50f2598b-4fa8-4fd6-8682-4b5ab0ea4fbd"); // Log an Interaction:Start:Set Current Person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "9392E3D7-A28B-4CD8-8B03-5E147B102EF1", @"False"); // Log an Interaction:Start:Set Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "61E6E1BC-E657-4F00-B2E9-769AAA25B9F7", @"24cb1492-6a9e-4c2f-b765-fca93dc6a9c5"); // Log an Interaction:Start:Set Person:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "DDEFB300-0A4F-4086-99BE-A32761928F5E", @"True"); // Log an Interaction:Start:Set Person:Entity Is Required
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "1246C53A-FD92-4E08-ABDE-9A6C37E70C7B", @"False"); // Log an Interaction:Start:Set Person:Use Id instead of Guid
            RockMigrationHelper.AddActionTypeAttributeValue("FD1128AF-3E57-445A-A801-2CB6FBFDE635", "00D8331D-3055-4531-B374-6B98A9A71D70", @"{{ Entity.PrimaryAlias.Guid }}"); // Log an Interaction:Start:Set Person:Lava Template
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Log an Interaction:Start:Set CompletedOn to Current Date:Active
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"8172e8fa-237f-426c-8fbc-cf37680f1637"); // Log an Interaction:Start:Set CompletedOn to Current Date:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("99112EBA-0CFE-41CE-B131-795885A1A35D", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ 'Now' | Date:'MM/dd/yyyy' }}"); // Log an Interaction:Start:Set CompletedOn to Current Date:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("AE85804B-E2BB-42A9-8674-E2415604A6E6", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Log an Interaction:Start:Gather Input:Active
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
		WHERE [PersonAlias].[Guid] IN (SELECT * FROM STRING_SPLIT('{{ Workflow | Attribute:'PersonandFamily','RawValue' }}', ','))

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
            RockMigrationHelper.AddActionTypeAttributeValue("901782E9-944B-4EE9-BD07-DE816941CC15", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Log an Interaction:Start:Log Interactions:Active
            RockMigrationHelper.AddActionTypeAttributeValue("901782E9-944B-4EE9-BD07-DE816941CC15", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Log an Interaction:Start:Log Interactions:Continue On Error
            RockMigrationHelper.AddActionTypeAttributeValue("6F0DEF86-B4FF-4A55-A797-40F4FB1261FA", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Log an Interaction:Start:Share a Lead:Active
            RockMigrationHelper.AddActionTypeAttributeValue("6F0DEF86-B4FF-4A55-A797-40F4FB1261FA", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/" + SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = '65BE4770-FF21-492B-B17C-E6050AF44091'").ToString() + "?Lead={{ Workflow | Attribute:'PersonandFamily','RawValue' | Split:',' | First }}"); // Log an Interaction:Start:Share a Lead:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("6F0DEF86-B4FF-4A55-A797-40F4FB1261FA", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Log an Interaction:Start:Share a Lead:Processing Options
            RockMigrationHelper.AddActionTypeAttributeValue("B7D0EBB3-888F-46B0-86B3-6478B7AB2AD8", "DF7714A7-6E0B-4EF7-8D65-CD2EC420F829", @"False"); // Log an Interaction:Start:Assign a Follow-Up:Active
            RockMigrationHelper.AddActionTypeAttributeValue("B7D0EBB3-888F-46B0-86B3-6478B7AB2AD8", "48D80FA5-EA12-4C00-B18D-AA5C6741E66D", @"/WorkflowEntry/" + SqlScalar("SELECT [Id] FROM WorkflowType WHERE [Guid] = 'EE8E8ED0-86B4-466B-9ADC-7A5E38D25A01'").ToString() + "?FollowUpWith={{ Workflow | Attribute:'PersonandFamily','RawValue' | Split:',' | First }}"); // Log an Interaction:Start:Assign a Follow-Up:Url|Url Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("B7D0EBB3-888F-46B0-86B3-6478B7AB2AD8", "493F8877-C41E-49B1-8140-9FEB5E87C760", @"0"); // Log an Interaction:Start:Assign a Follow-Up:Processing Options

            #endregion

            

            #region Log an Interaction (Communication)

            RockMigrationHelper.UpdateWorkflowType(false, true, "Log an Interaction (Communication)", "", "D3EA0403-2070-4833-8384-E11F21594900", "Work", "fa fa-list-ol", 28800, true, 0, "EAD317E1-4546-41BE-BCF6-82BD6130C2B4", 0); // Log an Interaction (Communication)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "9C204CD0-1233-41C5-818A-C5DA439445AA", "CommunicationId", "CommunicationId", "", 0, @"", "8DD9725F-FF03-48E1-9072-C8F345321160", false); // Log an Interaction (Communication):CommunicationId
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "9C204CD0-1233-41C5-818A-C5DA439445AA", "VisibleTo", "VisibleTo", "", 1, @"", "2FC3E1BE-FF1D-4DAF-A429-53EA8BF4BD43", false); // Log an Interaction (Communication):VisibleTo
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "309460EF-0CC5-41C6-9161-B3837BA3D374", "Category", "Category", "", 2, @"463e4941-c87d-4dda-b296-a4d799f438e7", "02D59D98-0D8A-47B7-A91A-4C2BE4B5B210", false); // Log an Interaction (Communication):Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Source", "Source", "", 3, @"", "701E7009-AD6C-4183-BFA5-7EC7E154F784", false); // Log an Interaction (Communication):Source
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Medium", "Medium", "", 4, @"", "AD9AE8CC-B2D3-4BED-923F-47783F35BA71", false); // Log an Interaction (Communication):Medium
            RockMigrationHelper.UpdateWorkflowTypeAttribute("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Campaign", "Campaign", "", 5, @"", "5D94A23E-CA69-4D22-AC06-0B1D447AF8B4", false); // Log an Interaction (Communication):Campaign
            RockMigrationHelper.AddAttributeQualifier("8DD9725F-FF03-48E1-9072-C8F345321160", "ispassword", @"False", "9DFE7313-6742-40F1-9036-F80274F19FF0"); // Log an Interaction (Communication):CommunicationId:ispassword
            RockMigrationHelper.AddAttributeQualifier("8DD9725F-FF03-48E1-9072-C8F345321160", "maxcharacters", @"", "9B4534CA-B206-44A3-8F95-2C4FAA0ABC7A"); // Log an Interaction (Communication):CommunicationId:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("8DD9725F-FF03-48E1-9072-C8F345321160", "showcountdown", @"False", "5F025CA8-16CB-451C-BAD0-39B7DAAA37EF"); // Log an Interaction (Communication):CommunicationId:showcountdown
            RockMigrationHelper.AddAttributeQualifier("2FC3E1BE-FF1D-4DAF-A429-53EA8BF4BD43", "ispassword", @"False", "D90C9B43-9F24-4D0B-AF3E-C225F16ACA3A"); // Log an Interaction (Communication):VisibleTo:ispassword
            RockMigrationHelper.AddAttributeQualifier("2FC3E1BE-FF1D-4DAF-A429-53EA8BF4BD43", "maxcharacters", @"", "6D5C0D80-36BD-4B5E-B6A2-1451A895BACD"); // Log an Interaction (Communication):VisibleTo:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("2FC3E1BE-FF1D-4DAF-A429-53EA8BF4BD43", "showcountdown", @"False", "60EE976A-C85E-4A01-A7DA-F9BA4D678FAA"); // Log an Interaction (Communication):VisibleTo:showcountdown
            RockMigrationHelper.AddAttributeQualifier("02D59D98-0D8A-47B7-A91A-4C2BE4B5B210", "entityTypeName", @"Rock.Model.Interaction", "43AFD0CC-5E3E-447C-A444-D91E54986579"); // Log an Interaction (Communication):Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("02D59D98-0D8A-47B7-A91A-4C2BE4B5B210", "qualifierColumn", @"", "17BA7C17-042F-4033-9E3A-C40C8B63909B"); // Log an Interaction (Communication):Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("02D59D98-0D8A-47B7-A91A-4C2BE4B5B210", "qualifierValue", @"", "E12AD628-52EB-43BF-A8F3-D87273B1C6F5"); // Log an Interaction (Communication):Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("701E7009-AD6C-4183-BFA5-7EC7E154F784", "ispassword", @"False", "DA0DEE05-7F91-4EE4-B275-A0EB62903AED"); // Log an Interaction (Communication):Source:ispassword
            RockMigrationHelper.AddAttributeQualifier("701E7009-AD6C-4183-BFA5-7EC7E154F784", "maxcharacters", @"", "7F7E62C9-0AAE-4596-986D-1E8E41E4DFF5"); // Log an Interaction (Communication):Source:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("701E7009-AD6C-4183-BFA5-7EC7E154F784", "showcountdown", @"False", "228CC1D3-9810-4797-92ED-F942E64CFFF3"); // Log an Interaction (Communication):Source:showcountdown
            RockMigrationHelper.AddAttributeQualifier("AD9AE8CC-B2D3-4BED-923F-47783F35BA71", "ispassword", @"False", "72E56595-E426-422F-8CBD-5EA641B8592E"); // Log an Interaction (Communication):Medium:ispassword
            RockMigrationHelper.AddAttributeQualifier("AD9AE8CC-B2D3-4BED-923F-47783F35BA71", "maxcharacters", @"", "00948E69-75E6-4BCC-AFE4-2C431F9287E1"); // Log an Interaction (Communication):Medium:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("AD9AE8CC-B2D3-4BED-923F-47783F35BA71", "showcountdown", @"False", "072283D6-6304-4F1C-8C58-9B9D07C6664F"); // Log an Interaction (Communication):Medium:showcountdown
            RockMigrationHelper.AddAttributeQualifier("5D94A23E-CA69-4D22-AC06-0B1D447AF8B4", "ispassword", @"False", "408B45C0-B5ED-42F8-B847-1651004D9DD4"); // Log an Interaction (Communication):Campaign:ispassword
            RockMigrationHelper.AddAttributeQualifier("5D94A23E-CA69-4D22-AC06-0B1D447AF8B4", "maxcharacters", @"", "E6473A97-028B-4D5F-8A17-C7A8099107BA"); // Log an Interaction (Communication):Campaign:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("5D94A23E-CA69-4D22-AC06-0B1D447AF8B4", "showcountdown", @"False", "3DA3F14F-2817-4927-8928-6007459BA993"); // Log an Interaction (Communication):Campaign:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("EAD317E1-4546-41BE-BCF6-82BD6130C2B4", true, "Start", "", true, 0, "518B047B-484F-473D-AC7B-E6C31543459F"); // Log an Interaction (Communication):Start
            RockMigrationHelper.UpdateWorkflowActionType("518B047B-484F-473D-AC7B-E6C31543459F", "Insert Interactions", 0, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "3AE37A67-837E-499F-9582-341986849F1F"); // Log an Interaction (Communication):Start:Insert Interactions
            RockMigrationHelper.AddActionTypeAttributeValue("3AE37A67-837E-499F-9582-341986849F1F", "F3B9908B-096F-460B-8320-122CF046D1F9", @"-- Get list of channels to log interaction to
DECLARE @componentsToPostIn TABLE (ChannelGuid uniqueidentifier)

INSERT INTO @componentsToPostIn (ChannelGuid)
SELECT value [Guid] FROM string_split('{{ Workflow | Attribute:'VisibleTo','RawValue' }}',',')

-- If general visiblity is checked, only log it to the General component, not others
DECLARE @GeneralVisibility bit = (SELECT 1 FROM @componentsToPostIn WHERE [ChannelGuid] = '41D3B3BC-E03C-4282-871A-0FC87AD12982')
IF @GeneralVisibility = 1 DELETE FROM @componentsToPostIn WHERE [ChannelGuid] != '41D3B3BC-E03C-4282-871A-0FC87AD12982';

DECLARE @FirstResult uniqueidentifier = (SELECT TOP (1) [ChannelGuid] FROM @componentsToPostIn)

-- Create an interaction session for our bulk insert
INSERT INTO [InteractionSession] (CreatedDateTime, CreatedByPersonAliasId, [Guid])
SELECT GETDATE(), Communication.SenderPersonAliasId, NEWID()
FROM Communication WHERE Communication.Id = {{ Workflow | Attribute:'CommunicationId' | AsInteger }}
DECLARE @SessionId int = SCOPE_IDENTITY()

-- Log the first components interactions. If we are logging to multiple interaction channel components, log subsequent channel interactions as a link to the first.

INSERT INTO [Interaction]
    (InteractionDateTime
    ,Operation
    ,InteractionComponentId
    ,InteractionSessionId
    ,EntityId
    ,PersonAliasId
    ,InteractionSummary
    ,CreatedDateTime
    ,[Guid]
    ,[Source]
    ,[Medium]
    ,[Campaign]
    ,[ChannelCustomIndexed1]
    )
    SELECT 
        GETDATE()
        ,FriendlyName
        ,(SELECT [Id] FROM InteractionComponent WHERE [Guid] = @FirstResult) [InteractionComponentId]
        ,@SessionId
        ,CommunicationRecipient.PersonAliasId
        ,[Communication].SenderPersonAliasId
        ,[Communication].Subject
        ,GETDATE()
        ,NEWID()
        ,'{{ Workflow | Attribute:'Source' | SanitizeSql }}'
        ,'{{ Workflow | Attribute:'Medium' | SanitizeSql }}'
        ,'{{ Workflow | Attribute:'Campaign' | SanitizeSql }}'
        ,(SELECT [Id] FROM Category WHERE [Guid] = '{{ Workflow | Attribute:'Category','RawValue' }}')
        FROM [CommunicationRecipient]
        INNER JOIN [Communication] ON [Communication].Id = CommunicationRecipient.CommunicationId
        INNER JOIN [EntityType] ON [CommunicationRecipient].MediumEntityTypeId = EntityType.Id
        WHERE CommunicationId = {{ Workflow | Attribute:'CommunicationId' | AsInteger }}


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
	WHERE [ChannelComponents].[Guid] != @FirstResult AND [Interaction].InteractionSessionId = @SessionId");
            // Log an Interaction (Communication):Start:Insert Interactions:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("3AE37A67-837E-499F-9582-341986849F1F", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Log an Interaction (Communication):Start:Insert Interactions:Active
            RockMigrationHelper.AddActionTypeAttributeValue("3AE37A67-837E-499F-9582-341986849F1F", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Log an Interaction (Communication):Start:Insert Interactions:Continue On Error

            #endregion



            #region Log an Interaction (Bulk)

            RockMigrationHelper.UpdateWorkflowType(false, true, "Log an Interaction (Bulk)", "", "D3EA0403-2070-4833-8384-E11F21594900", "Interaction", "fa fa-list-ol", 28800, true, 0, "592AAE6F-EE1A-4752-A20C-C94D607A4621", 0); // Log an Interaction (Bulk)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Completed By", "CompletedBy", "", 0, @"", "BA39B511-AB5E-4400-B8F0-E673CEC4E427", false); // Log an Interaction (Bulk):Completed By
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "6B6AA175-4758-453F-8D83-FCD8044B5F36", "Completed On", "CompletedOn", "", 1, @"", "A2569BEF-456A-4124-B294-8FF4B019D14B", false); // Log an Interaction (Bulk):Completed On
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "7525C4CB-EE6B-41D4-9B64-A08048D5A5C0", "Type", "Type", "", 2, @"", "36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", false); // Log an Interaction (Bulk):Type
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Summary", "Summary", "", 3, @"", "7D0DCC9F-59D7-4EF1-8151-30105082CB4C", false); // Log an Interaction (Bulk):Summary
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "Communication Body (optional)", "EmailBodyifany", "", 4, @"", "E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", false); // Log an Interaction (Bulk):Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "AC0C8C60-1392-4870-A2D9-EABE17541940", "Visible To", "VisibleTo", "", 5, @"41d3b3bc-e03c-4282-871a-0fc87ad12982", "1A42A499-6EAC-4F0A-B6CF-25B33B84569A", true); // Log an Interaction (Bulk):Visible To
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "309460EF-0CC5-41C6-9161-B3837BA3D374", "Category", "Category", "", 6, @"463e4941-c87d-4dda-b296-a4d799f438e7", "1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", false); // Log an Interaction (Bulk):Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Source", "Source", "", 7, @"", "CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", false); // Log an Interaction (Bulk):Source
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Medium", "Medium", "", 8, @"", "DA76E800-224E-451E-8C5E-154C88AC34BC", false); // Log an Interaction (Bulk):Medium
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Campaign", "Campaign", "", 9, @"", "C97E98AA-4804-4F53-8259-48F46F985A0D", false); // Log an Interaction (Bulk):Campaign
            RockMigrationHelper.UpdateWorkflowTypeAttribute("592AAE6F-EE1A-4752-A20C-C94D607A4621", "9C204CD0-1233-41C5-818A-C5DA439445AA", "EntitySetId", "EntitySetId", "", 10, @"", "3812F91C-D9AB-4AA1-B460-4890E4165516", false); // Log an Interaction (Bulk):EntitySetId
            RockMigrationHelper.AddAttributeQualifier("BA39B511-AB5E-4400-B8F0-E673CEC4E427", "EnableSelfSelection", @"True", "5BF1BD39-6E32-4C5D-BEBC-0EEE57765452"); // Log an Interaction (Bulk):Completed By:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "datePickerControlType", @"Date Picker", "CD9CE32D-AFEB-473F-B6B5-C828AB90A2CE"); // Log an Interaction (Bulk):Completed On:datePickerControlType
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "displayCurrentOption", @"False", "61E97D6B-CE01-4034-A053-0C4D81F881C0"); // Log an Interaction (Bulk):Completed On:displayCurrentOption
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "displayDiff", @"False", "40BB64BC-5D60-4D74-8F45-FE76378B6A45"); // Log an Interaction (Bulk):Completed On:displayDiff
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "format", @"", "8B93803B-9F9D-416F-9532-17CD2B8464A4"); // Log an Interaction (Bulk):Completed On:format
            RockMigrationHelper.AddAttributeQualifier("A2569BEF-456A-4124-B294-8FF4B019D14B", "futureYearCount", @"", "FAA90798-8928-4091-A0CC-21CEB9B15D10"); // Log an Interaction (Bulk):Completed On:futureYearCount
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "fieldtype", @"ddl", "26F57F9F-9AC3-48CB-886D-0E1E9880BFBD"); // Log an Interaction (Bulk):Type:fieldtype
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "repeatColumns", @"", "C943CAFF-0D85-4D33-A119-2A5C0B5E06C4"); // Log an Interaction (Bulk):Type:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", "values", @"Phone Call,Email,Text,Meeting,Card", "55D493EA-7A8A-46DB-A0EE-BE707CC3DF2D"); // Log an Interaction (Bulk):Type:values
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "allowhtml", @"False", "707CBA99-9F68-4D75-A7E7-BBB14DD3430A"); // Log an Interaction (Bulk):Summary:allowhtml
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "maxcharacters", @"500", "982D09B1-E765-4C10-8FAD-522A84C43103"); // Log an Interaction (Bulk):Summary:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "numberofrows", @"", "804EDF92-A895-49B8-B158-063B510EDE6B"); // Log an Interaction (Bulk):Summary:numberofrows
            RockMigrationHelper.AddAttributeQualifier("7D0DCC9F-59D7-4EF1-8151-30105082CB4C", "showcountdown", @"False", "EDC16D49-1C00-4C4E-8DEE-966DDA8C6C08"); // Log an Interaction (Bulk):Summary:showcountdown
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "allowhtml", @"True", "F9308F47-0675-4FE1-B777-413EFE2C53AB"); // Log an Interaction (Bulk):Communication Body (optional):allowhtml
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "maxcharacters", @"", "92F08065-1B27-4C7F-BCB5-1BE73FB15A76"); // Log an Interaction (Bulk):Communication Body (optional):maxcharacters
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "numberofrows", @"10", "1AFA08E5-B275-4774-926F-45710A20EE40"); // Log an Interaction (Bulk):Communication Body (optional):numberofrows
            RockMigrationHelper.AddAttributeQualifier("E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", "showcountdown", @"False", "B2BAFD36-A06A-4D25-A502-E531A98BC86A"); // Log an Interaction (Bulk):Communication Body (optional):showcountdown
            RockMigrationHelper.AddAttributeQualifier("1A42A499-6EAC-4F0A-B6CF-25B33B84569A", "interactionChannel", SqlScalar("SELECT Id FROM InteractionChannel WHERE [Guid] ='D1853AE1-145F-4AE1-84CF-E7F62024B121'").ToString(), "B1F25BFF-8543-4590-BF23-394BE0349830"); // Log an Interaction (Bulk):Visible To:interactionChannel
            RockMigrationHelper.AddAttributeQualifier("1A42A499-6EAC-4F0A-B6CF-25B33B84569A", "repeatColumns", @"", "18CCA55A-89AF-43D0-959C-A8FB469939FA"); // Log an Interaction (Bulk):Visible To:repeatColumns
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "entityTypeName", @"Rock.Model.Interaction", "D10DF227-4BBA-4625-B22D-F554EBFECAA2"); // Log an Interaction (Bulk):Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "qualifierColumn", @"", "41CFF221-4E93-46DC-AE5D-AFCC62668075"); // Log an Interaction (Bulk):Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", "qualifierValue", @"", "196A7535-FE28-4710-B136-224EC03FF075"); // Log an Interaction (Bulk):Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "ispassword", @"False", "6FB0B10A-F4AA-44EF-BCA5-7884817BA851"); // Log an Interaction (Bulk):Source:ispassword
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "maxcharacters", @"", "BDCB8C7A-3C70-4818-9EDC-F785A0FDE3FE"); // Log an Interaction (Bulk):Source:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", "showcountdown", @"False", "DECA3BBB-F01A-4E3F-AA5C-5D4E5251BDC6"); // Log an Interaction (Bulk):Source:showcountdown
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "ispassword", @"False", "446B0359-F846-4B9F-9A0D-BD874C0DD1D0"); // Log an Interaction (Bulk):Medium:ispassword
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "maxcharacters", @"", "30CBB64B-CDFA-40F3-92AB-90282A536719"); // Log an Interaction (Bulk):Medium:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("DA76E800-224E-451E-8C5E-154C88AC34BC", "showcountdown", @"False", "C1CC51C9-C313-4E46-9015-62E83745CB30"); // Log an Interaction (Bulk):Medium:showcountdown
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "ispassword", @"False", "270F80C4-F79A-43C8-824D-35514D67E882"); // Log an Interaction (Bulk):Campaign:ispassword
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "maxcharacters", @"", "2370F1A6-3A5A-4350-B956-FF2F03A20367"); // Log an Interaction (Bulk):Campaign:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("C97E98AA-4804-4F53-8259-48F46F985A0D", "showcountdown", @"False", "A83AEAB8-B300-4D2E-9370-49F9E4494C63"); // Log an Interaction (Bulk):Campaign:showcountdown
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "ispassword", @"False", "19178C09-F63A-4210-AA36-947971F50932"); // Log an Interaction (Bulk):EntitySetId:ispassword
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "maxcharacters", @"", "F67FFA5C-32BF-4FBA-AFB9-DA89F1EF9864"); // Log an Interaction (Bulk):EntitySetId:maxcharacters
            RockMigrationHelper.AddAttributeQualifier("3812F91C-D9AB-4AA1-B460-4890E4165516", "showcountdown", @"False", "6CDB278B-B291-4F36-BBC8-FF6C18A78DA7"); // Log an Interaction (Bulk):EntitySetId:showcountdown
            RockMigrationHelper.UpdateWorkflowActivityType("592AAE6F-EE1A-4752-A20C-C94D607A4621", true, "Start", "", true, 0, "E32D4B55-6E0F-44C6-9182-4577B05FF650"); // Log an Interaction (Bulk):Start
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
</script>", "Save^fdc397cd-8b4a-436e-bea1-bce2e6717c03^^Your information has been submitted successfully.|Share a Lead^53ca2cb9-8bfa-450c-a3aa-fd3f3fd3bc8a^^|Assign Follow-Up^3c026b37-29d4-47cb-bb6e-da43afe779fe^^", "", true, "", "46E336DD-8A8F-4403-A496-03438C709AB7"); // Log an Interaction (Bulk):Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "BA39B511-AB5E-4400-B8F0-E673CEC4E427", 0, true, false, true, false, @"", @"", "1CEC080C-AC71-4E91-9E92-788880B21378"); // Log an Interaction (Bulk):Start:Gather Input:Completed By
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "A2569BEF-456A-4124-B294-8FF4B019D14B", 2, true, false, true, false, @"", @"", "E87F6DE2-834F-41F9-BBB8-8AAB7DD54D42"); // Log an Interaction (Bulk):Start:Gather Input:Completed On
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "36A722A5-D0CE-4FEB-AEF4-D67F8401EB34", 3, true, false, true, false, @"", @"", "91F0739F-EC54-4FBC-AD5C-8D7C984BFF8F"); // Log an Interaction (Bulk):Start:Gather Input:Type
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "7D0DCC9F-59D7-4EF1-8151-30105082CB4C", 4, true, false, true, false, @"", @"", "F260609B-4F42-4273-9BEE-9F5B13026F70"); // Log an Interaction (Bulk):Start:Gather Input:Summary
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "E20EBE39-2A0C-42E8-A6B4-9D72F67FC2A9", 6, true, false, false, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseBody""><i class=""fa fa-caret-down""></i>Communication Body</a>
<div class=""collapse"" id=""collapseBody"">", @"</div>", "A35258D3-3506-4CD4-96F7-32D3AA01DFDC"); // Log an Interaction (Bulk):Start:Gather Input:Communication Body (optional)
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "1A42A499-6EAC-4F0A-B6CF-25B33B84569A", 1, true, false, true, false, @"<!--<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseDepartments""><i class=""fa fa-caret-down""></i>Visible To: <span>All Departments</span></a>
<div class=""collapse"" id=""collapseDepartments"">-->", @"<!--</div>-->", "693A60E4-45C1-46E0-A5A7-97A8433ED211"); // Log an Interaction (Bulk):Start:Gather Input:Visible To
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "1E05C074-A8F4-48A2-B3AF-EA3E95AD07C4", 5, true, false, true, true, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseCategories""><i class=""fa fa-caret-down""></i>Category: <span>General</span></a>
<div class=""collapse"" id=""collapseCategories"">", @"</div>", "110A4FAA-1421-4050-BA59-732E2E4AA8E7"); // Log an Interaction (Bulk):Start:Gather Input:Category
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "CF89EF1E-CD3A-4845-8759-5D8DFCFFE472", 7, true, false, false, false, @"<a class=""collapser collapsed"" collapsed data-toggle=""collapse"" href=""#collapseSourceCode""><i class=""fa fa-caret-down""></i>UTM</a>
<div class=""collapse"" id=""collapseSourceCode"">", @"", "1804D4C4-5E19-4C6C-9433-FB37B3287A8E"); // Log an Interaction (Bulk):Start:Gather Input:Source
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "DA76E800-224E-451E-8C5E-154C88AC34BC", 8, true, false, false, false, @"", @"", "D87D7586-C6C1-4030-8472-E22B36C69002"); // Log an Interaction (Bulk):Start:Gather Input:Medium
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "C97E98AA-4804-4F53-8259-48F46F985A0D", 9, true, false, false, false, @"", @"</div>", "1ED49C31-4C16-489C-972D-C6B51FF8345E"); // Log an Interaction (Bulk):Start:Gather Input:Campaign
            RockMigrationHelper.UpdateWorkflowActionFormAttribute("46E336DD-8A8F-4403-A496-03438C709AB7", "3812F91C-D9AB-4AA1-B460-4890E4165516", 10, false, true, false, false, @"", @"", "2FF13BB0-7E80-4B90-AA19-7BA05ABDE683"); // Log an Interaction (Bulk):Start:Gather Input:EntitySetId
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Set Current Person", 0, "24B7D5E6-C30F-48F4-9D7E-AF45A342CF3A", true, false, "", "", 1, "", "CC262870-6E1D-4A38-96E1-A8C2F8E862BA"); // Log an Interaction (Bulk):Start:Set Current Person
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Set CompletedOn to Current Date", 1, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "51FED126-27A1-44EA-97B9-BB9EE05194B2"); // Log an Interaction (Bulk):Start:Set CompletedOn to Current Date
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Gather Input", 2, "486DC4FA-FCBC-425F-90B0-E606DA8A9F68", true, false, "46E336DD-8A8F-4403-A496-03438C709AB7", "", 1, "", "9800F253-719F-4023-B2EB-4090082CE6B1"); // Log an Interaction (Bulk):Start:Gather Input
            RockMigrationHelper.UpdateWorkflowActionType("E32D4B55-6E0F-44C6-9182-4577B05FF650", "Insert Interactions", 3, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "2C954467-3F4C-467E-8819-7E2948614655"); // Log an Interaction (Bulk):Start:Insert Interactions
            RockMigrationHelper.AddActionTypeAttributeValue("CC262870-6E1D-4A38-96E1-A8C2F8E862BA", "DE9CB292-4785-4EA3-976D-3826F91E9E98", @"False"); // Log an Interaction (Bulk):Start:Set Current Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("CC262870-6E1D-4A38-96E1-A8C2F8E862BA", "BBED8A83-8BB2-4D35-BAFB-05F67DCAD112", @"ba39b511-ab5e-4400-b8f0-e673cec4e427"); // Log an Interaction (Bulk):Start:Set Current Person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Log an Interaction (Bulk):Start:Set CompletedOn to Current Date:Active
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"a2569bef-456a-4124-b294-8ff4b019d14b"); // Log an Interaction (Bulk):Start:Set CompletedOn to Current Date:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("51FED126-27A1-44EA-97B9-BB9EE05194B2", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ 'Now' | Date:'MM/dd/yyyy' }}"); // Log an Interaction (Bulk):Start:Set CompletedOn to Current Date:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("9800F253-719F-4023-B2EB-4090082CE6B1", "234910F2-A0DB-4D7D-BAF7-83C880EF30AE", @"False"); // Log an Interaction (Bulk):Start:Gather Input:Active
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
	WHERE [ChannelComponents].[Guid] != @FirstResult AND [Interaction].InteractionSessionId = @SessionId"); // Log an Interaction (Bulk):Start:Insert Interactions:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("2C954467-3F4C-467E-8819-7E2948614655", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Log an Interaction (Bulk):Start:Insert Interactions:Active
            RockMigrationHelper.AddActionTypeAttributeValue("2C954467-3F4C-467E-8819-7E2948614655", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Log an Interaction (Bulk):Start:Insert Interactions:Continue On Error

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


            // Delete Page Interaction Details from Site:Rock RMS
            RockMigrationHelper.DeletePage("7796B670-CA8D-4DDA-AF36-1AF036E5A2AE"); //  Page: Interaction Details, Layout: PersonDetail, Site: Rock RMS

            // Delete PageContext for Page:Interaction Details, Entity: Rock.Model.Person, Parameter: {PersonId}
            RockMigrationHelper.DeletePageContext("21B6C841-E91C-4548-B74C-1BBBE0E53AB4");

        }
    }
}
