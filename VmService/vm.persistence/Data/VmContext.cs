using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using vm.persistence.Entities;

namespace vm.persistence.Data
{
    public class VmContext: DbContext
    {
        public DbSet<VmMetadata> VmMedata { get; set; }
        public DbSet<Profile> Profile { get; set; }
        private string _connectionStr { get; set; }

        public VmContext(DbContextOptions<VmContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
