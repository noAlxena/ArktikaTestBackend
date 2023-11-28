namespace arktiktest{
    public class DataObject{
        public int Id{get;set;}
    }
    public class Material:DataObject{
        public required string Name {get;set;}
        public required decimal Price {get;set;}
        public required int SellerId {get;set;}
    } 
    public class Seller:DataObject{
        public required string Name{get;set;}
    }
}