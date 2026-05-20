using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.Models
{
    internal class Airline
    {
        public string IATA_code { get; set; }
        public string name { get; set; }
        public string country_of_registration { get; set; }
        public string contact_information { get; set; }
    }
}
