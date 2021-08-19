using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using VisitorRegistration.Domain.Models;

namespace VisitorRegistration.DataAccess
{
    public class VisitorRegistrationDbContext : DbContext
    {
        #region DbSets
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("VisitorRegistration"));
        }
    }
}
