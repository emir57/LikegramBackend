using Microsoft.EntityFrameworkCore.Migrations;

namespace Likegram.DataAccess.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmKey",
                table: "Users",
                newName: "ConfirmCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmCode",
                table: "Users",
                newName: "ConfirmKey");
        }
    }
}
