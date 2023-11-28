namespace arktiktest{
    /// <summary>
    /// Объект базы данных
    /// </summary>
    public class DataObject{
        /// <summary>
        /// Id базы данных
        /// </summary>
        public int Id{get;set;}
    }
    /// <summary>
    /// Материал
    /// </summary>
    public class Material:DataObject{
        /// <summary>
        /// Название материала
        /// </summary>
        public required string Name {get;set;}
        /// <summary>
        /// Цена материала
        /// </summary>
        public required decimal Price {get;set;}
        /// <summary>
        /// Id продовца
        /// </summary>
        public required int SellerId {get;set;}
    }
    /// <summary>
    /// Продавец
    /// </summary>
    public class Seller:DataObject{
        /// <summary>
        /// Имя продовца
        /// </summary>
        public required string Name{get;set;}
    }
}