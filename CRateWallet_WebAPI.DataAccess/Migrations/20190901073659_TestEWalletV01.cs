using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRateWallet_WebAPI.DataAccess.Migrations
{
    public partial class TestEWalletV01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIVE_DESCRIPTION",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTVIE_STATUS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVE_DESCRIPTION", x => x.ACTVIE_STATUS);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USERNAME = table.Column<string>(maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 20, nullable: false),
                    ADMIN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ADMIN_ACCOUNT_NO = table.Column<string>(maxLength: 20, nullable: true),
                    ADMIN_NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.ADMIN_ID);
                    table.ForeignKey(
                        name: "FK_ADMIN_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GENDER_DESCRIPTION",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    GENDER = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENDER_DESCRIPTION", x => x.GENDER);
                    table.ForeignKey(
                        name: "FK_GENDER_DESCRIPTION_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MERCHANT",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USERNAME = table.Column<string>(maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 20, nullable: false),
                    MERCHANT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PARTNERSHIP = table.Column<string>(maxLength: 100, nullable: false),
                    MERCHANT_ACCOUNT_NO = table.Column<string>(maxLength: 20, nullable: true),
                    MERCHANT_NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCHANT", x => x.MERCHANT_ID);
                    table.ForeignKey(
                        name: "FK_MERCHANT_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OTP_FOR_REGIS",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    OTP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OTP = table.Column<string>(maxLength: 10, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    REFERENCE = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTP_FOR_REGIS", x => x.OTP_ID);
                    table.ForeignKey(
                        name: "FK_OTP_FOR_REGIS_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TYPE_OTP_MANAGEMENT",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    TYPE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPE_OTP_MANAGEMENT", x => x.TYPE);
                    table.ForeignKey(
                        name: "FK_TYPE_OTP_MANAGEMENT_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_TOKEN",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    TOKEN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    REFRESH_TOKEN = table.Column<string>(maxLength: 50, nullable: false),
                    ADMIN_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_TOKEN", x => x.TOKEN_ID);
                    table.ForeignKey(
                        name: "FK_ADMIN_TOKEN_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADMIN_TOKEN_ADMIN_ADMIN_ID",
                        column: x => x.ADMIN_ID,
                        principalTable: "ADMIN",
                        principalColumn: "ADMIN_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_WALLET",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    ACCOUNT_NO = table.Column<string>(maxLength: 20, nullable: true),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    SURNAME = table.Column<string>(maxLength: 50, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    MOBILE_NO = table.Column<string>(maxLength: 20, nullable: false),
                    GENDER = table.Column<int>(nullable: false),
                    BALANCE = table.Column<decimal>(nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_WALLET", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USER_WALLET_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_WALLET_GENDER_DESCRIPTION_GENDER",
                        column: x => x.GENDER,
                        principalTable: "GENDER_DESCRIPTION",
                        principalColumn: "GENDER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MERCHANT_TOKEN",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    TOKEN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    REFRESH_TOKEN = table.Column<string>(maxLength: 50, nullable: false),
                    MERCHANT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCHANT_TOKEN", x => x.TOKEN_ID);
                    table.ForeignKey(
                        name: "FK_MERCHANT_TOKEN_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MERCHANT_TOKEN_MERCHANT_MERCHANT_ID",
                        column: x => x.MERCHANT_ID,
                        principalTable: "MERCHANT",
                        principalColumn: "MERCHANT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_USER_TRANSACTIONS",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<int>(nullable: false),
                    REFERENCE = table.Column<string>(maxLength: 20, nullable: false),
                    OLD_BALANCE = table.Column<decimal>(nullable: false),
                    BALANCE_CHANGE = table.Column<decimal>(nullable: false),
                    NEW_BALANCE = table.Column<decimal>(nullable: false),
                    ADMIN_USER_TRANSACTIONS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ADMIN_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_USER_TRANSACTIONS", x => x.ADMIN_USER_TRANSACTIONS_ID);
                    table.ForeignKey(
                        name: "FK_ADMIN_USER_TRANSACTIONS_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADMIN_USER_TRANSACTIONS_ADMIN_ADMIN_ID",
                        column: x => x.ADMIN_ID,
                        principalTable: "ADMIN",
                        principalColumn: "ADMIN_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADMIN_USER_TRANSACTIONS_USER_WALLET_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER_WALLET",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MERCHANT_USER_TRANSACTIONS",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<int>(nullable: false),
                    REFERENCE = table.Column<string>(maxLength: 20, nullable: false),
                    OLD_BALANCE = table.Column<decimal>(nullable: false),
                    BALANCE_CHANGE = table.Column<decimal>(nullable: false),
                    NEW_BALANCE = table.Column<decimal>(nullable: false),
                    MERCHANTUSERTRANSACTIONSID = table.Column<int>(name: "MERCHANT USER TRANSACTIONS ID", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MERCHANT_ID = table.Column<int>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCHANT_USER_TRANSACTIONS", x => x.MERCHANTUSERTRANSACTIONSID);
                    table.ForeignKey(
                        name: "FK_MERCHANT_USER_TRANSACTIONS_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MERCHANT_USER_TRANSACTIONS_MERCHANT_MERCHANT_ID",
                        column: x => x.MERCHANT_ID,
                        principalTable: "MERCHANT",
                        principalColumn: "MERCHANT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MERCHANT_USER_TRANSACTIONS_USER_WALLET_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER_WALLET",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTP_MANAGEMENT",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<int>(nullable: false),
                    OTP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OTP = table.Column<string>(maxLength: 10, nullable: false),
                    TYPE = table.Column<int>(nullable: false),
                    REFERENCE = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTP_MANAGEMENT", x => x.OTP_ID);
                    table.ForeignKey(
                        name: "FK_OTP_MANAGEMENT_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OTP_MANAGEMENT_TYPE_OTP_MANAGEMENT_TYPE",
                        column: x => x.TYPE,
                        principalTable: "TYPE_OTP_MANAGEMENT",
                        principalColumn: "TYPE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OTP_MANAGEMENT_USER_WALLET_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER_WALLET",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIN_MANAGEMENT",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    USER_ID = table.Column<int>(nullable: false),
                    PIN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PIN = table.Column<string>(maxLength: 10, nullable: false),
                    SALT = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIN_MANAGEMENT", x => x.PIN_ID);
                    table.ForeignKey(
                        name: "FK_PIN_MANAGEMENT_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PIN_MANAGEMENT_USER_WALLET_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER_WALLET",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_TOKEN",
                columns: table => new
                {
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CREATE_DATETIME = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ACTIVE_STATUS = table.Column<int>(nullable: false, defaultValue: 1),
                    TOKEN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    REFRESH_TOKEN = table.Column<string>(maxLength: 50, nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TOKEN", x => x.TOKEN_ID);
                    table.ForeignKey(
                        name: "FK_USER_TOKEN_ACTIVE_DESCRIPTION_ACTIVE_STATUS",
                        column: x => x.ACTIVE_STATUS,
                        principalTable: "ACTIVE_DESCRIPTION",
                        principalColumn: "ACTVIE_STATUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_TOKEN_USER_WALLET_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER_WALLET",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_ACTIVE_STATUS",
                table: "ADMIN",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_TOKEN_ACTIVE_STATUS",
                table: "ADMIN_TOKEN",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_TOKEN_ADMIN_ID",
                table: "ADMIN_TOKEN",
                column: "ADMIN_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_USER_TRANSACTIONS_ACTIVE_STATUS",
                table: "ADMIN_USER_TRANSACTIONS",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_USER_TRANSACTIONS_ADMIN_ID",
                table: "ADMIN_USER_TRANSACTIONS",
                column: "ADMIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADMIN_USER_TRANSACTIONS_USER_ID",
                table: "ADMIN_USER_TRANSACTIONS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GENDER_DESCRIPTION_ACTIVE_STATUS",
                table: "GENDER_DESCRIPTION",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_ACTIVE_STATUS",
                table: "MERCHANT",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_TOKEN_ACTIVE_STATUS",
                table: "MERCHANT_TOKEN",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_TOKEN_MERCHANT_ID",
                table: "MERCHANT_TOKEN",
                column: "MERCHANT_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_USER_TRANSACTIONS_ACTIVE_STATUS",
                table: "MERCHANT_USER_TRANSACTIONS",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_USER_TRANSACTIONS_MERCHANT_ID",
                table: "MERCHANT_USER_TRANSACTIONS",
                column: "MERCHANT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MERCHANT_USER_TRANSACTIONS_USER_ID",
                table: "MERCHANT_USER_TRANSACTIONS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_FOR_REGIS_ACTIVE_STATUS",
                table: "OTP_FOR_REGIS",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_MANAGEMENT_ACTIVE_STATUS",
                table: "OTP_MANAGEMENT",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_MANAGEMENT_TYPE",
                table: "OTP_MANAGEMENT",
                column: "TYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OTP_MANAGEMENT_USER_ID",
                table: "OTP_MANAGEMENT",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PIN_MANAGEMENT_ACTIVE_STATUS",
                table: "PIN_MANAGEMENT",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_PIN_MANAGEMENT_USER_ID",
                table: "PIN_MANAGEMENT",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TYPE_OTP_MANAGEMENT_ACTIVE_STATUS",
                table: "TYPE_OTP_MANAGEMENT",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TOKEN_ACTIVE_STATUS",
                table: "USER_TOKEN",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TOKEN_USER_ID",
                table: "USER_TOKEN",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_WALLET_ACTIVE_STATUS",
                table: "USER_WALLET",
                column: "ACTIVE_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_USER_WALLET_GENDER",
                table: "USER_WALLET",
                column: "GENDER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN_TOKEN");

            migrationBuilder.DropTable(
                name: "ADMIN_USER_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "MERCHANT_TOKEN");

            migrationBuilder.DropTable(
                name: "MERCHANT_USER_TRANSACTIONS");

            migrationBuilder.DropTable(
                name: "OTP_FOR_REGIS");

            migrationBuilder.DropTable(
                name: "OTP_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "PIN_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "USER_TOKEN");

            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "MERCHANT");

            migrationBuilder.DropTable(
                name: "TYPE_OTP_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "USER_WALLET");

            migrationBuilder.DropTable(
                name: "GENDER_DESCRIPTION");

            migrationBuilder.DropTable(
                name: "ACTIVE_DESCRIPTION");
        }
    }
}
