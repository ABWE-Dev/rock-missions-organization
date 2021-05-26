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
    [MigrationNumber(19, "1.12.0")]
    class Badges : Migration
    {
        public override void Up()
        {
            // Missionary Status Lava Shortcode
            Sql(@"INSERT INTO LavaShortcode ([Name], [Description], [Documentation], IsSystem, IsActive, TagName, Markup, TagType, EnabledLavaCommands, [Parameters], CreatedDateTime, [Guid])
                VALUES('Missionary Status', 'Show a badge with the status of a missionary', '<p>{[ missionarystatus aliasid:''1'' ]}</p>', 1, 1, 'missionarystatus', '{% step where:''StepTypeId == 6 && PersonAliasId == {{aliasid}}'' sort:''CompletedDateTime desc'' %}
                    {% assign ongoingStep = stepItems | Sort:''CompletedDateTime'',''asc'' | First %}
                            {% if ongoingStep.CompletedDateTime == null %}
                                {% assign finalStep = ongoingStep %}
                            {% else %}
                                {% assign finalStep = stepItems | First %}
                            {% endif %}
                    <div class=''label label-success''>Missionary<span style=""background-color: rgba(255,255,255,.3);padding: inherit;margin-left: .6em;margin-right: -.6em;"">{{finalStep.StepStatus.Name}}</span></div>
                {% endstep %}
                ', 1, 'RockEntity', 'aliasid^', GETDATE(), 'D1858984-3956-45A5-978E-A7B4AAA1F43E')");

            // Create Missionaries DataView category
            RockMigrationHelper.UpdateCategory("57F8FA29-DCF1-4F74-8553-87E90F234139", "Missionaries", "", "DataViews related to missionaries", "D8BA3512-7690-4D06-9AAC-82529D7A6720", 0, "BDD2C36F-7575-48A8-8B70-3A566E3811ED");

            // Create [GroupAll] DataViewFilter for DataView: All Missionaries
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '2F9FAE7C-4C8A-46B7-B27C-1C1933D8B36D') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','2F9FAE7C-4C8A-46B7-B27C-1C1933D8B36D')
            END
            ");

            // Create Rock.Reporting.DataFilter.Person.StepsTakenFilter DataViewFilter for DataView: All Missionaries
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '59c990ed-f5b4-4379-a926-852cba08fa03|7aae4cbb-9058-4beb-968b-4c0d9c92b4ef|c44e0b69-0a69-4713-af5e-0e00d660b708,8e33b5be-a9ec-4893-9352-dc5cfb99ceb2,9d7d7730-4cc6-4c1e-bbfc-57f9add4c102,68ceff2c-b080-41f5-b0e7-c64ee455668d,25de3d25-30ee-48bf-810b-27876fdf0e2f,03557f01-ee9d-4fe1-abba-bd314d87aa0d|All,,,,|All,,,,|' for Rock.Reporting.DataFilter.Person.StepsTakenFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '9E3A81C6-0EB4-4965-80A8-89724844F102') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '2F9FAE7C-4C8A-46B7-B27C-1C1933D8B36D'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '7B984B07-F67C-4B78-BB81-9AFDDF750382')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'59c990ed-f5b4-4379-a926-852cba08fa03|7aae4cbb-9058-4beb-968b-4c0d9c92b4ef|c44e0b69-0a69-4713-af5e-0e00d660b708,8e33b5be-a9ec-4893-9352-dc5cfb99ceb2,9d7d7730-4cc6-4c1e-bbfc-57f9add4c102,68ceff2c-b080-41f5-b0e7-c64ee455668d,25de3d25-30ee-48bf-810b-27876fdf0e2f,03557f01-ee9d-4fe1-abba-bd314d87aa0d|All,,,,|All,,,,|','9E3A81C6-0EB4-4965-80A8-89724844F102')
            END
            ");

            // Create DataView: All Missionaries
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '1B2BF8B1-F01F-4134-B36A-79E7D5884E23') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'D8BA3512-7690-4D06-9AAC-82529D7A6720'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = '2F9FAE7C-4C8A-46B7-B27C-1C1933D8B36D'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid])
            VALUES(0,'All Missionaries','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'1B2BF8B1-F01F-4134-B36A-79E7D5884E23')
            END
            ");

            string BadgeDataViewAttribute = SqlScalar(@"DECLARE @InDataViewComponentId int = (SELECT [Id] FROM [EntityType] WHERE [name] = 'Rock.Badge.Component.InDataView')
            DECLARE @DataViewAttributeGuid uniqueidentifier = (SELECT [Guid] FROM [Attribute] WHERE [Key] = 'DataView' AND [EntityTypeQualifierColumn] = 'BadgeComponentEntityTypeId' AND [EntityTypeQualifierValue] = @InDataViewComponentId)
            SELECT @DataViewAttributeGuid").ToString();
            string BadgeContentAttribute = SqlScalar(@"DECLARE @InDataViewComponentId int = (SELECT [Id] FROM [EntityType] WHERE [name] = 'Rock.Badge.Component.InDataView')
            DECLARE @BadgeContentAttributeGuid uniqueidentifier = (SELECT [Guid] FROM [Attribute] WHERE [Key] = 'BadgeContent' AND [EntityTypeQualifierColumn] = 'BadgeComponentEntityTypeId' AND [EntityTypeQualifierValue] = @InDataViewComponentId)
            SELECT @BadgeContentAttributeGuid").ToString();
            RockMigrationHelper.AddOrUpdateBadge("Missionary Status", "Indicate the status of a missionary", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "5E44BA37-2131-4518-A502-FCF1543D3348");
            RockMigrationHelper.AddBadgeAttributeValue("5E44BA37-2131-4518-A502-FCF1543D3348", BadgeDataViewAttribute, "1b2bf8b1-f01f-4134-b36a-79e7d5884e23");
            RockMigrationHelper.AddBadgeAttributeValue("5E44BA37-2131-4518-A502-FCF1543D3348", BadgeContentAttribute, "{[ missionarystatus aliasid:'{{Person.PrimaryAliasId}}' ]}");

            // Donor Profile Lava Shortcode
            Sql(@"INSERT INTO LavaShortcode ([Name], [Description], [Documentation], IsSystem, IsActive, TagName, Markup, TagType, EnabledLavaCommands, [Parameters], CreatedDateTime, [Guid])
            VALUES ('Donor Profile', 'Show a badge with the summary of a donor', '<p>{[ donorprofile personid:''1'' ]}</p>', 1, 1, 'donorprofile', '{% sql %}
            DECLARE @MissionaryAccountId int = (SELECT [Id] FROM [DefinedValue] WHERE [Guid] = ''53329569-5097-4975-BDFE-AD7A6CE920F9'')
            DECLARE @ProjectAccountId int = (SELECT [Id] FROM [DefinedValue] WHERE [Guid] = ''FB0507A0-4D30-41D6-98E1-A48BC9F35967'')

            SELECT
                COUNT(FinancialTransaction.Id) [Count]
                ,COUNT(DISTINCT CASE
                    WHEN FinancialAccount.AccountTypeValueId = @MissionaryAccountId AND DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 365 THEN FinancialAccount.Id
                    WHEN FinancialAccount.AccountTypeValueId = @MissionaryAccountId AND DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 365 THEN FinancialAccount.ParentAccountId
                    ELSE NULL
                END) [MissionaryAccounts]
                ,COUNT(DISTINCT CASE
                    WHEN FinancialAccount.AccountTypeValueId = @ProjectAccountId AND DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 365 THEN FinancialAccount.Id
                    WHEN FinancialAccount.AccountTypeValueId = @ProjectAccountId AND DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 365 THEN FinancialAccount.ParentAccountId
                    ELSE NULL
                END) [ProjectAccounts]
                ,ISNULL(SUM(CASE
                    WHEN DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 365 THEN [FinancialTransactionDetail].[Amount]
                    ELSE 0
                 END),0) [ThisYTD]
                ,ISNULL(SUM(CASE
                    WHEN DATEDIFF(dd,TransactionDateTime,GETDATE()) > 365 THEN [FinancialTransactionDetail].[Amount]
                    ELSE 0
                 END),0) [LastYTD]
            FROM
            FinancialTransactionDetail
            INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
            INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
            WHERE AuthorizedPersonAliasId IN (SELECT Id FROM PersonAlias WHERE PersonId IN (SELECT [Id] FROM Person WHERE GivingId = (SELECT [GivingId] FROM Person WHERE Id = {{ personid }})))
                AND (
                    DATEDIFF(dd,TransactionDateTime,GETDATE()) <= 730
                )
            {% endsql %}

            {% assign result = results | First %}

            <div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ result.MissionaryAccounts }} <i class=""fa fa-group""></i></div>
            <div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ result.ProjectAccounts }} <i class= ""fa fa-hammer""></i></div>
            <div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ result.ThisYTD | FormatAsCurrency }}
            {% if result.ThisYTD > result.LastYTD %}<i class=""text-success fa fa-caret-square-up""></i>{% else %}<i class=""text-danger fa fa-caret-square-down""></i>{% endif %}</div>'
            , 1, 'Sql', 'personid^', GETDATE(), '694913FD-9068-4547-89B6-59ABDFE44CB8')");


            // Create Missionaries DataView category
            RockMigrationHelper.UpdateCategory("57F8FA29-DCF1-4F74-8553-87E90F234139", "Donors", "", "DataViews related to donors", "ECF4C847-39A9-48DF-811D-D14A93391FDD", 0, "BDD2C36F-7575-48A8-8B70-3A566E3811ED");

            // Create [GroupAll] DataViewFilter for DataView: Top Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'BD21A971-E2A5-406C-8350-1D9DA71F486E') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','BD21A971-E2A5-406C-8350-1D9DA71F486E')
            END
            ");

            // Create com.blueboxmoon.DataToolkit.DataFilter.SqlFilter DataViewFilter for DataView: Top Donors
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '600|SELECT%20%5BPerson%5D.%5BId%5D%20FROM%20%28SELECT%20TOP%20%2850%29%0A%20%20%20%20PersonId%2C%20GivingId%0AFROM%20%5BFinancialTransactionDetail%5D%0AINNER%20JOIN%20%5BFinancialTransaction%5D%20ON%20FinancialTransactionDetail.TransactionId%20%3D%20FinancialTransaction.Id%0ALEFT%20JOIN%20%5BPersonAlias%5D%20ON%20%5BPersonAlias%5D.Id%20%3D%20AuthorizedPersonAliasId%0ALEFT%20JOIN%20%5BPerson%5D%20ON%20%5BPerson%5D.Id%20%3D%20PersonAlias.PersonId%0AWHERE%20DATEDIFF%28mm%2C%20TransactionDateTime%2C%20GETDATE%28%29%29%20%3C%3D%2084%20AND%20Person.RecordTypeValueId%20%3D%201%0AGROUP%20BY%20PersonId%2C%20GivingId%0AORDER%20BY%20SUM%28FinancialTransactionDetail.Amount%29%20DESC%29%20%5BTopDonors%5D%0AINNER%20JOIN%20%5BPerson%5D%20ON%20%5BTopDonors%5D.GivingId%20%3D%20%5BPerson%5D.GivingId' for com.blueboxmoon.DataToolkit.DataFilter.SqlFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '613E2EBA-752B-47D2-8591-F3CE2F4FED23') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'BD21A971-E2A5-406C-8350-1D9DA71F486E'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = 'CB00FBF0-EC3A-4246-98B0-D420CAD15B30')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'600|SELECT%20%5BPerson%5D.%5BId%5D%20FROM%20%28SELECT%20TOP%20%2850%29%0A%20%20%20%20PersonId%2C%20GivingId%0AFROM%20%5BFinancialTransactionDetail%5D%0AINNER%20JOIN%20%5BFinancialTransaction%5D%20ON%20FinancialTransactionDetail.TransactionId%20%3D%20FinancialTransaction.Id%0ALEFT%20JOIN%20%5BPersonAlias%5D%20ON%20%5BPersonAlias%5D.Id%20%3D%20AuthorizedPersonAliasId%0ALEFT%20JOIN%20%5BPerson%5D%20ON%20%5BPerson%5D.Id%20%3D%20PersonAlias.PersonId%0AWHERE%20DATEDIFF%28mm%2C%20TransactionDateTime%2C%20GETDATE%28%29%29%20%3C%3D%2084%20AND%20Person.RecordTypeValueId%20%3D%201%0AGROUP%20BY%20PersonId%2C%20GivingId%0AORDER%20BY%20SUM%28FinancialTransactionDetail.Amount%29%20DESC%29%20%5BTopDonors%5D%0AINNER%20JOIN%20%5BPerson%5D%20ON%20%5BTopDonors%5D.GivingId%20%3D%20%5BPerson%5D.GivingId','613E2EBA-752B-47D2-8591-F3CE2F4FED23')
            END
            ");

            // Create DataView: Top Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '64DEC83E-3DF2-424D-8D5E-2CEB4E3FF639') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'ECF4C847-39A9-48DF-811D-D14A93391FDD'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = 'BD21A971-E2A5-406C-8350-1D9DA71F486E'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid], [PersistedScheduleIntervalMinutes])
            VALUES(0,'Top Donors','Return a list of the Top 50 people giving groups. Note: This dataview will return more than 50 people because of people that have ""Group Giving With Family"" set.',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'64DEC83E-3DF2-424D-8D5E-2CEB4E3FF639',1440)
            END
            ");

            // Create [GroupAll] DataViewFilter for DataView: Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'BE1AA13B-D1D8-4294-910E-7A02A74510F8') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','BE1AA13B-D1D8-4294-910E-7A02A74510F8')
            END
            ");
            // Create Rock.Reporting.DataFilter.Person.GivingAmountFilter DataViewFilter for DataView: Donors
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '256|0.01||||True|Last,84,Month,,' for Rock.Reporting.DataFilter.Person.GivingAmountFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '3D718521-3466-4E7B-8B4E-DD87CC7E1946') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'BE1AA13B-D1D8-4294-910E-7A02A74510F8'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '1087DEE3-9932-4647-88A3-7CD87AB16B7D')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'256|0.01||||True|Last,84,Month,,','3D718521-3466-4E7B-8B4E-DD87CC7E1946')
            END
            ");
            // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: Donors
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_RecordTypeValueId","36cf10d6-c695-413d-8e7c-4546efef385e"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'DFBF6A91-E5B2-4523-A70E-9384594CCD0A') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'BE1AA13B-D1D8-4294-910E-7A02A74510F8'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_RecordTypeValueId"",""36cf10d6-c695-413d-8e7c-4546efef385e""]','DFBF6A91-E5B2-4523-A70E-9384594CCD0A')
            END
            ");
            // Create DataView: Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '21ECFE7B-41C6-47D0-BD21-44E810E3CE29') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'ECF4C847-39A9-48DF-811D-D14A93391FDD'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = 'BE1AA13B-D1D8-4294-910E-7A02A74510F8'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid], [PersistedScheduleIntervalMinutes])
            VALUES(0,'Donors','Person record types who have given $0.01 or more in the past 84 months (7 years)',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'21ECFE7B-41C6-47D0-BD21-44E810E3CE29', 1440)
            END
            ");

            // Create [GroupAll] DataViewFilter for DataView: Global Gospel Fund Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'E957094B-B23B-438E-A275-444D4BD07240') BEGIN
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','E957094B-B23B-438E-A275-444D4BD07240')
            END
            ");
            // Create Rock.Reporting.DataFilter.Person.GivingAmountFilter DataViewFilter for DataView: Global Gospel Fund Donors
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '256|0.01|||1498c488-bd30-47d3-9ff5-0cb93714a3b7,a725752f-e26e-4d90-a1e0-5bba62ec7a52,4cf14abe-3d9d-438b-99f5-982ae9e6f3ec,a79b9f90-d7cf-4e73-8c58-7e768e6c0d73,317c5702-ea82-434c-9745-286df4ff62b6,e89c7e8a-8c18-4934-9dcb-2a48570bb5e0,1aa69db8-97dc-4b8d-b1e7-aedf4a27dd28,044a1a32-2d54-43fe-9c1d-353f4caaacea,bc676515-55b3-468b-91ee-b3f308d3d7ac,502098b5-3cbc-4f53-9b3e-ffb7a0840caa,2c93a8d9-eeca-4807-b869-c90e10ea67e5|True|Previous,84,Month,,' for Rock.Reporting.DataFilter.Person.GivingAmountFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '6F4225A0-EFA9-4B08-A2A6-ECB32F165A24') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'E957094B-B23B-438E-A275-444D4BD07240'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '1087DEE3-9932-4647-88A3-7CD87AB16B7D')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'256|1.00|||1498C488-BD30-47D3-9FF5-0CB93714A3B7|True|Previous,24,Month,,','6F4225A0-EFA9-4B08-A2A6-ECB32F165A24')
            END
            ");
            // Create Rock.Reporting.DataFilter.OtherDataViewFilter DataViewFilter for DataView: Global Gospel Fund Donors
            /* NOTE to Developer. Review that the generated DataViewFilter.Selection '{"DataViewId":15,"UsePersisted":true}' for Rock.Reporting.DataFilter.OtherDataViewFilter will work on different databases */
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'EF8B10A4-1845-40EB-91E2-6FEDC27432FA') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = 'E957094B-B23B-438E-A275-444D4BD07240'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '068C1177-68E5-4D08-8386-96EE3C9880F1')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'{""DataViewId"":"+SqlScalar("SELECT [Id] FROM DataView WHERE [Guid] = '21ECFE7B-41C6-47D0-BD21-44E810E3CE29'").ToString()+@",""UsePersisted"":true}','EF8B10A4-1845-40EB-91E2-6FEDC27432FA')
            END
            ");
            // Create DataView: Global Gospel Fund Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '0961B722-7A72-401E-A9BB-635F766712E8') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'ECF4C847-39A9-48DF-811D-D14A93391FDD'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = 'E957094B-B23B-438E-A275-444D4BD07240'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid], [PersistedScheduleIntervalMinutes])
            VALUES(0,'Global Gospel Fund Donors','',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'0961B722-7A72-401E-A9BB-635F766712E8', 1440)
            END
            ");

            // Create [GroupAll] DataViewFilter for DataView: 24 Month Donors
            Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '90E4F195-8853-4807-905A-30FE50BE2DBB') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '00000000-0000-0000-0000-000000000000'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '00000000-0000-0000-0000-000000000000')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (1,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'','90E4F195-8853-4807-905A-30FE50BE2DBB')
            END
            ");
                        // Create Rock.Reporting.DataFilter.Person.GivingAmountFilter DataViewFilter for DataView: 24 Month Donors
                        /* NOTE to Developer. Review that the generated DataViewFilter.Selection '256|0.01||||True|Last,24,Month,,' for Rock.Reporting.DataFilter.Person.GivingAmountFilter will work on different databases */
                        Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = 'F06D347C-8452-4378-B2A0-02D6962B42A9') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '90E4F195-8853-4807-905A-30FE50BE2DBB'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '1087DEE3-9932-4647-88A3-7CD87AB16B7D')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'256|0.01||||True|Last,24,Month,,','F06D347C-8452-4378-B2A0-02D6962B42A9')
            END
            ");
                        // Create Rock.Reporting.DataFilter.PropertyFilter DataViewFilter for DataView: 24 Month Donors
                        /* NOTE to Developer. Review that the generated DataViewFilter.Selection '["Property_RecordTypeValueId","36cf10d6-c695-413d-8e7c-4546efef385e"]' for Rock.Reporting.DataFilter.PropertyFilter will work on different databases */
                        Sql(@"
            IF NOT EXISTS (SELECT * FROM DataViewFilter where [Guid] = '971CE3DE-1FF7-4782-83BE-C92C10145EB8') BEGIN    
                DECLARE
                    @ParentDataViewFilterId int = (select Id from DataViewFilter where [Guid] = '90E4F195-8853-4807-905A-30FE50BE2DBB'),
                    @DataViewFilterEntityTypeId int = (select Id from EntityType where [Guid] = '03F0D6AC-D181-48B6-B4BC-1F2652B55323')

                INSERT INTO [DataViewFilter] (ExpressionType, ParentId, EntityTypeId, Selection, [Guid]) 
                values (0,@ParentDataViewFilterId,@DataViewFilterEntityTypeId,'[""Property_RecordTypeValueId"",""36cf10d6-c695-413d-8e7c-4546efef385e""]','971CE3DE-1FF7-4782-83BE-C92C10145EB8')
            END
            ");
                        // Create DataView: 24 Month Donors
                        Sql(@"
            IF NOT EXISTS (SELECT * FROM DataView where [Guid] = '36C47693-04B1-4807-A30E-FD66B0CD9DB5') BEGIN
            DECLARE
                @categoryId int = (select top 1 [Id] from [Category] where [Guid] = 'ECF4C847-39A9-48DF-811D-D14A93391FDD'),
                @entityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '72657ED8-D16E-492E-AC12-144C5E7567E7'),
                @dataViewFilterId  int = (select top 1 [Id] from [DataViewFilter] where [Guid] = '90E4F195-8853-4807-905A-30FE50BE2DBB'),
                @transformEntityTypeId  int = (select top 1 [Id] from [EntityType] where [Guid] = '00000000-0000-0000-0000-000000000000')

            INSERT INTO [DataView] ([IsSystem], [Name], [Description], [CategoryId], [EntityTypeId], [DataViewFilterId], [TransformEntityTypeId], [Guid], [PersistedScheduleIntervalMinutes])
            VALUES(0,'24 Month Donors','Person record types who have given $0.01 or more in the past 24 months',@categoryId,@entityTypeId,@dataViewFilterId,@transformEntityTypeId,'36C47693-04B1-4807-A30E-FD66B0CD9DB5', 1440)
            END
            ");

            // Donor Status
            RockMigrationHelper.AddOrUpdateBadge("Donor Status", "Indicate whether a person is a donor", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "C81949F9-F3B1-466C-84B0-FA5F7887CB9D");
            RockMigrationHelper.AddBadgeAttributeValue("C81949F9-F3B1-466C-84B0-FA5F7887CB9D", BadgeDataViewAttribute, "21ecfe7b-41c6-47d0-bd21-44e810e3ce29");
            RockMigrationHelper.AddBadgeAttributeValue("C81949F9-F3B1-466C-84B0-FA5F7887CB9D", BadgeContentAttribute, @"<div class=""label label-success"">Donor</div>
            ");

            // Donor Profile
            RockMigrationHelper.AddOrUpdateBadge("Donor Profile", "Show a donor profile snapshot, including the number of missionary accounts they give to, number of projects, and dollar amount.", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "2F809E23-94C6-45C2-A3F1-6658AF868C57");
            RockMigrationHelper.AddBadgeAttributeValue("2F809E23-94C6-45C2-A3F1-6658AF868C57", BadgeDataViewAttribute, "36c47693-04b1-4807-a30e-fd66b0cd9db5");
            RockMigrationHelper.AddBadgeAttributeValue("2F809E23-94C6-45C2-A3F1-6658AF868C57", BadgeContentAttribute, @"<div class=""badge"" style=""margin-top: 7px; padding-top: 0px"">{[ donorprofile personid:'{{Person.Id}}' ]}</div>");

            // Top Donor
            RockMigrationHelper.AddOrUpdateBadge("Top Donor", "Indicate whether a person is a top donor (in the top 50 giving units by dollar value over the past 24 months)", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "8369C92A-3B4F-47DD-9C50-1BBDA2BE9B7A");
            RockMigrationHelper.AddBadgeAttributeValue("8369C92A-3B4F-47DD-9C50-1BBDA2BE9B7A", BadgeDataViewAttribute, "64dec83e-3df2-424d-8d5e-2ceb4e3ff639");
            RockMigrationHelper.AddBadgeAttributeValue("8369C92A-3B4F-47DD-9C50-1BBDA2BE9B7A", BadgeContentAttribute, @"<div class='badge' style=""margin-top: 7px; padding: 10px;color: black;background-color: #efefef;"">
                <i class=""fas fa-star"" style=""color: gold;""></i> Top Donor
            </div>");

            // Global Gospel Fund Donor
            RockMigrationHelper.AddOrUpdateBadge("Global Gospel Fund Donor", "Indicate whether a person is a donor", "Rock.Model.Person", "Rock.Badge.Component.InDataView", 0, "D5E88C94-F22D-450C-96E0-180E55FBDA32");
            RockMigrationHelper.AddBadgeAttributeValue("D5E88C94-F22D-450C-96E0-180E55FBDA32", BadgeDataViewAttribute, "0961b722-7a72-401e-a9bb-635f766712e8");
            RockMigrationHelper.AddBadgeAttributeValue("D5E88C94-F22D-450C-96E0-180E55FBDA32", BadgeContentAttribute, @"<div class='badge' style=""margin-top: 7px; padding: 10px;color: black;background-color: #efefef;margin-right: 5px;"">
                <i class=""fas fa-globe-americas"" style=""color: green;""></i> Global Gospel
            </div>");

            // Update badge bar with donor badges
            RockMigrationHelper.UpdateBlockAttributeValue("98A30DD7-8665-4C6D-B1BB-A8380E862A04", "F5AB231E-3836-4D52-BD03-BF79773C237A", "d5e88c94-f22d-450c-96e0-180e55fbda32,8369c92a-3b4f-47dd-9c50-1bbda2be9b7a,2f809e23-94c6-45c2-a3f1-6658af868c57,8a9ad88e-359f-46fd-9ba1-8b0603644f17");
            // Remove most badges from right badge bar
            RockMigrationHelper.UpdateBlockAttributeValue("F3E6CC14-C540-4FFC-A5A9-48AD9CC0A61B", "F5AB231E-3836-4D52-BD03-BF79773C237A", "cce09793-89f6-4042-a98a-ed38392bcfcc");
            // Change PersonBio badges to remove connection status, campus and add Missionary, Donor statuses
            RockMigrationHelper.UpdateBlockAttributeValue("B5C1FDB6-0224-43E4-8E26-6B2EAF86253A", "8E11F65B-7272-4E9F-A4F1-89CE08E658DE", "c81949f9-f3b1-466c-84b0-fa5f7887cb9d,5E44BA37-2131-4518-A502-FCF1543D3348,66972bff-42cd-49ab-9a7a-e1b9deca4eca");
            
            // Remove middle badge bar
            RockMigrationHelper.DeleteBlock("AA588E23-D34C-433A-BA3D-B0B82797A22F");
        }

        public override void Down()
        {
            // Delete Missionary Status Lava Shortcode
            Sql("DELETE FROM LavaShortcode WHERE [Guid] = 'D1858984-3956-45A5-978E-A7B4AAA1F43E'");
            // Delete Donor Profile Lava Shortcode
            Sql("DELETE FROM LavaShortcode WHERE [Guid] = '694913FD-9068-4547-89B6-59ABDFE44CB8'");

            // Delete DataView: All Missionaries
            Sql(@"DELETE FROM DataView where [Guid] = '1B2BF8B1-F01F-4134-B36A-79E7D5884E23'");
            // Delete DataViewFilter for DataView: All Missionaries
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '9E3A81C6-0EB4-4965-80A8-89724844F102'");
            // Delete DataViewFilter for DataView: All Missionaries
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '2F9FAE7C-4C8A-46B7-B27C-1C1933D8B36D'");

            // Delete DataView: Top Donors
            Sql(@"DELETE FROM DataView where [Guid] = '64DEC83E-3DF2-424D-8D5E-2CEB4E3FF639'");
            // Delete DataViewFilter for DataView: Top Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '613E2EBA-752B-47D2-8591-F3CE2F4FED23'");
            // Delete DataViewFilter for DataView: Top Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'BD21A971-E2A5-406C-8350-1D9DA71F486E'");

            // Delete DataView: Donors
            Sql(@"DELETE FROM DataView where [Guid] = '21ECFE7B-41C6-47D0-BD21-44E810E3CE29'");
            // Delete DataViewFilter for DataView: Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'DFBF6A91-E5B2-4523-A70E-9384594CCD0A'");
            // Delete DataViewFilter for DataView: Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '3D718521-3466-4E7B-8B4E-DD87CC7E1946'");
            // Delete DataViewFilter for DataView: Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'BE1AA13B-D1D8-4294-910E-7A02A74510F8'");

            // Delete DataView: Global Gospel Fund Donors
            Sql(@"DELETE FROM DataView where [Guid] = '0961B722-7A72-401E-A9BB-635F766712E8'");
            // Delete DataViewFilter for DataView: Global Gospel Fund Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'EF8B10A4-1845-40EB-91E2-6FEDC27432FA'");
            // Delete DataViewFilter for DataView: Global Gospel Fund Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '6F4225A0-EFA9-4B08-A2A6-ECB32F165A24'");
            // Delete DataViewFilter for DataView: Global Gospel Fund Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'E957094B-B23B-438E-A275-444D4BD07240'");

            // Delete DataView: 24 Month Donors
            Sql(@"DELETE FROM DataView where [Guid] = '36C47693-04B1-4807-A30E-FD66B0CD9DB5'");
            // Delete DataViewFilter for DataView: 24 Month Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '971CE3DE-1FF7-4782-83BE-C92C10145EB8'");
            // Delete DataViewFilter for DataView: 24 Month Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = 'F06D347C-8452-4378-B2A0-02D6962B42A9'");
            // Delete DataViewFilter for DataView: 24 Month Donors
            Sql(@"DELETE FROM DataViewFilter where [Guid] = '90E4F195-8853-4807-905A-30FE50BE2DBB'");   

            // Delete badge
            Sql("DELETE FROM [Badge] WHERE [Guid] = '5E44BA37-2131-4518-A502-FCF1543D3348'");
        }
    }
}
