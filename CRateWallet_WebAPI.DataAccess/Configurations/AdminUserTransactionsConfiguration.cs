using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class AdminUserTransactionsConfiguration : IEntityTypeConfiguration<AdminUserTransactions>
    {
        public void Configure(EntityTypeBuilder<AdminUserTransactions> builder)
        {
            builder.HasKey(entity => entity.AdminUserTransactionsId);

            builder.ToTable("ADMIN_USER_TRANSACTIONS");

            builder.Property(entity => entity.AdminUserTransactionsId).HasColumnName("ADMIN_USER_TRANSACTIONS_ID");

            builder.Property(entity => entity.AdminId).HasColumnName("ADMIN_ID");

            builder.HasOne(entity => entity.Admin)
                .WithMany(entity => entity.AdminUserTransactions)
                .HasForeignKey(entity => entity.AdminId);

            builder.Property(entity => entity.Reference)
                .HasColumnName("REFERENCE")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.OldBalance).HasColumnName("OLD_BALANCE");

            builder.Property(entity => entity.BalanceChange).HasColumnName("BALANCE_CHANGE");

            builder.Property(entity => entity.NewBalance).HasColumnName("NEW_BALANCE");

            builder.Property(entity => entity.UserId).HasColumnName("USER_ID");

            builder.HasOne(entity => entity.User)
                .WithMany(entity => entity.AdminUserTransactions)
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
                .WithOne(entity => entity.AdminUserTransactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<AdminUserTransactions>(entity => entity.ActiveStatus);
        }
    }
}
