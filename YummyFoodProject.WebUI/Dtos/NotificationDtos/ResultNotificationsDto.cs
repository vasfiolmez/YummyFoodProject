namespace YummyFoodProject.WebUI.Dtos.NotificationDtos
{
    public class ResultNotificationsDto
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
