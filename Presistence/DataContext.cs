using Domain;
using Microsoft.EntityFrameworkCore;

namespace Presistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

    }
}