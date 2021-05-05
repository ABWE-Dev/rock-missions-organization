//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Rock;
//using Rock.Model;
//using Rock.Plugin;

//namespace org.abwe.RockMissions.Migrations
//{
//    [MigrationNumber(13, "1.12.0")]
//    public class StepWorkflows : Migration
//    {
//        public override void Up()
//        {
//            #region Categories

//            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Timelines", "fa fa-stream", "", "CD91BB47-441E-42D2-A730-736839306CCA", 0); // Timelines

//            #endregion

//            #region Add Person to Field

//            RockMigrationHelper.UpdateWorkflowType(false, true, "Add Person to Field", "", "CD91BB47-441E-42D2-A730-736839306CCA", "Work", "fa fa-list-ol", 28800, true, 0, "DBB96699-08C6-4123-8D56-F318259B6106", 0); // Add Person to Field
//            RockMigrationHelper.UpdateWorkflowTypeAttribute("DBB96699-08C6-4123-8D56-F318259B6106", "829803DB-7CA3-44F6-B1CB-669D61ED6E92", "Step", "Step", "", 0, @"", "5528A23F-E052-4B6C-8800-DB111B5F1150", false); // Add Person to Field:Step
//            RockMigrationHelper.UpdateWorkflowTypeAttribute("DBB96699-08C6-4123-8D56-F318259B6106", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "Person", "Person", "", 1, @"", "C85DE973-3282-4412-A752-AED6117B2DF7", false); // Add Person to Field:Person
//            RockMigrationHelper.UpdateWorkflowTypeAttribute("DBB96699-08C6-4123-8D56-F318259B6106", "F4399CEF-827B-48B2-A735-F7806FCFE8E8", "Group", "Group", "", 2, @"", "8AA97C1F-9815-43D7-8933-A934E6448F31", false); // Add Person to Field:Group
//            RockMigrationHelper.UpdateWorkflowTypeAttribute("DBB96699-08C6-4123-8D56-F318259B6106", "3BB25568-E793-4D12-AE80-AC3FDA6FD8A8", "Group Role", "GroupRole", "", 3, @"", "32897869-FF12-4AFA-BB49-F70F88A4B205", false); // Add Person to Field:Group Role
//            RockMigrationHelper.AddAttributeQualifier("C85DE973-3282-4412-A752-AED6117B2DF7", "EnableSelfSelection", @"False", "D225329A-216E-465E-A670-FA6C1B3D1482"); // Add Person to Field:Person:EnableSelfSelection
//            RockMigrationHelper.AddAttributeQualifier("32897869-FF12-4AFA-BB49-F70F88A4B205", "grouptype", @"40", "E9FD6A12-8EA1-4ACB-9DA5-F61E9756DB40"); // Add Person to Field:Group Role:grouptype
//            RockMigrationHelper.UpdateWorkflowActivityType("DBB96699-08C6-4123-8D56-F318259B6106", true, "Start", "", true, 0, "CE9E610A-A137-4497-8F29-9755A71C8D41"); // Add Person to Field:Start
//            RockMigrationHelper.UpdateWorkflowActionType("CE9E610A-A137-4497-8F29-9755A71C8D41", "Set Step Entity", 0, "972F19B9-598B-474B-97A4-50E56E7B59D2", true, false, "", "", 1, "", "E25527B4-C80B-4750-A609-7CC6BCEB8A4D"); // Add Person to Field:Start:Set Step Entity
//            RockMigrationHelper.UpdateWorkflowActionType("CE9E610A-A137-4497-8F29-9755A71C8D41", "Set Person", 1, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "57CCB938-0C25-4478-B502-87BB35D69BD0"); // Add Person to Field:Start:Set Person
//            RockMigrationHelper.UpdateWorkflowActionType("CE9E610A-A137-4497-8F29-9755A71C8D41", "Set Group", 2, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "78BA3BB6-FAE6-4FE9-995C-C9A016D78454"); // Add Person to Field:Start:Set Group
//            RockMigrationHelper.UpdateWorkflowActionType("CE9E610A-A137-4497-8F29-9755A71C8D41", "Set Group Role", 3, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "2A0ECB20-8A94-43B3-A634-AB12BE5781C4"); // Add Person to Field:Start:Set Group Role
//            RockMigrationHelper.UpdateWorkflowActionType("CE9E610A-A137-4497-8F29-9755A71C8D41", "Add Group Member", 4, "A41216D6-6FB0-4019-B222-2C29B4519CF4", true, false, "", "", 1, "", "F2C0214C-952C-4BBE-82DC-3A00B57AB0E8"); // Add Person to Field:Start:Add Group Member
//            RockMigrationHelper.AddActionTypeAttributeValue("E25527B4-C80B-4750-A609-7CC6BCEB8A4D", "9392E3D7-A28B-4CD8-8B03-5E147B102EF1", @"False"); // Add Person to Field:Start:Set Step Entity:Active
//            RockMigrationHelper.AddActionTypeAttributeValue("E25527B4-C80B-4750-A609-7CC6BCEB8A4D", "61E6E1BC-E657-4F00-B2E9-769AAA25B9F7", @"5528a23f-e052-4b6c-8800-db111b5f1150"); // Add Person to Field:Start:Set Step Entity:Attribute
//            RockMigrationHelper.AddActionTypeAttributeValue("E25527B4-C80B-4750-A609-7CC6BCEB8A4D", "DDEFB300-0A4F-4086-99BE-A32761928F5E", @"True"); // Add Person to Field:Start:Set Step Entity:Entity Is Required
//            RockMigrationHelper.AddActionTypeAttributeValue("E25527B4-C80B-4750-A609-7CC6BCEB8A4D", "1246C53A-FD92-4E08-ABDE-9A6C37E70C7B", @"False"); // Add Person to Field:Start:Set Step Entity:Use Id instead of Guid
//            RockMigrationHelper.AddActionTypeAttributeValue("57CCB938-0C25-4478-B502-87BB35D69BD0", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Add Person to Field:Start:Set Person:Active
//            RockMigrationHelper.AddActionTypeAttributeValue("57CCB938-0C25-4478-B502-87BB35D69BD0", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"c85de973-3282-4412-a752-aed6117b2df7"); // Add Person to Field:Start:Set Person:Attribute
//            RockMigrationHelper.AddActionTypeAttributeValue("57CCB938-0C25-4478-B502-87BB35D69BD0", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{% assign step = Workflow | Attribute:'Step','Object' %}{{ step.PersonAlias.Guid }}"); // Add Person to Field:Start:Set Person:Text Value|Attribute Value
//            RockMigrationHelper.AddActionTypeAttributeValue("78BA3BB6-FAE6-4FE9-995C-C9A016D78454", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Add Person to Field:Start:Set Group:Active
//            RockMigrationHelper.AddActionTypeAttributeValue("78BA3BB6-FAE6-4FE9-995C-C9A016D78454", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"8aa97c1f-9815-43d7-8933-a934e6448f31"); // Add Person to Field:Start:Set Group:Attribute
//            RockMigrationHelper.AddActionTypeAttributeValue("78BA3BB6-FAE6-4FE9-995C-C9A016D78454", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Field','rawvalue' }}"); // Add Person to Field:Start:Set Group:Text Value|Attribute Value
//            RockMigrationHelper.AddActionTypeAttributeValue("2A0ECB20-8A94-43B3-A634-AB12BE5781C4", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Add Person to Field:Start:Set Group Role:Active
//            RockMigrationHelper.AddActionTypeAttributeValue("2A0ECB20-8A94-43B3-A634-AB12BE5781C4", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"32897869-ff12-4afa-bb49-f70f88a4b205"); // Add Person to Field:Start:Set Group Role:Attribute
//            RockMigrationHelper.AddActionTypeAttributeValue("2A0ECB20-8A94-43B3-A634-AB12BE5781C4", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"{{ Workflow | Attribute:'Step','Object' | Attribute:'Role','rawvalue' }}"); // Add Person to Field:Start:Set Group Role:Text Value|Attribute Value
//            RockMigrationHelper.AddActionTypeAttributeValue("F2C0214C-952C-4BBE-82DC-3A00B57AB0E8", "A18C3143-0586-4565-9F36-E603BC674B4E", @"False"); // Add Person to Field:Start:Add Group Member:Active
//            RockMigrationHelper.AddActionTypeAttributeValue("F2C0214C-952C-4BBE-82DC-3A00B57AB0E8", "F3B9908B-096F-460B-8320-122CF046D1F9", @"{% assign stepGuid = Workflow|Attribute:'Step','RawValue' %}
//            {% step where:'Guid ==""{{ stepGuid }}""' %}
//                {% assign step = stepItems | First %}
//            {% endstep %}

//            INSERT INTO GroupMember (IsSystem, GroupId, PersonId, GroupRoleId, GroupMemberStatus, [Guid], IsNotified, CommunicationPreference)
//            SELECT 0, [Group].Id, PersonAlias.PersonId, GroupTypeRole.Id, 1, NEWID(), 1, 0
//            FROM PersonAlias
//            CROSS APPLY (SELECT [Id] FROM GroupTypeRole WHERE GroupTypeRole.[Guid] = '{{ step | Attribute:'Role','RawValue' }}') [GroupTypeRole]
//            CROSS APPLY (SELECT [Id] FROM [Group] WHERE [Group].[Guid] = '{{ step | Attribute:'Field','RawValue' }}') [Group]
//            OUTER APPLY ( SELECT [Id] FROM GroupMember [Existing] WHERE [Existing].[GroupId] = [Group].[Id] AND Existing.PersonId = PersonAlias.PersonId AND Existing.GroupRoleId = GroupTypeRole.Id) [Existing]
//            WHERE PersonAlias.Guid = '{{ step.PersonAlias.Guid }}' AND Existing.Id IS NULL"); // Add Person to Field:Start:Add Group Member:SQLQuery
//            RockMigrationHelper.AddActionTypeAttributeValue("F2C0214C-952C-4BBE-82DC-3A00B57AB0E8", "9A567F6A-2A77-4ECD-80F7-BBD7D54E843C", @"False"); // Add Person to Field:Start:Add Group Member:Continue On Error

//            #endregion

//            #region DefinedValue AttributeType qualifier helper

//            Sql(@"
//			            UPDATE [aq] SET [key] = 'definedtype', [Value] = CAST( [dt].[Id] as varchar(5) )
//			            FROM [AttributeQualifier] [aq]
//			            INNER JOIN [Attribute] [a] ON [a].[Id] = [aq].[AttributeId]
//			            INNER JOIN [FieldType] [ft] ON [ft].[Id] = [a].[FieldTypeId]
//			            INNER JOIN [DefinedType] [dt] ON CAST([dt].[guid] AS varchar(50) ) = [aq].[value]
//			            WHERE [ft].[class] = 'Rock.Field.Types.DefinedValueFieldType'
//			            AND [aq].[key] = 'definedtypeguid'
//		            ");

//            #endregion
//        }

//        public override void Down()
//        {
            
//        }
//    }
//}
