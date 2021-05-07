using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.SystemGuid
{
    /// <summary>
    /// System Defined Types
    /// </summary>
    public static class DefinedValue
    {
        /// <summary>
        /// Mission Organization Connection Statuses
        /// </summary>
        public const string PERSON_CONNECTION_STATUS_CONTACT = "CFB54177-3CC8-4A27-A1BF-7214415D7127";
        public const string PERSON_CONNECTION_STATUS_DONOR = "181CA31A-DE08-4C61-A7CC-205F5B1CEB77";
        public const string PERSON_CONNECTION_STATUS_LEAD = "6CBE5A37-B525-4C6F-82DB-E012B4F4F779";
        public const string PERSON_CONNECTION_STATUS_MISSIONARY = "41540783-D9EF-4C70-8F1D-C9E83D91ED5F";
        public const string PERSON_CONNECTION_STATUS_STAFF = "30AE3FE6-C1A2-44D9-A35A-D24E610CF612";
        public const string PERSON_CONNECTION_STATUS_VOLUNTEER = "D6DBD004-3F27-4377-9552-2687CF2B114E";
        // There are two other connection types, applicant and partner, but because of their protected status
        // they are tracked differently.

        /// <summary>
        /// Phone Type - Field 
        /// </summary>
        public const string PHONE_TYPE_FIELD = "35FADC75-9C52-4861-9AFA-02722E308360";

        /// <summary>
        /// Location Type - Field 
        /// </summary>
        public const string LOCATION_TYPE_FIELD = "F5C1BD2D-4D2D-461B-8CF4-922104460E97";

        /// <summary>
        /// Currency Type - Missionary To Missionary Donation 
        /// </summary>
        public const string CURRENCY_TYPE_MISSIONARY_TO_MISSIONARY_DONATION = "3B1A575D-2A05-48CE-9ED8-486B78109672";

        /// <summary>
        /// Currency Type - Internal Transfer 
        /// </summary>
        public const string CURRENCY_TYPE_INTERNAL_TRANSFER = "2BCCD3E7-050B-4AA5-880B-D8168C702A40";

        /// <summary>
        /// Currency Type - Wire 
        /// </summary>
        public const string CURRENCY_TYPE_WIRE = "04A7959D-02E3-4ADB-9F46-2537921E518E";


        /// <summary>
        /// Account Type - Missionary 
        /// </summary>
        public const string ACCOUNT_TYPE_MISSIONARY = "53329569-5097-4975-BDFE-AD7A6CE920F9";

        /// <summary>
        /// Account Type - Project 
        /// </summary>
        public const string ACCOUNT_TYPE_PROJECT = "FB0507A0-4D30-41D6-98E1-A48BC9F35967";

    }
}
