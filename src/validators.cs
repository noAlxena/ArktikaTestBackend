using FluentValidation;
namespace arktiktest{

    public class SellerValidator : AbstractValidator<SellerDTO>{
        public SellerValidator(){
            RuleFor(x=>x.Name).NotEmpty();
        }
    }

    public class MaterialValidator : AbstractValidator<MaterialDTO>{
        public MaterialValidator(DbMain db){
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Price).GreaterThan(0);
            RuleFor(x=>x.SellerId).Must(x => null != db.Sellers.Find(x));
        }
    }
}