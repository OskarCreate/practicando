using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace practicando.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=dpg-d0ntugemcj7s73dtjqcg-a.oregon-postgres.render.com;Database=api_4q4m;Username=api_4q4m_user;Password=gzCptGJGf0UCCLTWfgO1EbCW9gvsz5ql;Port=5432;SSL Mode=Require;Trust Server Certificate=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
