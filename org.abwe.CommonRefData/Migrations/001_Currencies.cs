﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;

namespace org.abwe.CommonRefData.Migrations
{
    [MigrationNumber(2,"1.6.0")]
    class Currencies : Migration
    {
        public override void Up()
        {
            RockMigrationHelper.AddDefinedType("Financial", "Currency", "World Currencies", org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES);

            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AFA", "Afghanistan Afghani", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ALL", "Albanian Lek", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "DZD", "Algerian dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AOA", "Angolan Kwanzaa reajustado", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ARS", "Argentine peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AMD", "Armenian dram", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AWG", "Aruban guilder", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AUD", "Australian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AZN", "Azerbaijanian new manat", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BSD", "Bahamian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BHD", "Bahraini dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BDT", "Bangladeshi taka", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BBD", "Barbados dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BYN", "Belarusian ruble", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BZD", "Belize dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BMD", "Bermudian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BTN", "Bhutan ngultrum", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BOB", "Bolivian boliviano", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BWP", "Botswana pula", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BRL", "Brazilian real", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GBP", "British pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BND", "Brunei dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BGN", "Bulgarian lev", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "BIF", "Burundi franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KHR", "Cambodian riel", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CAD", "Canadian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CVE", "Cape Verde escudo", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KYD", "Cayman Islands dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XOF", "CFA franc BCEAO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XAF", "CFA franc BEAC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XPF", "CFP franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CLP", "Chilean peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CNY", "Chinese yuan renminbi", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "COP", "Colombian peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KMF", "Comoros franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CDF", "Congolese franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CRC", "Costa Rican colon", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "HRK", "Croatian kuna", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CUP", "Cuban peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CZK", "Czech koruna", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "DKK", "Danish krone", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "DJF", "Djibouti franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "DOP", "Dominican peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XCD", "East Caribbean dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "EGP", "Egyptian pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SVC", "El Salvador colon", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ERN", "Eritrean nakfa", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "EEK", "Estonian kroon", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ETB", "Ethiopian birr", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "EUR", "EU euro", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "FKP", "Falkland Islands pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "FJD", "Fiji dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GMD", "Gambian dalasi", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GEL", "Georgian lari", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GHS", "Ghanaian new cedi", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GIP", "Gibraltar pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XAU", "Gold(ounce)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XFO", "Gold franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GTQ", "Guatemalan quetzal", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GNF", "Guinean franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "GYD", "Guyana dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "HTG", "Haitian gourde", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "HNL", "Honduran lempira", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "HKD", "Hong Kong SAR dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "HUF", "Hungarian forint", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ISK", "Icelandic krona", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XDR", "IMF special drawing right", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "INR", "Indian rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "IDR", "Indonesian rupiah", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "IRR", "Iranian rial", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "IQD", "Iraqi dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ILS", "Israeli new shekel", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "JMD", "Jamaican dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "JPY", "Japanese yen", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "JOD", "Jordanian dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KZT", "Kazakh tenge", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KES", "Kenyan shilling", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KWD", "Kuwaiti dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KGS", "Kyrgyz som", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LAK", "Lao kip", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LVL", "Latvian lats", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LBP", "Lebanese pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LSL", "Lesotho loti", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LRD", "Liberian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LYD", "Libyan dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LTL", "Lithuanian litas", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MOP", "Macao SAR pataca", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MKD", "Macedonian denar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MGA", "Malagasy ariary", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MWK", "Malawi kwacha", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MYR", "Malaysian ringgit", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MVR", "Maldivian rufiyaa", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MRO", "Mauritanian ouguiya", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MUR", "Mauritius rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MXN", "Mexican peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MDL", "Moldovan leu", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MNT", "Mongolian tugrik", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MAD", "Moroccan dirham", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MZN", "Mozambique new metical", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "MMK", "Myanmar kyat", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NAD", "Namibian dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NPR", "Nepalese rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ANG", "Netherlands Antillian guilder", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NZD", "New Zealand dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NIO", "Nicaraguan cordoba oro", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NGN", "Nigerian naira", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KPW", "North Korean won", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "NOK", "Norwegian krone", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "OMR", "Omani rial", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PKR", "Pakistani rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XPD", "Palladium(ounce)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PAB", "Panamanian balboa", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PGK", "Papua New Guinea kina", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PYG", "Paraguayan guarani", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PEN", "Peruvian nuevo sol", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PHP", "Philippine peso", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XPT", "Platinum(ounce)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "PLN", "Polish zloty", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "QAR", "Qatari rial", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "RON", "Romanian new leu", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "RUB", "Russian ruble", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "RWF", "Rwandan franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SHP", "Saint Helena pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "WST", "Samoan tala", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "STD", "Sao Tome and Principe dobra", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SAR", "Saudi riyal", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "RSD", "Serbian dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SCR", "Seychelles rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SLL", "Sierra Leone leone", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XAG", "Silver(ounce)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SGD", "Singapore dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SBD", "Solomon Islands dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SOS", "Somali shilling", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ZAR", "South African rand", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "KRW", "South Korean won", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "LKR", "Sri Lanka rupee", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SDG", "Sudanese pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SRD", "Suriname dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SZL", "Swaziland lilangeni", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SEK", "Swedish krona", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "CHF", "Swiss franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "SYP", "Syrian pound", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TWD", "Taiwan New dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TJS", "Tajik somoni", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TZS", "Tanzanian shilling", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "THB", "Thai baht", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TOP", "Tongan pa'anga", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TTD", "Trinidad and Tobago dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TND", "Tunisian dinar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TRY", "Turkish lira", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "TMT", "Turkmen new manat", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "AED", "UAE dirham", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "UGX", "Uganda new shilling", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "XFU", "UIC franc", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "UAH", "Ukrainian hryvnia", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "UYU", "Uruguayan peso uruguayo", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "USD", "US dollar", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "UZS", "Uzbekistani sum", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "VUV", "Vanuatu vatu", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "VEF", "Venezuelan bolivar fuerte", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "VND", "Vietnamese dong", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "YER", "Yemeni rial", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ZMK", "Zambian kwacha", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES, "ZWL", "Zimbabwe dollar", Guid.NewGuid().ToString(), false);
        }
        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedType(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES);
        }
    }
}
