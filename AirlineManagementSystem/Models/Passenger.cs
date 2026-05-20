namespace AirlineManagementSystem.Models;

public class Passenger
{
    public string Passenger_Id { get; set; }
    public string Full_Name { get; set; }
    public DateTime Date_Of_Birth { get; set; }
    public string Nationality { get; set; }
    public string Passport_Number { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Registration_Date { get; set; }
    public int Loyalty_Points_Balance { get; set; }
    public string Tier_Status { get; set; }
    public string Password { get; set; }
}