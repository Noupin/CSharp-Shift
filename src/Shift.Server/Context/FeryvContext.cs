using Microsoft.EntityFrameworkCore;
using Shift.Server.Models.SQL;

namespace Shift.Server.Context
{
    public class FeryvContext : DbContext
    {
        public DbSet<FeryvUserSQL> Users { get; set; }

        public FeryvContext(DbContextOptions<FeryvContext> feryvContext) : base(feryvContext)
        {
        }
    }
}