namespace YummyFoodProject.WebApi.Entities
{
    public class FoodEvent
    {
        public int FoodEventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
