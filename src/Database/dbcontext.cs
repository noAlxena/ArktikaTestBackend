using Microsoft.EntityFrameworkCore;

namespace arktiktest{
    public class DbMain:DbContext{
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbMain(DbContextOptions<DbMain> options):base(options){
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }
    }

}