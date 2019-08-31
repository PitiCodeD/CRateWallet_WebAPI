using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class MerchantUserTransactionsConfiguration : IEntityTypeConfiguration<MerchantUserTransactions>
    {
        public void Configure(EntityTypeBuilder<MerchantUserTransactions> builder)
        {
            builder.HasKey(entity => entity.MerchantUserTransactionsId);

            builder.ToTable("MERCHANT_USER_TRANSACTIONS");

            builder.Property(entity => entity.MerchantUserTransactionsId).HasColumnName("MERCHANT USER TRANSACTIONS ID");

            builder.Property(entity => entity.MerchantId).HasColumnName("MERCHANT_ID");

            builder.HasOne(entity => entity.Merchant)
                .WithMany(entity => entity.MerchantUserTransactions)
                .HasForeignKey(entity => entity.MerchantId);


            builder.Property(entity => entity.Reference)
                .HasColumnName("REFERENCE")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.OldBalance).HasColumnName("OLD_BALANCE");

            builder.Property(entity => entity.BalanceChange).HasColumnName("BALANCE_CHANGE");

            builder.Property(entity => entity.NewBalance).HasColumnName("NEW_BALANCE");

            builder.Property(entity => entity.UserId).HasColumnName("USER_ID");

            builder.HasOne(entity => entity.User)
                .WithMany(entity => entity.MerchantUserTransactions)
                .HasForeignKey(entity => entity.UserId);

            builder.Property(entity => entity.CreateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATETIME");

            builder.Property(entity => entity.UpdateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("UpdateTime");

            builder.Property(entity => entity.ActiveStatus)
                .HasDefaultValue(1)
                .HasColumnName("ACTIVE_STATUS");

            builder.HasOne(entity => entity.ActiveDescription)
                .WithMany(entity => entity.MerchantUserTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
