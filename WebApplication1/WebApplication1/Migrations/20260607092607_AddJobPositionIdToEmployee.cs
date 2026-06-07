using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class AddJobPositionIdToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobPositionId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobPositionId",
                table: "Employee",
                column: "JobPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobPositions_JobPositionId",
                table: "Employee",
                column: "JobPositionId",
                principalTable: "JobPositions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobPositions_JobPositionId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobPositionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "JobPositionId",
                table: "Employee");
        }
    }
}
