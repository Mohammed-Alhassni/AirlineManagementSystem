namespace AirlineManagementSystem.Models;

public class CrewMember
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string Nationality { get; set; }
    public string LicenseNumber { get; set; } // Nullable if needed, kept as string
    public string AirlineAffiliationIcao { get; set; }
    public int YearsExperience { get; set; }
    public string AvailabilityStatus { get; set; }
}