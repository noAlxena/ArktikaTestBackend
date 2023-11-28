using Microsoft.EntityFrameworkCore;
namespace arktiktest{
    public class DbRepository<TObject,DTObject> where TObject : DataObject where DTObject : IDataTransferObject<TObject>{
        protected DbMain _ctx;
        protected DbSet<TObject> _set;
        public DbRepository(DbMain ctx, DbSet<TObject> set){
            _set = set;
            _ctx = ctx;
        }
        public virtual async Task<List<TObject>> GetAll(){
            return await _set.ToListAsync();
        }
        public virtual async Task<TObject?> GetOne(int id){
            return await _set.FindAsync(id);
        }
        public virtual async Task<TObject?> Post(DTObject obj){
            TObject req = obj.Create();
            await _set.AddAsync(req);
            await _ctx.SaveChangesAsync();
            return req;
        }
        public virtual async Task<TObject?> Put(int id,DTObject obj){
            TObject? req = await _set.FindAsync(id);
            if(req == null)
                return null;
            obj.Fill(req);
            _ctx.SaveChanges();
            return req;
        }
        public virtual async Task<TObject?> Delete(int id){
            TObject? req = await _set.FindAsync(id);
            if(req == null)
                return null;
            _set.Remove(req);
            await _ctx.SaveChangesAsync();
            return req;
        }
    };

}