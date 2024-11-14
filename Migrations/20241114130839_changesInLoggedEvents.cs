using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalizedHealthRX_Api.Migrations
{
    /// <inheritdoc />
    public partial class changesInLoggedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "LoggedWebHookData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CaseId",
                table: "LoggedWebHookData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "LoggedWebHookData",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "LoggedWebHookData");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "LoggedWebHookData");

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "LoggedWebHookData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
