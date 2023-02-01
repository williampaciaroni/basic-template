
using Bsctmplt.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bsctmplt.EntityFrameworkCore
{
    public class BsctmpltDbContext : DbContext
    {
        public BsctmpltDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
  
            optionsBuilder
                .UseSqlServer(BsctmpltDbContextFactory.GetConfiguration().GetConnectionString("DefaultConnection")
                );
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Sample
            modelBuilder.Entity<Sample>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();

                e.HasIndex(x => x.Value).IsUnique();
            });
            #endregion
            base.OnModelCreating(modelBuilder);

        }



    }
}
