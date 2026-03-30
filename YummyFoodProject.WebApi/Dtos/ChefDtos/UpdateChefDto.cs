namespace YummyFoodProject.WebApi.Dtos.ChefDtos
{
    public class UpdateChefDto
    {
        public int ChefId { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
