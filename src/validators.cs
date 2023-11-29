using FluentValidation;
namespace arktiktest{

    /// <summary>
    /// Класс для валидации продавцов
    /// </summary>
    public class SellerValidator : AbstractValidator<SellerDTO>{

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public SellerValidator(){
            RuleFor(x=>x.Name).NotEmpty();
        }
    }

    /// <summary>
    /// Класс для валидации материалов
    /// </summary>
    public class MaterialValidator : AbstractValidator<MaterialDTO>{

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public MaterialValidator(DbMain db){
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Price).GreaterThan(0);
            RuleFor(x=>x.SellerId).Must(x => null != db.Sellers.Find(x));
        }
    }
}