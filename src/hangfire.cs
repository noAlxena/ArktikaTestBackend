using Microsoft.EntityFrameworkCore;

namespace arktiktest{
    
    class priceUpdater{
        DbMain _dbl;
        public priceUpdater(DbMain db){
            _dbl = db;
        }
        async public Task updatePrices(){
            var random = new Random();
            List<Material> list = await _dbl.Materials.ToListAsync();
            foreach(var t in list)
                t.Price = Convert.ToDecimal(random.NextDouble())*100;
            await _dbl.SaveChangesAsync();
        }
    }
    
}