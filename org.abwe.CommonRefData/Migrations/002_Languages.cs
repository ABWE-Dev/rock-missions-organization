using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;

namespace org.abwe.CommonRefData.Migrations
{
    [MigrationNumber(2, "1.6.0")]
    class Languages : Migration
    {
        public override void Up()
        {
            System.Diagnostics.Debug.WriteLine("Executing Languages Up Migration");
            RockMigrationHelper.AddDefinedType("Communication", "Language", "World Languages", org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES);

            // value if alpha then ISO 639-1 code, if numeric then part of a macrolanguage like Mandarin in the Chinese family or 
            // other non ISO 639-1 recognized language
            //
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AB", "ABKHAZIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "OM", "AFAN, OROMO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AA", "AFAR", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "15", "AF - MAAY", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AF", "AFRIKAANS", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SQ", "ALBANIAN, SHQIP", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "01", "AMERICAN SIGN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AM", "AMHARIC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AR", "ARABIC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HY", "ARMENIAN, HAYEREN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AS", "ASSAMESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "16", "ASSYRIAN NEO-ARAMAIC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AY", "AYMARA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "AZ", "AZERBAIJANI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BA", "BASHKIR", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "EU", "BASQUE, EUSKERA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "17", "BEHDINI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BN", "BENGALI,BANGLA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "DZ", "BHUTANI,BHUTANESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BH", "BIHARI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BI", "BISLAMA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BS", "BOSNIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BR", "BRETON", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BG", "BULGARIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MY", "BURMESE,MYANMASA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BE", "BYELORUSSIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KM", "CAMBODIAN,KHMER", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "12", "CANTONESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "CA", "CATALAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "19", "CHALDEAN NEO-ARAMAIC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "CH", "CHAMARRO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "CO", "CORSICAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HR", "CROATIAN, CROAT, HRVATSKI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "CS", "CZECH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "DA", "DANISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "21", "DINKA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "NL", "DUTCH,NEDERLANDS", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "EN", "ENGLISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ET", "ESTONIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FO", "FAROESE,FAEROESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FA", "FARSI,PARSIAN,PERSIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FJ", "FIJI,FIJIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FI", "FINNISH,SUOMI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "22", "FLEMISH(DUTCH)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "23", "FORMOSAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FR", "FRENCH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FY", "FRISIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "24", "FUJIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "25", "FUKIENESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "FL", "FULA, FULAH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "GL", "GALICIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KA", "GEORGIAN,KARTULI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "DE", "GERMAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "EL", "GREEK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KL", "GREENLANDIC,KALAALLISUT", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "GN", "GUARANI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "GU", "GUJARATI,GUJERATI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HT", "HAITIAN CREOLE/ FRENCH CREOLE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "26", "HAKKA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HA", "HAUSA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "27", "HAWRAMI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HE", "HEBREW,IWRITH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HI", "HINDI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "28", "HMONG(BLUE / GREEN)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "03", "HMONG(WHITE)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "29", "HUNANESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "HU", "HUNGARIAN,MAGYAR", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "30", "IBO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "IS", "ICELANDIC,ISLENZK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "04", "ILACANO(ILOKO)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ID", "INDONESIAN, BAHASA, INDONESIA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "IU", "INUKTITUT", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "IK", "INUPIAK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "GA", "IRISH, GAEILGE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "IT", "ITALIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "JA", "JAPANESE, NIHONGO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "JV", "JAVANESE, BAHASA JAWA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KN", "KANNADA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KS", "KASHMIRI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KK", "KAZAKH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "RW", "KINYARWANDA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KY", "KIRGHIZ,KYRGYZ", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "RN", "KIRUNDI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KO", "KOREAN,CHOSON - O", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "31", "KPELLE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "KU", "KURDISH,ZIMANY KURDY", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "32", "KURMANJI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "LO", "LAOTIAN,LAOTHIAN,PHA XA LOA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "LV", "LATVIAN,LETTISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "LN", "LINGALA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "LT", "LITHUANIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MK", "MACEDONIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MG", "MALAGASY", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MS", "MALAY, BAHASA MALAYSIA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ML", "MALAYALAM", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MT", "MALTESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "14", "MANDARIN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MI", "MAORI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MR", "MARATHI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MH", "MARSHALLESE(EBON)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "33", "MENDE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "06", "MIEN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "34", "MIXE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "35", "MIXTECO - ALTA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "36", "MIXTECO - BAJA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MO", "MOLDAVIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "MN", "MONGOLIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "NE", "NAPALI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "NV", "NAVAJO, NAVAHO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "NO", "NORWEGIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "37", "NUER", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "OC", "OCCITAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "OR", "ORIYA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "PS", "PASHTO,PUSHTO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "PL", "POLISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "PT", "PORTUGESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "PA", "PUNJABI,PANJABI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "QU", "QUECHUA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "RM", "RHAETO - ROMANCE,ROMANSCH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "RO", "ROMANIA,RUMANIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "RU", "RUSSIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SM", "SAMOAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SG", "SANGHO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "GD", "SCOTS GAELIC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SR", "SERBIAN, SRPSKI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ST", "SESOTHO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TN", "SETSWANA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "38", "SHANGHAINESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SN", "SHONA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SD", "SINDHI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SI", "SINGHALESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SS", "SISWATI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SK", "SLOVAK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SL", "SLOVENIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SO", "SOMALI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ES", "SPANISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SU", "SUDANESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SW", "SWAHILI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "SV", "SWEDISH,SVENSKA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TL", "TAGALOG", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TG", "TAJIK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TA", "TAMIL", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "39", "TARASCO", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TT", "TATAR", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TE", "TELUGU", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TH", "THAI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "BO", "TIBETIAN,BODSKAD", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TI", "TIGRIGNA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "40", "TIO CHIU OR TEOCHEW", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TO", "TONGAN(LANGUAGE OF TONGA)", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TS", "TSONGA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TR", "TURKISH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TK", "TURKMEN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "TW", "TWI", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "UG", "UIGUR", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "UK", "UKRAINIAN", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "UR", "URDU", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "UZ", "UZBEK", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "VI", "VIETNAMESE", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "CY", "WELSH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "WO", "WOLOF", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "41", "WU", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "XH", "XHOSA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "YI", "YIDDISH,JIDDISCH", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "YO", "YORUBA", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "42", "ZAPTEC", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ZA", "ZHUANG", Guid.NewGuid().ToString(), false);
            RockMigrationHelper.AddDefinedValue(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES, "ZU", "ZULU", Guid.NewGuid().ToString(), false);
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedType(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES);
        }
    }
}
