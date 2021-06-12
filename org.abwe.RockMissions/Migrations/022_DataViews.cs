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
    [MigrationNumber(22, "1.12.0")]
    class DataViews : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.UpdateCategory(Rock.SystemGuid.EntityType.DATAVIEW, "Staff", "", "Dataviews for Staff", "9b722a31-4afc-463a-9528-a0fb87e7a31d", 0, "BDD2C36F-7575-48A8-8B70-3A566E3811ED");
            RockMigrationHelper.UpdateCategory(Rock.SystemGuid.EntityType.DATAVIEW, "Steps", "", "Dataviews for various steps", "82828449-d3f6-4b42-a468-b6f36c58a956", 0, "BDD2C36F-7575-48A8-8B70-3A566E3811ED");


            #region Active Appointment Steps
            // Create [GroupAll] DataViewFilter for DataView: Active Appointment Steps
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','DC388268-6704-4AFF-9102-AF60064CF2F7')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Appointment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_StepTypeId","1","6"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '0586C357-448E-495E-AB43-12B801B88631') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323'),
                    @StepTypeId varchar(10) = (select Id from StepType where [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_StepTypeId"",""1"",""'+@StepTypeId+'""]','0586C357-448E-495E-AB43-12B801B88631')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Appointment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_StartDateTime","1024","CURRENT:0\tAll||||"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '18A97C64-CDA0-452A-B76D-C71ACC0ECD1A') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_StartDateTime"",""1024"",""CURRENT:0\tAll||||""]','18A97C64-CDA0-452A-B76D-C71ACC0ECD1A')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Appointment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_CompletedDateTime","32",""]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '4DF424BA-0295-4B01-B024-6DBE788C8EFE') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_CompletedDateTime"",""32"",""""]','4DF424BA-0295-4B01-B024-6DBE788C8EFE')
            END
            ");
            // Create DataView: Active Appointment Steps
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '02404B2E-256C-4389-82DB-F276FA0294FD') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = '82828449-d3f6-4b42-a468-b6f36c58a956'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '8EADB0DC-17F4-4541-A46E-53F89E21A622'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid])
            VALUES(1,'Active Appointment Steps','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'02404B2E-256C-4389-82DB-F276FA0294FD')
            END
            ");

            #endregion


            #region Active Employment Steps

            // Create [GroupAll] DataViewFilter for DataView: Active Employment Steps
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','6264FEA0-7A67-4BBB-AD44-73720F1F778A')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Employment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_StepTypeId","1","7"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '01F64B46-BF82-4359-BBBA-DECCE6DD26D4') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323'),
                    @StepTypeId varchar(10) = (select Id from StepType where [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_StepTypeId"",""1"",""'+@StepTypeId+'""]','01F64B46-BF82-4359-BBBA-DECCE6DD26D4')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Employment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_StartDateTime","1024","CURRENT:0\tAll||||"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'CB0480B9-05B5-46A7-8D3B-42EF5C63C3F0') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_StartDateTime"",""1024"",""CURRENT:0\tAll||||""]','CB0480B9-05B5-46A7-8D3B-42EF5C63C3F0')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Active Employment Steps
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_CompletedDateTime","32",""]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '06BAF6A8-15EE-4036-9C5D-5C8766D6DBBE') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_CompletedDateTime"",""32"",""""]','06BAF6A8-15EE-4036-9C5D-5C8766D6DBBE')
            END
            ");
            // Create DataView: Active Employment Steps
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = 'EA87128A-D66A-44FE-AF66-5C72AF783CD3') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = '82828449-d3f6-4b42-a468-b6f36c58a956'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '8EADB0DC-17F4-4541-A46E-53F89E21A622'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid])
            VALUES(1,'Active Employment Steps','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'EA87128A-D66A-44FE-AF66-5C72AF783CD3')
            END
            ");

            #endregion

            #region Active Missionaries

            // Create [GroupAll] DataViewFilter for DataView: Active Missionaries
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '9306E935-ABA6-42B5-8CA4-52A57F8B95DC') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','9306E935-ABA6-42B5-8CA4-52A57F8B95DC')
            END
            ");
            // Create Rock.Reporting.DataFilter.Person.StepDataViewFilter DataViewFilter for DataView: Active Missionaries
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '02404b2e-256c-4389-82db-f276fa0294fd' for Rock.Reporting.DataFilter.Person.StepDataViewFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '99C0810B-AD45-4297-9361-0922B5B4B56D') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '9306E935-ABA6-42B5-8CA4-52A57F8B95DC'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '93CBA12B-A143-464A-8F37-16F0CE9F316C')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'02404b2e-256c-4389-82db-f276fa0294fd','99C0810B-AD45-4297-9361-0922B5B4B56D')
            END
            ");
            // Create DataView: Active Missionaries
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '02B14A46-C2D5-43A6-888E-9D0DBBD61512') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'D8BA3512-7690-4D06-9AAC-82529D7A6720'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = '9306E935-ABA6-42B5-8CA4-52A57F8B95DC'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid])
            VALUES(1,'Active Missionaries','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'02B14A46-C2D5-43A6-888E-9D0DBBD61512')
            END
            ");

            #endregion

            // Create [GroupAll] DataViewFilter for DataView: Active Staff
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32')
            END
            ");
            // Create Rock.Reporting.DataFilter.Person.StepDataViewFilter DataViewFilter for DataView: Active Staff
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection 'ea87128a-d66a-44fe-af66-5c72af783cd3' for Rock.Reporting.DataFilter.Person.StepDataViewFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '00D32C98-F611-4E59-BE84-56E2ABE24AE0') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '93CBA12B-A143-464A-8F37-16F0CE9F316C')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'ea87128a-d66a-44fe-af66-5c72af783cd3','00D32C98-F611-4E59-BE84-56E2ABE24AE0')
            END
            ");
            // Create Rock.Reporting.DataFilter.NotInOtherDataViewFilter DataViewFilter for DataView: Active Staff
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '{"DataViewId":22,"UsePersisted":false}' for Rock.Reporting.DataFilter.NotInOtherDataViewFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '23939818-0360-4E76-A332-F87FC356B1E0') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = 'CEEEE67D-DF8E-4D99-9E39-A410DF7A2680'),
                    @DataViewId varchar(10) = (select Id from DataView where [Guid] = '02B14A46-C2D5-43A6-888E-9D0DBBD61512')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'{""DataViewId"":'+@DataViewId+',""UsePersisted"":false}','23939818-0360-4E76-A332-F87FC356B1E0')
            END
            ");
            // Create DataView: Active Staff
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '59EBC1D6-A6B4-4D1B-9D13-C0AB4C1083B1') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = '9b722a31-4afc-463a-9528-a0fb87e7a31d'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = 'F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid])
            VALUES(1,'Active Staff','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'59EBC1D6-A6B4-4D1B-9D13-C0AB4C1083B1')
            END
            ");

            // Delete Adult Members and Attendees and associated DataViews
            Sql(@"DELETE FROM DataViewFilter where DataViewId = 1");
            Sql(@"DELETE FROM DataView where [Guid] = '0DA5F82F-CFFE-45AF-B725-49B3899A1F72'");

            Sql(@"DELETE FROM DataViewFilter where DataViewId = 2");
            Sql(@"DELETE FROM DataView where [Guid] = 'D0846DB2-7AE8-4897-867F-1AF5CC1DE95A'");

            Sql(@"DELETE FROM DataViewFilter where DataViewId = 3");
            Sql(@"DELETE FROM DataView where [Guid] = '1D144B43-F985-4122-B2E3-D548CC3B2A82'");
            
            Sql(@"DELETE FROM DataViewFilter where DataViewId = 8");
            Sql(@"DELETE FROM DataView where [Guid] = 'CB4BB264-A1F4-4EDB-908F-2CCF3A534BC7'");


            // Add Staff Badge
            string BadgeContentAttribute = SqlScalar(@"DECLARE @InDataViewComponentId int = (SELECT [Id] FROM [EntityType] WHERE [name] = 'Rock.Badge.Component.InDataView')
            DECLARE @BadgeContentAttributeGuid uniqueidentifier = (SELECT [Guid] FROM [Attribute] WHERE [Key] = 'BadgeContent' AND [EntityTypeQualifierColumn] = 'BadgeComponentEntityTypeId' AND [EntityTypeQualifierValue] = @InDataViewComponentId)
            SELECT @BadgeContentAttributeGuid").ToString();
            string BadgeDataViewAttribute = SqlScalar(@"DECLARE @InDataViewComponentId int = (SELECT [Id] FROM [EntityType] WHERE [name] = 'Rock.Badge.Component.InDataView')
            DECLARE @DataViewAttributeGuid uniqueidentifier = (SELECT [Guid] FROM [Attribute] WHERE [Key] = 'DataView' AND [EntityTypeQualifierColumn] = 'BadgeComponentEntityTypeId' AND [EntityTypeQualifierValue] = @InDataViewComponentId)
            SELECT @DataViewAttributeGuid").ToString();

            RockMigrationHelper.AddOrUpdateBadge("Staff", "Indicate whether a person is an active staff member", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "548dc52c-3bc0-4ec0-93dc-c6d9e0b033e7");
            RockMigrationHelper.AddBadgeAttributeValue("548dc52c-3bc0-4ec0-93dc-c6d9e0b033e7", BadgeDataViewAttribute, "59EBC1D6-A6B4-4D1B-9D13-C0AB4C1083B1");
            RockMigrationHelper.AddBadgeAttributeValue("548dc52c-3bc0-4ec0-93dc-c6d9e0b033e7", BadgeContentAttribute, @"{% step where:'StepTypeId == "+SqlScalar("SELECT [Id] FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'").ToString()+@"' %}
                {% assign department = stepItems | First | Attribute:'Department' %}
            {% endstep %}

            <div class='label label-success'>Staff</div> <div class=""label label-campus""> {{ department }} </div>
            ");

            // Update Missionary Status Badge with department
            RockMigrationHelper.AddBadgeAttributeValue("5E44BA37-2131-4518-A502-FCF1543D3348", BadgeContentAttribute, @"{% assign departmentGM = Person | Groups:'"+SqlScalar("SELECT [Id] FROM [GroupType] WHERE [Guid] = 'b1602ac6-7f14-4ac2-88ca-ebfa780d3c38'").ToString()+@"' | First %}
            {% assign department = departmentGM.Group.ParentGroup.Name %}

            {[ missionarystatus aliasid:'{{Person.PrimaryAliasId}}' ]} {% if department != empty %}<div class=""label label-campus"">{{ department }}</div>{% endif %}");

            // Change PersonBio badges to remove connection status, campus and add Missionary, Donor statuses
            RockMigrationHelper.UpdateBlockAttributeValue("B5C1FDB6-0224-43E4-8E26-6B2EAF86253A", "8E11F65B-7272-4E9F-A4F1-89CE08E658DE", "c81949f9-f3b1-466c-84b0-fa5f7887cb9d,5E44BA37-2131-4518-A502-FCF1543D3348,66972bff-42cd-49ab-9a7a-e1b9deca4eca,548dc52c-3bc0-4ec0-93dc-c6d9e0b033e7");
        }

        public override void Down()
        {
            // Delete DataView: Active Appointment Steps
            Sql(@"DELETE FROM DataView where [Guid] = '02404B2E-256C-4389-82DB-F276FA0294FD'");
            // Delete DataViewFilter for DataView: Active Appointment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '4DF424BA-0295-4B01-B024-6DBE788C8EFE'");
            // Delete DataViewFilter for DataView: Active Appointment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '18A97C64-CDA0-452A-B76D-C71ACC0ECD1A'");
            // Delete DataViewFilter for DataView: Active Appointment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '0586C357-448E-495E-AB43-12B801B88631'");
            // Delete DataViewFilter for DataView: Active Appointment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'DC388268-6704-4AFF-9102-AF60064CF2F7'");

            // Delete DataView: Active Employment Steps
            Sql(@"DELETE FROM DataView where [Guid] = 'EA87128A-D66A-44FE-AF66-5C72AF783CD3'");
            // Delete DataViewFilter for DataView: Active Employment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '06BAF6A8-15EE-4036-9C5D-5C8766D6DBBE'");
            // Delete DataViewFilter for DataView: Active Employment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'CB0480B9-05B5-46A7-8D3B-42EF5C63C3F0'");
            // Delete DataViewFilter for DataView: Active Employment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '01F64B46-BF82-4359-BBBA-DECCE6DD26D4'");
            // Delete DataViewFilter for DataView: Active Employment Steps
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '6264FEA0-7A67-4BBB-AD44-73720F1F778A'");

            // Delete DataView: Active Missionaries
            Sql(@"DELETE FROM DataView where [Guid] = '02B14A46-C2D5-43A6-888E-9D0DBBD61512'");
            // Delete DataViewFilter for DataView: Active Missionaries
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '99C0810B-AD45-4297-9361-0922B5B4B56D'");
            // Delete DataViewFilter for DataView: Active Missionaries
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '9306E935-ABA6-42B5-8CA4-52A57F8B95DC'");

            // Delete DataView: Active Staff
            Sql(@"DELETE FROM DataView where [Guid] = '59EBC1D6-A6B4-4D1B-9D13-C0AB4C1083B1'");
            // Delete DataViewFilter for DataView: Active Staff
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '23939818-0360-4E76-A332-F87FC356B1E0'");
            // Delete DataViewFilter for DataView: Active Staff
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '00D32C98-F611-4E59-BE84-56E2ABE24AE0'");
            // Delete DataViewFilter for DataView: Active Staff
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'F0ABD121-97E4-4F41-B5E4-ECE0F5EE0C32'");
        }
    }
}
