using AirlineManagementSystem.CustomAttributes;

namespace AirlineManagementSystem.Models;

public class Flight
{
    public string FlightNumber { get; set; }
    [ForeignKey("airport")]
    public string OriginAirportIata { get; set; }
    [ForeignKey("airport")]
    public string DestinationAirportIata { get; set; }
    [ForeignKey("airline")]
    public string AirlineIcaoCode { get; set; }
    [ForeignKey("aircraft")]
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