namespace YummyFoodProject.WebApi.Dtos.FoodEventsDtos
{
    public class CreateFoodEventsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
