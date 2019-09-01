using Microsoft.EntityFrameworkCore.Migrations;

namespace CRateWallet_WebAPI.DataAccess.Migrations
{
    public partial class TestEWalletV05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OTP_MANAGEMENT_TYPE",
                table: "OTP_MANAGEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_MANAGEMENT_TYPE",
                table: "OTP_MANAGEMENT",
                column: "TYPE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OTP_MANAGEMENT_TYPE",
                table: "OTP_MANAGEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_MANAGEMENT_TYPE",
                table: "OTP_MANAGEMENT",
                column: "TYPE",
                unique: true);
        }
    }
}
