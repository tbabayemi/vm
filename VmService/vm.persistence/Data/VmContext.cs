using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vm.persistence.Entities;

namespace vm.persistence.Data
{
    public class VmContext: DbContext
    {
        public DbSet<ProfileMetadata> ProfileMetadatas { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        private string _connectionStr { get; set; }

        public VmContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var localAppSettingPath = AppDomain.CurrentDomain.BaseDirectory.Replace("vm.persistence", "vm.services");
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(localAppSettingPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(Constant.ConnectionStringName));
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasOne(metadata => metadata.Metadata).WithOne(profile => profile.Profile);
        }
    }
}
