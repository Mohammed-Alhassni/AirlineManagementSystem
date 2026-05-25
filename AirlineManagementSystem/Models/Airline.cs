using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.Models
{
    internal class Airline
    {
        public string IataCode { get; set; }
        public string Name { get; set; }
        public string CountryOfRegistration { get; set; }
        public string ContactInformation { get; set; }
    }
}
