using FluentValidation;

namespace Shop.Api.Dtos.ProductDtos
{
    public class ProductPostDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
    }

    public class ProductPostDtoValidator:AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20).MinimumLength(3);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DiscountPercent).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
