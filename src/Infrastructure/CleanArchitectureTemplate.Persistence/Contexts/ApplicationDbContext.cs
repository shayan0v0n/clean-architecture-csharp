using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistence.Contexts
{
    // when use class libarary you must install package Microsoft.EntityFrameworkCore.Design in main project 
    //add-migration 'migrationname'
    //update-database

    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        //const string connectionString = "Server=DARGAHI\\MSSQL2022;Database=Test;user Id= sa;password=@Md912161009;Integrated Security=true;Initial Catalog=Test;TrustServerCertificate=true";
        const string connectionString = "Server=localhost;Database=Test;user id= sa;password=912161009;Integrated Security=true;trusted_connection=true;TrustServerCertificate=true;";


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(9,0)");
            }
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


}
