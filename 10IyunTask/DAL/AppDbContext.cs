using _10IyunTask.Models;
using Microsoft.EntityFrameworkCore;

namespace _10IyunTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
    }   
}
