using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class OtpForRegisConfiguration : IEntityTypeConfiguration<OtpForRegis>
    {
        public void Configure(EntityTypeBuilder<OtpForRegis> builder)
        {
            builder.HasKey(entity => entity.OtpId);

            builder.ToTable("OTP_FOR_REGIS");

            builder.Property(entity => entity.OtpId).HasColumnName("OTP_ID");

            builder.Property(entity => entity.Otp)
                .HasColumnName("OTP")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(entity => entity.Email)
                .HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(entity => entity.Reference)
                .HasColumnName("REFERENCE")
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
                .WithMany(entity => entity.OtpForRegis)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
