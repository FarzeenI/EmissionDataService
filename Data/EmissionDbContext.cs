using EmissionDataRecordService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
    
namespace EmissionDataRecordService.Data
{
    public class EmissionDbContext : DbContext
    {
        public EmissionDbContext(DbContextOptions<EmissionDbContext> options) : base(options)
        {
        }

        public DbSet<EmissionDataRecord> EmissionDataRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmissionDataRecord>()
                 .HasKey(e => new { e.Material_Number, e.Iso_Country_Code });
                 // Composite Key
        }
    }
}
