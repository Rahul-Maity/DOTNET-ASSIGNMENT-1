using DOTNET_ASSIGNMENT_1.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_ASSIGNMENT_1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Item>Items { get; set; }
    }
}
