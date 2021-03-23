using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace UserManagementApplication.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        { 
        }

        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserIdx).HasName("users_pkey");
                entity.ToTable("users");

                entity.Property(e => e.UserIdx).HasColumnName("useridx").UseIdentityAlwaysColumn();
                entity.Property(e => e.UserName).IsRequired().HasColumnName("username").HasMaxLength(50);
                entity.Property(e => e.UserId).IsRequired().HasColumnName("userid").HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasColumnName("password").HasMaxLength(256);
                entity.Property(e => e.NickName).IsRequired().HasColumnName("nickname").HasMaxLength(100);
                entity.Property(e => e.PublicYn).IsRequired().HasColumnName("publicyn");
                entity.Property(e => e.ModifyDate).IsRequired().HasColumnName("modifydate").HasColumnType("timestamp with time zone");
                entity.Property(e => e.RegistDate).IsRequired().HasColumnName("registdate").HasColumnType("timestamp with time zone");
            });
        }
    }
}
