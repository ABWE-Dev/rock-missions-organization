using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock;
using Rock.Model;
using Rock.Plugin;

namespace org.abwe.RockMissions.Migrations
{
    [MigrationNumber(23, "1.12.0")]
    public class StepWorkflows : Migration
    {
        public override void Up()
        {
            #region Categories

            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Missions", "", "", "D3EA0403-2070-4833-8384-E11F21594900", 0); // Missions

            #endregion

            #region Sync Assignment Step to Group

            RockMigrationHelper.UpdateWorkflowType(false, true, "Sync Assignment Step to Group", "", "D3EA0403-2070-4833-8384-E11F21594900", "Work", "fa fa-list-ol", 28800, true, 0, "2320CC8D-E73C-40AA-9728-0C8598C26F23", 0); // Sync Assignment Step to Group
            Sql("UPDATE [WorkflowType] SET CompletedWorkflowRetentionPeriod = 7 WHERE [Guid] = '2320CC8D-E73C-40AA-9728-0C8598C26F23'");
            RockMigrationHelper.UpdateWorkflowTypeAttribute("2320CC8D-E73C-40AA-9728-0C8598C26F23", "829803DB-7CA3-44F6-B1CB-669D61ED6E92", "Step", "Step", "", 0, @"", "E04BD87D-12C8-45E1-B0D9-6A5997F2F5C6", false); // Sync Assignment Step to Group:Step
            RockMigrationHelper.UpdateWorkflowTypeAttribute("2320CC8D-E73C-40AA-9728-0C8598C26F23", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Person", "Person", "", 1, @"", "7BEBB7BD-D074-4BBF-BD95-D7F8AFC83486", false); // Sync Assignment Step to Group:Person
            RockMigrationHelper.UpdateWorkflowTypeAttribute("2320CC8D-E73C-40AA-9728-0C8598C26F23", "F4399CEF-827B-48B2-A735-F7806FCFE8E8", "Group", "Group", "", 2, @"", "63C9BB6B-7155-4AF7-8368-7D11E7009B23", false); // Sync Assignment Step to Group:Group
            RockMigrationHelper.UpdateWorkflowTypeAttribute("2320CC8D-E73C-40AA-9728-0C8598C26F23", "3BB25568-E793-4D12-AE80-AC3FDA6FD8A8", "Group Role", "GroupRole", "", 3, @"", "1F8B9127-440A-4C14-B21B-3428F861A7AA", false); // Sync Assignment Step to Group:Group Role
            RockMigrationHelper.AddAttributeQualifier("7BEBB7BD-D074-4BBF-BD95-D7F8AFC83486", "EnableSelfSelection", @"False", "4DC0D627-EAD5-4F27-B6E8-34780322CB5C"); // Sync Assignment Step to Group:Person:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("1F8B9127-440A-4C14-B21B-3428F861A7AA", "grouptype", @"", "E675F5DF-A3E9-4C16-8583-E276011B17A7"); // Sync Assignment Step to Group:Group Role:grouptype
            RockMigrationHelper.UpdateWorkflowActivityType("2320CC8D-E73C-40AA-9728-0C8598C26F23", true, "Start", "", true, 0, "D99F7518-15B7-498A-8A1F-C67E41F8986D"); // Sync Assignment Step to Group:Start
            RockMigrationHelper.UpdateWorkflowActionType("D99F7518-15B7-498A-8A1F-C67E41F8986D", "Set Step Entity", 0, "972F19B9-598B-474B-97A4-50E56E7B59D2", true, false, "", "", 1, "", "929D5FA7-EA7C-4C49-828E-5B4EA151D7D3"); // Sync Assignment Step to Group:Start:Set Step Entity
            RockMigrationHelper.UpdateWorkflowActionType("D99F7518-15B7-498A-8A1F-C67E41F8986D", "Set Person", 1, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "6516A71D-133F-44E5-B46C-596EDCF5301D"); // Sync Assignment Step to Group:Start:Set Person
            RockMigrationHelper.UpdateWorkflowActionType("D99F7518-15B7-498A-8A1F-C67E41F8986D", "Set Group", 2, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "AC4358C7-A972-424F-82BD-6C8B1A66A023"); // Sync Assignment Step to Group:Start:Set Group
            RockMigrationHelper.UpdateWorkflowActionType("D99F7518-15B7-498A-8A1F-C67E41F8986D", "Set Group Role", 3, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "A68F7E2C-0C58-496E-900F-B28339CF729B"); // Sync Assignment Step to Group:Start:Set Group Role
            RockMigrationHelper.UpdateWorkflowActionType("D99F7518-15B7-498A-8A1F-C67E41F8986D", "Add Group Member", 4, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "956D8A6D-25A3-4778-ADB3-3DB29492E30B"); // Sync Assignment Step to Group:Start:Add Group Member
            RockMigrationHelper.AddActionTypeAttributeValue("929D5FA7-EA7C-4C49-828E-5B4EA151D7D3", "9392E3D7-A28B-4CD8-8B03-5E147B102EF1", @"False"); // Sync Assignment Step to Group:Start:Set Step Entity:Active
            RockMigrationHelper.AddActionTypeAttributeValue("929D5FA7-EA7C-4C49-828E-5B4EA151D7D3", "61E6E1BC-E657-4F00-B2E9-769AAA25B9F7", @"e04bd87d-12c8-45e1-b0d9-6a5997f2f5c6"); // Sync Assignment Step to Group:Start:Set Step Entity:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("929D5FA7-EA7C-4C49-828E-5B4EA151D7D3", "DDEFB300-0A4F-4086-99BE-A32761928F5E", @"True"); // Sync Assignment Step to Group:Start:Set Step Entity:Entity Is Required
            RockMigrationHelper.AddActionTypeAttributeValue("929D5FA7-EA7C-4C49-828E-5B4EA151D7D3", "1246C53A-FD92-4E08-ABDE-9A6C37E70C7B", @"False"); // Sync Assignment Step to Group:Start:Set Step Entity:Use Id instead of Guid
            RockMigrationHelper.AddActionTypeAttributeValue("6516A71D-133F-44E5-B46C-596EDCF5301D", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{% assign step = Workflow | Attribute:'Step','Object' %}{{ step.PersonAlias.Guid }}"); // Sync Assignment Step to Group:Start:Set Person:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("6516A71D-133F-44E5-B46C-596EDCF5301D", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Sync Assignment Step to Group:Start:Set Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("6516A71D-133F-44E5-B46C-596EDCF5301D", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"7bebb7bd-d074-4bbf-bd95-d7f8afc83486"); // Sync Assignment Step to Group:Start:Set Person:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("AC4358C7-A972-424F-82BD-6C8B1A66A023", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Details','rawvalue' | Split:'|' | First }}"); // Sync Assignment Step to Group:Start:Set Group:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("AC4358C7-A972-424F-82BD-6C8B1A66A023", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Sync Assignment Step to Group:Start:Set Group:Active
            RockMigrationHelper.AddActionTypeAttributeValue("AC4358C7-A972-424F-82BD-6C8B1A66A023", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"63c9bb6b-7155-4af7-8368-7d11e7009b23"); // Sync Assignment Step to Group:Start:Set Group:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("A68F7E2C-0C58-496E-900F-B28339CF729B", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Details','rawvalue' | Split:'|' | Last }}"); // Sync Assignment Step to Group:Start:Set Group Role:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("A68F7E2C-0C58-496E-900F-B28339CF729B", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Sync Assignment Step to Group:Start:Set Group Role:Active
            RockMigrationHelper.AddActionTypeAttributeValue("A68F7E2C-0C58-496E-900F-B28339CF729B", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"1f8b9127-440a-4c14-b21b-3428f861a7aa"); // Sync Assignment Step to Group:Start:Set Group Role:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("956D8A6D-25A3-4778-ADB3-3DB29492E30B", "F3B9908B-096F-460B-8320-122CF046D1F9", @"{% assign stepGuid = Workflow|Attribute:'Step','RawValue' %}
            {% step where:'Guid ==""""{{ stepGuid }}""""' %}
                {% assign step = stepItems | First %}
            {% endstep %}
            INSERT INTO GroupMember (IsSystem, GroupId, PersonId, GroupRoleId, GroupMemberStatus, [Guid], IsNotified, CommunicationPreference)
            SELECT 0, [Group].Id, PersonAlias.PersonId, GroupTypeRole.Id, 1, NEWID(), 1, 0
            FROM PersonAlias
            CROSS APPLY (SELECT [Id] FROM GroupTypeRole WHERE GroupTypeRole.[Guid] = '{{ step | Attribute:'Details','RawValue' | Split:'|' | Last }}') [GroupTypeRole]
            CROSS APPLY (SELECT [Id] FROM [Group] WHERE [Group].[Guid] = '{{ step | Attribute:'Details','RawValue' | Split:'|' | First }}') [Group]
            OUTER APPLY ( SELECT [Id] FROM GroupMember [Existing] WHERE [Existing].[GroupId] = [Group].[Id] AND Existing.PersonId = PersonAlias.PersonId AND Existing.GroupRoleId = GroupTypeRole.Id) [Existing]
            WHERE PersonAlias.Guid = '{{ step.PersonAlias.Guid }}' AND Existing.Id IS NULL"); // Sync Assignment Step to Group:Start:Add Group Member:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("956D8A6D-25A3-4778-ADB3-3DB29492E30B", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Sync Assignment Step to Group:Start:Add Group Member:Active
            RockMigrationHelper.AddActionTypeAttributeValue("956D8A6D-25A3-4778-ADB3-3DB29492E30B", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Sync Assignment Step to Group:Start:Add Group Member:Continue On Error

            #endregion



            #region Remove Assignment Step from Group

            RockMigrationHelper.UpdateWorkflowType(false, true, "Remove Assignment Step from Group", "", "D3EA0403-2070-4833-8384-E11F21594900", "Work", "fa fa-list-ol", 28800, true, 0, "E47C07D0-7E3C-4DC9-A757-10EC698047CD", 0); // Remove Assignment Step from Group
            Sql("UPDATE [WorkflowType] SET CompletedWorkflowRetentionPeriod = 7 WHERE [Guid] = 'E47C07D0-7E3C-4DC9-A757-10EC698047CD'");
            RockMigrationHelper.UpdateWorkflowTypeAttribute("E47C07D0-7E3C-4DC9-A757-10EC698047CD", "829803DB-7CA3-44F6-B1CB-669D61ED6E92", "Step", "Step", "", 0, @"", "FD9ADB93-2787-41B7-9941-25DE3704615B", false); // Remove Assignment Step from Group:Step
            RockMigrationHelper.UpdateWorkflowTypeAttribute("E47C07D0-7E3C-4DC9-A757-10EC698047CD", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Person", "Person", "", 1, @"", "C4D58335-55C0-48E8-BECC-AF22402A40CE", false); // Remove Assignment Step from Group:Person
            RockMigrationHelper.UpdateWorkflowTypeAttribute("E47C07D0-7E3C-4DC9-A757-10EC698047CD", "F4399CEF-827B-48B2-A735-F7806FCFE8E8", "Group", "Group", "", 2, @"", "CA43CF03-25EA-4A74-9A20-02FB8B697D49", false); // Remove Assignment Step from Group:Group
            RockMigrationHelper.UpdateWorkflowTypeAttribute("E47C07D0-7E3C-4DC9-A757-10EC698047CD", "3BB25568-E793-4D12-AE80-AC3FDA6FD8A8", "Group Role", "GroupRole", "", 3, @"", "3A481456-0B8C-4B07-A04D-938BFC4828ED", false); // Remove Assignment Step from Group:Group Role
            RockMigrationHelper.AddAttributeQualifier("C4D58335-55C0-48E8-BECC-AF22402A40CE", "EnableSelfSelection", @"False", "389D56EE-8082-4975-8DF5-03780AB17322"); // Remove Assignment Step from Group:Person:EnableSelfSelection
            RockMigrationHelper.AddAttributeQualifier("3A481456-0B8C-4B07-A04D-938BFC4828ED", "grouptype", @"", "B4C4F79F-58E7-4F51-B1CF-CFAC97A99E94"); // Remove Assignment Step from Group:Group Role:grouptype
            RockMigrationHelper.UpdateWorkflowActivityType("E47C07D0-7E3C-4DC9-A757-10EC698047CD", true, "Start", "", true, 0, "F5498B42-95A1-47BF-B9B6-2876431EC4D6"); // Remove Assignment Step from Group:Start
            RockMigrationHelper.UpdateWorkflowActionType("F5498B42-95A1-47BF-B9B6-2876431EC4D6", "Set Step Entity", 0, "972F19B9-598B-474B-97A4-50E56E7B59D2", true, false, "", "", 1, "", "D7B6AAB4-B9FE-4690-B4B1-F19B42F54C8B"); // Remove Assignment Step from Group:Start:Set Step Entity
            RockMigrationHelper.UpdateWorkflowActionType("F5498B42-95A1-47BF-B9B6-2876431EC4D6", "Set Person", 1, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "A2436B01-87A8-47D5-9D5F-2CC64B9123F1"); // Remove Assignment Step from Group:Start:Set Person
            RockMigrationHelper.UpdateWorkflowActionType("F5498B42-95A1-47BF-B9B6-2876431EC4D6", "Set Group", 2, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "35016EB5-7DD7-4F4E-88C9-F02EE627AB27"); // Remove Assignment Step from Group:Start:Set Group
            RockMigrationHelper.UpdateWorkflowActionType("F5498B42-95A1-47BF-B9B6-2876431EC4D6", "Set Group Role", 3, "BC21E57A-1477-44B3-A7C2-61A806118945", true, false, "", "", 1, "", "2F1F4051-2F21-4014-8975-C915C16F2E11"); // Remove Assignment Step from Group:Start:Set Group Role
            RockMigrationHelper.UpdateWorkflowActionType("F5498B42-95A1-47BF-B9B6-2876431EC4D6", "Remove Group Member", 4, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "9BB5DBC0-7DD4-422F-B6B2-BE0059760D63"); // Remove Assignment Step from Group:Start:Remove Group Member
            RockMigrationHelper.AddActionTypeAttributeValue("D7B6AAB4-B9FE-4690-B4B1-F19B42F54C8B", "9392E3D7-A28B-4CD8-8B03-5E147B102EF1", @"False"); // Remove Assignment Step from Group:Start:Set Step Entity:Active
            RockMigrationHelper.AddActionTypeAttributeValue("D7B6AAB4-B9FE-4690-B4B1-F19B42F54C8B", "61E6E1BC-E657-4F00-B2E9-769AAA25B9F7", @"fd9adb93-2787-41b7-9941-25de3704615b"); // Remove Assignment Step from Group:Start:Set Step Entity:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("D7B6AAB4-B9FE-4690-B4B1-F19B42F54C8B", "DDEFB300-0A4F-4086-99BE-A32761928F5E", @"True"); // Remove Assignment Step from Group:Start:Set Step Entity:Entity Is Required
            RockMigrationHelper.AddActionTypeAttributeValue("D7B6AAB4-B9FE-4690-B4B1-F19B42F54C8B", "1246C53A-FD92-4E08-ABDE-9A6C37E70C7B", @"False"); // Remove Assignment Step from Group:Start:Set Step Entity:Use Id instead of Guid
            RockMigrationHelper.AddActionTypeAttributeValue("A2436B01-87A8-47D5-9D5F-2CC64B9123F1", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{% assign step = Workflow | Attribute:'Step','Object' %}{{ step.PersonAlias.Guid }}"); // Remove Assignment Step from Group:Start:Set Person:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("A2436B01-87A8-47D5-9D5F-2CC64B9123F1", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Remove Assignment Step from Group:Start:Set Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("A2436B01-87A8-47D5-9D5F-2CC64B9123F1", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"c4d58335-55c0-48e8-becc-af22402a40ce"); // Remove Assignment Step from Group:Start:Set Person:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("35016EB5-7DD7-4F4E-88C9-F02EE627AB27", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Details','rawvalue' | Split:'|' | First }}"); // Remove Assignment Step from Group:Start:Set Group:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("35016EB5-7DD7-4F4E-88C9-F02EE627AB27", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Remove Assignment Step from Group:Start:Set Group:Active
            RockMigrationHelper.AddActionTypeAttributeValue("35016EB5-7DD7-4F4E-88C9-F02EE627AB27", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"ca43cf03-25ea-4a74-9a20-02fb8b697d49"); // Remove Assignment Step from Group:Start:Set Group:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("2F1F4051-2F21-4014-8975-C915C16F2E11", "F1F6F9D6-FDC5-489C-8261-4B9F45B3EED4", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Details','rawvalue' | Split:'|' | Last }}"); // Remove Assignment Step from Group:Start:Set Group Role:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("2F1F4051-2F21-4014-8975-C915C16F2E11", "F1924BDC-9B79-4018-9D4A-C3516C87A514", @"False"); // Remove Assignment Step from Group:Start:Set Group Role:Active
            RockMigrationHelper.AddActionTypeAttributeValue("2F1F4051-2F21-4014-8975-C915C16F2E11", "431273C6-342D-4030-ADC7-7CDEDC7F8B27", @"3a481456-0b8c-4b07-a04d-938bfc4828ed"); // Remove Assignment Step from Group:Start:Set Group Role:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("9BB5DBC0-7DD4-422F-B6B2-BE0059760D63", "F3B9908B-096F-460B-8320-122CF046D1F9", @"{% assign stepGuid = Workflow|Attribute:'Step','RawValue' %}
            {% step where:'Guid ==""""{{ stepGuid }}""""' %}
                {% assign step = stepItems | First %}
            {% endstep %}

            DELETE FROM GroupMember
            WHERE [GroupMember].[PersonId] = (SELECT [PersonId] FROM [PersonAlias] WHERE [Guid] = '{{ step.PersonAlias.Guid }}')
            AND GroupRoleId = (SELECT [Id] FROM GroupTypeRole WHERE GroupTypeRole.[Guid] = '{{ step | Attribute:'Details','RawValue' | Split:'|' | Last }}')
            AND GroupId = (SELECT [Id] FROM [Group] WHERE [Group].[Guid] = '{{ step | Attribute:'Details','RawValue' | Split:'|' | First }}')"); // Remove Assignment Step from Group:Start:Remove Group Member:SQLQuery
            RockMigrationHelper.AddActionTypeAttributeValue("9BB5DBC0-7DD4-422F-B6B2-BE0059760D63", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Remove Assignment Step from Group:Start:Remove Group Member:Active
            RockMigrationHelper.AddActionTypeAttributeValue("9BB5DBC0-7DD4-422F-B6B2-BE0059760D63", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Remove Assignment Step from Group:Start:Remove Group Member:Continue On Error

            #endregion

            Sql(@"
                DECLARE @StepProgramId int = (SELECT [Id] FROM [StepProgram] WHERE [Guid] = '59c990ed-f5b4-4379-a926-852cba08fa03');
                DECLARE @StepTypeId int = (SELECT [Id] FROM StepType WHERE [Guid] = 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03');

                INSERT INTO [dbo].[StepWorkflowTrigger]
                            ([StepProgramId],[StepTypeId] ,[WorkflowTypeId],[TriggerType],[TypeQualifier],[WorkflowName],[IsActive],[CreatedDateTime],[ModifiedDateTime],[Guid])
                        VALUES
                            (
			                    @StepProgramId
                                ,@StepTypeId
                                ,(SELECT [Id] FROM WorkflowType WHERE [Guid] = '2320CC8D-E73C-40AA-9728-0C8598C26F23')
                                ,0
                                ,'|'+(SELECT TOP (1) CONVERT(varchar(10), [Id]) FROM StepStatus WHERE [Name] = 'Active')
                                ,'Sync Assignment Step to Group'
                                ,1
                                ,GETDATE()
                                ,GETDATE()
                                ,'4e467d9a-51b3-444e-89cf-9795515fab69'),
		                    (
			                    @StepProgramId
                                ,@StepTypeId
                                ,(SELECT [Id] FROM WorkflowType WHERE [Guid] = 'E47C07D0-7E3C-4DC9-A757-10EC698047CD')
                                ,2
                                ,'|'
                                ,'Sync Assignment Step to Group'
                                ,1
                                ,GETDATE()
                                ,GETDATE()
                                ,'811e7880-d927-4f05-8c14-396d7f67d261')
		   
            ");
        }

        public override void Down()
        {

        }
    }
}
