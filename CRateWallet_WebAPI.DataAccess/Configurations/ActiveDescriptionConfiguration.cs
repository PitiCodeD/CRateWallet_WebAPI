using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class ActiveDescriptionConfiguration : IEntityTypeConfiguration<ActiveDescription>
    {
        public void Configure(EntityTypeBuilder<ActiveDescription> builder)
        {
            builder.HasKey(entity => entity.ActvieStatus);

            builder.ToTable("ACTIVE_DESCRIPTION");

            builder.Property(entity => entity.ActvieStatus).HasColumnName("ACTVIE_STATUS");

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
        }
    }
}
