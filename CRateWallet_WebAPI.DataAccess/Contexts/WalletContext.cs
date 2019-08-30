using CRateWallet_WebAPI.DataAccess.Configurations;
using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Contexts
{
    public class WalletContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=TestWallet;trusted_connection=true;");
        }

        public DbSet<User> User { get; set; }
        public DbSet<GenderDescription> GenderDescription { get; set; }
        public DbSet<ActiveDescription> ActiveDescription { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<MerchantUserTransactions> MerchantUserTransactions { get; set; }
        public DbSet<AdminUserTransactions> AdminUserTransactions { get; set; }
        public DbSet<OtpManagement> OtpManagement { get; set; }
        public DbSet<PinManagement> PinManagement { get; set; }
        public DbSet<TypeOtpManagement> TypeOtpManagement { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<AdminToken> AdminToken { get; set; }
        public DbSet<MerchantToken> MerchantToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GenderDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ActiveDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantUserTransactionsConfiguration());
            modelBuilder.ApplyConfiguration(new AdminUserTransactionsConfiguration());
            modelBuilder.ApplyConfiguration(new OtpManagementConfiguration());
            modelBuilder.ApplyConfiguration(new PinManagementConfiguration());
            modelBuilder.ApplyConfiguration(new TypeOtpManagementConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTokenConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantTokenConfiguration());
        }
    }
}
