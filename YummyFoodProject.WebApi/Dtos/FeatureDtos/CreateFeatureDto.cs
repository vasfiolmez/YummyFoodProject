namespace YummyFoodProject.WebApi.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; } = null!;
        public string Subtitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? VideoUrl { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
