namespace AirlineManagementSystem.FileHandling
{
    internal class DataSeed
    {
        public static void DataInitialize(bool isBinDirectory = false)
        {
            try
            {
                /// <summary>
                /// Generates all schema CSV files from the SkyTrack ERD. If they exist, they will be deleted
                /// </summary>

                //on start up, if dataseed enabled it will create new database by deleting exsting databases, other wise it will duplicate the values 
                //check which folder we are using bin/working dir 
                if (isBinDirectory) 
                { 
                    //delete data in bin dir
                    if (Directory.Exists("Data"))
                    {
                        Directory.Delete("Data", recursive: true);
                        Console.WriteLine("existing data directory deleted. ");
                    }

                }
                else
                {
                    //delete data in working dir
                    if (Directory.Exists(Path.Combine("..", "..", "..", "Data"))) 
                    {
                        Directory.Delete(Path.Combine("..", "..", "..", "Data"), recursive: true);
                        Console.WriteLine("existing data directory deleted. ");

                    }
                }

                CsvCreator.CreateCsv("admin", ["username", "password", "name"]);
                CsvCreator.CreateCsv("airline", ["IATA_code", "name", "country_of_registration", "contact_information"]);
                CsvCreator.CreateCsv("aircraft", ["registration_number", "model", "manufacturer", "total_seat_capacity", "business_class_seat_count", "economy_class_seat_count", "manufacturing_year", "operational_status", "airline_IATA_code"]);
                CsvCreator.CreateCsv("airport", ["IATA_code", "full_name", "city", "country", "GMT_time_offset"]);
                CsvCreator.CreateCsv("flight", ["flight_number", "origin_airport_IATA", "destination_airport_IATA", "aircraft_registration", "scheduled_departure_datetime", "scheduled_arrival_datetime", "actual_departure_datetime", "actual_arrival_datetime", "status", "available_business_seats", "available_economy_seats", "base_price"]);
                CsvCreator.CreateCsv("crew_member", ["Employee_Id", "Full_Name", "Role", "Nationality", "License_Number", "Airline_Affiliation_Icao", "Years_Experience", "Availability_Status"]);                CsvCreator.CreateCsv("flight_assignments", ["flight_number", "employee_id"]);
                CsvCreator.CreateCsv("passenger", ["passenger_id", "full_name", "date_of_birth", "nationality", "passport_number", "contact_information", "email", "registration_date", "loyalty_points_balance", "airline_IATA_code", "password"]);
                CsvCreator.CreateCsv("ticket", ["ticket_id", "passenger_id", "flight_number", "seat_number", "booking_date_time", "travel_class", "final_price_paid", "loyalty_points_earned"]);
                CsvCreator.CreateCsv("baggage", ["baggage_id", "ticket_id", "weight_kg", "baggage_type", "status"]);
                CsvCreator.CreateCsv("promotions", ["promo_code", "discount_percentage", "validity_start_date", "validity_end_date", "minimum_usage_count", "applicable_flight_class", "active_status"]);
                CsvCreator.CreateCsv("user_logs", ["log_id", "timestamp", "action_details", "active_user_id"]);

                // 1. Admin Rows (Independent)
                RawInsert.AddRaw("admin", ["MohdAlhsni", "9922", "Mohammed Al Hasni"]);
                RawInsert.AddRaw("admin", ["SarahJones", "4411", "Sarah Jones"]);

                // 2. Airline Rows (Independent parent)
                RawInsert.AddRaw("airline", ["WY", "Oman Air", "Oman", "info@omanair.com"]);
                RawInsert.AddRaw("airline", ["EK", "Emirates", "UAE", "contact@emirates.com"]);

                // 3. Aircraft Rows (Dependent on airline.airline_IATA_code)
                RawInsert.AddRaw("aircraft", ["A9C-AM", "Boeing 787", "Boeing", "290", "30", "260", "2019", "Active", "WY"]);
                RawInsert.AddRaw("aircraft", ["A6-EEV", "Airbus A380", "Airbus", "517", "14", "503", "2015", "Active", "EK"]);

                // 4. Airport Rows (Independent parent)
                RawInsert.AddRaw("airport", ["MCT", "Muscat International Airport", "Muscat", "Oman", "+4"]);
                RawInsert.AddRaw("airport", ["DXB", "Dubai International Airport", "Dubai", "UAE", "+4"]);
                RawInsert.AddRaw("airport", ["LHR", "Heathrow Airport", "London", "UK", "+1"]);

                // 5. Flight Rows (Dependent on airport.IATA_code & aircraft.registration_number)
                RawInsert.AddRaw("flight", ["WY101", "MCT", "LHR", "A9C-AM", "2026-06-01 14:00:00", "2026-06-01 19:10:00", "", "", "Scheduled", "30", "260", "450.00"]);
                RawInsert.AddRaw("flight", ["EK203", "DXB", "LHR", "A6-EEV", "2026-06-02 09:45:00", "2026-06-02 14:15:00", "", "", "Scheduled", "14", "503", "600.00"]);

                // 6. Crew Member Rows (Dependent on airline.airline_IATA_code)
                RawInsert.AddRaw("crew_member", ["EMP001", "Ali Al-Balushi", "Pilot", "Omani", "LIC-OM-9921", "OMA", "12", "Available"]);
                RawInsert.AddRaw("crew_member", ["EMP002", "Sarah Jones", "Co-Pilot", "British", "LIC-UK-4412", "UAE", "7", "Available"]);
                RawInsert.AddRaw("crew_member", ["EMP003", "John Smith", "Cabin Crew", "American", "None", "UAE", "4", "On Leave"]);

                // 7. Flight Assignments Rows (Dependent on flight.flight_number & crew_member.employee_ID)
                RawInsert.AddRaw("flight_assignments", ["WY101", "EMP001"]);
                RawInsert.AddRaw("flight_assignments", ["EK203", "EMP002"]);

                // 8. Passenger Rows (Dependent on airline.airline_IATA_code)
                RawInsert.AddRaw("passenger", ["PAS9901", "Ahmed Al-Riyami", "1990-05-12", "Omani", "A8899001", "ahmed@email.com", "ahmed@email.com", "2024-01-15", "1500", "WY", "pass123!"]);
                RawInsert.AddRaw("passenger", ["PAS9902", "Emma Watson", "1993-09-20", "British", "B2233445", "emma@email.com", "emma@email.com", "2025-03-10", "450", "EK", "securePwd99"]);

                // 9. Ticket Rows (Dependent on passenger.passenger_id & flight.flight_number)
                RawInsert.AddRaw("ticket", ["TCK-0001", "PAS9901", "WY101", "12A", "2026-05-10 10:30:00", "Economy", "450.00", "45"]);
                RawInsert.AddRaw("ticket", ["TCK-0002", "PAS9902", "EK203", "02B", "2026-05-12 16:45:00", "Business", "1200.00", "120"]);

                // 10. Baggage Rows (Dependent on ticket.ticket_id)
                RawInsert.AddRaw("baggage", ["BAG-0001", "TCK-0001", "21.5", "Checked", "Checked-In"]);
                RawInsert.AddRaw("baggage", ["BAG-0002", "TCK-0002", "8.0", "Cabin", "Hand-Carry"]);

                // 11. Promotions Rows (Independent)
                RawInsert.AddRaw("promotions", ["FLY2026", "15", "2026-01-01", "2026-12-31", "1", "Economy", "true"]);
                RawInsert.AddRaw("promotions", ["BIZCLASS", "20", "2026-05-01", "2026-08-31", "1", "Business", "true"]);

                // 12. User Logs Rows (Dependent on user mapping constraint: Admin ID or Passenger ID)
                RawInsert.AddRaw("user_logs", ["LOG-0001", "2026-05-19 10:00:00", "Admin logged into system", "MohdAlhsni"]);
                RawInsert.AddRaw("user_logs", ["LOG-0002", "2026-05-19 10:15:00", "Passenger booked a flight ticket", "PAS9901"]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in data seeding: {e.Message}");
            }
        }
    }
}
