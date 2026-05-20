namespace AirlineManagementSystem.Models;

public class UserLog
{
    public int Log_Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Action_Type { get; set; }
    public string Acting_User_Id { get; set; }
}