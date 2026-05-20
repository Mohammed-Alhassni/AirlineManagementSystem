using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.Models
{
    internal class Aircraft
    {
        public string Registration_Number { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Total_Seat_Capacity { get; set; }
        public int Business_Class_Seat_Count { get; set; }
        public int Economy_Class_Seat_Count { get; set; }
        public int manufacturing_year { get; set; }
        public string operational_status { get; set; }
        public string airline_IATA_code { get; set; }
    }
}
