using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTest.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTestUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTests",
                table: "UserTests",
                columns: new[] { "UserId", "TestId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTests",
                table: "UserTests");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests",
                column: "UserId");
        }
    }
}
