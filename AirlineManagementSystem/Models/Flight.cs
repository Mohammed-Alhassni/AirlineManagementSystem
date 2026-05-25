namespace AirlineManagementSystem.Models;

public class Flight
{
    public string FlightNumber { get; set; }
    public string OriginAirportIata { get; set; }
    public string DestinationAirportIata { get; set; }
    public string AirlineIcaoCode { get; set; }
    public string AircraftRegistration { get; set; }
    public DateTime ScheduledDepartureDatetime { get; set; }
    public DateTime ScheduledArrivalDatetime { get; set; }
    public DateTime? ActualDepartureDatetime { get; set; }
    public DateTime? ActualArrivalDatetime { get; set; }
    public string Status { get; set; }
    public int AvailableBusinessSeats { get; set; }
    public int AvailableEconomySeats { get; set; }
    public decimal BasePrice { get; set; }
}