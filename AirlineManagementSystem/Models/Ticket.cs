namespace AirlineManagementSystem.Models;

public class Ticket
{
    public string TicketId { get; set; }
    public string PassengerId { get; set; }
    public string FlightNumber { get; set; }
    public string SeatClass { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingDateTime { get; set; }
    public string TicketStatus { get; set; }
    public decimal FinalPricePaid { get; set; }
    public int LoyaltyPointsEarned { get; set; }
}