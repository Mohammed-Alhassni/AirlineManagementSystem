namespace AirlineManagementSystem.Models;

public class CrewMember
{
    public string Employee_Id { get; set; }
    public string Full_Name { get; set; }
    public string Role { get; set; }
    public string Nationality { get; set; }
    public string License_Number { get; set; } // Nullable if needed, kept as string
    public string Airline_Affiliation_Icao { get; set; }
    public int Years_Experience { get; set; }
    public string Availability_Status { get; set; }
}