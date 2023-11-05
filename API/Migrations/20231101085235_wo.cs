using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class wo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cs_work_orders");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tb_work_orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_work_orders");

            migrationBuilder.CreateTable(
                name: "tb_cs_work_orders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    work_order_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cs_work_orders", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_cs_work_orders_tb_m_employees_EmployeeGuid",
                        column: x => x.EmployeeGuid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "FK_tb_cs_work_orders_tb_work_orders_work_order_guid",
                        column: x => x.work_order_guid,
                        principalTable: "tb_work_orders",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cs_work_orders_EmployeeGuid",
                table: "tb_cs_work_orders",
                column: "EmployeeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cs_work_orders_work_order_guid",
                table: "tb_cs_work_orders",
                column: "work_order_guid");
        }
    }
}
