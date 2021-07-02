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
    [MigrationNumber(29, "1.12.0")]
    class StepsGrids : Migration
    {
        public override void Up()
        {
            // Add Block Steps Timeline to Page: Steps, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "CB9ABA3B-6962-4A42-BDA1-EA71B7309232".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "46A95A66-8FAC-4327-837D-EE846A424982".AsGuid(), "Steps Timeline", "SectionC1", @"", @"", 0, "86499AEF-9859-4992-9168-938A91F2CA7E");

            // Add Block Career to Page: Timelines, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "18E2C178-DD5D-4031-960A-71994057FDE4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "5D5EB7BA-A9CE-4801-8168-6CA8ECD354D4".AsGuid(), "Career", "SubNavigation", @"", @"", 1, "C50A41DB-6925-44B6-856E-27ADE9C8D84E");

            // Add Block Travel to Page: Timelines, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "18E2C178-DD5D-4031-960A-71994057FDE4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "5D5EB7BA-A9CE-4801-8168-6CA8ECD354D4".AsGuid(), "Travel", "SubNavigation", @"", @"", 2, "6993B7F8-7A0E-4CCD-8602-3834D28862B2");

            // Add Block Clearances to Page: Timelines, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "18E2C178-DD5D-4031-960A-71994057FDE4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "5D5EB7BA-A9CE-4801-8168-6CA8ECD354D4".AsGuid(), "Clearances", "SubNavigation", @"", @"", 3, "EF7FCA50-B64F-47DE-B940-8888E65F97E5");

            // Update Order for Page: Steps,  Zone: SectionC1,  Block: Steps Timeline
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '86499AEF-9859-4992-9168-938A91F2CA7E'");

            // Update Order for Page: Steps,  Zone: SectionC1,  Block: Steps
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '46E5C15A-44A5-4FB3-8CE8-572FB0D85367'");


            // Update Order for Page: Timelines,  Zone: SubNavigation,  Block: Career
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = 'C50A41DB-6925-44B6-856E-27ADE9C8D84E'");

            // Update Order for Page: Timelines,  Zone: SubNavigation,  Block: Clearances
            Sql(@"UPDATE [Block] SET [Order] = 3 WHERE [Guid] = 'EF7FCA50-B64F-47DE-B940-8888E65F97E5'");

            // Update Order for Page: Timelines,  Zone: SubNavigation,  Block: Steps Timeline
            Sql(@"UPDATE [Block] SET [Order] = 0 WHERE [Guid] = '8995F48B-CEA0-439C-924C-ADF96ACC93CC'");

            // Update Order for Page: Timelines,  Zone: SubNavigation,  Block: Travel
            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '6993B7F8-7A0E-4CCD-8602-3834D28862B2'");


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
            RockMigrationHelper.AddBlockAttributeValue("86499AEF-9859-4992-9168-938A91F2CA7E", "5644C455-2029-4B3A-ABA3-F2A0F0866D5B", SqlScalar($"SELECT STRING_AGG([Id],',') FROM StepType WHERE [Guid] IN ('{SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_BOOK}','{SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_COURSE}','{SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_LANGUAGE_SCHOOL}')").ToString());


            // Add Block Attribute Value
            //   Block: Career
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Show Campus Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("C50A41DB-6925-44B6-856E-27ADE9C8D84E", "5297FCCB-722B-4D96-82F8-480B4D938E89", @"False");

            // Add Block Attribute Value
            //   Block: Career
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Entry Page
            //   Attribute Value: 6a4f75a3-95d1-43d5-aaf7-93cec040f346
            RockMigrationHelper.AddBlockAttributeValue("C50A41DB-6925-44B6-856E-27ADE9C8D84E", "B6AF94FF-6D7F-4FFC-8DA7-A78519EF7500", @"6a4f75a3-95d1-43d5-aaf7-93cec040f346");

            // Add Block Attribute Value
            //   Block: Career
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Program
            //   Attribute Value: 59C990ED-F5B4-4379-A926-852CBA08FA03
            RockMigrationHelper.AddBlockAttributeValue("C50A41DB-6925-44B6-856E-27ADE9C8D84E", "B4E07CC9-53E0-47CF-AC22-10F2085547A3", @"59C990ED-F5B4-4379-A926-852CBA08FA03");

            // Add Block Attribute Value
            //   Block: Career
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row
            //   Attribute Value: 5
            RockMigrationHelper.AddBlockAttributeValue("C50A41DB-6925-44B6-856E-27ADE9C8D84E", "FBAB162B-556B-44DA-B830-D629529C0542", @"5");

            // Add Block Attribute Value
            //   Block: Career
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row Mobile
            //   Attribute Value: 1
            RockMigrationHelper.AddBlockAttributeValue("C50A41DB-6925-44B6-856E-27ADE9C8D84E", "9E4F6CB9-0228-4D37-BDED-A33FD96EBC75", @"1");

            // Add Block Attribute Value
            //   Block: Travel
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row Mobile
            //   Attribute Value: 1
            RockMigrationHelper.AddBlockAttributeValue("6993B7F8-7A0E-4CCD-8602-3834D28862B2", "9E4F6CB9-0228-4D37-BDED-A33FD96EBC75", @"1");

            // Add Block Attribute Value
            //   Block: Travel
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Program
            //   Attribute Value: 38104628-DBCC-4719-BED5-966BE9449D5A
            RockMigrationHelper.AddBlockAttributeValue("6993B7F8-7A0E-4CCD-8602-3834D28862B2", "B4E07CC9-53E0-47CF-AC22-10F2085547A3", @"38104628-DBCC-4719-BED5-966BE9449D5A");

            // Add Block Attribute Value
            //   Block: Travel
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Entry Page
            //   Attribute Value: 6a4f75a3-95d1-43d5-aaf7-93cec040f346
            RockMigrationHelper.AddBlockAttributeValue("6993B7F8-7A0E-4CCD-8602-3834D28862B2", "B6AF94FF-6D7F-4FFC-8DA7-A78519EF7500", @"6a4f75a3-95d1-43d5-aaf7-93cec040f346");

            // Add Block Attribute Value
            //   Block: Travel
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row
            //   Attribute Value: 5
            RockMigrationHelper.AddBlockAttributeValue("6993B7F8-7A0E-4CCD-8602-3834D28862B2", "FBAB162B-556B-44DA-B830-D629529C0542", @"5");

            // Add Block Attribute Value
            //   Block: Travel
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Show Campus Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("6993B7F8-7A0E-4CCD-8602-3834D28862B2", "5297FCCB-722B-4D96-82F8-480B4D938E89", @"False");

            // Add Block Attribute Value
            //   Block: Clearances
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row
            //   Attribute Value: 5
            RockMigrationHelper.AddBlockAttributeValue("EF7FCA50-B64F-47DE-B940-8888E65F97E5", "FBAB162B-556B-44DA-B830-D629529C0542", @"5");

            // Add Block Attribute Value
            //   Block: Clearances
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Entry Page
            //   Attribute Value: 6a4f75a3-95d1-43d5-aaf7-93cec040f346
            RockMigrationHelper.AddBlockAttributeValue("EF7FCA50-B64F-47DE-B940-8888E65F97E5", "B6AF94FF-6D7F-4FFC-8DA7-A78519EF7500", @"6a4f75a3-95d1-43d5-aaf7-93cec040f346");

            // Add Block Attribute Value
            //   Block: Clearances
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Step Program
            //   Attribute Value: ACF26DE6-F052-472A-8421-3293F99A3A9F
            RockMigrationHelper.AddBlockAttributeValue("EF7FCA50-B64F-47DE-B940-8888E65F97E5", "B4E07CC9-53E0-47CF-AC22-10F2085547A3", @"ACF26DE6-F052-472A-8421-3293F99A3A9F");

            // Add Block Attribute Value
            //   Block: Clearances
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Show Campus Column
            //   Attribute Value: True
            RockMigrationHelper.AddBlockAttributeValue("EF7FCA50-B64F-47DE-B940-8888E65F97E5", "5297FCCB-722B-4D96-82F8-480B4D938E89", @"False");

            // Add Block Attribute Value
            //   Block: Clearances
            //   BlockType: Steps
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: Steps Per Row Mobile
            //   Attribute Value: 1
            RockMigrationHelper.AddBlockAttributeValue("EF7FCA50-B64F-47DE-B940-8888E65F97E5", "9E4F6CB9-0228-4D37-BDED-A33FD96EBC75", @"1");

        }

        public override void Down()
        {

        }
    }
}
