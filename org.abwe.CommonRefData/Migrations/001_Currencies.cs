using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rock.Plugin;

namespace org.abwe.CommonRefData.Migrations
{
    [MigrationNumber(1,"1.6.0")]
    class Currencies : Migration
    {
        public override void Up()
        {
            System.Diagnostics.Debug.WriteLine("Executing Currencies Up Migration");
            RockMigrationHelper.AddDefinedType("Financial", "Currency", "World Currencies", org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES);

            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AED", "UAE dirham", "5EF1B8FE-D456-4520-855E-6880C3F0A7CB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AFA", "Afghanistan Afghani", "EFB68B4B-59E2-4F06-8651-E3D321A1121B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ALL", "Albanian Lek", "65BDD09E-2A23-47B6-BC37-DDDF476FC50B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AMD", "Armenian dram", "B315DE18-9C1A-4D9A-BCDD-9296FF0A62E3", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ANG", "Netherlands Antillian guilder", "92F91F24-9EB9-4EC5-AC56-2487F46C6EF5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AOA", "Angolan Kwanzaa reajustado", "A0C99DD1-3E3D-4620-915A-7E646E0DEFBC", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ARS", "Argentine peso", "334A6E14-A468-429B-8D96-A23D090617EB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AUD", "Australian dollar", "0B5B7FE2-D82F-499B-99DD-7408CE17E651", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AWG", "Aruban guilder", "F4145442-FDE6-4BFF-9048-0A2F421AFA46", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "AZN", "Azerbaijanian new manat", "03E9A2BF-5B06-4702-9D55-6DDFAEA49E06", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BBD", "Barbados dollar", "639B07C3-10CF-4043-A1C4-20D04BACE559", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BDT", "Bangladeshi taka", "D72F2B71-B6AD-4BA1-A942-A51C6A32816E", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BGN", "Bulgarian lev", "DF4832AE-1C95-42E7-9A8C-7DA8748AF93B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BHD", "Bahraini dinar", "0808B158-9CD5-4E0B-B327-AD9025B52CA2", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BIF", "Burundi franc", "B45B4528-3E93-4551-A535-1B4A742023BF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BMD", "Bermudian dollar", "1D302117-E078-431F-8A05-F3C35A85CE5B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BND", "Brunei dollar", "81ACD462-0B36-46EC-80B8-D982390F1432", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BOB", "Bolivian boliviano", "C5F96B3E-F9EC-4F4C-850B-3A5DEDA95E43", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BRL", "Brazilian real", "BBC37BFC-2757-4239-96ED-F98D18C8520B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BSD", "Bahamian dollar", "925ED81C-7E5B-44A1-917E-3E67B24209A7", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BTN", "Bhutan ngultrum", "771DD02C-50BC-47A2-8CC7-596677CB3563", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BWP", "Botswana pula", "17A2DB81-C35C-45C3-B0B8-7B634908122D", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BYN", "Belarusian ruble", "761B00AE-EC94-4333-BB6D-85B5104938AF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "BZD", "Belize dollar", "E2E2479A-6057-4A50-94A4-ABB2B4D0B1DE", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CAD", "Canadian dollar", "4FBA5986-4DAE-4CD1-87AD-CB51F4C85E8C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CDF", "Congolese franc", "8520D3E3-ED3D-4C9B-A287-C58A4F31F669", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CHF", "Swiss franc", "5EAC672A-A469-40FD-A672-173940A6B3AA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CLP", "Chilean peso", "4AD998EA-5685-4165-AFC0-11CC0881F963", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CNY", "Chinese yuan renminbi", "9DAC369E-95B2-4B8D-90C2-451AF7EFB7B8", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "COP", "Colombian peso", "578E15C3-06BE-43F2-A705-83528EE23D14", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CRC", "Costa Rican colon", "FF13C9E1-251B-400F-B6F6-5C1EB60BA6C2", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CUP", "Cuban peso", "C4354713-6FCE-4B65-8D05-0A1A43644679", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CVE", "Cape Verde escudo", "93AD927E-920E-4CC2-96E3-696661897C5C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "CZK", "Czech koruna", "C0FA337B-80D2-4AAC-A8B8-17A1F8D913BB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "DJF", "Djibouti franc", "04BBCFF9-C1A6-42FD-8B62-591B9E2E31D6", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "DKK", "Danish krone", "88290A8F-581A-4122-A06E-4F779238CED0", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "DOP", "Dominican peso", "AB108687-161B-4E7C-89F7-CCE1DFAE628C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "DZD", "Algerian dinar", "1342C133-3B7A-43FC-8447-0CF2F97545CB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "EEK", "Estonian kroon", "C844E9CD-9F59-46AE-9C00-39EAAD2F2255", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "EGP", "Egyptian pound", "FE68FEAA-1658-4870-AC38-6D4184CB6BFF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ERN", "Eritrean nakfa", "E452E709-3B67-4FBE-A682-E24D03908374", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ETB", "Ethiopian birr", "50628EB1-A47F-43DC-B7F1-43DFAA028D14", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "EUR", "EU euro", "A85DF076-D0C4-492F-8871-E9D8C8B3C82F", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "FJD", "Fiji dollar", "BCBE4140-0E40-49CE-B442-E8EC564165F8", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "FKP", "Falkland Islands pound", "735A7052-A797-499A-8355-031C9E33CDA8", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GBP", "British pound", "B4915279-C41B-497C-B886-E8AFF9A20CB7", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GEL", "Georgian lari", "4B0A453D-EF7C-4229-B654-6BFFC8FE39A8", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GHS", "Ghanaian new cedi", "23D7707E-DD28-4FD8-9A61-80F85588BC94", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GIP", "Gibraltar pound", "372576E9-5BEB-4F34-95A0-DDFF4E66C056", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GMD", "Gambian dalasi", "FA57FDBF-6443-45E1-B1F8-63A94CD658DF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GNF", "Guinean franc", "790372BE-BED8-4737-B450-5C129AE5DF93", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GTQ", "Guatemalan quetzal", "10742713-5326-4719-B110-CA8B4F8571D8", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "GYD", "Guyana dollar", "DA8BAD87-E3E5-468D-91E9-46C6347333B3", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "HKD", "Hong Kong SAR dollar", "2FA4B07F-FF75-4BE0-9BEF-1FE3CEBF73FE", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "HNL", "Honduran lempira", "93231D4E-D0C2-4606-82CB-B82BD8C92841", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "HRK", "Croatian kuna", "99E9964A-0A65-4ADB-A24D-7DC1590A4254", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "HTG", "Haitian gourde", "954E9252-197A-449B-AC80-259C590CDDB0", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "HUF", "Hungarian forint", "31E8DDDD-FE35-46D1-87F7-C5BC8918D6DB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "IDR", "Indonesian rupiah", "6F66D505-0165-4254-A53D-EDFEA120F937", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ILS", "Israeli new shekel", "0F27B375-922D-4F24-BB89-1B38C816C978", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "INR", "Indian rupee", "3FCBA892-E211-4BE9-8BAC-E94E3D82790C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "IQD", "Iraqi dinar", "D78117D3-59F2-4F7B-9632-0A9F1402453D", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "IRR", "Iranian rial", "2408AD3A-C09B-4D98-A58F-747FF62AB005", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ISK", "Icelandic krona", "0A6DB989-EE3B-4E69-85DF-26DE25B2040F", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "JMD", "Jamaican dollar", "4A15240C-EC67-4E40-AD15-28C9F19FCA17", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "JOD", "Jordanian dinar", "E504AB51-0012-4D89-86FA-AC62CAA186EA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "JPY", "Japanese yen", "39DFAFCA-1D53-47EF-8B30-755AD7CD28B9", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KES", "Kenyan shilling", "954B9AAB-AA11-4B13-B999-52D3AF18829F", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KGS", "Kyrgyz som", "012CAFD1-34DD-411C-802C-455034EDB8BF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KHR", "Cambodian riel", "56DBDA0E-2BCB-4440-8C27-E87A195C6CC5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KMF", "Comoros franc", "1AC57E1E-353D-46BA-BF59-969BC77E054B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KPW", "North Korean won", "A9C518E3-3C3E-47E6-AA07-E9F5233157B5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KRW", "South Korean won", "9B2C374F-F381-4277-88D2-ED47569E115A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KWD", "Kuwaiti dinar", "6C544AA3-B98E-43BD-8CE3-DDF807A1B8AA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KYD", "Cayman Islands dollar", "E986831E-215F-4084-9D3A-8A3F9C17293C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "KZT", "Kazakh tenge", "61DA2DC0-6AAB-4195-A8F2-97393086CA4E", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LAK", "Lao kip", "10A985CB-75DF-4BC4-B4D0-48D7448F671F", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LBP", "Lebanese pound", "1EC6EB1E-87B0-4C3D-B125-AC0C0611F0EB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LKR", "Sri Lanka rupee", "38179832-A29A-4958-ACA3-4BE1B8D2B3CA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LRD", "Liberian dollar", "2F46D022-0434-4A84-90CA-4AF594C9E3FA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LSL", "Lesotho loti", "7AD28AB2-1CA4-4941-BCE9-1BADF4CFE323", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LTL", "Lithuanian litas", "F79F649A-3A60-4289-8452-37C3E06ECD7A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LVL", "Latvian lats", "AD2DC8D2-D01F-459A-96BD-93CE386CB79A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "LYD", "Libyan dinar", "15F0E004-F38B-4BF7-97AD-C642C5B3923A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MAD", "Moroccan dirham", "58B698B6-FFF6-4902-9927-3CFF54BF9146", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MDL", "Moldovan leu", "D4D41921-A000-436A-A364-C34A11779A9A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MGA", "Malagasy ariary", "137E0AFE-FDDD-4556-A3F1-9779EBA89F29", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MKD", "Macedonian denar", "C663D295-76B1-4B95-B701-233AA48A0C52", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MMK", "Myanmar kyat", "0511EC42-28FA-4640-A7A9-DDA502F119BA", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MNT", "Mongolian tugrik", "77B25C24-FD28-4933-86B1-E54DA874DBC9", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MOP", "Macao SAR pataca", "46AAC335-8F96-4C54-8E3C-9C478F33DFFE", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MRO", "Mauritanian ouguiya", "85409593-0CB8-489C-B462-B738367E96B4", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MUR", "Mauritius rupee", "793299D3-4ED9-412C-A402-3B3CA53A2A62", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MVR", "Maldivian rufiyaa", "E604C1CF-4291-4D09-B1EB-6ECC94F1B902", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MWK", "Malawi kwacha", "72AE6223-DCAB-4718-B617-C1CBCEA89932", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MXN", "Mexican peso", "0111C11C-CC52-43A9-A93A-FD3E38CAA596", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MYR", "Malaysian ringgit", "5D516F89-32BC-486E-A517-7824DE0F2DF2", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "MZN", "Mozambique new metical", "0FF3F3B9-4A0B-4263-B20C-022B0F946674", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NAD", "Namibian dollar", "C3105682-B039-49D3-B740-C682CAEFF3D6", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NGN", "Nigerian naira", "8D00AECD-DC8A-498F-926B-F08FE8A47895", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NIO", "Nicaraguan cordoba oro", "D5F85780-4D0F-495A-A358-566B0AE5F073", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NOK", "Norwegian krone", "812F8E33-613E-459E-9B84-1C8A12AEA0A7", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NPR", "Nepalese rupee", "69E91A50-680F-45F3-94F7-F2B843B9C439", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "NZD", "New Zealand dollar", "CC218EFD-F080-4603-A655-AD0BCD8CB039", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "OMR", "Omani rial", "AFF02E99-22A8-477C-8763-58FE83474AD5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PAB", "Panamanian balboa", "038AB89F-A88B-4B16-B3FA-6D2F6533941A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PEN", "Peruvian nuevo sol", "B5195060-B51C-425F-94B5-16073553BB93", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PGK", "Papua New Guinea kina", "809586DB-D623-4410-9BCE-F585BD6EF8F4", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PHP", "Philippine peso", "2B892512-FE6A-414C-BF46-0B54C7DFF8DC", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PKR", "Pakistani rupee", "6E9D181C-42C0-4164-AACA-225C437B8625", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PLN", "Polish zloty", "09EF721D-15E5-46F4-ADDB-4CDA65BFBCC2", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "PYG", "Paraguayan guarani", "433A181C-2660-4441-9BE5-C85F7B6701EF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "QAR", "Qatari rial", "59820143-94D0-4506-9182-341E2309FF75", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "RON", "Romanian new leu", "7554DCE0-C77A-49A9-8018-C7B79B13C003", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "RSD", "Serbian dinar", "D7082B50-38BB-4CEA-A341-9F085367EF80", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "RUB", "Russian ruble", "24737209-2BE7-4221-AC0A-D47FE6951A9A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "RWF", "Rwandan franc", "9705E8BB-9CD2-49E5-9ADF-0FC8E466DDC9", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SAR", "Saudi riyal", "3EEA6E77-2F0F-4983-953B-B062B826A8E5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SBD", "Solomon Islands dollar", "B594438E-3EA2-48DB-92CF-D89F26D0DF14", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SCR", "Seychelles rupee", "89C103EE-0340-4152-B315-DD70E3950B2A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SDG", "Sudanese pound", "EDBE7031-1AB2-4AE7-80C2-025A80F91D8C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SEK", "Swedish krona", "51E781AB-CDD0-4683-891B-FFAFF720D3CE", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SGD", "Singapore dollar", "E1B4C499-E911-49E7-B435-E00CFF888627", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SHP", "Saint Helena pound", "E8C2ED07-B1F0-4739-B879-B9AA559A379F", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SLL", "Sierra Leone leone", "1EA6A551-EBB2-4A0B-BBB3-A373A4C58B9E", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SOS", "Somali shilling", "3F64190C-EA21-48F3-A63C-DBA0E296CBF0", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SRD", "Suriname dollar", "81F551AA-653D-4D49-B8B2-93E4E6D930C6", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "STD", "Sao Tome and Principe dobra", "C0EC54F5-8CC9-40FD-98A2-C6C2FDECFBBC", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SVC", "El Salvador colon", "321C36A6-67D7-4C51-BBFB-61DF7871B7E1", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SYP", "Syrian pound", "AB905EBB-4923-481E-917A-12104081292A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "SZL", "Swaziland lilangeni", "641C6A2B-E152-42B5-AE34-138F92C61E0B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "THB", "Thai baht", "6757139C-459C-47A9-8DD7-F30B1D529606", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TJS", "Tajik somoni", "9091822B-AE0D-46E3-B73F-F31C4D8A3C6B", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TMT", "Turkmen new manat", "9581DECF-AD05-4B9C-9BC4-05105F231994", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TND", "Tunisian dinar", "500271B1-C535-4BFB-8756-E526E6EF7384", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TOP", "Tongan pa'anga", "43F12848-5B35-4C60-8A10-3CC908C293D0", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TRY", "Turkish lira", "50D965D2-FE6D-4F1A-9279-F5435813CB1A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TTD", "Trinidad and Tobago dollar", "2800BFA3-05A8-4A42-A6CF-841CEDDAAF1D", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TWD", "Taiwan New dollar", "D3A7F5C1-D791-4087-98E4-0C2661A33329", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "TZS", "Tanzanian shilling", "15ABE77F-5405-4DB8-9F3B-923EB251ED05", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "UAH", "Ukrainian hryvnia", "2E40F7F7-641D-40F7-AEA5-290A1DF55E75", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "UGX", "Uganda new shilling", "2C86D8E2-5997-4273-9DC7-18E0120E246D", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "USD", "US dollar", "04A56305-56EE-4AC3-8B60-CC49758DCA95", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "UYU", "Uruguayan peso uruguayo", "DBC36A91-B5ED-4769-9233-20BDC2B68FED", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "UZS", "Uzbekistani sum", "727D8D5C-6DD1-4584-A6CA-8B9141D79AC7", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "VEF", "Venezuelan bolivar fuerte", "6DFE05F1-AB5B-4F81-B921-CB1C35BD99B5", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "VND", "Vietnamese dong", "36FFBEDA-8E82-4DA5-8EA7-AC43F2011687", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "VUV", "Vanuatu vatu", "F1287913-8E8F-46DC-91ED-B36681BFF9FD", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "WST", "Samoan tala", "AE171025-8879-4957-BCE2-0A5FFBACCFC3", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XAF", "CFA franc BEAC", "A5EA57FD-D532-4594-889B-A35EAB9E2DEF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XAG", "Silver(ounce)", "62A2038C-1A89-431B-91A0-20961B0FE618", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XAU", "Gold(ounce)", "3788A734-00FE-46C7-A787-420ACE9B868A", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XCD", "East Caribbean dollar", "D9D67151-8B64-45F4-B49F-6A015AE5639C", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XDR", "IMF special drawing right", "40EBF95A-8996-4C84-B1FD-65B103E10A30", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XFO", "Gold franc", "1DBB1044-316F-47EC-950B-EA833BDAC796", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XFU", "UIC franc", "84F34318-7890-495C-8A75-F112216269CB", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XOF", "CFA franc BCEAO", "4B72A061-881E-40A0-85CB-F723527336AF", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XPD", "Palladium(ounce)", "BBC92B87-17FC-45B0-98E2-3F33B2784ED3", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XPF", "CFP franc", "5C69E433-B840-48A9-A716-DDBA3115BA48", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "XPT", "Platinum(ounce)", "74903C7B-8289-4390-A1BE-DC28D2009FF0", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "YER", "Yemeni rial", "16FEEEA1-0A97-4859-B1EE-138917B18615", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ZAR", "South African rand", "F81F26D6-FBD4-4EBB-BA93-37B8CE6A0474", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ZMK", "Zambian kwacha", "F0D78CBB-8493-457C-B380-4EF0A0D73F7D", false);
            RockMigrationHelper.UpdateDefinedValue("7517A918-932D-440E-A1CA-E1D9A6706B26", "ZWL", "Zimbabwe dollar", "8E8B1B8F-C8B9-4EE4-B0AE-4D5EC3B7E8F9", false);
        }
        public override void Down()
        {
            
            RockMigrationHelper.DeleteDefinedValue("0111C11C-CC52-43A9-A93A-FD3E38CAA596"); // MXN
            RockMigrationHelper.DeleteDefinedValue("012CAFD1-34DD-411C-802C-455034EDB8BF"); // KGS
            RockMigrationHelper.DeleteDefinedValue("038AB89F-A88B-4B16-B3FA-6D2F6533941A"); // PAB
            RockMigrationHelper.DeleteDefinedValue("03E9A2BF-5B06-4702-9D55-6DDFAEA49E06"); // AZN
            RockMigrationHelper.DeleteDefinedValue("04A56305-56EE-4AC3-8B60-CC49758DCA95"); // USD
            RockMigrationHelper.DeleteDefinedValue("04BBCFF9-C1A6-42FD-8B62-591B9E2E31D6"); // DJF
            RockMigrationHelper.DeleteDefinedValue("0511EC42-28FA-4640-A7A9-DDA502F119BA"); // MMK
            RockMigrationHelper.DeleteDefinedValue("0808B158-9CD5-4E0B-B327-AD9025B52CA2"); // BHD
            RockMigrationHelper.DeleteDefinedValue("09EF721D-15E5-46F4-ADDB-4CDA65BFBCC2"); // PLN
            RockMigrationHelper.DeleteDefinedValue("0A6DB989-EE3B-4E69-85DF-26DE25B2040F"); // ISK
            RockMigrationHelper.DeleteDefinedValue("0B5B7FE2-D82F-499B-99DD-7408CE17E651"); // AUD
            RockMigrationHelper.DeleteDefinedValue("0F27B375-922D-4F24-BB89-1B38C816C978"); // ILS
            RockMigrationHelper.DeleteDefinedValue("0FF3F3B9-4A0B-4263-B20C-022B0F946674"); // MZN
            RockMigrationHelper.DeleteDefinedValue("10742713-5326-4719-B110-CA8B4F8571D8"); // GTQ
            RockMigrationHelper.DeleteDefinedValue("10A985CB-75DF-4BC4-B4D0-48D7448F671F"); // LAK
            RockMigrationHelper.DeleteDefinedValue("1342C133-3B7A-43FC-8447-0CF2F97545CB"); // DZD
            RockMigrationHelper.DeleteDefinedValue("137E0AFE-FDDD-4556-A3F1-9779EBA89F29"); // MGA
            RockMigrationHelper.DeleteDefinedValue("15ABE77F-5405-4DB8-9F3B-923EB251ED05"); // TZS
            RockMigrationHelper.DeleteDefinedValue("15F0E004-F38B-4BF7-97AD-C642C5B3923A"); // LYD
            RockMigrationHelper.DeleteDefinedValue("16FEEEA1-0A97-4859-B1EE-138917B18615"); // YER
            RockMigrationHelper.DeleteDefinedValue("17A2DB81-C35C-45C3-B0B8-7B634908122D"); // BWP
            RockMigrationHelper.DeleteDefinedValue("1AC57E1E-353D-46BA-BF59-969BC77E054B"); // KMF
            RockMigrationHelper.DeleteDefinedValue("1D302117-E078-431F-8A05-F3C35A85CE5B"); // BMD
            RockMigrationHelper.DeleteDefinedValue("1DBB1044-316F-47EC-950B-EA833BDAC796"); // XFO
            RockMigrationHelper.DeleteDefinedValue("1EA6A551-EBB2-4A0B-BBB3-A373A4C58B9E"); // SLL
            RockMigrationHelper.DeleteDefinedValue("1EC6EB1E-87B0-4C3D-B125-AC0C0611F0EB"); // LBP
            RockMigrationHelper.DeleteDefinedValue("23D7707E-DD28-4FD8-9A61-80F85588BC94"); // GHS
            RockMigrationHelper.DeleteDefinedValue("2408AD3A-C09B-4D98-A58F-747FF62AB005"); // IRR
            RockMigrationHelper.DeleteDefinedValue("24737209-2BE7-4221-AC0A-D47FE6951A9A"); // RUB
            RockMigrationHelper.DeleteDefinedValue("2800BFA3-05A8-4A42-A6CF-841CEDDAAF1D"); // TTD
            RockMigrationHelper.DeleteDefinedValue("2B892512-FE6A-414C-BF46-0B54C7DFF8DC"); // PHP
            RockMigrationHelper.DeleteDefinedValue("2C86D8E2-5997-4273-9DC7-18E0120E246D"); // UGX
            RockMigrationHelper.DeleteDefinedValue("2E40F7F7-641D-40F7-AEA5-290A1DF55E75"); // UAH
            RockMigrationHelper.DeleteDefinedValue("2F46D022-0434-4A84-90CA-4AF594C9E3FA"); // LRD
            RockMigrationHelper.DeleteDefinedValue("2FA4B07F-FF75-4BE0-9BEF-1FE3CEBF73FE"); // HKD
            RockMigrationHelper.DeleteDefinedValue("31E8DDDD-FE35-46D1-87F7-C5BC8918D6DB"); // HUF
            RockMigrationHelper.DeleteDefinedValue("321C36A6-67D7-4C51-BBFB-61DF7871B7E1"); // SVC
            RockMigrationHelper.DeleteDefinedValue("334A6E14-A468-429B-8D96-A23D090617EB"); // ARS
            RockMigrationHelper.DeleteDefinedValue("36FFBEDA-8E82-4DA5-8EA7-AC43F2011687"); // VND
            RockMigrationHelper.DeleteDefinedValue("372576E9-5BEB-4F34-95A0-DDFF4E66C056"); // GIP
            RockMigrationHelper.DeleteDefinedValue("3788A734-00FE-46C7-A787-420ACE9B868A"); // XAU
            RockMigrationHelper.DeleteDefinedValue("38179832-A29A-4958-ACA3-4BE1B8D2B3CA"); // LKR
            RockMigrationHelper.DeleteDefinedValue("39DFAFCA-1D53-47EF-8B30-755AD7CD28B9"); // JPY
            RockMigrationHelper.DeleteDefinedValue("3EEA6E77-2F0F-4983-953B-B062B826A8E5"); // SAR
            RockMigrationHelper.DeleteDefinedValue("3F64190C-EA21-48F3-A63C-DBA0E296CBF0"); // SOS
            RockMigrationHelper.DeleteDefinedValue("3FCBA892-E211-4BE9-8BAC-E94E3D82790C"); // INR
            RockMigrationHelper.DeleteDefinedValue("40EBF95A-8996-4C84-B1FD-65B103E10A30"); // XDR
            RockMigrationHelper.DeleteDefinedValue("433A181C-2660-4441-9BE5-C85F7B6701EF"); // PYG
            RockMigrationHelper.DeleteDefinedValue("43F12848-5B35-4C60-8A10-3CC908C293D0"); // TOP
            RockMigrationHelper.DeleteDefinedValue("46AAC335-8F96-4C54-8E3C-9C478F33DFFE"); // MOP
            RockMigrationHelper.DeleteDefinedValue("4A15240C-EC67-4E40-AD15-28C9F19FCA17"); // JMD
            RockMigrationHelper.DeleteDefinedValue("4AD998EA-5685-4165-AFC0-11CC0881F963"); // CLP
            RockMigrationHelper.DeleteDefinedValue("4B0A453D-EF7C-4229-B654-6BFFC8FE39A8"); // GEL
            RockMigrationHelper.DeleteDefinedValue("4B72A061-881E-40A0-85CB-F723527336AF"); // XOF
            RockMigrationHelper.DeleteDefinedValue("4FBA5986-4DAE-4CD1-87AD-CB51F4C85E8C"); // CAD
            RockMigrationHelper.DeleteDefinedValue("500271B1-C535-4BFB-8756-E526E6EF7384"); // TND
            RockMigrationHelper.DeleteDefinedValue("50628EB1-A47F-43DC-B7F1-43DFAA028D14"); // ETB
            RockMigrationHelper.DeleteDefinedValue("50D965D2-FE6D-4F1A-9279-F5435813CB1A"); // TRY
            RockMigrationHelper.DeleteDefinedValue("51E781AB-CDD0-4683-891B-FFAFF720D3CE"); // SEK
            RockMigrationHelper.DeleteDefinedValue("56DBDA0E-2BCB-4440-8C27-E87A195C6CC5"); // KHR
            RockMigrationHelper.DeleteDefinedValue("578E15C3-06BE-43F2-A705-83528EE23D14"); // COP
            RockMigrationHelper.DeleteDefinedValue("58B698B6-FFF6-4902-9927-3CFF54BF9146"); // MAD
            RockMigrationHelper.DeleteDefinedValue("59820143-94D0-4506-9182-341E2309FF75"); // QAR
            RockMigrationHelper.DeleteDefinedValue("5C69E433-B840-48A9-A716-DDBA3115BA48"); // XPF
            RockMigrationHelper.DeleteDefinedValue("5D516F89-32BC-486E-A517-7824DE0F2DF2"); // MYR
            RockMigrationHelper.DeleteDefinedValue("5EAC672A-A469-40FD-A672-173940A6B3AA"); // CHF
            RockMigrationHelper.DeleteDefinedValue("5EF1B8FE-D456-4520-855E-6880C3F0A7CB"); // AED
            RockMigrationHelper.DeleteDefinedValue("61DA2DC0-6AAB-4195-A8F2-97393086CA4E"); // KZT
            RockMigrationHelper.DeleteDefinedValue("62A2038C-1A89-431B-91A0-20961B0FE618"); // XAG
            RockMigrationHelper.DeleteDefinedValue("639B07C3-10CF-4043-A1C4-20D04BACE559"); // BBD
            RockMigrationHelper.DeleteDefinedValue("641C6A2B-E152-42B5-AE34-138F92C61E0B"); // SZL
            RockMigrationHelper.DeleteDefinedValue("65BDD09E-2A23-47B6-BC37-DDDF476FC50B"); // ALL
            RockMigrationHelper.DeleteDefinedValue("6757139C-459C-47A9-8DD7-F30B1D529606"); // THB
            RockMigrationHelper.DeleteDefinedValue("69E91A50-680F-45F3-94F7-F2B843B9C439"); // NPR
            RockMigrationHelper.DeleteDefinedValue("6C544AA3-B98E-43BD-8CE3-DDF807A1B8AA"); // KWD
            RockMigrationHelper.DeleteDefinedValue("6DFE05F1-AB5B-4F81-B921-CB1C35BD99B5"); // VEF
            RockMigrationHelper.DeleteDefinedValue("6E9D181C-42C0-4164-AACA-225C437B8625"); // PKR
            RockMigrationHelper.DeleteDefinedValue("6F66D505-0165-4254-A53D-EDFEA120F937"); // IDR
            RockMigrationHelper.DeleteDefinedValue("727D8D5C-6DD1-4584-A6CA-8B9141D79AC7"); // UZS
            RockMigrationHelper.DeleteDefinedValue("72AE6223-DCAB-4718-B617-C1CBCEA89932"); // MWK
            RockMigrationHelper.DeleteDefinedValue("735A7052-A797-499A-8355-031C9E33CDA8"); // FKP
            RockMigrationHelper.DeleteDefinedValue("74903C7B-8289-4390-A1BE-DC28D2009FF0"); // XPT
            RockMigrationHelper.DeleteDefinedValue("7554DCE0-C77A-49A9-8018-C7B79B13C003"); // RON
            RockMigrationHelper.DeleteDefinedValue("761B00AE-EC94-4333-BB6D-85B5104938AF"); // BYN
            RockMigrationHelper.DeleteDefinedValue("771DD02C-50BC-47A2-8CC7-596677CB3563"); // BTN
            RockMigrationHelper.DeleteDefinedValue("77B25C24-FD28-4933-86B1-E54DA874DBC9"); // MNT
            RockMigrationHelper.DeleteDefinedValue("790372BE-BED8-4737-B450-5C129AE5DF93"); // GNF
            RockMigrationHelper.DeleteDefinedValue("793299D3-4ED9-412C-A402-3B3CA53A2A62"); // MUR
            RockMigrationHelper.DeleteDefinedValue("7AD28AB2-1CA4-4941-BCE9-1BADF4CFE323"); // LSL
            RockMigrationHelper.DeleteDefinedValue("809586DB-D623-4410-9BCE-F585BD6EF8F4"); // PGK
            RockMigrationHelper.DeleteDefinedValue("812F8E33-613E-459E-9B84-1C8A12AEA0A7"); // NOK
            RockMigrationHelper.DeleteDefinedValue("81ACD462-0B36-46EC-80B8-D982390F1432"); // BND
            RockMigrationHelper.DeleteDefinedValue("81F551AA-653D-4D49-B8B2-93E4E6D930C6"); // SRD
            RockMigrationHelper.DeleteDefinedValue("84F34318-7890-495C-8A75-F112216269CB"); // XFU
            RockMigrationHelper.DeleteDefinedValue("8520D3E3-ED3D-4C9B-A287-C58A4F31F669"); // CDF
            RockMigrationHelper.DeleteDefinedValue("85409593-0CB8-489C-B462-B738367E96B4"); // MRO
            RockMigrationHelper.DeleteDefinedValue("88290A8F-581A-4122-A06E-4F779238CED0"); // DKK
            RockMigrationHelper.DeleteDefinedValue("89C103EE-0340-4152-B315-DD70E3950B2A"); // SCR
            RockMigrationHelper.DeleteDefinedValue("8D00AECD-DC8A-498F-926B-F08FE8A47895"); // NGN
            RockMigrationHelper.DeleteDefinedValue("8E8B1B8F-C8B9-4EE4-B0AE-4D5EC3B7E8F9"); // ZWL
            RockMigrationHelper.DeleteDefinedValue("9091822B-AE0D-46E3-B73F-F31C4D8A3C6B"); // TJS
            RockMigrationHelper.DeleteDefinedValue("925ED81C-7E5B-44A1-917E-3E67B24209A7"); // BSD
            RockMigrationHelper.DeleteDefinedValue("92F91F24-9EB9-4EC5-AC56-2487F46C6EF5"); // ANG
            RockMigrationHelper.DeleteDefinedValue("93231D4E-D0C2-4606-82CB-B82BD8C92841"); // HNL
            RockMigrationHelper.DeleteDefinedValue("93AD927E-920E-4CC2-96E3-696661897C5C"); // CVE
            RockMigrationHelper.DeleteDefinedValue("954B9AAB-AA11-4B13-B999-52D3AF18829F"); // KES
            RockMigrationHelper.DeleteDefinedValue("954E9252-197A-449B-AC80-259C590CDDB0"); // HTG
            RockMigrationHelper.DeleteDefinedValue("9581DECF-AD05-4B9C-9BC4-05105F231994"); // TMT
            RockMigrationHelper.DeleteDefinedValue("9705E8BB-9CD2-49E5-9ADF-0FC8E466DDC9"); // RWF
            RockMigrationHelper.DeleteDefinedValue("99E9964A-0A65-4ADB-A24D-7DC1590A4254"); // HRK
            RockMigrationHelper.DeleteDefinedValue("9B2C374F-F381-4277-88D2-ED47569E115A"); // KRW
            RockMigrationHelper.DeleteDefinedValue("9DAC369E-95B2-4B8D-90C2-451AF7EFB7B8"); // CNY
            RockMigrationHelper.DeleteDefinedValue("A0C99DD1-3E3D-4620-915A-7E646E0DEFBC"); // AOA
            RockMigrationHelper.DeleteDefinedValue("A5EA57FD-D532-4594-889B-A35EAB9E2DEF"); // XAF
            RockMigrationHelper.DeleteDefinedValue("A85DF076-D0C4-492F-8871-E9D8C8B3C82F"); // EUR
            RockMigrationHelper.DeleteDefinedValue("A9C518E3-3C3E-47E6-AA07-E9F5233157B5"); // KPW
            RockMigrationHelper.DeleteDefinedValue("AB108687-161B-4E7C-89F7-CCE1DFAE628C"); // DOP
            RockMigrationHelper.DeleteDefinedValue("AB905EBB-4923-481E-917A-12104081292A"); // SYP
            RockMigrationHelper.DeleteDefinedValue("AD2DC8D2-D01F-459A-96BD-93CE386CB79A"); // LVL
            RockMigrationHelper.DeleteDefinedValue("AE171025-8879-4957-BCE2-0A5FFBACCFC3"); // WST
            RockMigrationHelper.DeleteDefinedValue("AFF02E99-22A8-477C-8763-58FE83474AD5"); // OMR
            RockMigrationHelper.DeleteDefinedValue("B315DE18-9C1A-4D9A-BCDD-9296FF0A62E3"); // AMD
            RockMigrationHelper.DeleteDefinedValue("B45B4528-3E93-4551-A535-1B4A742023BF"); // BIF
            RockMigrationHelper.DeleteDefinedValue("B4915279-C41B-497C-B886-E8AFF9A20CB7"); // GBP
            RockMigrationHelper.DeleteDefinedValue("B5195060-B51C-425F-94B5-16073553BB93"); // PEN
            RockMigrationHelper.DeleteDefinedValue("B594438E-3EA2-48DB-92CF-D89F26D0DF14"); // SBD
            RockMigrationHelper.DeleteDefinedValue("BBC37BFC-2757-4239-96ED-F98D18C8520B"); // BRL
            RockMigrationHelper.DeleteDefinedValue("BBC92B87-17FC-45B0-98E2-3F33B2784ED3"); // XPD
            RockMigrationHelper.DeleteDefinedValue("BCBE4140-0E40-49CE-B442-E8EC564165F8"); // FJD
            RockMigrationHelper.DeleteDefinedValue("C0EC54F5-8CC9-40FD-98A2-C6C2FDECFBBC"); // STD
            RockMigrationHelper.DeleteDefinedValue("C0FA337B-80D2-4AAC-A8B8-17A1F8D913BB"); // CZK
            RockMigrationHelper.DeleteDefinedValue("C3105682-B039-49D3-B740-C682CAEFF3D6"); // NAD
            RockMigrationHelper.DeleteDefinedValue("C4354713-6FCE-4B65-8D05-0A1A43644679"); // CUP
            RockMigrationHelper.DeleteDefinedValue("C5F96B3E-F9EC-4F4C-850B-3A5DEDA95E43"); // BOB
            RockMigrationHelper.DeleteDefinedValue("C663D295-76B1-4B95-B701-233AA48A0C52"); // MKD
            RockMigrationHelper.DeleteDefinedValue("C844E9CD-9F59-46AE-9C00-39EAAD2F2255"); // EEK
            RockMigrationHelper.DeleteDefinedValue("CC218EFD-F080-4603-A655-AD0BCD8CB039"); // NZD
            RockMigrationHelper.DeleteDefinedValue("D3A7F5C1-D791-4087-98E4-0C2661A33329"); // TWD
            RockMigrationHelper.DeleteDefinedValue("D4D41921-A000-436A-A364-C34A11779A9A"); // MDL
            RockMigrationHelper.DeleteDefinedValue("D5F85780-4D0F-495A-A358-566B0AE5F073"); // NIO
            RockMigrationHelper.DeleteDefinedValue("D7082B50-38BB-4CEA-A341-9F085367EF80"); // RSD
            RockMigrationHelper.DeleteDefinedValue("D72F2B71-B6AD-4BA1-A942-A51C6A32816E"); // BDT
            RockMigrationHelper.DeleteDefinedValue("D78117D3-59F2-4F7B-9632-0A9F1402453D"); // IQD
            RockMigrationHelper.DeleteDefinedValue("D9D67151-8B64-45F4-B49F-6A015AE5639C"); // XCD
            RockMigrationHelper.DeleteDefinedValue("DA8BAD87-E3E5-468D-91E9-46C6347333B3"); // GYD
            RockMigrationHelper.DeleteDefinedValue("DBC36A91-B5ED-4769-9233-20BDC2B68FED"); // UYU
            RockMigrationHelper.DeleteDefinedValue("DF4832AE-1C95-42E7-9A8C-7DA8748AF93B"); // BGN
            RockMigrationHelper.DeleteDefinedValue("E1B4C499-E911-49E7-B435-E00CFF888627"); // SGD
            RockMigrationHelper.DeleteDefinedValue("E2E2479A-6057-4A50-94A4-ABB2B4D0B1DE"); // BZD
            RockMigrationHelper.DeleteDefinedValue("E452E709-3B67-4FBE-A682-E24D03908374"); // ERN
            RockMigrationHelper.DeleteDefinedValue("E504AB51-0012-4D89-86FA-AC62CAA186EA"); // JOD
            RockMigrationHelper.DeleteDefinedValue("E604C1CF-4291-4D09-B1EB-6ECC94F1B902"); // MVR
            RockMigrationHelper.DeleteDefinedValue("E8C2ED07-B1F0-4739-B879-B9AA559A379F"); // SHP
            RockMigrationHelper.DeleteDefinedValue("E986831E-215F-4084-9D3A-8A3F9C17293C"); // KYD
            RockMigrationHelper.DeleteDefinedValue("EDBE7031-1AB2-4AE7-80C2-025A80F91D8C"); // SDG
            RockMigrationHelper.DeleteDefinedValue("EFB68B4B-59E2-4F06-8651-E3D321A1121B"); // AFA
            RockMigrationHelper.DeleteDefinedValue("F0D78CBB-8493-457C-B380-4EF0A0D73F7D"); // ZMK
            RockMigrationHelper.DeleteDefinedValue("F1287913-8E8F-46DC-91ED-B36681BFF9FD"); // VUV
            RockMigrationHelper.DeleteDefinedValue("F4145442-FDE6-4BFF-9048-0A2F421AFA46"); // AWG
            RockMigrationHelper.DeleteDefinedValue("F79F649A-3A60-4289-8452-37C3E06ECD7A"); // LTL
            RockMigrationHelper.DeleteDefinedValue("F81F26D6-FBD4-4EBB-BA93-37B8CE6A0474"); // ZAR
            RockMigrationHelper.DeleteDefinedValue("FA57FDBF-6443-45E1-B1F8-63A94CD658DF"); // GMD
            RockMigrationHelper.DeleteDefinedValue("FE68FEAA-1658-4870-AC38-6D4184CB6BFF"); // EGP
            RockMigrationHelper.DeleteDefinedValue("FF13C9E1-251B-400F-B6F6-5C1EB60BA6C2"); // CRC

            RockMigrationHelper.DeleteDefinedType(org.abwe.CommonRefData.SystemGuid.DefinedType.CURRENCIES);

        }
    }
}
