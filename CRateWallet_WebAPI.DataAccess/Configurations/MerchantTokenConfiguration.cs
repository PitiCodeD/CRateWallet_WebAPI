﻿using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class MerchantTokenConfiguration : IEntityTypeConfiguration<MerchantToken>
    {
        public void Configure(EntityTypeBuilder<MerchantToken> builder)
        {
            builder.HasKey(entity => entity.TokenId);

            builder.ToTable("MERCHANT_TOKEN");

            builder.Property(entity => entity.TokenId).HasColumnName("TOKEN_ID");

            builder.Property(entity => entity.RefreshToken)
                .HasColumnName("REFRESH_TOKEN")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(entity => entity.CreateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATETIME");

            builder.Property(entity => entity.UpdateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATETIME");

            builder.Property(entity => entity.ActiveStatus)
                .HasDefaultValue(1)
                .HasColumnName("ACTIVE_STATUS");

            builder.HasOne(entity => entity.ActiveDescription)
                .WithMany(entity => entity.MerchantToken)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);

            builder.Property(entity => entity.MerchantId).HasColumnName("MERCHANT_ID");

            builder.HasOne(entity => entity.Merchant)
                .WithOne(entity => entity.MerchantToken)
                .HasForeignKey<MerchantToken>(entity => entity.MerchantId);
        }
    }
}
