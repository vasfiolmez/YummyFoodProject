namespace YummyFoodProject.WebUI.Dtos.TestimonialDtos
{
    public class ResultTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string ImageUrl { get; set; }
    }
}
