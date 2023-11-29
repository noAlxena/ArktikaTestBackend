using Microsoft.EntityFrameworkCore;

namespace arktiktest{

    /// <summary>
    /// Контест базы данных
    /// </summary>
    public class DbMain:DbContext{

        /// <summary>
        /// Набор материалов
        /// </summary>
        public DbSet<Material> Materials { get; set; } = null!;

        /// <summary>
        /// Набор продавцов
        /// </summary>
        public DbSet<Seller> Sellers { get; set; } = null!;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="options"><inheritdoc/></param>
        public DbMain(DbContextOptions<DbMain> options):base(options){
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }
    }

}