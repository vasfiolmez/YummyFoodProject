using FluentValidation;
using YummyFoodProject.WebApi.Dtos.ProductDtos;

namespace YummyFoodProject.WebApi.ValidationRules.ProductRules
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adını boş geçmeyin.")
                .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Price)
                .InclusiveBetween(0, 1000).WithMessage("Ürün fiyatı 0 ile 1000 TL arasında olmalıdır.");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
        }
    }
}
