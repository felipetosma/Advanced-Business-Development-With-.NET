using Microsoft.EntityFrameworkCore;

namespace TODOList.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        public DbSet<TODO> TODOs { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
    }
}
