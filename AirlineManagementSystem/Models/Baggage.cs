namespace AirlineManagementSystem.Models;

public class Baggage
{
    public string Baggage_Id { get; set; }
    public string Ticket_Id { get; set; }
    public float Weight_Kg { get; set; }
    public string Baggage_Type { get; set; }
    public string Status { get; set; }
}