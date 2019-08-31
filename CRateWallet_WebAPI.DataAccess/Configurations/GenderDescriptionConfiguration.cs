using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class GenderDescriptionConfiguration : IEntityTypeConfiguration<GenderDescription>
    {
        public void Configure(EntityTypeBuilder<GenderDescription> builder)
        {
            builder.HasKey(entity => entity.Gender);

            builder.ToTable("GENDER_DESCRIPTION");

            builder.Property(entity => entity.Gender).HasColumnName("GENDER");

            builder.Property(entity => entity.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(100);

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
                .WithMany(entity => entity.GenderDescription)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
