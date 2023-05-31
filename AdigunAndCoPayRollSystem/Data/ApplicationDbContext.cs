using AdigunAndCoPayRollSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdigunAndCoPayRollSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        public DbSet<Position> Position { get; set; }
        public DbSet<PayrollStructure>PayrollStructure { get; set; }
        public DbSet<PayrollComponent> PayrollComponent { get; set; }
        public DbSet<CadreLevel> CadreLevel { get; set; }
        public DbSet<Employee> Employee { get; set; }
        
    }
}
