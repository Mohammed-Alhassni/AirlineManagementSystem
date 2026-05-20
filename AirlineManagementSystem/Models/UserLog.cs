namespace AirlineManagementSystem.Models;

public class UserLog
{
    public string Log_Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Action_Type { get; set; }
    public string Acting_User_Id { get; set; }
}