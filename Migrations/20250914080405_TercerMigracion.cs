using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_NET_CORE.Migrations
{
    /// <inheritdoc />
    public partial class TercerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[] { 1, "Author de a mentis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);
        }
    }
}
