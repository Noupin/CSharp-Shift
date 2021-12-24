using Microsoft.EntityFrameworkCore;

namespace Shift.Server.Models.SQL
{
    public class ShiftContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShiftCategory> ShiftCategories { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }
}