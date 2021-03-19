using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(7, "1.12.0")]
    public class PaymentTypes : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.UpdateDefinedValue("1D1304DE-E83A-44AF-B11D-0C66DD600B81", "Internal Transfer", "Used to track internal transfers.", SystemGuid.DefinedValue.CURRENCY_TYPE_INTERNAL_TRANSFER, false);
            RockMigrationHelper.UpdateDefinedValue("1D1304DE-E83A-44AF-B11D-0C66DD600B81", "Missionary To Missionary Donation", "Used to track donations from one missionary to another.", SystemGuid.DefinedValue.CURRENCY_TYPE_MISSIONARY_TO_MISSIONARY_DONATION, false);
            RockMigrationHelper.UpdateDefinedValue("1D1304DE-E83A-44AF-B11D-0C66DD600B81", "Wire", "Used to track wires.", SystemGuid.DefinedValue.CURRENCY_TYPE_WIRE, false);
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.CURRENCY_TYPE_WIRE); // Wire	1
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.CURRENCY_TYPE_INTERNAL_TRANSFER); // Internal Transfer	1
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.CURRENCY_TYPE_MISSIONARY_TO_MISSIONARY_DONATION); // Missionary To Missionary Donation	1
        }
    }
}
