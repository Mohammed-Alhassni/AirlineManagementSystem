namespace AirlineManagementSystem.Models;

public class Ticket
{
    public string Ticket_Id { get; set; }
    public string Passenger_Id { get; set; }
    public string Flight_Number { get; set; }
    public string Seat_Class { get; set; }
    public string Seat_Number { get; set; }
    public DateTime Booking_Date_Time { get; set; }
    public string Ticket_Status { get; set; }
    public decimal Final_Price_Paid { get; set; }
    public int Loyalty_Points_Earned { get; set; }
}