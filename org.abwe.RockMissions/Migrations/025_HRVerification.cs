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
    [MigrationNumber(25, "1.12.0")]
    class HRVerification : Migration
    {
        public override void Up()
        {
            // HR verification
            Sql(@"INSERT INTO [Attribute] ([IsSystem],[FieldTypeId],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Key],[Name],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid],[CreatedDateTime],[ModifiedDateTime],[ForeignKey],[IconCssClass],[AllowSearch],[ForeignGuid],[ForeignId],[IsIndexEnabled],[IsAnalytic],[IsAnalyticHistory],[IsActive],[EnableHistory],[PreHtml],[PostHtml],[AbbreviatedName],[ShowOnBulk],[IsPublic])
                VALUES
                (0, 11, 478, N'StepTypeId', (SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'), N'HR Verification', N'HR Verification', N'The date HR verified this person is ready to leave for the field.', 0, 1, N'', 0, 0, '{9c4632af-7111-4138-aa7b-c64187618708}', GETDATE(), GETDATE(), NULL, N'', 0, NULL, NULL, 0, 0, 0, 1, 0, N'', N'', N'HR Verification', 0, 0)");
            // Update attribute for pledges
            Sql("UPDATE [Attribute] SET [FieldTypeId] = (SELECT [Id] FROM [FieldType] WhERE [Guid] = '3EE69CBC-35CE-4496-88CC-8327A447603F') WHERE [Guid] = 'c3d80aba-52b9-4587-a10f-337eeef4faa0'");
            
            // Add Block Steps Timeline to Page: Steps, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "CB9ABA3B-6962-4A42-BDA1-EA71B7309232".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "46A95A66-8FAC-4327-837D-EE846A424982".AsGuid(), "Steps Timeline", "SectionC1", @"", @"", 0, "86499AEF-9859-4992-9168-938A91F2CA7E");


            // Add Block Attribute Value
            //   Block: Steps Timeline
            //   BlockType: Steps Timeline
            //   Block Location: Page=Steps, Site=Rock RMS
            //   Attribute: Step Entry Page
            //   Attribute Value: 7a04966a-8e4e-49ea-a03c-7dd4b52a7b28
            RockMigrationHelper.AddBlockAttributeValue("86499AEF-9859-4992-9168-938A91F2CA7E", "5D341011-9CC5-46A5-9ED9-998FE874B743", @"7a04966a-8e4e-49ea-a03c-7dd4b52a7b28");

            // Add Block Attribute Value
            //   Block: Steps Timeline
            //   BlockType: Steps Timeline
            //   Block Location: Page=Steps, Site=Rock RMS
            //   Attribute: StepTypes
            //   Attribute Value: 8,9,16
            RockMigrationHelper.AddBlockAttributeValue("86499AEF-9859-4992-9168-938A91F2CA7E", "5644C455-2029-4B3A-ABA3-F2A0F0866D5B", @"8,9,16");


            // Update Order for Page: Steps,  Zone: SectionC1,  Block: Steps Timeline
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '86499AEF-9859-4992-9168-938A91F2CA7E'");

            // Update Order for Page: Steps,  Zone: SectionC1,  Block: Steps
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '46E5C15A-44A5-4FB3-8CE8-572FB0D85367'");

            // Ministry summary block order
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '06AF35BE-8252-4B45-A076-7D41A9A7A527'");
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '4CC50BE8-72ED-43E0-8D11-7E2A590453CC'");
        }

        public override void Down()
        {

        }
    }
}
