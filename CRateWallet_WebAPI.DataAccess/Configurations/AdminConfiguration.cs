using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(entity => entity.AdminId);

            builder.ToTable("ADMIN");

            builder.Property(entity => entity.AdminId).HasColumnName("ADMIN_ID");

            builder.Property(entity => entity.AdminAccountNo)
                .HasColumnName("ADMIN_ACCOUNT_NO")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.AdminName)
                .HasColumnName("ADMIN_NAME")
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
                .WithMany(entity => entity.Admin)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
