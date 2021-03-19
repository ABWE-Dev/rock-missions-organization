using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(4, "1.12.0")]
    public class ConnectionStatuses : Migration
    {
        public override void Up()
        {
            // Disable built-in Connection Statuses
            Sql($@"UPDATE DefinedValue SET IsActive = 0 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_ATTENDEE}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 0 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_MEMBER}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 0 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_PARTICIPANT}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 0 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_VISITOR}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 0 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_WEB_PROSPECT}'");

            // Create missions agency connection statuses
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Contact", "A category for individuals who don't fall in any of the other categories", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_CONTACT, false);
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Donor", "Donors are individuals who have made a financial contribution to the organization within the last 7 years.", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_DONOR, false);
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Lead", "An individual who is a prospective donor or missionary for the organization.", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_LEAD, false);
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Missionary", "Missionaries are individuals called and sent by a sending church.", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_MISSIONARY, true);
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Staff", "An employee of the organization", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_STAFF, false);
            RockMigrationHelper.UpdateDefinedValue(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Volunteer", "", SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_VOLUNTEER, false);
        }

        public override void Down()
        {
            // Re-activate default connection statuses
            Sql($@"UPDATE DefinedValue SET IsActive = 1 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_ATTENDEE}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 1 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_MEMBER}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 1 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_PARTICIPANT}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 1 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_VISITOR}'");
            Sql($@"UPDATE DefinedValue SET IsActive = 1 WHERE Guid = '{Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_WEB_PROSPECT}'");

            // Delete mission agency connection statuses
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_CONTACT);
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_DONOR);
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_LEAD);
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_MISSIONARY);
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_STAFF);
            RockMigrationHelper.DeleteDefinedValue(SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_VOLUNTEER);
        }
    }
}
