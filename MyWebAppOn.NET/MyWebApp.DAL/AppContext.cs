
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Entity;

namespace MyWebApp.DAL
{
    public class AppContext : DbContext
    {
        public DbSet<Disease> Picture { get; set; }
        public DbSet<Doctor> Owner { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Patient> Byer { get; set; }
        public DbSet<Street> Collection { get; set; }
        
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();   // создаем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=tcp:sharps.database.windows.net,1433;Initial Catalog=sharps;Persist Security Info=False;User ID=grisha;Password=g.89091259328;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
