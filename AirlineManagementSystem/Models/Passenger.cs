namespace AirlineManagementSystem.Models;

public class Passenger
{
    public string PassengerId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public string PassportNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int LoyaltyPointsBalance { get; set; }
    public string TierStatus { get; set; }
    public string Password { get; set; }
}