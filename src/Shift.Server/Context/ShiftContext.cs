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
            //Category
            builder.Entity<CategorySQL>()
                .HasIndex(u => u.Name)
                .IsUnique();

            //Inference Worker
            builder.Entity<InferenceWorkerSQL>()
                .HasIndex(u => u.ShiftId)
                .IsUnique();

            //Shift
            builder.Entity<ShiftSQL>()
                .HasIndex(u => u.Title)
                .IsUnique();

            //Shift Category
            builder.Entity<ShiftCategorySQL>()
                .HasKey(u => new { u.CategoryName, u.ShiftId });
            builder.Entity<ShiftCategorySQL>()
                .HasOne(pt => pt.Shift)
                .WithMany(p => p.ShiftCategories)
                .HasForeignKey(c => c.ShiftId);
            builder.Entity<ShiftCategorySQL>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.ShiftCategories)
                .HasForeignKey(c => c.CategoryName);

            //Train Worker
            builder.Entity<InferenceWorkerSQL>()
                .HasIndex(u => u.ShiftId)
                .IsUnique();

            //User
            builder.Entity<UserSQL>()
                .Property(u => u.Id)
                .ValueGeneratedNever();
        }
    }
}