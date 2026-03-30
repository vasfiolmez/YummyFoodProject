namespace YummyFoodProject.WebApi.Dtos.ChefDtos
{
    public class CreateChefDto
    {
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
