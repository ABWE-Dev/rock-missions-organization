using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock;
using Rock.Model;
using Rock.Plugin;
using Rock.Security;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(15, "1.12.0")]
    public class EmploymentDepartmentAndSupervisor : Migration
    {
        public override void Up()
        {
            // Delete old department attribute
            RockMigrationHelper.DeleteAttribute("034EA0EA-BCF5-4248-ADF9-FC87CFD7DABF"); // Rock.Model.Step: Department

            Sql(@"
                INSERT INTO [Attribute] ([IsSystem],[FieldTypeId],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Key],[Name],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid],[CreatedDateTime],[ModifiedDateTime],[ForeignKey],[IconCssClass],[AllowSearch],[ForeignGuid],[ForeignId],[IsIndexEnabled],[IsAnalytic],[IsAnalyticHistory],[IsActive],[EnableHistory],[PreHtml],[PostHtml],[AbbreviatedName],[ShowOnBulk],[IsPublic])
                VALUES
                (0,16,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Department',N'Department',N'',1,1,N'',0,1,'{06B15698-F962-4A78-A54C-10F0732DF0CF}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Department',0,0),
                (0,18,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Supervisor',N'Supervisor',N'',1,1,N'',0,1,'{A92A2AF9-39A5-453E-AA50-AD741C75EDAD}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Supervisor',0,0)
            ");

            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "AllowAddingNewValues", @"False", "25251028-2E29-4D9A-85FF-E4FC67B29A16");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "allowmultiple", @"False", "11D23BBB-0798-41DC-8DDE-C9FAF18E69F7");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "definedtype", SqlScalar("SELECT [Id] FROM [DefinedType] WHERE [Guid] = '"+SystemGuid.DefinedType.DEPARTMENTS+"'").ToString(), "71558384-1303-4B8B-A9F0-75A6A307C1B3");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "displaydescription", @"False", "A442B690-5787-411E-9B0B-71728F969F50");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "enhancedselection", @"True", "985C9961-41A4-4661-86B0-35E638D6017A");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "includeInactive", @"False", "84A7DF4F-9302-4C81-B64E-58558D4453D5");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("06B15698-F962-4A78-A54C-10F0732DF0CF", "RepeatColumns", @"", "8DEAD721-8B3D-4547-92A6-B8F8EAD0B993");
            // Qualifier for attribute: Supervisor
            RockMigrationHelper.UpdateAttributeQualifier("A92A2AF9-39A5-453E-AA50-AD741C75EDAD", "EnableSelfSelection", @"False", "C7A422A7-1FF3-4E3A-B9DB-2B2E8C1B4D3D");

        }

        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("06B15698-F962-4A78-A54C-10F0732DF0CF"); // Rock.Model.Step: Department
            RockMigrationHelper.DeleteAttribute("A92A2AF9-39A5-453E-AA50-AD741C75EDAD"); // Rock.Model.Step: Supervisor

        }
    }
}