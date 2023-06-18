namespace Shop.Api.Dtos.ProductDtos
{
    public class ProductGetAllItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public BrandInProductsDto Brand { get; set; }

    }

    public class BrandInProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
