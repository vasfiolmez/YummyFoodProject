namespace YummyFoodProject.WebApi.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
