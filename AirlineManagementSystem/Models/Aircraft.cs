using System;
using System.Collections.Generic;
using System.Text;
using AirlineManagementSystem.CustomAttributes;

namespace AirlineManagementSystem.Models
{
    internal class Aircraft
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int TotalSeatCapacity { get; set; }
        public int BusinessClassSeatCount { get; set; }
        public int EconomyClassSeatCount { get; set; }
        public int ManufacturingYear { get; set; }
        public string OperationalStatus { get; set; }
        [ForeignKey("airline", "IATA_code")]
        public string AirlineIataCode { get; set; }
    }
}
