using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyMigrationsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MngLastName",
                table: "Managers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "MngFirstName",
                table: "Managers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "EmpSalary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "EmpLastName",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "EmpFirstName",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Managers",
                newName: "MngLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Managers",
                newName: "MngFirstName");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "EmpSalary");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "EmpLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employees",
                newName: "EmpFirstName");
        }
    }
}
