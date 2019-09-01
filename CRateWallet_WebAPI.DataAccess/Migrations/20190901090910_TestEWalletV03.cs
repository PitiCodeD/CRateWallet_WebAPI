using Microsoft.EntityFrameworkCore.Migrations;

namespace CRateWallet_WebAPI.DataAccess.Migrations
{
    public partial class TestEWalletV03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ACTIVE_STATUS",
                table: "OTP_MANAGEMENT",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ACTIVE_STATUS",
                table: "OTP_MANAGEMENT",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 2);
        }
    }
}
