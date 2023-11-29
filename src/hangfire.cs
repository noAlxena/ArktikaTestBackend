using Microsoft.EntityFrameworkCore;

namespace arktiktest{
    
    /// <summary>
    /// Класс для ежедневного обновления цен
    /// </summary>
    class priceUpdater{
        DbMain db;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="db">база данных в которой будут обновлятся цены</param>
        public priceUpdater(DbMain db){
            this.db = db;
        }

        /// <summary>
        /// Функция обновления цен
        /// </summary>
        async public Task updatePrices(){
            var random = new Random();
            List<Material> list = await db.Materials.ToListAsync();
            foreach(var t in list)
                t.Price = Convert.ToDecimal(random.NextDouble())*100;
            await db.SaveChangesAsync();
        }
    }
    
}