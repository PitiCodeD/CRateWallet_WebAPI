using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class PinManagementConfiguration : IEntityTypeConfiguration<PinManagement>
    {
        public void Configure(EntityTypeBuilder<PinManagement> builder)
        {
            builder.HasKey(entity => entity.PinId);

            builder.ToTable("PIN_MANAGEMENT");

            builder.Property(entity => entity.PinId).HasColumnName("PIN_ID");

            builder.Property(entity => entity.Pin)
                .HasColumnName("PIN")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(entity => entity.Salt)
                .HasColumnName("SALT")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.UserId).HasColumnName("USER_ID");

            builder.HasOne(entity => entity.User)
                .WithOne(entity => entity.PinManagement)
                .HasForeignKey<PinManagement>(entity => entity.UserId);

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
                .WithMany(entity => entity.PinManagement)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
