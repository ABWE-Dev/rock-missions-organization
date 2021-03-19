using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(6, "1.12.0")]
    public class FinancialAccounts : Migration
    {
        public override void Up()
        {
            // Insert base Missionaries account
            Sql($@"INSERT [dbo].[FinancialAccount] ([Name], [PublicName], [Description], [IsTaxDeductible], [GlCode], [Order], [IsActive], [Guid], [Url], [PublicDescription], [IsPublic], [ForeignGuid], [ForeignId])
	            VALUES (N'Missionaries', N'Missionaries', N'', 0, N'', 0, 1, N'{SystemGuid.FinancialAccounts.FINANCIAL_ACCOUNT_MISSIONARIES}', N'', N'', 0, NULL, NULL)");

            // Insert base Projects account
            Sql($@"INSERT [dbo].[FinancialAccount] ([Name], [PublicName], [Description], [IsTaxDeductible], [GlCode], [Order], [IsActive], [Guid], [Url], [PublicDescription], [IsPublic], [ForeignGuid], [ForeignId])
	            VALUES (N'Projects', N'Projects', N'', 0, N'', 0, 1, N'{SystemGuid.FinancialAccounts.FINANCIAL_ACCOUNT_PROJECTS}', N'', N'', 0, NULL, NULL)");

            RockMigrationHelper.UpdateDefinedValue("752DA126-471F-4221-8503-5297593C99FF", "Missionary", "A missionary account", SystemGuid.DefinedValue.ACCOUNT_TYPE_MISSIONARY, false);
            RockMigrationHelper.UpdateDefinedValue("752DA126-471F-4221-8503-5297593C99FF", "Project", "A project account", SystemGuid.DefinedValue.ACCOUNT_TYPE_PROJECT, false);
        }

        public override void Down()
        {
            Sql($"DELETE FROM FinancialAccount WHERE Guid = {SystemGuid.FinancialAccounts.FINANCIAL_ACCOUNT_MISSIONARIES}");
            Sql($"DELETE FROM FinancialAccount WHERE Guid = {SystemGuid.FinancialAccounts.FINANCIAL_ACCOUNT_PROJECTS}");

            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.ACCOUNT_TYPE_MISSIONARY); // Missionary
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.ACCOUNT_TYPE_PROJECT); // Project
        }
    }
}
