namespace AirlineManagementSystem.Models;

public class Flight
{
    public string Flight_Number { get; set; }
    public string Origin_Airport_Iata { get; set; }
    public string Destination_Airport_Iata { get; set; }
    public string Airline_Icao_Code { get; set; }
    public string Aircraft_Registration { get; set; }
    public DateTime Scheduled_Departure_Datetime { get; set; }
    public DateTime Scheduled_Arrival_Datetime { get; set; }
    public DateTime Actual_Departure_Datetime { get; set; }
    public DateTime Actual_Arrival_Datetime { get; set; }   
    public string Status { get; set; }
    public int Available_Business_Seats { get; set; }
    public int Available_Economy_Seats { get; set; }
    public decimal Base_Price { get; set; }
}