using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(entity => entity.MerchantId);

            builder.ToTable("MERCHANT");

            builder.Property(entity => entity.MerchantId).HasColumnName("MERCHANT_ID");

            builder.Property(entity => entity.Partnership)
                .HasColumnName("PARTNERSHIP")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(entity => entity.MerchantAccountNo)
                .HasColumnName("MERCHANT_ACCOUNT_NO")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.MerchantName)
                .HasColumnName("MERCHANT_NAME")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(entity => entity.Username)
                .HasColumnName("USERNAME")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.Password)
                .HasColumnName("PASSWORD")
                .IsRequired()
                .HasMaxLength(20);

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
                .WithMany(entity => entity.Merchant)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
