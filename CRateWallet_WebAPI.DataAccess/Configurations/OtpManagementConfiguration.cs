using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class OtpManagementConfiguration : IEntityTypeConfiguration<OtpManagement>
    {
        public void Configure(EntityTypeBuilder<OtpManagement> builder)
        {
            builder.HasKey(entity => entity.OtpId);

            builder.ToTable("OTP_MANAGEMENT");

            builder.Property(entity => entity.OtpId).HasColumnName("OTP_ID");

            builder.Property(entity => entity.Otp)
                .HasColumnName("OTP")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(entity => entity.Type)
                .HasColumnName("TYPE")
                .HasDefaultValue(1);

            builder.HasOne(entity => entity.TypeOtpManagement)
                .WithMany(entity => entity.OtpManagement)
                .HasForeignKey(entity => entity.Type);

            builder.Property(entity => entity.Reference)
                .HasColumnName("REFERENCE")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.UserId).HasColumnName("USER_ID");

            builder.HasOne(entity => entity.User)
                .WithOne(entity => entity.OtpManagement)
                .HasForeignKey<OtpManagement>(entity => entity.UserId);

            builder.Property(entity => entity.CreateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("CREATE_DATETIME");

            builder.Property(entity => entity.UpdateDatetime)
                .HasDefaultValueSql("GETUTCDATE()")
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATETIME");

            builder.Property(entity => entity.ActiveStatus)
                .HasDefaultValue(2)
                .HasColumnName("ACTIVE_STATUS");

            builder.HasOne(entity => entity.ActiveDescription)
                .WithMany(entity => entity.OtpManagement)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
