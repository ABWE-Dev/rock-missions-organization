using Rock;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.abwe.RockMissions.Migrations
{
    public abstract class ABWEMigration : Migration
    {
		public void AddEntitySecurity(string entityTypeName, string entityTypeTableName, string entityGuid, int order, string action, bool allow, string groupGuid, Rock.Model.SpecialRole specialRoleType, string authGuid, string entityGuidField = "Guid")
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
	}
}
