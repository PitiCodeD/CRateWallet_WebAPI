﻿// <auto-generated />
using System;
using CRateWallet_WebAPI.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRateWallet_WebAPI.DataAccess.Migrations
{
    [DbContext(typeof(WalletContext))]
    [Migration("20190831013726_TestEWalletV02")]
    partial class TestEWalletV02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", b =>
                {
                    b.Property<int>("ActvieStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTVIE_STATUS")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("ActvieStatus");

                    b.ToTable("ACTIVE_DESCRIPTION");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ADMIN_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<string>("AdminAccountNo")
                        .IsRequired()
                        .HasColumnName("ADMIN_ACCOUNT_NO")
                        .HasMaxLength(20);

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnName("ADMIN_NAME")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("USERNAME")
                        .HasMaxLength(20);

                    b.HasKey("AdminId");

                    b.HasIndex("ActiveStatus");

                    b.ToTable("ADMIN");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.AdminToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TOKEN_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<int>("AdminId")
                        .HasColumnName("ADMIN_ID");

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("TokenId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.ToTable("ADMIN_TOKEN");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.AdminUserTransactions", b =>
                {
                    b.Property<int>("AdminUserTransactionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ADMIN_USER_TRANSACTIONS_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<int>("AdminId")
                        .HasColumnName("ADMIN_ID");

                    b.Property<decimal>("BalanceChange")
                        .HasColumnName("BALANCE_CHANGE");

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<decimal>("NewBalance")
                        .HasColumnName("NEW_BALANCE");

                    b.Property<decimal>("OldBalance")
                        .HasColumnName("OLD_BALANCE");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnName("REFERENCE")
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("AdminUserTransactionsId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("ADMIN_USER_TRANSACTIONS");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.GenderDescription", b =>
                {
                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GENDER")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Gender");

                    b.HasIndex("ActiveStatus");

                    b.ToTable("GENDER_DESCRIPTION");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.Merchant", b =>
                {
                    b.Property<int>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MERCHANT_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("MerchantAccountNo")
                        .IsRequired()
                        .HasColumnName("MERCHANT_ACCOUNT_NO")
                        .HasMaxLength(20);

                    b.Property<string>("MerchantName")
                        .IsRequired()
                        .HasColumnName("MERCHANT_NAME")
                        .HasMaxLength(50);

                    b.Property<string>("Partnership")
                        .IsRequired()
                        .HasColumnName("PARTNERSHIP")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("USERNAME")
                        .HasMaxLength(20);

                    b.HasKey("MerchantId");

                    b.HasIndex("ActiveStatus");

                    b.ToTable("MERCHANT");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.MerchantToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TOKEN_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("MerchantId")
                        .HasColumnName("MERCHANT_ID");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("TokenId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("MerchantId")
                        .IsUnique();

                    b.ToTable("MERCHANT_TOKEN");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.MerchantUserTransactions", b =>
                {
                    b.Property<int>("MerchantUserTransactionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MERCHANT USER TRANSACTIONS ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<decimal>("BalanceChange")
                        .HasColumnName("BALANCE_CHANGE");

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("MerchantId")
                        .HasColumnName("MERCHANT_ID");

                    b.Property<int>("MyProperty");

                    b.Property<decimal>("NewBalance")
                        .HasColumnName("NEW_BALANCE");

                    b.Property<decimal>("OldBalance")
                        .HasColumnName("OLD_BALANCE");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnName("REFERENCE")
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("MerchantUserTransactionsId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("MerchantId");

                    b.HasIndex("UserId");

                    b.ToTable("MERCHANT_USER_TRANSACTIONS");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.OtpManagement", b =>
                {
                    b.Property<int>("OtpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OTP_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasColumnName("OTP")
                        .HasMaxLength(10);

                    b.Property<int>("Type")
                        .HasColumnName("TYPE");

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("OtpId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("OTP_MANAGEMENT");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.PinManagement", b =>
                {
                    b.Property<int>("PinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PIN_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnName("PIN")
                        .HasMaxLength(10);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnName("SALT")
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("PinId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PIN_MANAGEMENT");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.TypeOtpManagement", b =>
                {
                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TYPE")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Type");

                    b.HasIndex("ActiveStatus");

                    b.ToTable("TYPE_OTP_MANAGEMENT");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnName("ACCOUNT_NO")
                        .HasMaxLength(20);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<decimal>("Balance")
                        .HasColumnName("BALANCE");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnName("BIRTH_DATE")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnName("GENDER");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnName("MOBILE_NO")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("SURNAME")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("UserId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("Gender");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.UserToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TOKEN_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ACTIVE_STATUS")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDatetime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CREATE_DATETIME")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateDatetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdateTime")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("TokenId");

                    b.HasIndex("ActiveStatus");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("USER_TOKEN");
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.Admin", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("Admin")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.AdminToken", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("AdminToken")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.Admin", "Admin")
                        .WithOne("AdminToken")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.AdminToken", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.AdminUserTransactions", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("AdminUserTransactions")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.Admin", "Admin")
                        .WithMany("AdminUserTransactions")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.User", "User")
                        .WithMany("AdminUserTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.GenderDescription", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("GenderDescription")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.Merchant", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("Merchant")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.MerchantToken", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("MerchantToken")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.Merchant", "Merchant")
                        .WithOne("MerchantToken")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.MerchantToken", "MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.MerchantUserTransactions", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("MerchantUserTransactions")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.Merchant", "Merchant")
                        .WithMany("MerchantUserTransactions")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.User", "User")
                        .WithMany("MerchantUserTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.OtpManagement", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("OtpManagement")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.TypeOtpManagement", "TypeOtpManagement")
                        .WithOne("OtpManagement")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.OtpManagement", "Type")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.User", "User")
                        .WithOne("OtpManagement")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.OtpManagement", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.PinManagement", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("PinManagement")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.User", "User")
                        .WithOne("PinManagement")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.PinManagement", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.TypeOtpManagement", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("TypeOtpManagement")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.User", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("User")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.GenderDescription", "GenderDescription")
                        .WithMany("User")
                        .HasForeignKey("Gender")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CRateWallet_WebAPI.DataAccess.Models.UserToken", b =>
                {
                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.ActiveDescription", "ActiveDescription")
                        .WithMany("UserToken")
                        .HasForeignKey("ActiveStatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRateWallet_WebAPI.DataAccess.Models.User", "User")
                        .WithOne("UserToken")
                        .HasForeignKey("CRateWallet_WebAPI.DataAccess.Models.UserToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
