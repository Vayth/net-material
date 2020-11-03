using LeaveRequest.Domain.Employees;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveRequest.Infrastructure.Data
{
    public class LeaveRequestDbContext : IdentityDbContext
    {
        public LeaveRequestDbContext(DbContextOptions<LeaveRequestDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().OwnsOne(p => p.Name);
            modelBuilder.Entity<Employee>().OwnsOne(p => p.Address);
            modelBuilder.Entity<Employee>().Property("CreatedBy").HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property("LastModifiedBy").HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property("CreatedTime").HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Employee>().Property("IsDeleted").HasDefaultValueSql("0");
        }
    }
}
