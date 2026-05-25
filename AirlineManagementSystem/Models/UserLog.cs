namespace AirlineManagementSystem.Models;

public class UserLog
{
    public string LogId { get; set; }
    public DateTime Timestamp { get; set; }
    public string ActionType { get; set; }
    public string ActingUserId { get; set; }
}