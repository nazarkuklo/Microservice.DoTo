using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Microservice.TaskManagement.Persistence.Migrations
{
    public partial class AddTableTagEntityTaskEntity_StatusEntityRenameEntityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Tasks_EntityId",
                table: "Statuses");

            migrationBuilder.DropTable(
                name: "TagEntityTaskEntity");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_EntityId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Statuses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(6256),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 253, DateTimeKind.Local).AddTicks(5154),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Statuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<List<Nullable<int>>>(
                name: "TaskIds",
                table: "Statuses",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagTasks_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTasks_TagId",
                table: "TagTasks",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTasks_TaskId",
                table: "TagTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TagTasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskIds",
                table: "Statuses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 253, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Statuses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Statuses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagEntityTaskEntity",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntityTaskEntity", x => new { x.TagsId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_TagEntityTaskEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEntityTaskEntity_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_EntityId",
                table: "Statuses",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagEntityTaskEntity_TaskId",
                table: "TagEntityTaskEntity",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Tasks_EntityId",
                table: "Statuses",
                column: "EntityId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
