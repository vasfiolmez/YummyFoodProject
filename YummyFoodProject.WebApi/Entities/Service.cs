namespace YummyFoodProject.WebApi.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconUrl { get; set; } = null!;
}
