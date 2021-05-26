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
    [MigrationNumber(13, "1.12.0")]
    public class StepTypes : Migration
    {
        private void AddStepSecurity(string entityTypeName, string entityTypeTableName, string entityGuid, int order, string action, bool allow, string groupGuid, Rock.Model.SpecialRole specialRoleType, string authGuid, string entityGuidField = "Guid")
        {
            if (string.IsNullOrWhiteSpace(groupGuid))
            {
                groupGuid = Guid.Empty.ToString();
            }

            int specialRole = specialRoleType.ConvertToInt();

            char allowChar = allow ? 'A' : 'D';

            string sql = $@"
            DECLARE @groupId INT

            SET @groupId = (
		            SELECT [Id]
		            FROM [Group]
		            WHERE [Guid] = '{groupGuid}'
		            )

            DECLARE @entityTypeId INT

            SET @entityTypeId = (
		            SELECT [Id]
		            FROM [EntityType]
		            WHERE [name] = '{entityTypeName}'
		            )

            DECLARE @entityId INT

            SET @entityId = (
		            SELECT [Id]
		            FROM [{entityTypeTableName}]
		            WHERE [{entityGuidField}] = '{entityGuid}'
		            )

            IF (
		            @entityId IS NOT NULL
		            AND @entityId != 0
		            )
            BEGIN
	            IF NOT EXISTS (
			            SELECT [Id]
			            FROM [Auth]
			            WHERE [EntityTypeId] = @entityTypeId
				            AND [EntityId] = @entityId
				            AND [Action] = '{action}'
				            AND [SpecialRole] = {specialRole}
				            AND [GroupId] = @groupId
			            )
	            BEGIN
		            INSERT INTO [dbo].[Auth] (
			            [EntityTypeId]
			            ,[EntityId]
			            ,[Order]
			            ,[Action]
			            ,[AllowOrDeny]
			            ,[SpecialRole]
			            ,[GroupId]
			            ,[Guid]
			            )
		            VALUES (
			            @entityTypeId
			            ,@entityId
			            ,{order}
			            ,'{action}'
			            ,'{allowChar}'
			            ,{specialRole}
			            ,@groupId
			            ,'{authGuid}'
			            )
	            END
            END
            ";
            Sql(sql);
        }

        public override void Up()
        {
            RockMigrationHelper.UpdateFieldType("Missions Org Group and Role", "Field Type to select a specific group and role", "org.abwe.RockMissions", "Rock.Field.Types.ABWECampusGroupAndRoleFieldType", SystemGuid.FieldType.FIELD_TYPE_CAMPUS_GROUP_ROLE, true);

            RockMigrationHelper.AddDefinedType("Missions Orgs", "Courses", "Missions Organization courses for personal development", "E811C31F-475E-42DE-B754-B6A63EC1ABBD", @"");
            RockMigrationHelper.UpdateDefinedValue("E811C31F-475E-42DE-B754-B6A63EC1ABBD", "Sample Course", "", "3886578B-48EB-4607-9A0E-4BBE1ADCC880", false);

            // Add Step Types and Attributes
            Sql(@"
/**
**  Rock Missions Step Types
**/

-- Add Category
INSERT INTO [Category]
    (
        IsSystem
        ,EntityTypeId
        ,[Name]
        ,[Guid]
        ,[Order]
        ,[Description]
        ,[CreatedDateTime]
        ,[ModifiedDateTime]
    )
VALUES
    (
        0
        ,480
        ,'Missions'
        ,'6af22686-023b-47c7-8dfe-f1d8a4b3b3d9'
        ,0
        ,'Step programs related to the Missions Organization plugin'
        ,GETDATE()
        ,GETDATE()   
    )

-- Step Programs
INSERT INTO [StepProgram]
    (
        [Name]
        ,[Description]
        ,[IconCssClass]
        ,[CategoryId]
        ,[DefaultListView]
        ,[IsActive]
        ,[Order]
        ,[CreatedDateTime]
        ,[ModifiedDateTime]
        ,[Guid]
        ,[StepTerm]
    )
    VALUES
    (
        'Career'
        ,'Missions Organization career steps'
        ,'fa fa-user-hard-hat'
        ,(SELECT [Id] FROM [Category] WHERE [Guid] = '6af22686-023b-47c7-8dfe-f1d8a4b3b3d9')
        ,1
        ,1
        ,4
        ,GETDATE()
        ,GETDATE()
        ,'59c990ed-f5b4-4379-a926-852cba08fa03'
        ,'Step'
    ),
    (
        'Travel'
        ,'Travel for missionaries'
        ,'fa fa-plane'
        ,(SELECT [Id] FROM [Category] WHERE [Guid] = '6af22686-023b-47c7-8dfe-f1d8a4b3b3d9')
        ,1
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'38104628-dbcc-4719-bed5-966be9449d5a'
        ,'Date'
    ),
    (
        'Clearances'
        ,'Clearances for missionaries'
        ,'fa fa-clipboard-check'
        ,(SELECT [Id] FROM [Category] WHERE [Guid] = '6af22686-023b-47c7-8dfe-f1d8a4b3b3d9')
        ,1
        ,1
        ,1
        ,GETDATE()
        ,GETDATE()
        ,'acf26de6-f052-472a-8421-3293f99a3a9f'
        ,'Clearance'
    ),
    (
        'Personal Development'
        ,'Steps for personal development'
        ,'fa fa-books'
        ,(SELECT [Id] FROM [Category] WHERE [Guid] = '6af22686-023b-47c7-8dfe-f1d8a4b3b3d9')
        ,1
        ,1
        ,4
        ,GETDATE()
        ,GETDATE()
        ,'a18be29d-e42c-428e-9ae4-0ac57e4eed3e'
        ,'Step'
    )

-- Step Statuses
INSERT INTO [dbo].[StepStatus]
           ([Name]
           ,[StepProgramId]
           ,[IsCompleteStatus]
           ,[StatusColor]
           ,[IsActive]
           ,[Order]
           ,[CreatedDateTime]
           ,[ModifiedDateTime]
           ,[Guid])
     VALUES
           (
               'Active'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,0
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
		   (
               'Concluded'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,1
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Retired'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,1
               ,''
               ,1
               ,4
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Transferred'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,1
               ,''
               ,1
               ,1
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Terminated'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,1
               ,''
               ,1
               ,2
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Resigned'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
               ,1
               ,''
               ,1
               ,3
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'In Progress'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = 'a18be29d-e42c-428e-9ae4-0ac57e4eed3e') -- Personal Development
               ,0
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Complete'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = 'a18be29d-e42c-428e-9ae4-0ac57e4eed3e') -- Personal Development
               ,1
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Planned'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
               ,0
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Ongoing'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
               ,0
               ,''
               ,1
               ,1
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Complete'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
               ,1
               ,''
               ,1
               ,2
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'In Progress'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = 'acf26de6-f052-472a-8421-3293f99a3a9f') -- Clearances
               ,0
               ,''
               ,1
               ,0
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           ),
           (
               'Complete'
               ,(SELECT Id FROM StepProgram WHERE [Guid] = 'acf26de6-f052-472a-8421-3293f99a3a9f') -- Clearances
               ,1
               ,''
               ,1
               ,1
               ,GETDATE()
               ,GETDATE()
               ,NEWID()
           )

-- Step Types

INSERT [dbo].[StepType] (
    [StepProgramId]
    ,[Name]
    ,[Description]
    ,[IconCssClass]
    ,[AllowMultiple]
    ,[HasEndDate]
    ,[ShowCountOnBadge]
    ,[AllowManualEditing]
    ,[HighlightColor]
    ,[IsActive]
    ,[Order]
    ,[CreatedDateTime]
    ,[ModifiedDateTime]
    ,[Guid]
    ,[IsDateRequired]
) VALUES
    (
        (SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
        ,'Field Assignment'
        ,''
        ,'fa fa-seedling'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(156,39,176)'
        ,1
        ,1
        ,GETDATE()
        ,GETDATE()
        ,'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'
        ,1
    ),(
        (SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
        ,'Appointment'
        ,''
        ,'fa fa-certificate'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(76,175,80)'
        ,1
        ,2
        ,GETDATE()
        ,GETDATE()
        ,'7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'
        ,1
    ),(
        (SELECT Id FROM StepProgram WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03') -- Career
        ,'Employment'
        ,''
        ,'fa fa-user-tie'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(33,150,243)'
        ,1
        ,3
        ,GETDATE()
        ,GETDATE()
        ,'2dabbcc8-19e6-4b59-aba2-a940cb876859'
        ,1
    ),(
        (SELECT Id FROM StepProgram WHERE [Guid] = 'a18be29d-e42c-428e-9ae4-0ac57e4eed3e') -- Personal Development
        ,'Book'
        ,''
        ,'fa fa-book'
        ,1
        ,0
        ,1
        ,1
        ,''
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'3036b703-b8fb-4f6f-9ec0-302b5b0f6c67'
        ,1
    ),(
        (SELECT Id FROM StepProgram WHERE [Guid] = 'a18be29d-e42c-428e-9ae4-0ac57e4eed3e') -- Personal Development
        ,'Course'
        ,''
        ,'fa fa-users-class'
        ,1
        ,0
        ,1
        ,1
        ,''
        ,1
        ,1
        ,GETDATE()
        ,GETDATE()
        ,'7d10fe63-8df4-454c-92ca-b745708192b6'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
        ,'Furlough'
        ,''
        ,'fa fa-island-tropical'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(33,150,243)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'ae81b102-7c6a-4c1a-a747-85a56a7887ef'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
        ,'Leave of Absence'
        ,''
        ,'fa fa-map-marker-slash'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(76,175,80)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'084b76bb-2881-41dc-abeb-5eaff7ed551d'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
        ,'Medical Furlough'
        ,''
        ,'fa fa-notes-medical'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(244,67,54)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'0f72067a-0238-487e-80a4-43a1cd7cac68'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Travel
        ,'Medical Leave of Absence'
        ,''
        ,'fa fa-notes-medical'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(244,67,54)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'ffc1cc5b-fe73-4dbf-bc99-dcb22ded90c2'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = 'acf26de6-f052-472a-8421-3293f99a3a9f') -- Clearances
        ,'Medical Clearance'
        ,''
        ,'fa fa-stethoscope'
        ,1
        ,1
        ,1
        ,1
        ,'rgb(238,118,37)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'6b3c5f2f-d220-4ea0-867d-02d717dde46d'
        ,1
    ), (
        (SELECT Id FROM StepProgram WHERE [Guid] = 'acf26de6-f052-472a-8421-3293f99a3a9f') -- Clearances
        ,'Financial Clearance'
        ,''
        ,'fa fa-search-dollar'
        ,1
        ,0
        ,1
        ,1
        ,'rgb(238,118,37)'
        ,1
        ,0
        ,GETDATE()
        ,GETDATE()
        ,'59a9bd76-0d0e-4a5d-b9d9-a4bad50ed72b'
        ,1
    )

-- Attributes

INSERT INTO [Attribute] ([IsSystem],[FieldTypeId],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Key],[Name],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid],[CreatedDateTime],[ModifiedDateTime],[ForeignKey],[IconCssClass],[AllowSearch],[ForeignGuid],[ForeignId],[IsIndexEnabled],[IsAnalytic],[IsAnalyticHistory],[IsActive],[EnableHistory],[PreHtml],[PostHtml],[AbbreviatedName],[ShowOnBulk],[IsPublic])
VALUES
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '084b76bb-2881-41dc-abeb-5eaff7ed551d'),N'Location',N'Location',N'',0,1,N'',0,1,'{d9c29ceb-1180-4826-8208-522de5f93c26}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Location',0,0),
(0,16,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7d10fe63-8df4-454c-92ca-b745708192b6'),N'Course',N'Course',N'',0,1,N'',0,1,'{d47de59b-b3e2-476a-aaff-c5722b466b7f}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Course',0,0),
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7d10fe63-8df4-454c-92ca-b745708192b6'),N'Location',N'Location',N'',1,0,N'',0,0,'{2a6fe8a8-ad49-476a-89ed-0a72731d8790}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Location',0,0),
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '0f72067a-0238-487e-80a4-43a1cd7cac68'),N'Location',N'Location',N'',0,1,N'',0,1,'{200603ab-4178-4eef-bf2c-f5fd3b611d94}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Location',0,0),
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ffc1cc5b-fe73-4dbf-bc99-dcb22ded90c2'),N'Location',N'Location',N'',0,1,N'',0,1,'{fb7a01cd-d632-4226-ad9b-b5ee1cee412f}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Location',0,0),
(0,1,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'JobTitle',N'Job Title',N'',0,1,N'',0,1,'{63350e79-db39-4ee9-a6f2-a4d8f73d3b44}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Job Title',0,0),
(0,67,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Department',N'Department',N'',1,1,N'aab2e9f4-e828-4fee-8467-73dc9dab784c|',0,1,'{034ea0ea-bcf5-4248-adf9-fc87cfd7dabf}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Department',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Commitment',N'Commitment',N'',2,1,N'',0,1,'{d9bd8668-aa0f-47e0-b037-7ef6c01ddcfa}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Commitment',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'FLSA',N'FLSA',N'',3,1,N'',0,1,'{46c4003c-9d57-4ff2-8c49-a2f3738e1999}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'FLSA',0,0),
(0,3,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Minister',N'Minister',N'',4,1,N'False',0,0,'{40d78067-ce1e-4a02-b8d2-b065ecfcb03f}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Minister',0,0),
(0,(SELECT Id FROM FieldType WHERE [Guid] = 'A0F1F865-68E1-49C3-A4A7-826808FF5E94'),478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'Details',N'Details',N'',0,1,N'',0,1,'{77019c0c-a06d-4e61-b216-850f9bc282dc}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Details',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Length',N'Length',N'',0,1,N'',0,1,'{ecc0a6ce-a261-45a2-b801-408d57b8c3d2}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Length',0,0),
(0,3,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Associate',N'Associate',N'',1,1,N'False',0,0,'{368827f0-f942-4c3e-90ac-3f6c10477e6c}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Associate',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Commitment',N'Commitment',N'',2,1,N'',0,1,'{c2094694-7a88-4ce3-bb34-0b42c5906c86}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Commitment',0,0),
(0,11,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'EDClearance',N'ED Clearance',N'',2,0,N'',0,0,'{c912fceb-766b-40a3-993e-3dd03c2a500a}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'CEIM Clearance',0,0),
(0,11,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'LeftforField',N'Left for Field',N'',1,1,N'',0,0,'{d4cce29b-0552-4b71-9dd8-1d226a9859e8}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Left for Field',0,0)
");

            // Qualifier for attribute: Assignment
            RockMigrationHelper.UpdateAttributeQualifier("77019c0c-a06d-4e61-b216-850f9bc282dc", "groupAndRolePickerLabel", @"Group", "615B04C6-0C19-432F-8D40-04F29EBEB1E3");

            // Qualifier for attribute: Length
            RockMigrationHelper.UpdateAttributeQualifier("ECC0A6CE-A261-45A2-B801-408D57B8C3D2", "values", @"Short-Term,Mid-Term,Long-Term", "F462F5C8-0161-4A7C-8AB4-BD11D8378AB7");
            // Qualifier for attribute: Length
            RockMigrationHelper.UpdateAttributeQualifier("ECC0A6CE-A261-45A2-B801-408D57B8C3D2", "fieldtype", @"ddl", "39B2E053-76D7-4669-B626-B822724BE4A9");
            // Qualifier for attribute: Length
            RockMigrationHelper.UpdateAttributeQualifier("ECC0A6CE-A261-45A2-B801-408D57B8C3D2", "repeatColumns", @"", "D2712A03-84E6-4771-ADFD-2FFB5E36790E");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("D9C29CEB-1180-4826-8208-522DE5F93C26", "ispassword", @"False", "13BD57DC-BE69-43B6-A2DC-1987CC665453");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("D9C29CEB-1180-4826-8208-522DE5F93C26", "maxcharacters", @"", "B7DF3E95-4A74-47EB-A2ED-BA9A64847F17");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("D9C29CEB-1180-4826-8208-522DE5F93C26", "showcountdown", @"False", "6DC5D2B8-A3BD-4196-879E-48B6074FD5FC");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "definedtype", SqlScalar("SELECT [Id] FROM DefinedType WHERE [Guid] = 'E811C31F-475E-42DE-B754-B6A63EC1ABBD'").ToString(), "7657EE8C-636F-4855-BCCE-149A0541B1FA");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "allowmultiple", @"False", "04A16101-4908-4AFD-A263-E6B254C73833");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "displaydescription", @"False", "30535088-543E-4573-870D-46295EC899EB");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "enhancedselection", @"False", "05262560-6C58-4E08-859C-B48EC1BB3BB9");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "includeInactive", @"False", "BBAA735B-888C-4CC5-8D1F-E42FF0D754A9");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "AllowAddingNewValues", @"True", "46582775-415E-4E89-9E70-AEDAD38FF635");
            // Qualifier for attribute: Course
            RockMigrationHelper.UpdateAttributeQualifier("D47DE59B-B3E2-476A-AAFF-C5722B466B7F", "RepeatColumns", @"", "6675502B-0C9B-46A4-9A7B-228F35A5DE29");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("FB7A01CD-D632-4226-AD9B-B5EE1CEE412F", "ispassword", @"False", "BF12C24F-1A37-45D4-8A84-0A93CEA67B21");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("FB7A01CD-D632-4226-AD9B-B5EE1CEE412F", "maxcharacters", @"", "93F033AB-BA94-4398-9CEE-D576AE51C25D");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("FB7A01CD-D632-4226-AD9B-B5EE1CEE412F", "showcountdown", @"False", "1F2E7AFA-32B9-4433-A5C3-731AA452FD3E");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("200603AB-4178-4EEF-BF2C-F5FD3B611D94", "ispassword", @"False", "2DABA6B0-C4C0-46CA-97F4-38678C957743");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("200603AB-4178-4EEF-BF2C-F5FD3B611D94", "maxcharacters", @"", "FF64D6AE-A88F-4C34-9556-407009D5D795");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("200603AB-4178-4EEF-BF2C-F5FD3B611D94", "showcountdown", @"False", "9053CDC8-7D83-499D-A113-B6B380111015");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("2A6FE8A8-AD49-476A-89ED-0A72731D8790", "ispassword", @"False", "EEC1DF8D-568A-4DA9-8F4B-937ACBF81EDB");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("2A6FE8A8-AD49-476A-89ED-0A72731D8790", "maxcharacters", @"", "58DE7EC5-7A29-4DCE-B7E4-02E6A698D75F");
            // Qualifier for attribute: Location
            RockMigrationHelper.UpdateAttributeQualifier("2A6FE8A8-AD49-476A-89ED-0A72731D8790", "showcountdown", @"False", "04A01D8A-D2B8-4F15-BAF2-4285AA6BA011");
            // Qualifier for attribute: Associate
            RockMigrationHelper.UpdateAttributeQualifier("368827F0-F942-4C3E-90AC-3F6C10477E6C", "truetext", @"Yes", "5CE9B554-C751-4224-92D7-029AFF367852");
            // Qualifier for attribute: Associate
            RockMigrationHelper.UpdateAttributeQualifier("368827F0-F942-4C3E-90AC-3F6C10477E6C", "falsetext", @"No", "40D74C64-79B1-4B3C-BA2F-60DFF213FEBB");
            // Qualifier for attribute: Associate
            RockMigrationHelper.UpdateAttributeQualifier("368827F0-F942-4C3E-90AC-3F6C10477E6C", "BooleanControlType", @"1", "3D3ABEA9-E1A1-4ACE-A4E9-42444613FA1C");
            // Qualifier for attribute: Commitment
            RockMigrationHelper.UpdateAttributeQualifier("C2094694-7A88-4CE3-BB34-0B42C5906C86", "values", @"Full-Time,Part-Time", "8456E24C-BDD3-4B02-B896-2B9C8901C84A");
            // Qualifier for attribute: Commitment
            RockMigrationHelper.UpdateAttributeQualifier("C2094694-7A88-4CE3-BB34-0B42C5906C86", "fieldtype", @"ddl", "59D36FDE-94B5-4380-8B00-43332E24354B");
            // Qualifier for attribute: Commitment
            RockMigrationHelper.UpdateAttributeQualifier("C2094694-7A88-4CE3-BB34-0B42C5906C86", "repeatColumns", @"", "FE4CCD6D-F7EC-4211-A392-712702786FC1");

            // Qualifier for attribute: Commitment (Employment)
            RockMigrationHelper.UpdateAttributeQualifier("D9BD8668-AA0F-47E0-B037-7EF6C01DDCFA", "values", @"Full-Time,Part-Time", "04DCD057-7691-4928-9670-C585EC897FD0");
            // Qualifier for attribute: Commitment (Employment)
            RockMigrationHelper.UpdateAttributeQualifier("D9BD8668-AA0F-47E0-B037-7EF6C01DDCFA", "fieldtype", @"ddl", "D04DB873-21F1-420E-B3C5-8CC552C5095E");
            // Qualifier for attribute: Commitment (Employment)
            RockMigrationHelper.UpdateAttributeQualifier("D9BD8668-AA0F-47E0-B037-7EF6C01DDCFA", "repeatColumns", @"", "917E0BFF-AC9A-404B-8380-828E3F78F2B5");
            // Qualifier for attribute: FLSA
            RockMigrationHelper.UpdateAttributeQualifier("46C4003C-9D57-4FF2-8C49-A2F3738E1999", "values", @"Exempt-Administrative,Exempt-Computer,Exempt-Creative,Exempt-Executive,Exempt-Minister,Exempt-Professional,Non-Exempt", "02FF62D8-C79D-4E73-BA9B-EA3AA376820F");
            // Qualifier for attribute: FLSA
            RockMigrationHelper.UpdateAttributeQualifier("46C4003C-9D57-4FF2-8C49-A2F3738E1999", "fieldtype", @"ddl", "93A0A6CA-DC9C-43EC-84F0-DA48DAF2085B");
            // Qualifier for attribute: FLSA
            RockMigrationHelper.UpdateAttributeQualifier("46C4003C-9D57-4FF2-8C49-A2F3738E1999", "repeatColumns", @"", "7F7E07D3-A530-4C23-BB56-73A0749C215B");
            // Qualifier for attribute: Minister
            RockMigrationHelper.UpdateAttributeQualifier("40D78067-CE1E-4A02-B8D2-B065ECFCB03F", "truetext", @"Yes", "648BC9A6-8EC0-4807-A54A-8F6D0CC410F9");
            // Qualifier for attribute: Minister
            RockMigrationHelper.UpdateAttributeQualifier("40D78067-CE1E-4A02-B8D2-B065ECFCB03F", "falsetext", @"No", "9C812804-46F2-47DC-99CF-DF01A5A3B6BD");
            // Qualifier for attribute: Minister
            RockMigrationHelper.UpdateAttributeQualifier("40D78067-CE1E-4A02-B8D2-B065ECFCB03F", "BooleanControlType", @"1", "FC2381E1-ED5D-4A15-8E0C-CD22820BFA05");
            // Qualifier for attribute: Department
            RockMigrationHelper.UpdateAttributeQualifier("034EA0EA-BCF5-4248-ADF9-FC87CFD7DABF", "groupPickerLabel", @"Group", "DC3C582A-1A50-4645-A676-AB8E23D97A03");
            // Qualifier for attribute: LeftforField
            RockMigrationHelper.UpdateAttributeQualifier("D4CCE29B-0552-4B71-9DD8-1D226A9859E8", "format", @"", "51528FCD-4A0C-43CE-B1F8-356D96141265");
            // Qualifier for attribute: LeftforField
            RockMigrationHelper.UpdateAttributeQualifier("D4CCE29B-0552-4B71-9DD8-1D226A9859E8", "displayDiff", @"False", "971E27D3-7EC9-475A-A00B-CD4CB05AEF1F");
            // Qualifier for attribute: LeftforField
            RockMigrationHelper.UpdateAttributeQualifier("D4CCE29B-0552-4B71-9DD8-1D226A9859E8", "displayCurrentOption", @"False", "41DE9BB3-5D15-4987-A0DF-C3286AA0B4C6");
            // Qualifier for attribute: LeftforField
            RockMigrationHelper.UpdateAttributeQualifier("D4CCE29B-0552-4B71-9DD8-1D226A9859E8", "datePickerControlType", @"Date Picker", "DF119327-409F-478F-AD8C-9AD1AC767BF8");
            // Qualifier for attribute: LeftforField
            RockMigrationHelper.UpdateAttributeQualifier("D4CCE29B-0552-4B71-9DD8-1D226A9859E8", "futureYearCount", @"", "F6368978-E59B-4197-B534-3CE4BCB9D842");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "futureYearCount", @"", "9EFB8DA5-4458-4E33-8DAD-5067DC066C9F");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "datePickerControlType", @"Date Picker", "0D5D86F9-298B-4821-A3A5-6192FA73A697");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "futureYearCount", @"", "9EFB8DA5-4458-4E33-8DAD-5067DC066C9F");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "displayCurrentOption", @"False", "CDC5F359-C41E-48B9-8474-527409A17346");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "displayDiff", @"False", "CB526FCC-76F3-4774-BBFD-87DFD6D40CE0");
            // Qualifier for attribute: CEIMClearance
            RockMigrationHelper.UpdateAttributeQualifier("C912FCEB-766B-40A3-993E-3DD03C2A500A", "format", @"", "A0299751-A6D3-4856-A3E8-4EFD366A3D93");

            // Add Page Timelines to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "BF04BB7E-BE3A-4A38-A37C-386B55496303", "F66758C6-3E3D-4598-AF4C-B317047B5987", "Timelines", "", "18E2C178-DD5D-4031-960A-71994057FDE4", "", "53CF4CBE-85F9-4A50-87D7-0D72A3FB2892");
            // Add Page Timeline Entry to Site:Rock RMS
            RockMigrationHelper.AddPage(true, "18E2C178-DD5D-4031-960A-71994057FDE4", Rock.SystemGuid.Layout.FULL_WIDTH_INTERNAL_SITE, "Timeline Entry", "", "6A4F75A3-95D1-43D5-AAF7-93CEC040F346");
            // Add Page Route for Timelines
            RockMigrationHelper.AddPageRoute("18E2C178-DD5D-4031-960A-71994057FDE4", "Person/{PersonId}/Timelines", "2EDD7D32-1557-43A8-98D9-CF9E3A4A758D");
            // Add Page Route for Timeline Entry
            RockMigrationHelper.AddPageRoute("6A4F75A3-95D1-43D5-AAF7-93CEC040F346", "Person/{PersonId}/Timelines/Add", "30F0FE0F-831A-4CB2-8B19-0476D5A6D110");
            // Add/Update BlockType Steps Timeline
            RockMigrationHelper.UpdateBlockType("Steps Timeline", "Displays a timeline of a person's steps", "~/Plugins/org_abwe/RockMissions/Churches/StepsTimeline.ascx", "org_abwe > Rock Missions > Steps Timeline", "46A95A66-8FAC-4327-837D-EE846A424982");
            // Add Block Steps Timeline to Page: Timelines, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "18E2C178-DD5D-4031-960A-71994057FDE4".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "46A95A66-8FAC-4327-837D-EE846A424982".AsGuid(), "Steps Timeline", "SubNavigation", @"", @"", 0, "8995F48B-CEA0-439C-924C-ADF96ACC93CC");
            // Attribute for BlockType: Steps Timeline:Step Entry Page
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("46A95A66-8FAC-4327-837D-EE846A424982", "BD53F9C9-EBA9-4D3F-82EA-DE5DD34A8108", "Step Entry Page", "StepPage", "Step Entry Page", @"The page where step records can be edited or added", 0, @"", "5D341011-9CC5-46A5-9ED9-998FE874B743");
            // Attribute for BlockType: Steps Timeline:StepTypes
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute("46A95A66-8FAC-4327-837D-EE846A424982", "BD0D9B57-2A41-4490-89FF-F01DAB7D4904", "StepTypes", "StepTypes", "StepTypes", @"", 0, @"", "5644C455-2029-4B3A-ABA3-F2A0F0866D5B");
            // Add Block Attribute Value
            //   Block: Steps Timeline
            //   BlockType: Steps Timeline
            //   Block Location: Page=Timelines, Site=Rock RMS
            //   Attribute: StepTypes
            //   Attribute Value: 6,7,8,9,11,12
            var StepTypeGuids = new List<string> { SystemGuid.StepType.STEP_TYPE_CAREER_APPOINTMENT, SystemGuid.StepType.STEP_TYPE_CAREER_EMPLOYMENT, SystemGuid.StepType.STEP_TYPE_CAREER_FIELD_ASSIGNMENT,
                SystemGuid.StepType.STEP_TYPE_CLEARANCE_FINANCIAL, SystemGuid.StepType.STEP_TYPE_CLEARANCE_MEDICAL, SystemGuid.StepType.STEP_TYPE_TRAVEL_FURLOUGH, SystemGuid.StepType.STEP_TYPE_TRAVEL_LEAVE_OF_ABSENCE,
                SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_FURLOUGH, SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_LEAVE_OF_ABSENCE };
            RockMigrationHelper.AddBlockAttributeValue("8995F48B-CEA0-439C-924C-ADF96ACC93CC", "5644C455-2029-4B3A-ABA3-F2A0F0866D5B",
                SqlScalar($"SELECT STRING_AGG(Id,',') FROM StepType WHERE [Guid] IN ('{StepTypeGuids.JoinStrings("','")}')").ToString()
            );
            // Add Block Attribute Value: Step Entry Page
            RockMigrationHelper.AddBlockAttributeValue("8995F48B-CEA0-439C-924C-ADF96ACC93CC", "5D341011-9CC5-46A5-9ED9-998FE874B743", "6A4F75A3-95D1-43D5-AAF7-93CEC040F346");
            // Delete default step program
            Sql("DELETE FROM StepProgram WHERE Id = 1");

            // Change default Steps page Steps block Step Program
            RockMigrationHelper.UpdateBlockAttributeValue("46E5C15A-44A5-4FB3-8CE8-572FB0D85367", "B4E07CC9-53E0-47CF-AC22-10F2085547A3", SystemGuid.StepProgram.STEP_PROGRAM_PERSONAL_DEVELOPMENT);

            // Add Block Step Entry to Page: Step Entry, Site: Rock RMS
            RockMigrationHelper.AddBlock(true, "6A4F75A3-95D1-43D5-AAF7-93CEC040F346".AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "8D78BC55-6E67-40AB-B453-994D69503838".AsGuid(), "Timeline Entry", "Main", @"<style>
                    .campus-picker { 
                        display: none;
                    }
                </style>", @"", 0, "985EBD06-AD2E-4FF5-8B1C-64C30710F91C");
            // Add Block Attribute Value
            //   Block: Step Entry
            //   BlockType: Step Entry
            //   Block Location: Page=Step Entry, Site=Rock RMS
            //   Attribute: Success Page
            //   Attribute Value: 18e2c178-dd5d-4031-960a-71994057fde4
            RockMigrationHelper.AddBlockAttributeValue("985EBD06-AD2E-4FF5-8B1C-64C30710F91C", "1BC93D94-6AB0-438B-B2EB-F3A3681DABEB", @"18e2c178-dd5d-4031-960a-71994057fde4");

            /** Security Roles for Step Types **/

            // Appointments
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_APPOINTMENT, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_HR, 0, "16f83431-49a6-44ff-9c82-adc8f130028e");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_APPOINTMENT, 1, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "a633c2ab-9334-416f-adbf-458e8812bed1");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_APPOINTMENT, 2, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "b530a09d-8440-4084-ba26-c00ebfc02f51");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_APPOINTMENT, 3, Authorization.EDIT, false, null, SpecialRole.AllUsers, "54552928-c2b7-4e2f-ac99-9502df7b7c88");

            // Assignments
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_FIELD_ASSIGNMENT, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_HR, 0, "e6bcd8ee-2fea-4e99-a5d3-0d0989a0c277");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_FIELD_ASSIGNMENT, 1, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "a31af976-a482-4260-893a-aa20b4692464");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_FIELD_ASSIGNMENT, 2, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "5a6bd3e3-5bb5-4232-bee7-b995d28a1f33");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_FIELD_ASSIGNMENT, 3, Authorization.EDIT, false, null, SpecialRole.AllUsers, "4d422f90-65bc-4b9c-a0f6-e56eadf12041");

            // Employment
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_EMPLOYMENT, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_HR, 0, "5ceceb92-d44b-4d97-b379-ebcf080e9920"); 
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_EMPLOYMENT, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "37693526-5de8-42fa-94b4-686bc6c458c3");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CAREER_EMPLOYMENT, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "398f91ee-467a-496c-a1bc-165ae6cd679d");

            // Employment FSLA attribute
            RockMigrationHelper.AddSecurityAuthForAttribute("46c4003c-9d57-4ff2-8c49-a2f3738e1999", 0, Authorization.VIEW, true, SystemGuid.Group.GROUP_HR, 0, "62b14a6c-5525-442d-a951-636e6842a1f8");
            RockMigrationHelper.AddSecurityAuthForAttribute("46c4003c-9d57-4ff2-8c49-a2f3738e1999", 1, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "8e2ece0b-0eb6-4e2f-b076-03f64d99d31b");
            RockMigrationHelper.AddSecurityAuthForAttribute("46c4003c-9d57-4ff2-8c49-a2f3738e1999", 1, Authorization.VIEW, false, null, (int)SpecialRole.AllUsers, "4644a936-f5c7-40d3-8e30-e9c66f65eeb2");

            // Employment Minister attribute
            RockMigrationHelper.AddSecurityAuthForAttribute("40d78067-ce1e-4a02-b8d2-b065ecfcb03f", 0, Authorization.VIEW, true, SystemGuid.Group.GROUP_HR, 0, "de376414-2ae3-4f83-9611-f8606cef1ea8");
            RockMigrationHelper.AddSecurityAuthForAttribute("40d78067-ce1e-4a02-b8d2-b065ecfcb03f", 1, Authorization.VIEW, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "805a8f9e-9fdb-47c7-8508-fdc926edcb5e");
            RockMigrationHelper.AddSecurityAuthForAttribute("40d78067-ce1e-4a02-b8d2-b065ecfcb03f", 1, Authorization.VIEW, false, null, (int)SpecialRole.AllUsers, "254545ce-c935-46cc-a857-109ff0a47f07");

            // Personal Development: Book
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_BOOK, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_TRAINING_WORKER, 0, "4a3c19ba-a4ac-47b3-bffc-41cc8ac6149a");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_BOOK, 1, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "742313f5-37c4-47a5-8aa5-a225c82227c8");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_BOOK, 2, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "5ee63bd2-6925-480d-9fc7-9136cfe6e331");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_BOOK, 3, Authorization.EDIT, false, null, SpecialRole.AllUsers, "6815583e-72c6-473d-adcb-1810c32e315a");

            // Personal Development: Course
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_COURSE, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_TRAINING_WORKER, 0, "42f97f52-2759-44ae-960f-4ec0fc6c6991");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_COURSE, 1, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "c0a5179d-e0fb-47b9-aa58-d2e6c286c13e");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_COURSE, 2, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "f54f78ed-deb3-4113-b0af-24e67bf64a88");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_PERSONAL_DEVELOPMENT_COURSE, 3, Authorization.EDIT, false, null, SpecialRole.AllUsers, "0cc1e655-1ccd-4a18-8f08-5e39a5e57b9f");

            // Travel: Furlough
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_FURLOUGH, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "9895bda4-9045-4a2e-94a5-00200455281d");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_FURLOUGH, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "0b6e1b80-dd4a-4d2e-a117-b41168b3788c");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_FURLOUGH, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "90badfbf-2286-4569-8e0f-d9b43f8d8f2b");

            // Travel: LOA
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_LEAVE_OF_ABSENCE, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "869dce14-01e0-4a88-9558-79db8ec0a590");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_LEAVE_OF_ABSENCE, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "92f024ba-f579-4677-bda0-005d75592d95");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_LEAVE_OF_ABSENCE, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "e617d9d3-f92c-47b7-bf46-0273affd411a");

            // Travel: Medical LOA
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_LEAVE_OF_ABSENCE, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "9a49e305-a3ca-496f-b0ba-72ef3b7bf17a");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_LEAVE_OF_ABSENCE, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "d81771bb-881b-43af-af9d-7620290811d1");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_LEAVE_OF_ABSENCE, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "d2877eda-d96c-49e5-824b-edcbc7ce0a8d");

            // Travel: Medical Furlough
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_FURLOUGH, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISSIONARY_WORKER, 0, "8872153e-9833-4a68-a2e8-4a8d4074667d");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_FURLOUGH, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "00d55f2c-89e4-480f-985f-d4f0a34a9316");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_TRAVEL_MEDICAL_FURLOUGH, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "dea28948-c6d3-423c-9c9d-ae3d4fe8faa4");

            // Clearances: Financial
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_FINANCIAL, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MISS_FINN_WORKER, 0, "eff8c2ba-3f4d-4bc7-b341-95e059de1c01");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_FINANCIAL, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "618e2623-4e25-4e25-bf32-3c31ee50ba3c");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_FINANCIAL, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "ab66f221-2b54-411b-8eba-41aca7ec3aff");

            // Clearances: Medical
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_MEDICAL, 0, Authorization.EDIT, true, SystemGuid.Group.GROUP_MEDICAL_ADMIN, 0, "9511f7d6-902c-494f-8bcc-7227d8a7ff23");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_MEDICAL, 1, Authorization.EDIT, true, Rock.SystemGuid.Group.GROUP_ADMINISTRATORS, 0, "c4fc8bc9-efec-4eaa-a487-b6ba9e84daac");
            AddStepSecurity("Rock.Model.StepType", "StepType", SystemGuid.StepType.STEP_TYPE_CLEARANCE_MEDICAL, 2, Authorization.EDIT, false, null, SpecialRole.AllUsers, "62b9f17d-a5b6-4660-8218-81052019baeb");
        }

        public override void Down()
        {
            RockMigrationHelper.DeleteDefinedValue("3886578B-48EB-4607-9A0E-4BBE1ADCC880"); // Good Soil
            RockMigrationHelper.DeleteDefinedType("E811C31F-475E-42DE-B754-B6A63EC1ABBD"); // Courses

            RockMigrationHelper.DeleteAttribute("77019C0C-A06D-4E61-B216-850F9BC282DC"); // Rock.Model.Step: Field
            RockMigrationHelper.DeleteAttribute("ECC0A6CE-A261-45A2-B801-408D57B8C3D2"); // Rock.Model.Step: Length
            RockMigrationHelper.DeleteAttribute("FB7A01CD-D632-4226-AD9B-B5EE1CEE412F"); // Rock.Model.Step: Location
            RockMigrationHelper.DeleteAttribute("200603AB-4178-4EEF-BF2C-F5FD3B611D94"); // Rock.Model.Step: Location
            RockMigrationHelper.DeleteAttribute("63350E79-DB39-4EE9-A6F2-A4D8F73D3B44"); // Rock.Model.Step: Job Title
            RockMigrationHelper.DeleteAttribute("D9C29CEB-1180-4826-8208-522DE5F93C26"); // Rock.Model.Step: Location
            RockMigrationHelper.DeleteAttribute("D47DE59B-B3E2-476A-AAFF-C5722B466B7F"); // Rock.Model.Step: Course
            RockMigrationHelper.DeleteAttribute("2A6FE8A8-AD49-476A-89ED-0A72731D8790"); // Rock.Model.Step: Location
            RockMigrationHelper.DeleteAttribute("034EA0EA-BCF5-4248-ADF9-FC87CFD7DABF"); // Rock.Model.Step: Department
            RockMigrationHelper.DeleteAttribute("368827F0-F942-4C3E-90AC-3F6C10477E6C"); // Rock.Model.Step: Associate
            RockMigrationHelper.DeleteAttribute("C2094694-7A88-4CE3-BB34-0B42C5906C86"); // Rock.Model.Step: Commitment
            RockMigrationHelper.DeleteAttribute("D9BD8668-AA0F-47E0-B037-7EF6C01DDCFA"); // Rock.Model.Step: Time
            RockMigrationHelper.DeleteAttribute("46C4003C-9D57-4FF2-8C49-A2F3738E1999"); // Rock.Model.Step: FLSA
            RockMigrationHelper.DeleteAttribute("40D78067-CE1E-4A02-B8D2-B065ECFCB03F"); // Rock.Model.Step: Minister
            RockMigrationHelper.DeleteAttribute("77019C0C-A06D-4E61-B216-850F9BC282DC"); // Rock.Model.Step: Field
            RockMigrationHelper.DeleteAttribute("2E9F95BC-4A9F-46E7-AEB3-19E36C7465B2"); // Rock.Model.Step: Role



            // Step Entry Page Attribute for BlockType: Steps Timeline
            RockMigrationHelper.DeleteAttribute("5D341011-9CC5-46A5-9ED9-998FE874B743");

            // StepTypes Attribute for BlockType: Steps Timeline
            RockMigrationHelper.DeleteAttribute("5644C455-2029-4B3A-ABA3-F2A0F0866D5B");

            // Remove Block: Steps Timeline, from Page: Timelines, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("8995F48B-CEA0-439C-924C-ADF96ACC93CC");

            // Remove Block: Step Entry, from Page: Step Entry, Site: Rock RMS
            RockMigrationHelper.DeleteBlock("985EBD06-AD2E-4FF5-8B1C-64C30710F91C");


            // Delete BlockType Steps Timeline
            RockMigrationHelper.DeleteBlockType("46A95A66-8FAC-4327-837D-EE846A424982"); // Steps Timeline


            // Delete BlockType Steps Timeline
            RockMigrationHelper.DeleteBlockType("46A95A66-8FAC-4327-837D-EE846A424982"); // Steps Timeline

            // Delete Page Step Entry from Site:Rock RMS
            RockMigrationHelper.DeletePage("6A4F75A3-95D1-43D5-AAF7-93CEC040F346"); //  Page: Step Entry, Layout: Full Width, Site: Rock RMS

            // Delete Page Timelines from Site:Rock RMS
            RockMigrationHelper.DeletePage("18E2C178-DD5D-4031-960A-71994057FDE4"); //  Page: Timelines, Layout: PersonDetail, Site: Rock RMS

            // Delete Field Type
            RockMigrationHelper.DeleteFieldType(SystemGuid.FieldType.FIELD_TYPE_CAMPUS_GROUP_ROLE);
        }
    }
}
