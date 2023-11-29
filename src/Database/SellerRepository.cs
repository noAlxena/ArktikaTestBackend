namespace arktiktest{
    /// <summary>
    /// Репозиторий для хранения продавцов
    /// </summary>
    public class SellerRepository:DbRepository<Seller,SellerDTO>{
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="ctx">контекст базы данных</param>
        public SellerRepository(DbMain ctx):base(ctx,ctx.Sellers){}

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public override async Task<Seller?> Delete(int id){
            Seller? req = await set.FindAsync(id);
            if(req == null)
                return null;
            var b = ctx.Materials.Where(x=>x.SellerId==id);
            ctx.Materials.RemoveRange(b);
            set.Remove(req);
            await ctx.SaveChangesAsync();
            return req;
        }
    }
}