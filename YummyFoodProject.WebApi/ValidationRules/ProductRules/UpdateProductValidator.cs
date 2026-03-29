using FluentValidation;
using YummyFoodProject.WebApi.Dtos.ProductDtos;

namespace YummyFoodProject.WebApi.ValidationRules.ProductRules
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            // Güncelleme için ID zorunluluğu
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Güncellenecek ürünün ID değeri boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir ürün ID değeri giriniz.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adını boş geçmeyin.")
                .Length(2, 50).WithMessage("Ürün adı 2-50 karakter arasında olmalıdır.");

            RuleFor(x => x.Price)
                .InclusiveBetween(0, 1000).WithMessage("Fiyat 0-1000 TL arasında olmalıdır.");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.");
        }
    }
}
