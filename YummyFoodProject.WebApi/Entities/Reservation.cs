namespace YummyFoodProject.WebApi.Entities;

public class Reservation
{
    public int ReservationId { get; set; }
    public string NameSurname { get; set; }=null!;  
    public string Email { get; set;} =null!;
    public int PhoneNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public  string ReservationTime { get; set; }
    public int CountofPeople { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
}
