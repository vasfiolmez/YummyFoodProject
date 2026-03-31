namespace YummyFoodProject.WebUI.Dtos.NotificationDtos
{
    public class ResultNotificationByIsReadFalse
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
