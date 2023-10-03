using Microsoft.EntityFrameworkCore;

namespace crud_opreation_api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
