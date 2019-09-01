using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class TypeOtpManagementConfiguration : IEntityTypeConfiguration<TypeOtpManagement>
    {
        public void Configure(EntityTypeBuilder<TypeOtpManagement> builder)
        {
            builder.HasKey(entity => entity.Type);

            builder.ToTable("TYPE_OTP_MANAGEMENT");

            builder.Property(entity => entity.Type).HasColumnName("TYPE");

            builder.Property(entity => entity.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired()
                .HasMaxLength(100);

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
                .WithMany(entity => entity.TypeOtpManagement)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
