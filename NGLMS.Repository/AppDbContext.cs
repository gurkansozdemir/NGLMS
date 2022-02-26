using Microsoft.EntityFrameworkCore;
using NGLMS.Core.Models;

namespace NGLMS.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
