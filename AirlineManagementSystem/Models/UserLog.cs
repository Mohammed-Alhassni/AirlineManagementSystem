using AirlineManagementSystem.CustomAttributes;

namespace AirlineManagementSystem.Models;

public class UserLog
{
    public string LogId { get; set; }
    public DateTime Timestamp { get; set; }
    public string ActionType { get; set; }
    [ForeignKey("admin")]
    [ForeignKey("passenger")]
    public string ActingUserId { get; set; }
}