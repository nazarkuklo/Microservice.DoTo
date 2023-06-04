using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Microservice.TaskManagement.Persistence.Migrations
{
    public partial class TagEntityTaskEntityRemoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagTasks",
                table: "TagTasks");

            migrationBuilder.DropIndex(
                name: "IX_TagTasks_TagId",
                table: "TagTasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TagTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 39, DateTimeKind.Local).AddTicks(3562),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 35, DateTimeKind.Local).AddTicks(3687),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 253, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Statuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 39, DateTimeKind.Local).AddTicks(2854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagTasks",
                table: "TagTasks",
                columns: new[] { "TagId", "TaskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagTasks",
                table: "TagTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(6256),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 39, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TagTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tags",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 253, DateTimeKind.Local).AddTicks(5154),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 35, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Statuses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 3, 16, 54, 0, 256, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 6, 4, 12, 31, 18, 39, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagTasks",
                table: "TagTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TagTasks_TagId",
                table: "TagTasks",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
