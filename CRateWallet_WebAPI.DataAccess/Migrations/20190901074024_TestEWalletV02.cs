using Microsoft.EntityFrameworkCore.Migrations;

namespace CRateWallet_WebAPI.DataAccess.Migrations
{
    public partial class TestEWalletV02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TYPE",
                table: "OTP_MANAGEMENT",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TYPE",
                table: "OTP_MANAGEMENT",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
