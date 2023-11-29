using Microsoft.EntityFrameworkCore;
namespace arktiktest{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    /// <typeparam name="DTObject">тип объекта передачи данных</typeparam>
    public abstract class DbRepository<TObject,DTObject> where TObject : DataObject where DTObject : IDataTransferObject<TObject>{

        /// <summary>
        /// Контекст базы данных 
        /// </summary>
        protected DbMain ctx;

        /// <summary>
        /// Набор изменяемых объектов
        /// </summary>
        protected DbSet<TObject> set;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="ctx">Контекст базы данных </param>
        /// <param name="set">Набор изменяемых объектов</param>
        public DbRepository(DbMain ctx, DbSet<TObject> set){
            this.set = set;
            this.ctx = ctx;
        }

        /// <summary>
        /// Получение списка объектов
        /// </summary>
        /// <returns>Список полученных объектов</returns>
        public virtual async Task<List<TObject>> GetAll(){
            return await set.ToListAsync();
        }

        /// <summary>
        /// Получение одного объекта
        /// </summary>
        /// <param name="id">Id запрашиваемого объекта</param>
        /// <returns>Получаемый объект или null</returns>
        public virtual async Task<TObject?> GetOne(int id){
            return await set.FindAsync(id);
        }

        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <param name="obj">Добавляемый объект</param>
        /// <returns>добавленный объект или null</returns>
        public virtual async Task<TObject?> Post(DTObject obj){
            TObject req = obj.Create();
            await set.AddAsync(req);
            await ctx.SaveChangesAsync();
            return req;
        }

        /// <summary>
        /// Изменение объекта
        /// </summary>
        /// <param name="id">Id изменяемого объекта</param>
        /// <param name="obj">Новые данные объекта</param>
        /// <returns>Имзменённый объект или null</returns>
        public virtual async Task<TObject?> Put(int id,DTObject obj){
            TObject? req = await set.FindAsync(id);
            if(req == null)
                return null;
            obj.Fill(req);
            ctx.SaveChanges();
            return req;
        }

        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        /// <returns>Удаленный объект или null</returns>
        public virtual async Task<TObject?> Delete(int id){
            TObject? req = await set.FindAsync(id);
            if(req == null)
                return null;
            set.Remove(req);
            await ctx.SaveChangesAsync();
            return req;
        }
    };

}