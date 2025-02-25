using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commencis.EfCore.Infrastructure.Migrations.BenchmarkSequentialDb
{
    /// <inheritdoc />
    public partial class IndexAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Id",
                table: "Teachers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Id",
                table: "Schools",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Id",
                table: "Courses",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_Id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Id",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Id",
                table: "Courses");
        }
    }
}
