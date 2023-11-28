namespace arktiktest{
    public class SellerRepository:DbRepository<Seller,SellerDTO>{
        public SellerRepository(DbMain ctx):base(ctx,ctx.Sellers){}
        public override async Task<Seller?> Delete(int id){
            Seller? req = await _set.FindAsync(id);
            if(req == null)
                return null;
            var b = _ctx.Materials.Where(x=>x.SellerId==id);
            _ctx.Materials.RemoveRange(b);
            _set.Remove(req);
            await _ctx.SaveChangesAsync();
            return req;
        }
    }
}