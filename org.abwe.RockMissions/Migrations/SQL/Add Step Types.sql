BEGIN TRANSACTION

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
               'Transitioned'
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
        ,'fa fa-map-marker-slash'
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
        (SELECT Id FROM StepProgram WHERE [Guid] = '38104628-dbcc-4719-bed5-966be9449d5a') -- Clearances
        ,'Medical Clearance'
        ,''
        ,''
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
        ,''
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
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Time',N'Time',N'',2,1,N'',0,1,'{d9bd8668-aa0f-47e0-b037-7ef6c01ddcfa}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Time',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'FLSA',N'FLSA',N'',3,1,N'',0,1,'{46c4003c-9d57-4ff2-8c49-a2f3738e1999}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'FLSA',0,0),
(0,3,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '2dabbcc8-19e6-4b59-aba2-a940cb876859'),N'Minister',N'Minister',N'',4,1,N'False',0,0,'{40d78067-ce1e-4a02-b8d2-b065ecfcb03f}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Minister',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'Field',N'Field',N'',0,1,N'',0,1,'{77019c0c-a06d-4e61-b216-850f9bc282dc}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Field',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Length',N'Length',N'',0,1,N'',0,1,'{ecc0a6ce-a261-45a2-b801-408d57b8c3d2}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Length',0,0),
(0,3,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Associate',N'Associate',N'',1,1,N'False',0,0,'{368827f0-f942-4c3e-90ac-3f6c10477e6c}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Associate',0,0),
(0,6,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef'),N'Commitment',N'Commitment',N'',2,1,N'',0,1,'{c2094694-7a88-4ce3-bb34-0b42c5906c86}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Commitment',0,0),
(0,11,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'CEIMClearance',N'CEIM Clearance',N'',2,0,N'',0,0,'{c912fceb-766b-40a3-993e-3dd03c2a500a}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'CEIM Clearance',0,0),
(0,11,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'LeftforField',N'Left for Field',N'',1,1,N'',0,0,'{d4cce29b-0552-4b71-9dd8-1d226a9859e8}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Left for Field',0,0),
(0,43,478,N'StepTypeId',(SELECT Id FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03'),N'Role',N'Role',N'',3,1,N'',0,1,'{2e9f95bc-4a9f-46e7-aeb3-19e36c7465b2}',GETDATE(),GETDATE(),NULL,N'',0,NULL,NULL,0,0,0,1,0,N'',N'',N'Role',0,0)

ROLLBACK TRANSACTION