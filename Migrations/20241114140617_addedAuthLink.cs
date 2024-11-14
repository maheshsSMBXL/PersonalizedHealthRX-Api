using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalizedHealthRX_Api.Migrations
{
    /// <inheritdoc />
    public partial class addedAuthLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthLink",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthLink",
                table: "User");
        }
    }
}
