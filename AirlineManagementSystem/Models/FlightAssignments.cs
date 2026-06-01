using AirlineManagementSystem.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.Models
{
    internal class FlightAssignments
    {
        [ForeignKey("flight")]
        public string FlightNumber { get; set; }
        [ForeignKey("crew_member")]
        public string EmployeeId { get; set; }
    }
}
