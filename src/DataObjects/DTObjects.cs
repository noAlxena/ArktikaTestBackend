using System.ComponentModel.DataAnnotations;
namespace arktiktest{
    /// <summary>
    /// Интерфейс для создания DTO
    /// </summary>
    /// <typeparam name="TObject">Объект данных</typeparam>
    public interface IDataTransferObject<TObject> where TObject:DataObject{
        /// <summary>
        /// Занести данные в объект данных
        /// </summary>
        /// <param name="dao">Объект данных который заполняется</param>
        void Fill(TObject dao);
        /// <summary>
        /// Создать новый объект данных
        /// </summary>
        /// <returns>Объект данных</returns>
        TObject Create();
    }
    /// <summary>
    /// Данные материала
    /// </summary>
    public class MaterialDTO:IDataTransferObject<Material>{
        /// <summary>
        /// название материала
        /// </summary>
        [Required]
        public required string Name {get;set;}
        /// <summary>
        /// цена материала
        /// </summary>
        [Required]
        public required decimal Price {get;set;}
        /// <summary>
        /// id продовца
        /// </summary>
        [Required]
        public required int SellerId {get;set;}
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dao"><inheritdoc/></param>
        public void Fill(Material dao){
            Material? from = dao;
            if(from!=null){
                from.Name = Name;
                from.Price = Price;
                from.SellerId = SellerId;
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public Material Create(){
            return new Material(){Id = 0,Name=this.Name,Price = this.Price,SellerId = this.SellerId};
        }
        /// <summary>
        /// Преревод в строку
        /// </summary>
        /// <returns>строка объекта</returns>
        public override string ToString()
        {
            return $"MaterialDTO Name={Name} Price={Price} SellerId={SellerId}";
        }
    }
    /// <summary>
    /// Данные продовца
    /// </summary>
    public class SellerDTO:IDataTransferObject<Seller>{
        /// <summary>
        /// имя продовца
        /// </summary>
        [Required]
        public required string Name {get;set;}
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dao"><inheritdoc/></param>
        public void Fill(Seller dao){
            Seller? from = dao;
            if(from!=null){
                from.Name = Name;
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public Seller Create(){
            return new Seller(){Id=0,Name=Name};
        }
        /// <summary>
        /// Преревод в строку
        /// </summary>
        /// <returns>строка объекта</returns>
        public override string ToString()
        {
            return $"SellerDTO Name={Name}";
        }
    }
}