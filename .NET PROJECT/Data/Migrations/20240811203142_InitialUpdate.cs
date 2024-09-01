using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedLab.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Test_DepartmentID",
                table: "Test",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Department_DepartmentID",
                table: "Test",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Department_DepartmentID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_DepartmentID",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Test");
        }
    }
}
