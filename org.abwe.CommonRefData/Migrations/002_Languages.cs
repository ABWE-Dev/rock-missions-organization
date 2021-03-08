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
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "01", "American Sign", "C3824926-71CE-4E35-A6F2-153E31642BA0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "03", "Hmong(White)", "9ED23458-4EDA-4E05-8A92-26AC66F6CE34", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "04", "Ilacano(Iloko)", "CF6BE70D-7C16-4844-B696-66EC718EB8A3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "06", "Mien", "7188B855-108A-4534-9362-55BDFA727726", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "12", "Cantonese", "DFF2764A-B7E9-4246-B338-75C31A61093D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "14", "Mandarin", "BB11E172-4745-40CF-8911-4A74743CAD7D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "15", "Af - Maay", "4F616E77-4959-455C-A9BA-0740A5E75959", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "16", "Assyrian Neo-Aramaic", "F7B1D486-5025-426C-AF8A-64E48380C11B", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "17", "Behdini", "8741A9ED-5FAE-44C5-86BE-76E79EA75894", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "19", "Chaldean Neo-Aramaic", "9E602793-EFAC-4DD5-8EC9-768359EE7221", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "21", "Dinka", "75F39AE8-175E-4CAB-9C2C-1D8166320454", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "22", "Flemish(Dutch)", "1C6DF6E5-8E50-4A4E-BCE7-B4E199761463", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "23", "Formosan", "D67AAFA0-2896-40DB-9427-658081E397EA", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "24", "Fujian", "C2DEEF60-0ED7-4300-BABC-F1C2B4E1B922", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "25", "Fukienese", "67A93816-558A-47B0-A38D-C55B68D150D6", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "26", "Hakka", "65891DF4-B906-4A7E-B525-6918177C1435", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "27", "Hawrami", "116F7E5E-CD81-4AC1-9E58-53207038B89C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "28", "Hmong(Blue / Green)", "C451543B-10E8-4409-9A5A-CD6733DD440E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "29", "Hunanese", "04AC0B2B-7447-4919-8E27-E2B82BAEA832", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "30", "Ibo", "C5221E9E-D4D0-4EB9-9533-A11976C6EE80", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "31", "Kpelle", "92207540-E849-4191-AA5E-AC27A7262E61", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "32", "Kurmanji", "B691864B-3C68-4AE3-B124-11DDC5AFA31C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "33", "Mende", "CEED7BBB-F60E-40A6-A55B-04FF958ADB34", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "34", "Mixe", "D7BD711E-C584-485B-97E2-A5BA5E48A46F", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "35", "Mixteco - Alta", "53D57ADD-4621-4FFB-9364-07451C098805", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "36", "Mixteco - Baja", "719389E1-81B2-4F9D-9F5E-BCD8EA9C6032", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "37", "Nuer", "9421681B-7AF1-44FF-8762-9C7511E3C7E5", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "38", "Shanghainese", "ED9F3EBA-EF1F-4572-A2A4-2A29B3E4E39A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "39", "Tarasco", "4F74F837-E225-4E69-A8DE-7E14DFBE2A2A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "40", "Tio Chiu or Teochew", "F311272C-3121-4231-9C47-9069E3BC98DA", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "41", "Wu", "969F3EC7-DA54-4356-BEB8-5FF14D2A6B3B", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "42", "Zaptec", "1D8ECCCC-0C02-4254-8D09-47B80C9FBE9E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AA", "Afar", "9D5BFC80-52BF-48AA-9A63-4C413397D4C8", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AB", "Abkhazian", "8CCB980C-5715-44C3-890E-3F083308D656", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AF", "Afrikaans", "DB07F76B-F1E8-478F-B072-2865BF8B4B78", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AM", "Amharic", "65AC66F2-D107-4B4E-90A8-9FC9EB35C0C5", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AR", "Arabic", "1822B7DF-7F7E-465A-9ABA-CB8EE45D0F0B", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AS", "Assamese", "EFD25F51-3A14-41D2-9D15-59C4CAB7AA1E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AY", "Aymara", "31B8CB01-A728-4247-AA1C-6FCE2838A62A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "AZ", "Azerbaijani", "4726CE6D-6B56-47A4-820E-D223B5565338", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BA", "Bashkir", "86110F6E-C26D-45E2-A050-9DEDA49A8E6D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BE", "Byelorussian", "8776443F-1A7E-415F-AD4A-0376F3DF80FB", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BG", "Bulgarian", "285986C4-25BE-4732-9860-5C3859DC7F64", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BH", "Bihari", "D752564A-CB64-45F3-9D61-9263605FC83E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BI", "Bislama", "CED914AF-3053-4238-8F0F-E07DEFCC6FFE", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BN", "Bengali,Bangla", "00816151-C2DC-4521-9EAC-CE0FA7C04C19", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BO", "Tibetian,Bodskad", "37A40E1B-662E-4F70-80EA-86193C53B351", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BR", "Breton", "6939963A-5D3E-4BFE-A4AF-15FDBD67DDAD", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "BS", "Bosnian", "9B1F310C-500F-4115-9029-BDB3D5988447", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "CA", "Catalan", "CB0B36AC-41D4-42B7-B89B-DC678FA5FB2A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "CH", "Chamarro", "71E88E06-DA3E-43C8-9C15-A8B280806ECC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "CO", "Corsican", "427AE17E-CDC8-496C-8515-51992F797355", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "CS", "Czech", "187349EB-195C-46C9-94D4-278CD17A6ACF", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "CY", "Welsh", "26D623CD-197C-443E-82D4-97ABEDAF15C4", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "DA", "Danish", "72DC2FEE-4C08-4B41-81E3-B20305F4C83F", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "DE", "German", "A3CB0CD8-0F1E-45F9-8EBA-7FB4C8C48B94", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "DZ", "Bhutani,Bhutanese", "7833FE2C-E341-464C-B4B7-306AEA5B8188", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "EL", "Greek", "FEA1E42D-61A0-42C1-9C48-5ADFB50D65B5", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "EN", "English", "C29BF918-60E7-47DA-BC65-22EED9111756", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ES", "Spanish", "C99B03E4-E2F5-43A1-9ADE-EB9C04FEE179", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ET", "Estonian", "00888EE3-61D7-4FFD-AACB-448E4E290888", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "EU", "Basque,Euskera", "83FAB84D-41B6-4D31-90F5-5616E1F7B383", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FA", "Farsi,Parsian,Persian", "E2607A3A-4713-4CFC-A8CA-34F8358FE27E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FI", "Finnish,Suomi", "12B8166C-0E9F-46F4-9464-A9D8814FDF30", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FJ", "Fiji,Fijian", "1B68C02F-2941-45F9-A19B-CE023B1604D0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FL", "Fula,Fulah", "2BDE7AAA-925E-4106-848E-61131CC934AC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FO", "Faroese,Faeroese", "577E24E4-5AEA-4D28-BAA1-AD61AB0FBB1D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FR", "French", "ED12D4EA-B6DE-4679-A560-7C35157F1F87", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "FY", "Frisian", "9790A85B-97AA-4ECC-95B3-D68B68A24BD3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "GA", "Irish, Gaeilge", "9BF8E446-BC83-4852-A1B3-B0D725C9E576", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "GD", "Scots Gaelic", "1E7AE75E-32B4-4205-B55C-B6D2024B0ACC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "GL", "Galician", "F3BAC0D4-048B-453E-887E-AB21B24BC8B9", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "GN", "Guarani", "CCFC71EC-CE3D-4CF3-B48D-100BD1E53E9A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "GU", "Gujarati,Gujerati", "F96882D2-FEF3-443C-A263-E2000B802980", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HA", "Hausa", "C9AC98A4-227F-476E-ABEF-91020FCF2CD3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HE", "Hebrew,Iwrith", "92507925-786A-4287-90C8-87E54959897C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HI", "Hindi", "FB3A952A-41E9-46FA-9947-4330473D922D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HR", "Croatian, Croat, Hrvatski", "226489C9-07A7-4D38-881B-CFE522C43E4B", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HT", "Haitian Creole/ French Creole", "1DFDD86B-9C7A-4086-8712-F663422C5A85", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HU", "Hungarian,Magyar", "EC5D07A1-DE10-45B7-B5AD-C7C10ABD9CBE", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "HY", "Armenian, Hayeren", "C474DF36-8D78-4CA8-9B49-DE57C0FCE6FC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ID", "Indonesian, Bahasa, Indonesia", "DC0E88F7-F3C0-4CCD-8B19-E1E61048A577", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "IK", "Inupiak", "02D1A1FC-3865-4B81-9A9A-39F70C7703AA", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "IS", "Icelandic,Islenzk", "FA954B09-DDEE-45FE-ACE3-33DAFA553606", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "IT", "Italian", "BD0AF588-E101-4BDD-9124-6BE5FA8BAE0A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "IU", "Inuktitut", "5EF44AF5-A871-4DF3-8E13-E09C75881695", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "JA", "Japanese, Nihongo", "94FA82B2-E4B7-4C36-B5BC-057BAB6CA6A3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "JV", "Javanese, Bahasa Jawa", "C8C4BE22-045C-42DE-BE87-1D43436D97EC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KA", "Georgian,Kartuli", "E6610690-6D2D-4C32-9F9C-4AA8E7253E51", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KK", "Kazakh", "53AE90CE-0B37-46D1-8054-D8D02B856A9A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KL", "Greenlandic,Kalaallisut", "C8BF156A-83FD-49D2-BAD2-AF08602E5D7D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KM", "Cambodian,Khmer", "444542F2-83F9-413C-A79B-AA03EC2A7772", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KN", "Kannada", "924DF344-BFAF-4992-A562-00C45055C004", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KO", "Korean,Choson - O", "5D7E8B14-0B8D-4D40-B28E-C5C78C54A89C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KS", "Kashmiri", "CA560F66-E0B8-4F2E-8E78-379E6F57CBF6", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KU", "Kurdish,Zimany Kurdy", "589D5506-E1F4-46BE-90FD-A8E3236333DD", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "KY", "Kirghiz,Kyrgyz", "B02CEE37-F730-4589-A5A9-7A2A540099D7", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "LN", "Lingala", "9D53E8F0-94BD-4A93-AC37-EEE5322C8AD6", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "LO", "Laotian,Laothian,Pha Xa Loa", "D24930D0-5F96-4D3C-A8B7-9F1F0E908452", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "LT", "Lithuanian", "F8CE49D1-0E14-4455-AF82-D3A8BD8CA863", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "LV", "Latvian,Lettish", "A276605A-48B0-448C-8E76-55B9F2B46C25", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MG", "Malagasy", "344ECA4A-A717-4CC5-87E1-3779878003D9", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MH", "Marshallese(Ebon)", "39E50B59-86C0-48B4-9C3B-2C5B4A3FBA98", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MI", "Maori", "28BBACA5-5177-4239-9D8F-E0ACE83DD9CD", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MK", "Macedonian", "F6183B32-ACCD-4A5B-8C33-673FDDCBEE6E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ML", "Malayalam", "8062320D-1850-4716-A7A8-B7A398E8A581", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MN", "Mongolian", "C199DF19-EC3E-4796-AF3A-4B23ED14ADEF", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MO", "Moldavian", "F93E99BA-3C8E-4587-B91A-76EC8ED39351", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MR", "Marathi", "F5A90D5B-4892-41F2-B38C-1E42BF69B8E0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MS", "Malay, Bahasa Malaysia", "A0E4BA8C-6CF6-495A-A236-71475A95A615", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MT", "Maltese", "4CB3B43D-5B04-493D-92E8-FB20FA24BC8F", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "MY", "Burmese,Myanmasa", "039E06FB-0B57-4893-B887-15D41E816B17", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "NE", "Napali", "75648A5A-4A61-4301-84D4-DB6F2C65AEC6", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "NL", "Dutch,Nederlands", "C67FEA7E-F707-485D-BEE6-84F8269A0F86", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "NO", "Norwegian", "CC942441-C26B-479F-9404-972DE979B286", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "NV", "Navajo, Navaho", "E5A8F237-157A-45BE-8855-D0337AEDB45D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "OC", "Occitan", "EC434C1C-F710-4D2F-A457-9FC28719D30E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "OM", "Afan, Oromo", "DC8C4C96-0371-47A4-85DF-69DDC56ADDCE", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "OR", "Oriya", "87D7C91B-C6A2-4B1D-9E14-779360084903", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "PA", "Punjabi,Panjabi", "C3AF5037-3D3A-4B3F-B349-7A9762CA5E76", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "PL", "Polish", "F58C518B-5CD4-4CF6-BE10-766EE2E81B0E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "PS", "Pashto,Pushto", "C4261BCB-7052-41ED-BC82-1FAFBFA9CA18", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "PT", "Portugese", "3E9333C9-7B7F-4E36-9250-BD09988B0C4E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "QU", "Quechua", "ACCF2394-BBB1-421F-A842-507D38D92AF3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "RM", "Rhaeto - Romance,Romansch", "FA540E15-3A8A-4E0C-90F8-059CD8A888A4", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "RN", "Kirundi", "AF1C2693-88B0-4ED6-98D3-CF06589A763B", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "RO", "Romania,Rumanian", "0431FE4A-6492-4C15-9C3B-51CA838C64FC", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "RU", "Russian", "321BE912-AD49-48CD-B34E-A06D2B079418", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "RW", "Kinyarwanda", "48F42E68-457E-40C7-87D3-AA0C257E563C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SD", "Sindhi", "97FA92B0-2776-4359-8ABA-7ED333FC11C0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SG", "Sangho", "1B452499-7D24-4A1A-94DE-07A2F6F45DE9", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SI", "Singhalese", "2654EBCD-F0B3-469D-B039-0414FA0CFB3C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SK", "Slovak", "7C36972B-5E4A-4298-AC58-88BF4F907849", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SL", "Slovenian", "3764C896-ACB7-4AE7-A925-658C0DB5FFD4", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SM", "Samoan", "648438E3-28ED-40FF-BC8B-9F9D6A9FA605", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SN", "Shona", "F542A191-591C-43E5-B933-6973F258605A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SO", "Somali", "24B5ACB5-1E9F-44E9-95EB-68D089D50A34", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SQ", "Albanian, Shqip", "DC4CEF63-9655-44DC-B540-A9AEEBF98557", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SR", "Serbian, Srpski", "056C8B61-86F8-46D1-A390-9461DCCC5B0D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SS", "Siswati", "C5F073C8-C207-4E2D-9B8F-48D7164B6AD7", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ST", "Sesotho", "D812BCCE-4DCB-4468-A649-3E37439A84B2", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SU", "Sudanese", "C00C2157-F7EE-47D3-A041-65D86B3A3A8E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SV", "Swedish,Svenska", "D73B0B67-EAF6-472A-AD1E-6FEA37158507", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "SW", "Swahili", "0284F26B-5108-4BC5-A039-FBB991DEA8E2", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TA", "Tamil", "4F059815-E577-4E5C-94A7-F53D36FEE9B8", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TE", "Telugu", "50C9FD2E-7E06-42F3-88C1-A518FDE9EA65", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TG", "Tajik", "6483C43A-1F9D-44BA-949E-F879AF5ECDD8", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TH", "Thai", "AC5837A5-03FD-4C8C-A637-8B2509BD331F", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TI", "Tigrigna", "D63EB497-88EB-4E5B-9042-680598751FBF", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TK", "Turkmen", "C91B339C-A4F2-4BBF-A059-D621EDAB01D3", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TL", "Tagalog", "ACE0232D-859C-4E80-8128-C13E76419BE6", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TN", "Setswana", "8F0B86CA-F728-4549-BE6E-625FF862EEF8", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TO", "Tongan", "8E16D2A7-42A8-4A5B-80B9-D2012BEE0DEF", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TR", "Turkish", "FC75C466-510F-4F9B-A249-37379B1E9A24", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TS", "Tsonga", "19746DDD-2FA7-4A9E-A1FD-DEA81ECF7D6E", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TT", "Tatar", "8051C88B-1001-4629-9EFC-575A3700C55D", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "TW", "Twi", "C5375739-75A0-420E-B00D-1F0ACD98ED9A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "UG", "Uigur", "4DDAFB2E-F69C-4166-B801-B68DA2FA2D4A", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "UK", "Ukrainian", "7E502E41-1AD5-4103-85C9-23CA51C98A72", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "UR", "Urdu", "51AE8B9E-3F67-4338-9A4C-DB0C51EAC611", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "UZ", "Uzbek", "A09FA93F-184D-4D22-BBA8-0E6AA3AA41F2", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "VI", "Vietnamese", "F8A398E8-CC06-4A39-B44B-694E3380930C", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "WO", "Wolof", "2DE98080-CEBB-418D-92D0-1B4E8EFBC009", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "XH", "Xhosa", "F80DC909-5DCF-4912-9ABC-2506EBA9D7A0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "YI", "Yiddish,Jiddisch", "07D453CF-E518-4D35-80A4-0684DFD2A556", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "YO", "Yoruba", "6053B961-F60A-43D2-B844-1D41AD6879E0", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ZA", "Zhuang", "2BE78C98-7702-4793-A4B4-94DB76B12FF5", false);
            RockMigrationHelper.UpdateDefinedValue("884AC1FE-AD6D-45E2-BB2C-899C49CB3774", "ZU", "Zulu", "F2EC4566-1DD3-4AE1-98F2-007658046398", false);

        }

        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedValue("00816151-C2DC-4521-9EAC-CE0FA7C04C19"); // BN
            RockMigrationHelper.DeleteDefinedValue("00888EE3-61D7-4FFD-AACB-448E4E290888"); // ET
            RockMigrationHelper.DeleteDefinedValue("0284F26B-5108-4BC5-A039-FBB991DEA8E2"); // SW
            RockMigrationHelper.DeleteDefinedValue("02D1A1FC-3865-4B81-9A9A-39F70C7703AA"); // IK
            RockMigrationHelper.DeleteDefinedValue("039E06FB-0B57-4893-B887-15D41E816B17"); // MY
            RockMigrationHelper.DeleteDefinedValue("0431FE4A-6492-4C15-9C3B-51CA838C64FC"); // RO
            RockMigrationHelper.DeleteDefinedValue("04AC0B2B-7447-4919-8E27-E2B82BAEA832"); // 29
            RockMigrationHelper.DeleteDefinedValue("056C8B61-86F8-46D1-A390-9461DCCC5B0D"); // SR
            RockMigrationHelper.DeleteDefinedValue("07D453CF-E518-4D35-80A4-0684DFD2A556"); // YI
            RockMigrationHelper.DeleteDefinedValue("116F7E5E-CD81-4AC1-9E58-53207038B89C"); // 27
            RockMigrationHelper.DeleteDefinedValue("12B8166C-0E9F-46F4-9464-A9D8814FDF30"); // FI
            RockMigrationHelper.DeleteDefinedValue("1822B7DF-7F7E-465A-9ABA-CB8EE45D0F0B"); // AR
            RockMigrationHelper.DeleteDefinedValue("187349EB-195C-46C9-94D4-278CD17A6ACF"); // CS
            RockMigrationHelper.DeleteDefinedValue("19746DDD-2FA7-4A9E-A1FD-DEA81ECF7D6E"); // TS
            RockMigrationHelper.DeleteDefinedValue("1B452499-7D24-4A1A-94DE-07A2F6F45DE9"); // SG
            RockMigrationHelper.DeleteDefinedValue("1B68C02F-2941-45F9-A19B-CE023B1604D0"); // FJ
            RockMigrationHelper.DeleteDefinedValue("1C6DF6E5-8E50-4A4E-BCE7-B4E199761463"); // 22
            RockMigrationHelper.DeleteDefinedValue("1D8ECCCC-0C02-4254-8D09-47B80C9FBE9E"); // 42
            RockMigrationHelper.DeleteDefinedValue("1DFDD86B-9C7A-4086-8712-F663422C5A85"); // HT
            RockMigrationHelper.DeleteDefinedValue("1E7AE75E-32B4-4205-B55C-B6D2024B0ACC"); // GD
            RockMigrationHelper.DeleteDefinedValue("226489C9-07A7-4D38-881B-CFE522C43E4B"); // HR
            RockMigrationHelper.DeleteDefinedValue("24B5ACB5-1E9F-44E9-95EB-68D089D50A34"); // SO
            RockMigrationHelper.DeleteDefinedValue("2654EBCD-F0B3-469D-B039-0414FA0CFB3C"); // SI
            RockMigrationHelper.DeleteDefinedValue("26D623CD-197C-443E-82D4-97ABEDAF15C4"); // CY
            RockMigrationHelper.DeleteDefinedValue("285986C4-25BE-4732-9860-5C3859DC7F64"); // BG
            RockMigrationHelper.DeleteDefinedValue("28BBACA5-5177-4239-9D8F-E0ACE83DD9CD"); // MI
            RockMigrationHelper.DeleteDefinedValue("2BDE7AAA-925E-4106-848E-61131CC934AC"); // FL
            RockMigrationHelper.DeleteDefinedValue("2BE78C98-7702-4793-A4B4-94DB76B12FF5"); // ZA
            RockMigrationHelper.DeleteDefinedValue("2DE98080-CEBB-418D-92D0-1B4E8EFBC009"); // WO
            RockMigrationHelper.DeleteDefinedValue("31B8CB01-A728-4247-AA1C-6FCE2838A62A"); // AY
            RockMigrationHelper.DeleteDefinedValue("321BE912-AD49-48CD-B34E-A06D2B079418"); // RU
            RockMigrationHelper.DeleteDefinedValue("344ECA4A-A717-4CC5-87E1-3779878003D9"); // MG
            RockMigrationHelper.DeleteDefinedValue("3764C896-ACB7-4AE7-A925-658C0DB5FFD4"); // SL
            RockMigrationHelper.DeleteDefinedValue("37A40E1B-662E-4F70-80EA-86193C53B351"); // BO
            RockMigrationHelper.DeleteDefinedValue("39E50B59-86C0-48B4-9C3B-2C5B4A3FBA98"); // MH
            RockMigrationHelper.DeleteDefinedValue("3E9333C9-7B7F-4E36-9250-BD09988B0C4E"); // PT
            RockMigrationHelper.DeleteDefinedValue("427AE17E-CDC8-496C-8515-51992F797355"); // CO
            RockMigrationHelper.DeleteDefinedValue("444542F2-83F9-413C-A79B-AA03EC2A7772"); // KM
            RockMigrationHelper.DeleteDefinedValue("4726CE6D-6B56-47A4-820E-D223B5565338"); // AZ
            RockMigrationHelper.DeleteDefinedValue("48F42E68-457E-40C7-87D3-AA0C257E563C"); // RW
            RockMigrationHelper.DeleteDefinedValue("4CB3B43D-5B04-493D-92E8-FB20FA24BC8F"); // MT
            RockMigrationHelper.DeleteDefinedValue("4DDAFB2E-F69C-4166-B801-B68DA2FA2D4A"); // UG
            RockMigrationHelper.DeleteDefinedValue("4F059815-E577-4E5C-94A7-F53D36FEE9B8"); // TA
            RockMigrationHelper.DeleteDefinedValue("4F616E77-4959-455C-A9BA-0740A5E75959"); // 15
            RockMigrationHelper.DeleteDefinedValue("4F74F837-E225-4E69-A8DE-7E14DFBE2A2A"); // 39
            RockMigrationHelper.DeleteDefinedValue("50C9FD2E-7E06-42F3-88C1-A518FDE9EA65"); // TE
            RockMigrationHelper.DeleteDefinedValue("51AE8B9E-3F67-4338-9A4C-DB0C51EAC611"); // UR
            RockMigrationHelper.DeleteDefinedValue("53AE90CE-0B37-46D1-8054-D8D02B856A9A"); // KK
            RockMigrationHelper.DeleteDefinedValue("53D57ADD-4621-4FFB-9364-07451C098805"); // 35
            RockMigrationHelper.DeleteDefinedValue("577E24E4-5AEA-4D28-BAA1-AD61AB0FBB1D"); // FO
            RockMigrationHelper.DeleteDefinedValue("589D5506-E1F4-46BE-90FD-A8E3236333DD"); // KU
            RockMigrationHelper.DeleteDefinedValue("5D7E8B14-0B8D-4D40-B28E-C5C78C54A89C"); // KO
            RockMigrationHelper.DeleteDefinedValue("5EF44AF5-A871-4DF3-8E13-E09C75881695"); // IU
            RockMigrationHelper.DeleteDefinedValue("6053B961-F60A-43D2-B844-1D41AD6879E0"); // YO
            RockMigrationHelper.DeleteDefinedValue("6483C43A-1F9D-44BA-949E-F879AF5ECDD8"); // TG
            RockMigrationHelper.DeleteDefinedValue("648438E3-28ED-40FF-BC8B-9F9D6A9FA605"); // SM
            RockMigrationHelper.DeleteDefinedValue("65891DF4-B906-4A7E-B525-6918177C1435"); // 26
            RockMigrationHelper.DeleteDefinedValue("65AC66F2-D107-4B4E-90A8-9FC9EB35C0C5"); // AM
            RockMigrationHelper.DeleteDefinedValue("67A93816-558A-47B0-A38D-C55B68D150D6"); // 25
            RockMigrationHelper.DeleteDefinedValue("6939963A-5D3E-4BFE-A4AF-15FDBD67DDAD"); // BR
            RockMigrationHelper.DeleteDefinedValue("7188B855-108A-4534-9362-55BDFA727726"); // 06
            RockMigrationHelper.DeleteDefinedValue("719389E1-81B2-4F9D-9F5E-BCD8EA9C6032"); // 36
            RockMigrationHelper.DeleteDefinedValue("71E88E06-DA3E-43C8-9C15-A8B280806ECC"); // CH
            RockMigrationHelper.DeleteDefinedValue("72DC2FEE-4C08-4B41-81E3-B20305F4C83F"); // DA
            RockMigrationHelper.DeleteDefinedValue("75648A5A-4A61-4301-84D4-DB6F2C65AEC6"); // NE
            RockMigrationHelper.DeleteDefinedValue("75F39AE8-175E-4CAB-9C2C-1D8166320454"); // 21
            RockMigrationHelper.DeleteDefinedValue("7833FE2C-E341-464C-B4B7-306AEA5B8188"); // DZ
            RockMigrationHelper.DeleteDefinedValue("7C36972B-5E4A-4298-AC58-88BF4F907849"); // SK
            RockMigrationHelper.DeleteDefinedValue("7E502E41-1AD5-4103-85C9-23CA51C98A72"); // UK
            RockMigrationHelper.DeleteDefinedValue("8051C88B-1001-4629-9EFC-575A3700C55D"); // TT
            RockMigrationHelper.DeleteDefinedValue("8062320D-1850-4716-A7A8-B7A398E8A581"); // ML
            RockMigrationHelper.DeleteDefinedValue("83FAB84D-41B6-4D31-90F5-5616E1F7B383"); // EU
            RockMigrationHelper.DeleteDefinedValue("86110F6E-C26D-45E2-A050-9DEDA49A8E6D"); // BA
            RockMigrationHelper.DeleteDefinedValue("8741A9ED-5FAE-44C5-86BE-76E79EA75894"); // 17
            RockMigrationHelper.DeleteDefinedValue("8776443F-1A7E-415F-AD4A-0376F3DF80FB"); // BE
            RockMigrationHelper.DeleteDefinedValue("87D7C91B-C6A2-4B1D-9E14-779360084903"); // OR
            RockMigrationHelper.DeleteDefinedValue("8CCB980C-5715-44C3-890E-3F083308D656"); // AB
            RockMigrationHelper.DeleteDefinedValue("8E16D2A7-42A8-4A5B-80B9-D2012BEE0DEF"); // TO
            RockMigrationHelper.DeleteDefinedValue("8F0B86CA-F728-4549-BE6E-625FF862EEF8"); // TN
            RockMigrationHelper.DeleteDefinedValue("92207540-E849-4191-AA5E-AC27A7262E61"); // 31
            RockMigrationHelper.DeleteDefinedValue("924DF344-BFAF-4992-A562-00C45055C004"); // KN
            RockMigrationHelper.DeleteDefinedValue("92507925-786A-4287-90C8-87E54959897C"); // HE
            RockMigrationHelper.DeleteDefinedValue("9421681B-7AF1-44FF-8762-9C7511E3C7E5"); // 37
            RockMigrationHelper.DeleteDefinedValue("94FA82B2-E4B7-4C36-B5BC-057BAB6CA6A3"); // JA
            RockMigrationHelper.DeleteDefinedValue("969F3EC7-DA54-4356-BEB8-5FF14D2A6B3B"); // 41
            RockMigrationHelper.DeleteDefinedValue("9790A85B-97AA-4ECC-95B3-D68B68A24BD3"); // FY
            RockMigrationHelper.DeleteDefinedValue("97FA92B0-2776-4359-8ABA-7ED333FC11C0"); // SD
            RockMigrationHelper.DeleteDefinedValue("9B1F310C-500F-4115-9029-BDB3D5988447"); // BS
            RockMigrationHelper.DeleteDefinedValue("9BF8E446-BC83-4852-A1B3-B0D725C9E576"); // GA
            RockMigrationHelper.DeleteDefinedValue("9D53E8F0-94BD-4A93-AC37-EEE5322C8AD6"); // LN
            RockMigrationHelper.DeleteDefinedValue("9D5BFC80-52BF-48AA-9A63-4C413397D4C8"); // AA
            RockMigrationHelper.DeleteDefinedValue("9E602793-EFAC-4DD5-8EC9-768359EE7221"); // 19
            RockMigrationHelper.DeleteDefinedValue("9ED23458-4EDA-4E05-8A92-26AC66F6CE34"); // 03
            RockMigrationHelper.DeleteDefinedValue("A09FA93F-184D-4D22-BBA8-0E6AA3AA41F2"); // UZ
            RockMigrationHelper.DeleteDefinedValue("A0E4BA8C-6CF6-495A-A236-71475A95A615"); // MS
            RockMigrationHelper.DeleteDefinedValue("A276605A-48B0-448C-8E76-55B9F2B46C25"); // LV
            RockMigrationHelper.DeleteDefinedValue("A3CB0CD8-0F1E-45F9-8EBA-7FB4C8C48B94"); // DE
            RockMigrationHelper.DeleteDefinedValue("AC5837A5-03FD-4C8C-A637-8B2509BD331F"); // TH
            RockMigrationHelper.DeleteDefinedValue("ACCF2394-BBB1-421F-A842-507D38D92AF3"); // QU
            RockMigrationHelper.DeleteDefinedValue("ACE0232D-859C-4E80-8128-C13E76419BE6"); // TL
            RockMigrationHelper.DeleteDefinedValue("AF1C2693-88B0-4ED6-98D3-CF06589A763B"); // RN
            RockMigrationHelper.DeleteDefinedValue("B02CEE37-F730-4589-A5A9-7A2A540099D7"); // KY
            RockMigrationHelper.DeleteDefinedValue("B691864B-3C68-4AE3-B124-11DDC5AFA31C"); // 32
            RockMigrationHelper.DeleteDefinedValue("BB11E172-4745-40CF-8911-4A74743CAD7D"); // 14
            RockMigrationHelper.DeleteDefinedValue("BD0AF588-E101-4BDD-9124-6BE5FA8BAE0A"); // IT
            RockMigrationHelper.DeleteDefinedValue("C00C2157-F7EE-47D3-A041-65D86B3A3A8E"); // SU
            RockMigrationHelper.DeleteDefinedValue("C199DF19-EC3E-4796-AF3A-4B23ED14ADEF"); // MN
            RockMigrationHelper.DeleteDefinedValue("C29BF918-60E7-47DA-BC65-22EED9111756"); // EN
            RockMigrationHelper.DeleteDefinedValue("C2DEEF60-0ED7-4300-BABC-F1C2B4E1B922"); // 24
            RockMigrationHelper.DeleteDefinedValue("C3824926-71CE-4E35-A6F2-153E31642BA0"); // 01
            RockMigrationHelper.DeleteDefinedValue("C3AF5037-3D3A-4B3F-B349-7A9762CA5E76"); // PA
            RockMigrationHelper.DeleteDefinedValue("C4261BCB-7052-41ED-BC82-1FAFBFA9CA18"); // PS
            RockMigrationHelper.DeleteDefinedValue("C451543B-10E8-4409-9A5A-CD6733DD440E"); // 28
            RockMigrationHelper.DeleteDefinedValue("C474DF36-8D78-4CA8-9B49-DE57C0FCE6FC"); // HY
            RockMigrationHelper.DeleteDefinedValue("C5221E9E-D4D0-4EB9-9533-A11976C6EE80"); // 30
            RockMigrationHelper.DeleteDefinedValue("C5375739-75A0-420E-B00D-1F0ACD98ED9A"); // TW
            RockMigrationHelper.DeleteDefinedValue("C5F073C8-C207-4E2D-9B8F-48D7164B6AD7"); // SS
            RockMigrationHelper.DeleteDefinedValue("C67FEA7E-F707-485D-BEE6-84F8269A0F86"); // NL
            RockMigrationHelper.DeleteDefinedValue("C8BF156A-83FD-49D2-BAD2-AF08602E5D7D"); // KL
            RockMigrationHelper.DeleteDefinedValue("C8C4BE22-045C-42DE-BE87-1D43436D97EC"); // JV
            RockMigrationHelper.DeleteDefinedValue("C91B339C-A4F2-4BBF-A059-D621EDAB01D3"); // TK
            RockMigrationHelper.DeleteDefinedValue("C99B03E4-E2F5-43A1-9ADE-EB9C04FEE179"); // ES
            RockMigrationHelper.DeleteDefinedValue("C9AC98A4-227F-476E-ABEF-91020FCF2CD3"); // HA
            RockMigrationHelper.DeleteDefinedValue("CA560F66-E0B8-4F2E-8E78-379E6F57CBF6"); // KS
            RockMigrationHelper.DeleteDefinedValue("CB0B36AC-41D4-42B7-B89B-DC678FA5FB2A"); // CA
            RockMigrationHelper.DeleteDefinedValue("CC942441-C26B-479F-9404-972DE979B286"); // NO
            RockMigrationHelper.DeleteDefinedValue("CCFC71EC-CE3D-4CF3-B48D-100BD1E53E9A"); // GN
            RockMigrationHelper.DeleteDefinedValue("CED914AF-3053-4238-8F0F-E07DEFCC6FFE"); // BI
            RockMigrationHelper.DeleteDefinedValue("CEED7BBB-F60E-40A6-A55B-04FF958ADB34"); // 33
            RockMigrationHelper.DeleteDefinedValue("CF6BE70D-7C16-4844-B696-66EC718EB8A3"); // 04
            RockMigrationHelper.DeleteDefinedValue("D24930D0-5F96-4D3C-A8B7-9F1F0E908452"); // LO
            RockMigrationHelper.DeleteDefinedValue("D63EB497-88EB-4E5B-9042-680598751FBF"); // TI
            RockMigrationHelper.DeleteDefinedValue("D67AAFA0-2896-40DB-9427-658081E397EA"); // 23
            RockMigrationHelper.DeleteDefinedValue("D73B0B67-EAF6-472A-AD1E-6FEA37158507"); // SV
            RockMigrationHelper.DeleteDefinedValue("D752564A-CB64-45F3-9D61-9263605FC83E"); // BH
            RockMigrationHelper.DeleteDefinedValue("D7BD711E-C584-485B-97E2-A5BA5E48A46F"); // 34
            RockMigrationHelper.DeleteDefinedValue("D812BCCE-4DCB-4468-A649-3E37439A84B2"); // ST
            RockMigrationHelper.DeleteDefinedValue("DB07F76B-F1E8-478F-B072-2865BF8B4B78"); // AF
            RockMigrationHelper.DeleteDefinedValue("DC0E88F7-F3C0-4CCD-8B19-E1E61048A577"); // ID
            RockMigrationHelper.DeleteDefinedValue("DC4CEF63-9655-44DC-B540-A9AEEBF98557"); // SQ
            RockMigrationHelper.DeleteDefinedValue("DC8C4C96-0371-47A4-85DF-69DDC56ADDCE"); // OM
            RockMigrationHelper.DeleteDefinedValue("DFF2764A-B7E9-4246-B338-75C31A61093D"); // 12
            RockMigrationHelper.DeleteDefinedValue("E2607A3A-4713-4CFC-A8CA-34F8358FE27E"); // FA
            RockMigrationHelper.DeleteDefinedValue("E5A8F237-157A-45BE-8855-D0337AEDB45D"); // NV
            RockMigrationHelper.DeleteDefinedValue("E6610690-6D2D-4C32-9F9C-4AA8E7253E51"); // KA
            RockMigrationHelper.DeleteDefinedValue("EC434C1C-F710-4D2F-A457-9FC28719D30E"); // OC
            RockMigrationHelper.DeleteDefinedValue("EC5D07A1-DE10-45B7-B5AD-C7C10ABD9CBE"); // HU
            RockMigrationHelper.DeleteDefinedValue("ED12D4EA-B6DE-4679-A560-7C35157F1F87"); // FR
            RockMigrationHelper.DeleteDefinedValue("ED9F3EBA-EF1F-4572-A2A4-2A29B3E4E39A"); // 38
            RockMigrationHelper.DeleteDefinedValue("EFD25F51-3A14-41D2-9D15-59C4CAB7AA1E"); // AS
            RockMigrationHelper.DeleteDefinedValue("F2EC4566-1DD3-4AE1-98F2-007658046398"); // ZU
            RockMigrationHelper.DeleteDefinedValue("F311272C-3121-4231-9C47-9069E3BC98DA"); // 40
            RockMigrationHelper.DeleteDefinedValue("F3BAC0D4-048B-453E-887E-AB21B24BC8B9"); // GL
            RockMigrationHelper.DeleteDefinedValue("F542A191-591C-43E5-B933-6973F258605A"); // SN
            RockMigrationHelper.DeleteDefinedValue("F58C518B-5CD4-4CF6-BE10-766EE2E81B0E"); // PL
            RockMigrationHelper.DeleteDefinedValue("F5A90D5B-4892-41F2-B38C-1E42BF69B8E0"); // MR
            RockMigrationHelper.DeleteDefinedValue("F6183B32-ACCD-4A5B-8C33-673FDDCBEE6E"); // MK
            RockMigrationHelper.DeleteDefinedValue("F7B1D486-5025-426C-AF8A-64E48380C11B"); // 16
            RockMigrationHelper.DeleteDefinedValue("F80DC909-5DCF-4912-9ABC-2506EBA9D7A0"); // XH
            RockMigrationHelper.DeleteDefinedValue("F8A398E8-CC06-4A39-B44B-694E3380930C"); // VI
            RockMigrationHelper.DeleteDefinedValue("F8CE49D1-0E14-4455-AF82-D3A8BD8CA863"); // LT
            RockMigrationHelper.DeleteDefinedValue("F93E99BA-3C8E-4587-B91A-76EC8ED39351"); // MO
            RockMigrationHelper.DeleteDefinedValue("F96882D2-FEF3-443C-A263-E2000B802980"); // GU
            RockMigrationHelper.DeleteDefinedValue("FA540E15-3A8A-4E0C-90F8-059CD8A888A4"); // RM
            RockMigrationHelper.DeleteDefinedValue("FA954B09-DDEE-45FE-ACE3-33DAFA553606"); // IS
            RockMigrationHelper.DeleteDefinedValue("FB3A952A-41E9-46FA-9947-4330473D922D"); // HI
            RockMigrationHelper.DeleteDefinedValue("FC75C466-510F-4F9B-A249-37379B1E9A24"); // TR
            RockMigrationHelper.DeleteDefinedValue("FEA1E42D-61A0-42C1-9C48-5ADFB50D65B5"); // EL


            RockMigrationHelper.DeleteDefinedType(org.abwe.CommonRefData.SystemGuid.DefinedType.LANGUAGES);
        }
    }
}
