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
    [MigrationNumber(24, "1.12.0")]
    class MissionaryData : Migration
    {
        public override void Up()
        {
            // Add Ministry Summary block

            // Add Block Ministry Summary to Layout: PersonDetail, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, null, "F66758C6-3E3D-4598-AF4C-B317047B5987".AsGuid(), "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "19B61D65-37E3-459F-A44F-DEF0089118A3".AsGuid(), "Ministry Summary", "FamilyDetail", @"", @"", 0, "06AF35BE-8252-4B45-A076-7D41A9A7A527");

            // Add/Update HtmlContent for Block: Ministry Summary
            RockMigrationHelper.UpdateHtmlContentBlock("06AF35BE-8252-4B45-A076-7D41A9A7A527", @"{% include '/Plugins/org_abwe/RockMissions/Lava/MinistrySummary.lava' %}", "63C977B6-C70F-4DE2-910D-3E2D4E113A82");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Cache Duration
            //   Attribute Value: 0
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "4DFDB295-6D0F-40A1-BEF9-7B70C56F66C4", @"0");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Require Approval
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "EC2B701B-4C1D-4F3F-9C77-A73C75D7FF7A", @"False");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Enable Versioning
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "7C1CE199-86CF-4EAE-8AB3-848416A72C58", @"False");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Start in Code Editor mode
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "0673E015-F8DD-4A52-B380-C758011331B2", @"True");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Image Root Folder
            //   Attribute Value: ~/Content
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "26F3AFC6-C05B-44A4-8593-AFE1D9969B0E", @"~/Content");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: User Specific Folders
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "9D3E4ED9-1BEF-4547-B6B0-CE29FE3835EE", @"False");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Document Root Folder
            //   Attribute Value: ~/Content
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "3BDB8AED-32C5-4879-B1CB-8FC7C8336534", @"~/Content");


            // Add/Update PageContext for Page:Timelines, Entity: Rock.Model.Person, Parameter: PersonId
            RockMigrationHelper.UpdatePageContext("18E2C178-DD5D-4031-960A-71994057FDE4", "Rock.Model.Person", "PersonId", "E2D7658C-CB40-4995-8B4E-84FFEDA49B20");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Enabled Lava Commands
            //   Attribute Value: RockEntity
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "7146AC24-9250-4FC4-9DF2-9803B9A84299", @"RockEntity");

            // Add Block Attribute Value
            //   Block: Ministry Summary
            //   BlockType: HTML Content
            //   Block Location: Layout=PersonDetail, Site=Rock RMS
            //   Attribute: Is Secondary Block
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("06AF35BE-8252-4B45-A076-7D41A9A7A527", "04C15DC1-DFB6-4D63-A7BC-0507D0E33EF4", @"False");

            // Change Employment attribute block to read Employment (non-ABWE)
            RockMigrationHelper.AddBlockAttributeValue("46D254C2-5A36-4F99-97A3-45DA8A49DB90", "ADBFBED7-2A61-49ED-93EC-AF48B0247F34", "Employment (non-ABWE)");

            // Delete Visit Information block
            RockMigrationHelper.DeleteBlock("8E86FDCD-4189-4EA4-8370-24ABD6463516");

            // Deactivate certain Family Analytics attributes related to attendance or eRA
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = 'CE5739C5-2156-E2AB-48E5-1337C38B935E'");
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = 'A106610C-A7A1-469E-4097-9DE6400FDFC2'");
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = '4711D67E-7526-9582-4A8E-1CD7BBE1B3A2'");
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = 'AB12B3B0-55B8-D6A5-4C1F-DB9CCB2C4342'");
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = '5F4C6462-018E-D19C-4AB0-9843CB21C57E'");
            Sql("UPDATE [Attribute] SET [IsActive] = 0 WHERE [Guid] = '45A1E978-DC5B-CFA1-4AF4-EA098A24C914'");


            // Add Block Financial Information to Page: Extended Attributes, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "1C737278-4CBA-404B-B6B3-E3F0E05AB5FE".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "D70A59DC-16BE-43BE-9880-59598FA7A94C".AsGuid(), "Financial Information", "SectionB2", @"", @"", 3, "D2753991-285C-4BB2-9718-9CD513805BB1");


            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Attribute Values
            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '8DA21ED3-E4BC-483C-8B22-A041FEEE8FF4'");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Childhood Information
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '441F849F-37C2-4709-B9BB-417204AF3168'");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Financial Information
            Sql(@"UPDATE [Block] SET [Order] = 3 WHERE [Guid] = 'D2753991-285C-4BB2-9718-9CD513805BB1'");

            // Add Block Attribute Value
            //   Block: Financial Information
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Category
            //   Attribute Value: 9f4dee29-6246-4b63-a7f3-b14d81780377
            RockMigrationHelper.AddBlockAttributeValue("D2753991-285C-4BB2-9718-9CD513805BB1", "EC43CF32-3BDF-4544-8B6A-CE9208DD7C81", @"9f4dee29-6246-4b63-a7f3-b14d81780377");

            // Add Block Attribute Value
            //   Block: Financial Information
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Use Abbreviated Name
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("D2753991-285C-4BB2-9718-9CD513805BB1", "51693680-B03C-468B-A771-CD8C103D0B1B", @"False");

            // Add Block Attribute Value
            //   Block: Financial Information
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Show Category Names as Separators
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("D2753991-285C-4BB2-9718-9CD513805BB1", "EF57237E-BA12-488A-9585-78466E4C3DB5", @"False");


            // Add family attributes
            // Entity: Rock.Model.Group Attribute: Ministry Summary
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.Group", "C28C7BF3-A552-4D77-9408-DEDCF760CED0", "GroupTypeId", "10", "Ministry Summary", "Ministry Summary", @"", 31057, @"", "75EAC4F3-3E4F-4A56-8AA1-FCFF3024ED30", "MinistrySummary");

            // Entity: Rock.Model.Group Attribute: Lives In
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.Group", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "GroupTypeId", "10", "Lives In", "Lives In", @"", 31058, @"", "0F007A83-4824-427A-A8E1-26AB0165FAA8", "LivesIn");

            // Entity: Rock.Model.Group Attribute: Serves In
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.Group", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "GroupTypeId", "10", "Serves In", "Serves In", @"", 31059, @"", "9F5641A6-4546-490C-9F69-DD4D02AF7160", "ServesIn");

            // Entity: Rock.Model.Group Attribute: Security Override
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.Group", "59D5A94C-94A0-4630-B80A-BB25697D74C7", "GroupTypeId", "10", "Security Override", "Security Override", @"", 31060, @"", "575EEA39-AA39-43DE-BB45-CA69A102DA38", "SecurityOverride");

            // Qualifier for attribute: MinistrySummary
            RockMigrationHelper.UpdateAttributeQualifier("75EAC4F3-3E4F-4A56-8AA1-FCFF3024ED30", "allowhtml", @"False", "A59B0FD4-C4D6-4642-A5B1-50245750295E");
            // Qualifier for attribute: MinistrySummary
            RockMigrationHelper.UpdateAttributeQualifier("75EAC4F3-3E4F-4A56-8AA1-FCFF3024ED30", "maxcharacters", @"", "394A8997-A523-4D55-93F9-BC8C7A2A65CC");
            // Qualifier for attribute: MinistrySummary
            RockMigrationHelper.UpdateAttributeQualifier("75EAC4F3-3E4F-4A56-8AA1-FCFF3024ED30", "numberofrows", @"", "3C2FA30D-9423-4619-8D88-5969C4C517D3");
            // Qualifier for attribute: MinistrySummary
            RockMigrationHelper.UpdateAttributeQualifier("75EAC4F3-3E4F-4A56-8AA1-FCFF3024ED30", "showcountdown", @"False", "F122FAA7-B77B-461B-8F43-5B0FEFE433DA");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "AllowAddingNewValues", @"False", "149B5D61-FF91-46D1-8044-954412FE098C");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "allowmultiple", @"False", "1A1C7116-5705-4264-A158-8CEE21F94A68");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "definedtype", @"45", "2644B01A-B4DA-4125-8CFC-430328522F80");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "displaydescription", @"True", "7EA388EC-C35A-4DFF-9DAF-0E022A87C952");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "enhancedselection", @"True", "61C17671-4052-4830-B822-B7A769DF259C");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "includeInactive", @"False", "013EDA56-E966-44DF-8C9A-E5FB470F0F53");
            // Qualifier for attribute: LivesIn
            RockMigrationHelper.UpdateAttributeQualifier("0F007A83-4824-427A-A8E1-26AB0165FAA8", "RepeatColumns", @"", "4FB06BFF-C696-466F-9892-6485C95D978E");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "AllowAddingNewValues", @"False", "6E9D1778-E20E-44C8-BEED-96D977DED435");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "allowmultiple", @"True", "347AE493-33AD-402E-B44D-C858D4F23890");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "definedtype", @"45", "6343C4EA-5AF5-4FD5-B51D-A2BD4C9C6605");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "displaydescription", @"True", "2CE9A1F9-003F-46E9-9B17-4CB8D67EFC26");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "enhancedselection", @"True", "F1F4C7F8-FD2A-49B2-BD66-9D343E4329A5");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "includeInactive", @"False", "1E661D78-A51E-47F3-B481-D522052C4EF8");
            // Qualifier for attribute: ServesIn
            RockMigrationHelper.UpdateAttributeQualifier("9F5641A6-4546-490C-9F69-DD4D02AF7160", "RepeatColumns", @"", "E87A6B12-537F-4EEF-BAC1-2E30947619ED");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "AllowAddingNewValues", @"False", "B89E9679-6951-44F8-ACCC-9FC75A9B34FF");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "allowmultiple", @"False", "16F50077-BCED-46DC-B179-487C0C662ADB");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "definedtype", SqlScalar("SELECT [Id] FROM DefinedType WHERE [Guid] = 'A4EFF1B9-E66E-4197-BCCD-104423399580'").ToString(), "BF26D2C4-AFCE-4024-9BAD-872D01B2C112");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "displaydescription", @"True", "F7650505-22BC-4810-BE9C-386F30AFDABA");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "enhancedselection", @"False", "F09E1E9F-2D41-4159-BC87-6CB9674AD390");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "includeInactive", @"False", "C6BE4BA1-3F07-404E-8F7E-168ECE53F37B");
            // Qualifier for attribute: SecurityOverride
            RockMigrationHelper.UpdateAttributeQualifier("575EEA39-AA39-43DE-BB45-CA69A102DA38", "RepeatColumns", @"", "AB92CEF8-DE66-4A36-AC7F-42B0CE9CCE60");

            // Change field assigment step type name to assignment
            Sql("UPDATE StepType SET [Name] = 'Assignment' WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'");
            // Change pledge recurring attribute type to currency
            RockMigrationHelper.UpdateEntityAttribute("Rock.Model.FinancialPledge", "3EE69CBC-35CE-4496-88CC-8327A447603F", null, null, "Recurring Amount", "The recurring amount of this pledge", 0, "", "c3d80aba-52b9-4587-a10f-337eeef4faa0");
            // Set Books Step Color
            Sql("UPDATE StepType SET [HighlightColor] = '#ca5a04' WHERE [Guid] = '3036b703-b8fb-4f6f-9ec0-302b5b0f6c67'");
            // Set Course Step Color
            Sql("UPDATE StepType SET [HighlightColor] = '#008a89' WHERE [Guid] = '7d10fe63-8df4-454c-92ca-b745708192b6'");
            // Add Language School Step type
            Sql(@"
-- Step Types

INSERT [dbo].[StepType] (
    [StepProgramId]
    ,[Name]
    ,[Description]
    ,[IconCssClass]
    ,[AllowMultiple]
    ,[HasEndDate]
    ,[ShowCountOnBadge]
    ,[AllowManualEditing]
    ,[HighlightColor]
    ,[IsActive]
    ,[Order]
    ,[CreatedDateTime]
    ,[ModifiedDateTime]
    ,[Guid]
    ,[IsDateRequired]
) VALUES
    (
        (SELECT Id FROM StepProgram WHERE [Guid] = 'a18be29d-e42c-428e-9ae4-0ac57e4eed3e') -- Personal Development
        ,'Language School'
        ,''
        ,'fa fa-graduation-cap'
        ,1
        ,1
        ,1
        ,1
        ,'#a3568a'
        ,1
        ,3
        ,GETDATE()
        ,GETDATE()
        ,'c286d2fb-41bf-4de6-870e-affaf4bb3b01'
        ,1
    )

-- Attributes

INSERT INTO [Attribute] ([IsSystem],[FieldTypeId],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Key],[Name],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid],[CreatedDateTime],[ModifiedDateTime],[ForeignKey],[IconCssClass],[AllowSearch],[ForeignGuid],[ForeignId],[IsIndexEnabled],[IsAnalytic],[IsAnalyticHistory],[IsActive],[EnableHistory],[PreHtml],[PostHtml],[AbbreviatedName],[ShowOnBulk],[IsPublic])
VALUES
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'c286d2fb-41bf-4de6-870e-affaf4bb3b01'),N'Location',N'Location',N'Where a person attended language school. This could include city, country, name of school, etc.',0,1,N'',0,0,'{76ffab77-009e-4acc-8c71-6d17f59ec5d7}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Location',0,0)
");
            // Add Field address type as option for families
            Sql("INSERT INTO [GroupTypeLocationType] (GroupTypeId, LocationTypeValueId) VALUES (10, (SELECT [Id] FROM DefinedValue WHERE [Guid] = 'F5C1BD2D-4D2D-461B-8CF4-922104460E97'))");
        }

        public override void Down()
        {

        }
    }
}
