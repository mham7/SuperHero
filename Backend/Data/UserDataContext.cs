global using Microsoft.EntityFrameworkCore;
namespace Backend.Data
{
    public class UserDataContext :DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options):base(options) { }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= .\\SQLEXPRESS;Database=superherodb;Trusted_Connection=true;MultipleActiveResultSets=True; TrustServerCertificate=true; ");
        }

        public DbSet<User> Users { get; set; }
    }
}
