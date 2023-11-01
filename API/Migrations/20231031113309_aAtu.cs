using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class aAtu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nik = table.Column<string>(type: "nchar(6)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: false),
                    expired_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_accounts", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_accounts_tb_m_employees_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_reports",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reports", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_reports_tb_m_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_account_roles_tb_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "tb_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_account_roles_tb_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_projects",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    report_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_approve = table.Column<bool>(type: "bit", nullable: false),
                    budget = table.Column<float>(type: "real", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_projects", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_projects_tb_reports_report_guid",
                        column: x => x.report_guid,
                        principalTable: "tb_reports",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_work_orders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    report_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_estimate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_approved = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_work_orders", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_work_orders_tb_m_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "FK_tb_work_orders_tb_projects_project_guid",
                        column: x => x.project_guid,
                        principalTable: "tb_projects",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "FK_tb_work_orders_tb_reports_report_guid",
                        column: x => x.report_guid,
                        principalTable: "tb_reports",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "tb_cs_work_orders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cs_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    work_order_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "tb_work_reports",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_finish = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    work_order_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_work_reports", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_work_reports_tb_m_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "FK_tb_work_reports_tb_work_orders_work_order_guid",
                        column: x => x.work_order_guid,
                        principalTable: "tb_work_orders",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_account_guid",
                table: "tb_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_role_guid",
                table: "tb_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cs_work_orders_EmployeeGuid",
                table: "tb_cs_work_orders",
                column: "EmployeeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cs_work_orders_work_order_guid",
                table: "tb_cs_work_orders",
                column: "work_order_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_email",
                table: "tb_m_employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_nik",
                table: "tb_m_employees",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_phone_number",
                table: "tb_m_employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_projects_report_guid",
                table: "tb_projects",
                column: "report_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_reports_employee_guid",
                table: "tb_reports",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_orders_employee_guid",
                table: "tb_work_orders",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_orders_project_guid",
                table: "tb_work_orders",
                column: "project_guid",
                unique: true,
                filter: "[project_guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_orders_report_guid",
                table: "tb_work_orders",
                column: "report_guid",
                unique: true,
                filter: "[report_guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_reports_employee_guid",
                table: "tb_work_reports",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_reports_work_order_guid",
                table: "tb_work_reports",
                column: "work_order_guid",
                unique: true,
                filter: "[work_order_guid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_account_roles");

            migrationBuilder.DropTable(
                name: "tb_cs_work_orders");

            migrationBuilder.DropTable(
                name: "tb_work_reports");

            migrationBuilder.DropTable(
                name: "tb_accounts");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_work_orders");

            migrationBuilder.DropTable(
                name: "tb_projects");

            migrationBuilder.DropTable(
                name: "tb_reports");

            migrationBuilder.DropTable(
                name: "tb_m_employees");
        }
    }
}
