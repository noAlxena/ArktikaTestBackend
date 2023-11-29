namespace arktiktest{
    /// <summary>
    /// Репозиторий для хранения продавцов
    /// </summary>
    public class MaterialRepository:DbRepository<Material,MaterialDTO>{

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public MaterialRepository(DbMain ctx):base(ctx,ctx.Materials){}
    }

}