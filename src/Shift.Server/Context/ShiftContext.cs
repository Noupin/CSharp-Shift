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
        public DbSet<InferenceWorkerSQL> InferenceWorkers { get; set; }
        public DbSet<TrainWorkerSQL> TrainWorkers { get; set; }

        public ShiftContext(DbContextOptions<ShiftContext> shiftContext) : base(shiftContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategorySQL>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}