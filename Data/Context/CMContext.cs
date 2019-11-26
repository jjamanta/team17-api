using Microsoft.EntityFrameworkCore;
using Team17.Domain.Entities;

namespace Team17.Data.Context
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions options)
        : base(options)
        {
            Database.AutoTransactionsEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FileEntity>().ToTable("File");

            /*
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<User>().ToTable("User");
            */
        }


    }
}
