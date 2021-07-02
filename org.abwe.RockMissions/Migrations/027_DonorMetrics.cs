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
    [MigrationNumber(27, "1.12.0")]
    class DonorMetrics : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.UpdatePersonAttributeCategory("Missions Org Giving", "fa fa-money", "Missions org giving analytics", "8953b504-7701-49d2-b226-93822d9af2e8");

            // Entity: Rock.Model.Person Attribute: Percentile
            RockMigrationHelper.UpdatePersonAttribute("A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "8953b504-7701-49d2-b226-93822d9af2e8", "Percentile", "Percentile", @"", @"", 31061, "0", SystemGuid.Attributes.GIVING_PERCENTILE);
            // Entity: Rock.Model.Person Attribute: Missionary Accounts Supported
            RockMigrationHelper.UpdatePersonAttribute("A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "8953b504-7701-49d2-b226-93822d9af2e8", "Missionary Accounts Supported", "MissionaryAccountsSupported", @"", "", 31062, @"0", SystemGuid.Attributes.GIVING_MISSIONARY_ACCOUNTS_SUPPORTED);
            // Entity: Rock.Model.Person Attribute: Project Accounts Supported
            RockMigrationHelper.UpdatePersonAttribute("A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "8953b504-7701-49d2-b226-93822d9af2e8", "Project Accounts Supported", "ProjectAccountsSupported", @"", "", 31063, @"0", SystemGuid.Attributes.GIVING_PROJECT_ACCOUNTS_SUPPORTED);
            // Entity: Rock.Model.Person Attribute: 12 Month Giving Total
            RockMigrationHelper.UpdatePersonAttribute("3EE69CBC-35CE-4496-88CC-8327A447603F", "8953b504-7701-49d2-b226-93822d9af2e8", "12 Month Giving Total", "12MonthGivingTotal", @"", "", 31064, @"0", SystemGuid.Attributes.GIVING_12_MONTH_GIVING_TOTAL);
            // Entity: Rock.Model.Person Attribute: Previous 12 Month Giving Total
            RockMigrationHelper.UpdatePersonAttribute("3EE69CBC-35CE-4496-88CC-8327A447603F", "8953b504-7701-49d2-b226-93822d9af2e8", "Previous 12 Month Giving Total", "Previous12MonthGivingTotal", @"", "", 31065, @"0", SystemGuid.Attributes.GIVING_PREV_12_MONTH_GIVING_TOTAL);
            // Entity: Rock.Model.Person Attribute: Global Gospel Fund Donor
            RockMigrationHelper.UpdatePersonAttribute("1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "8953b504-7701-49d2-b226-93822d9af2e8", "Global Gospel Fund Donor", "GlobalGospelFundDonor", @"", "", 31066, @"False", SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR);


            // Qualifier for attribute: GlobalGospelFundDonor
            RockMigrationHelper.UpdateAttributeQualifier(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, "BooleanControlType", @"1", "4306AA5F-5FE9-43E6-9B7B-EF6A99AD7DE6");
            // Qualifier for attribute: GlobalGospelFundDonor
            RockMigrationHelper.UpdateAttributeQualifier(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, "falsetext", @"No", "9FC832A7-6D33-454F-93C1-5F73FEC8ABFA");
            // Qualifier for attribute: GlobalGospelFundDonor
            RockMigrationHelper.UpdateAttributeQualifier(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, "truetext", @"Yes", "B58B46AB-D916-4767-B84B-C6A2BF2BE954");

            // Update security
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PERCENTILE, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "98194a3d-202d-4d3e-96f4-6ad0557c025e");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PERCENTILE, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "347c7532-1a9a-4c4c-a54d-2bcc57956c7f");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PERCENTILE, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "2c4cb07e-bcc3-45b7-bdd8-5f6e48dd2e33");

            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_MISSIONARY_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "d9b0c9b1-9c27-4c22-bd19-41765e589211");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_MISSIONARY_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "57174da4-e4e4-4ab1-b3ec-321593b3c288");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_MISSIONARY_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "899f87f5-286e-4b7d-b1cc-d08fbbcd9e60");

            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PROJECT_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "eb80ba5b-ac2b-415a-a3e3-483437ff5145");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PROJECT_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "067cef28-35ed-4f69-b4a1-ea815d2d9ec0");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PROJECT_ACCOUNTS_SUPPORTED, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "9e0a0f56-39c2-43cb-abf2-1ffc6dc40684");

            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "e9c60644-08c6-4c48-bb60-41f86411d9e7");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "2c533f6b-6510-42dc-8b88-791a151cc401");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "9b4fcee7-3d71-4b83-aecb-85f2b6164542");

            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PREV_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "81c9099b-b13a-4128-ac35-95e171fa02ae");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PREV_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "fd871254-743d-4e20-9065-77e5c6f9e994");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_PREV_12_MONTH_GIVING_TOTAL, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "22c1dd2a-112e-4115-96e6-2e5bffcc42d3");

            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_FINANCE_USERS, 0, "30956a0d-2221-455d-a54a-a908e9ce0362");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, 0, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "45891b04-fcb4-44dd-a7e6-f8e783642bda");
            RockMigrationHelper.AddSecurityAuthForAttribute(SystemGuid.Attributes.GIVING_GLOBAL_GOSPEL_FUND_DONOR, 0, Authorization.VIEW, false, "", (int)SpecialRole.AllUsers, "4f52f685-5d10-4e34-85da-568c62ec9cb6");


            // add ServiceJob: Calculate Missions Org Giving Statistics
            // Code Generated using Rock\Dev Tools\Sql\CodeGen_ServiceJobWithAttributes_ForAJob.sql
            Sql(@"IF NOT EXISTS( SELECT [Id] FROM [ServiceJob] WHERE [Class] = 'Rock.Jobs.RunSQL' AND [Guid] = 'A536A577-6805-41FE-ABF7-CA0C96E69686' )
            BEGIN
               INSERT INTO [ServiceJob] (
                  [IsSystem]
                  ,[IsActive]
                  ,[Name]
                  ,[Description]
                  ,[Class]
                  ,[CronExpression]
                  ,[NotificationStatus]
                  ,[Guid] )
               VALUES ( 
                  0
                  ,1
                  ,'Calculate Missions Org Giving Statistics'
                  ,''
                  ,'Rock.Jobs.RunSQL'
                  ,'0 0 2 1/1 * ? *'
                  ,1
                  ,'A536A577-6805-41FE-ABF7-CA0C96E69686'
                  );
            END");
            // Attribute: Rock.Jobs.RunSQL: SQL Query
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.ServiceJob", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Class", "Rock.Jobs.RunSQL", "SQL Query", "", @"SQL query to run", 0, @"", "7AD0C57A-D40E-4A14-81D8-8ACA68600FF5", "SQLQuery");
            // Attribute: Rock.Jobs.RunSQL: Command Timeout
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.ServiceJob", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Class", "Rock.Jobs.RunSQL", "Command Timeout", "", @"Maximum amount of time (in seconds) to wait for the SQL Query to complete. Leave blank to use the SQL default (30 seconds).", 1, @"180", "FF66ABF1-B01D-4AE7-814E-95D842B2EA99", "CommandTimeout");
            RockMigrationHelper.AddAttributeValue("7AD0C57A-D40E-4A14-81D8-8ACA68600FF5", Int32.Parse(SqlScalar("SELECT [Id] FROM ServiceJob WHERE [Guid] = 'A536A577-6805-41FE-ABF7-CA0C96E69686'").ToString()), @"DECLARE @GlobalGospelFundGuid uniqueidentifier = ''1498C488-BD30-47D3-9FF5-0CB93714A3B7'';
DECLARE @MissionaryAccountId int = (SELECT [Id] FROM [DefinedValue] WHERE [Guid] = ''53329569-5097-4975-BDFE-AD7A6CE920F9'')
DECLARE @ProjectAccountId int = (SELECT [Id] FROM [DefinedValue] WHERE [Guid] = ''FB0507A0-4D30-41D6-98E1-A48BC9F35967'')

DECLARE @PercentileAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''FAC84A6F-6D6C-4DA6-8FBB-B205C9CD43FB'')
DECLARE @GGFAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''256DE6C9-A282-47F0-8150-5AE81236F49E'')
DECLARE @MissionaryAccountsSupportedAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''F00B9B07-7616-45F9-91AE-43D6D6310A4E'')
DECLARE @ProjectAccountsSupportedAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''4CB9FC43-399B-4755-9F0A-C42EF11BB126'') 
DECLARE @12MonthGivingAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''2B43A278-A755-4B24-8085-32103A915657'')
DECLARE @Prev12MonthGivingAttributeId int  = (SELECT [Id] FROM [Attribute] WHERE [Guid] = ''432DDB0C-A998-40D4-B7C7-1891B2CBF252'')

-- Delete old values
DELETE FROM AttributeValue WHERE AttributeId IN (@PercentileAttributeId, @GGFAttributeId, @MissionaryAccountsSupportedAttributeId,
		@ProjectAccountsSupportedAttributeId, @12MonthGivingAttributeId, @Prev12MonthGivingAttributeId)

DECLARE @TempAttributeValues table (AttributeId int, EntityId int, [Value] varchar(max))

-- Calculate Percentiles
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT @PercentileAttributeId [AttributeId], [Person].[Id] [EntityId], FLOOR(PERCENT_RANK() OVER(PARTITION BY Person.RecordTypeValueId ORDER BY [Amount])*100) [Value]
FROM (SELECT GivingId, SUM(FinancialTransactionDetail.Amount) [Amount]
FROM [FinancialTransactionDetail]
INNER JOIN [FinancialTransaction] ON FinancialTransactionDetail.TransactionId = FinancialTransaction.Id
LEFT JOIN [PersonAlias] ON [PersonAlias].Id = AuthorizedPersonAliasId
LEFT JOIN [Person] ON [Person].Id = PersonAlias.PersonId
WHERE DATEDIFF(mm, TransactionDateTime, GETDATE()) <= 12
GROUP BY GivingId) [TopDonors]
INNER JOIN [Person] ON [TopDonors].GivingId = [Person].GivingId
OUTER APPLY (SELECT TOP (1) [Id] FROM [PersonAlias] WHERE PersonId = Person.Id) [Alias]

-- Calculate Missionary Accounts
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT
	@MissionaryAccountsSupportedAttributeId
	,p2.Id
    ,COUNT(DISTINCT FinancialAccount.Id) [MissionaryAccounts]
FROM FinancialTransactionDetail
INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
INNER JOIN [PersonAlias] ON FinancialTransaction.AuthorizedPersonAliasId = PersonAlias.Id
INNER JOIN [Person] ON Person.Id = PersonAlias.PersonId
INNER JOIN [Person] [p2] ON p2.GivingGroupId = Person.GivingGroupId
WHERE FinancialAccount.AccountTypeValueId = @MissionaryAccountId AND DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) <= 365
GROUP BY p2.Id HAVING SUM([Amount]) > 0

-- Calculate Project Accounts
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT
	@ProjectAccountsSupportedAttributeId
	,p2.Id
    ,COUNT(DISTINCT FinancialAccount.Id) [MissionaryAccounts]
FROM FinancialTransactionDetail
INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
INNER JOIN [PersonAlias] ON FinancialTransaction.AuthorizedPersonAliasId = PersonAlias.Id
INNER JOIN [Person] ON Person.Id = PersonAlias.PersonId
INNER JOIN [Person] [p2] ON p2.GivingGroupId = Person.GivingGroupId
WHERE FinancialAccount.AccountTypeValueId = @ProjectAccountId AND DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) <= 365
GROUP BY p2.Id HAVING SUM([Amount]) > 0

-- Calculate current 12 month giving
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT
	@12MonthGivingAttributeId
	,p2.Id
    ,SUM(FinancialTransactionDetail.Amount)
FROM FinancialTransactionDetail
INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
INNER JOIN [PersonAlias] ON FinancialTransaction.AuthorizedPersonAliasId = PersonAlias.Id
INNER JOIN [Person] ON Person.Id = PersonAlias.PersonId
INNER JOIN [Person] [p2] ON p2.GivingGroupId = Person.GivingGroupId
WHERE DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) <= 365
GROUP BY p2.Id

-- Calculate previous 12 month giving
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT
	@Prev12MonthGivingAttributeId
	,p2.Id
    ,SUM(FinancialTransactionDetail.Amount)
FROM FinancialTransactionDetail
INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
INNER JOIN [PersonAlias] ON FinancialTransaction.AuthorizedPersonAliasId = PersonAlias.Id
INNER JOIN [Person] ON Person.Id = PersonAlias.PersonId
INNER JOIN [Person] [p2] ON p2.GivingGroupId = Person.GivingGroupId
WHERE DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) > 365 AND DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) <= 730
GROUP BY p2.Id

-- Calculate GGF Giver
INSERT INTO @TempAttributeValues (AttributeId, EntityId, [Value])
SELECT
	@GGFAttributeId
	,p2.Id
	,''True''
FROM FinancialTransactionDetail
INNER JOIN [FinancialTransaction] ON [FinancialTransactionDetail].[TransactionId] = FinancialTransaction.Id
INNER JOIN [FinancialAccount] ON [FinancialTransactionDetail].[AccountId] = FinancialAccount.Id
INNER JOIN [PersonAlias] ON FinancialTransaction.AuthorizedPersonAliasId = PersonAlias.Id
INNER JOIN [Person] ON Person.Id = PersonAlias.PersonId
INNER JOIN [Person] [p2] ON p2.GivingGroupId = Person.GivingGroupId
WHERE FinancialAccount.[Guid] = @GlobalGospelFundGuid AND DATEDIFF(dd, FinancialTransaction.TransactionDateTime, GETDATE()) <= 365
GROUP BY p2.Id

-- Insert new values

INSERT INTO AttributeValue (AttributeId, EntityId, [Value], [ValueAsNumeric], IsSystem, [Guid])
SELECT AttributeId, EntityId, [Value], [Value], 0, NEWID()
FROM @TempAttributeValues
WHERE AttributeId != @GGFAttributeId

INSERT INTO AttributeValue (AttributeId, EntityId, [Value], IsSystem, [Guid])
SELECT AttributeId, EntityId, [Value], 0, NEWID()
FROM @TempAttributeValues
WHERE [AttributeId] = @GGFAttributeId", "7AD0C57A-D40E-4A14-81D8-8ACA68600FF5"); // Calculate Missions Org Giving Statistics: SQL Query
            RockMigrationHelper.AddAttributeValue("FF66ABF1-B01D-4AE7-814E-95D842B2EA99", Int32.Parse(SqlScalar("SELECT [Id] FROM ServiceJob WHERE [Guid] = 'A536A577-6805-41FE-ABF7-CA0C96E69686'").ToString()), @"300", "FF66ABF1-B01D-4AE7-814E-95D842B2EA99"); // Calculate Missions Org Giving Statistics: Command Timeout

            // Update Donor Profile lava shortcode
            Sql(@"UPDATE [LavaShortCode]
	SET [Markup] = '{% assign person = personid | PersonById %}

{% assign ggfDonor = person | Attribute:''GlobalGospelFundDonor'' %}
{% assign givingTotal = person | Attribute:''12MonthGivingTotal'',''RawValue'' | Default:''0'' %}
{% assign prevGivingTotal = person | Attribute:''Previous12MonthGivingTotal'', ''RawValue'' | Default:''0'' %}
<a href=""/Person/{{personid}}/Contributions"">
<div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ person | Attribute:''Percentile'' | Default:''0'' }} <i class=""fa fa-star"" style=""color: gold;""></i></div>
<div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ person | Attribute:''MissionaryAccountsSupported'' | Default:''0'' }} <i class=""fa fa-group""></i></div>
<div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"">{{ person | Attribute:''ProjectAccountsSupported'' | Default:''0'' }} <i class=""fa fa-hammer""></i></div>
<div class=""badge"" style=""background-color: #efefef;color: black;padding: 10px;"" title=""Prev: {{prevGivingTotal | FormatAsCurrency}}"">{{ givingTotal | FormatAsCurrency }}
{% if givingTotal > prevGivingTotal %}<i class=""text-success fa fa-caret-square-up""></i>{% else %}<i class=""text-danger fa fa-caret-square-down""></i>{% endif %}</div>

{% if ggfDonor == ""Yes"" %}
<div class=''badge'' style=""padding: 10px;color: black;background-color: #efefef;""><i class=""fas fa-globe-americas"" style=""color: black;""></i> Global Gospel </div>
{% endif %}
</a>' WHERE [Guid] = '694913FD-9068-4547-89B6-59ABDFE44CB8'");

            // Update badge
            string BadgeContentAttribute = SqlScalar(@"DECLARE @InDataViewComponentId int = (SELECT [Id] FROM [EntityType] WHERE [name] = 'Rock.Badge.Component.InDataView')
            DECLARE @BadgeContentAttributeGuid uniqueidentifier = (SELECT [Guid] FROM [Attribute] WHERE [Key] = 'BadgeContent' AND [EntityTypeQualifierColumn] = 'BadgeComponentEntityTypeId' AND [EntityTypeQualifierValue] = @InDataViewComponentId)
            SELECT @BadgeContentAttributeGuid").ToString();

            RockMigrationHelper.AddBadgeAttributeValue("2F809E23-94C6-45C2-A3F1-6658AF868C57", BadgeContentAttribute, @"<div class=""badge"" style=""margin-top: 7px; padding-top: 0px""><a href=""/Person/{{Person.Id}}/Contributions"">{[ donorprofile personid:'{{Person.Id}}' ]}</a></div>");
            RockMigrationHelper.UpdateBlockAttributeValue("98A30DD7-8665-4C6D-B1BB-A8380E862A04", "F5AB231E-3836-4D52-BD03-BF79773C237A", "2f809e23-94c6-45c2-a3f1-6658af868c57,8a9ad88e-359f-46fd-9ba1-8b0603644f17");

            // Add Block Attribute Values to Page: Extended Attributes, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "1C737278-4CBA-404B-B6B3-E3F0E05AB5FE".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "D70A59DC-16BE-43BE-9880-59598FA7A94C".AsGuid(), "Attribute Values", "SectionB2", @"", @"", 4, "310A7CC3-17D9-45B3-84F5-E6E607C25321");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Attribute Values
            Sql(@"UPDATE [Block] SET [Order] = 2 WHERE [Guid] = '8DA21ED3-E4BC-483C-8B22-A041FEEE8FF4'");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Attribute Values
            Sql(@"UPDATE [Block] SET [Order] = 4 WHERE [Guid] = '310A7CC3-17D9-45B3-84F5-E6E607C25321'");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Childhood Information
            Sql(@"UPDATE [Block] SET [Order] = 1 WHERE [Guid] = '441F849F-37C2-4709-B9BB-417204AF3168'");

            // Update Order for Page: Extended Attributes,  Zone: SectionB2,  Block: Financial Information
            Sql(@"UPDATE [Block] SET [Order] = 3 WHERE [Guid] = 'D2753991-285C-4BB2-9718-9CD513805BB1'");


            // Add Block Attribute Value
            //   Block: Attribute Values
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Use Abbreviated Name
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("310A7CC3-17D9-45B3-84F5-E6E607C25321", "51693680-B03C-468B-A771-CD8C103D0B1B", @"False");

            // Add Block Attribute Value
            //   Block: Attribute Values
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Show Category Names as Separators
            //   Attribute Value: False
            RockMigrationHelper.AddBlockAttributeValue("310A7CC3-17D9-45B3-84F5-E6E607C25321", "EF57237E-BA12-488A-9585-78466E4C3DB5", @"False");

            // Add Block Attribute Value
            //   Block: Attribute Values
            //   BlockType: Attribute Values
            //   Block Location: Page=Extended Attributes, Site=Rock RMS
            //   Attribute: Category
            //   Attribute Value: ffb348c5-4c42-4332-9b84-651b4a0b05de
            RockMigrationHelper.AddBlockAttributeValue("310A7CC3-17D9-45B3-84F5-E6E607C25321", "EC43CF32-3BDF-4544-8B6A-CE9208DD7C81", @"8953b504-7701-49d2-b226-93822d9af2e8");

        }

        public override void Down()
        {
            
        }
    }
}
