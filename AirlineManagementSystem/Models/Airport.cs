namespace AirlineManagementSystem.Models;

public class Airport
{
    public string Iata_Code { get; set; }
    public string Full_Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int Time_Zone_Offset { get; set; }
}