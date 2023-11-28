namespace arktiktest{
    public class MaterialRepository:DbRepository<Material,MaterialDTO>{
        public MaterialRepository(DbMain ctx):base(ctx,ctx.Materials){}
    }

}