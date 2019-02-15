using Microsoft.EntityFrameworkCore;

namespace Wims.Data
{
    public class MigrationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\wimsDev;Database=Wims-Migration;Trusted_Connection=True;");
        }
    }
}
