using Microsoft.EntityFrameworkCore;
using Shift.Server.Models.SQL;

namespace Shift.Server.Context
{
    public class ShiftContext : DbContext
    {
        public DbSet<CategorySQL> Categories { get; set; }
        public DbSet<ShiftCategorySQL> ShiftCategories { get; set; }
        public DbSet<ShiftSQL> Shifts { get; set; }
        public DbSet<UserSQL> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }
}