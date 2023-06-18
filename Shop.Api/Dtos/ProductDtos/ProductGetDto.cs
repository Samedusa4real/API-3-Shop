namespace Shop.Api.Dtos.ProductDtos
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public BrandInProductDto Brand { get; set; }

    }

    public class BrandInProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
