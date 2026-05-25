namespace AirlineManagementSystem.Models;

public class Baggage
{
    public string BaggageId { get; set; }
    public string TicketId { get; set; }
    public float WeightKg { get; set; }
    public string BaggageType { get; set; }
    public string Status { get; set; }
}