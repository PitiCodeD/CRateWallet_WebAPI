using CRateWallet_WebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(entity => entity.UserId);

            builder.ToTable("USER");

            builder.Property(entity => entity.UserId).HasColumnName("USER_ID");

            builder.Property(entity => entity.Email)
                .HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(entity => entity.AccountNo)
                .HasColumnName("ACCOUNT_NO")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(entity => entity.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50);

            builder.Property(entity => entity.Surname)
                .HasColumnName("SURNAME")
                .HasMaxLength(50);

            builder.Property(entity => entity.BirthDate)
                .HasColumnName("BIRTH_DATE")
                .HasColumnType("datetime");

            builder.Property(entity => entity.MobileNo)
                .HasColumnName("MOBILE_NO")
                .HasMaxLength(20);

            builder.Property(entity => entity.Gender).HasColumnName("GENDER");

            builder.HasOne(entity => entity.GenderDescription)
                .WithMany(entity => entity.User)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.Gender);

            builder.Property(entity => entity.Balance).HasColumnName("BALANCE");

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
                .WithMany(entity => entity.User)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(entity => entity.ActiveStatus);
        }
    }
}
