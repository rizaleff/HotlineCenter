using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Iga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_work_orders_tb_reports_report_guid",
                table: "tb_work_orders");

            migrationBuilder.DropIndex(
                name: "IX_tb_work_orders_report_guid",
                table: "tb_work_orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "report_guid",
                table: "tb_work_orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tb_work_orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_orders_report_guid",
                table: "tb_work_orders",
                column: "report_guid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_work_orders_tb_reports_report_guid",
                table: "tb_work_orders",
                column: "report_guid",
                principalTable: "tb_reports",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_work_orders_tb_reports_report_guid",
                table: "tb_work_orders");

            migrationBuilder.DropIndex(
                name: "IX_tb_work_orders_report_guid",
                table: "tb_work_orders");

            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_work_orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "report_guid",
                table: "tb_work_orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_orders_report_guid",
                table: "tb_work_orders",
                column: "report_guid",
                unique: true,
                filter: "[report_guid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_work_orders_tb_reports_report_guid",
                table: "tb_work_orders",
                column: "report_guid",
                principalTable: "tb_reports",
                principalColumn: "guid");
        }
    }
}
