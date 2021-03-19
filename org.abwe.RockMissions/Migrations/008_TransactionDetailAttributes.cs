using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(8, "1.12.0")]
    public class TransactionDetailAttributes : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialTransactionDetail", "1edafded-dfe6-4334-b019-6eecba89e05a", "", "", "Anonymous", "Anonymous", "This designation should be kept anonymous", 0, "N", SystemGuid.Attributes.TRANSACTION_DETAIL_ANONYMOUS, "Anonymous");
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialTransactionDetail", "1edafded-dfe6-4334-b019-6eecba89e05a", "", "", "Deductible", "Deductible", "This designation is tax deductible", 0, "N", SystemGuid.Attributes.TRANSACTION_DETAIL_DEDUCTIBLE, "Deductible");
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialTransactionDetail", "9c204cd0-1233-41c5-818a-c5da439445aa", "", "", "Marketing Code", "Marketing Code", "The marketing code that generated this contribution", 0, "", SystemGuid.Attributes.TRANSACTION_DETAIL_MARKETING_CODE, "MarketingCode");
            RockMigrationHelper.AddOrUpdateEntityAttribute("Rock.Model.FinancialTransactionDetail", "e4eab7b2-0b76-429b-afe4-ad86d7428c70", "", "", "Related Giving", "Related Giving", "The individual this gift originated from", 0, "", SystemGuid.Attributes.TRANSACTION_DETAIL_RELATED_GIVING, "RelatedGiving");

            Sql($@"UPDATE Attribute SET IsGridColumn = 1 WHERE [Guid] IN ('{SystemGuid.Attributes.TRANSACTION_DETAIL_ANONYMOUS}', '{SystemGuid.Attributes.TRANSACTION_DETAIL_DEDUCTIBLE}','{SystemGuid.Attributes.TRANSACTION_DETAIL_MARKETING_CODE}','{SystemGuid.Attributes.TRANSACTION_DETAIL_RELATED_GIVING}')");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute(SystemGuid.Attributes.TRANSACTION_DETAIL_ANONYMOUS);
            RockMigrationHelper.DeleteAttribute(SystemGuid.Attributes.TRANSACTION_DETAIL_DEDUCTIBLE);
            RockMigrationHelper.DeleteAttribute(SystemGuid.Attributes.TRANSACTION_DETAIL_MARKETING_CODE);
            RockMigrationHelper.DeleteAttribute(SystemGuid.Attributes.TRANSACTION_DETAIL_RELATED_GIVING);
        }
    }
}
