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
                CsvCreator.CreateCsv("airport", ["Iata_Code", "Full_Name", "City", "Country", "Time_Zone_Offset"]);                
                CsvCreator.CreateCsv("flight", ["Flight_Number", "Origin_Airport_Iata", "Destination_Airport_Iata", "Airline_Icao_Code", "Aircraft_Registration", "Scheduled_Departure_Datetime", "Scheduled_Arrival_Datetime", "Actual_Departure_Datetime", "Actual_Arrival_Datetime", "Status", "Available_Business_Seats", "Available_Economy_Seats", "Base_Price"]);
                CsvCreator.CreateCsv("crew_member", ["Employee_Id", "Full_Name", "Role", "Nationality", "License_Number", "Airline_Affiliation_Icao", "Years_Experience", "Availability_Status"]);                
                CsvCreator.CreateCsv("flight_assignments", ["flight_number", "employee_id"]);
                CsvCreator.CreateCsv("passenger", ["Passenger_Id", "Full_Name", "Date_Of_Birth", "Nationality", "Passport_Number", "Email", "Phone", "Registration_Date", "Loyalty_Points_Balance", "Tier_Status", "Password"]);                
                CsvCreator.CreateCsv("baggage", ["baggage_id", "ticket_id", "weight_kg", "baggage_type", "status"]);
                CsvCreator.CreateCsv("promotions", ["Promo_Code", "Discount_Percentage", "Validity_Start_Date", "Validity_End_Date", "Max_Uses", "Current_Use_Count", "Applicable_Fare_Class", "Active_Status"]);                
                CsvCreator.CreateCsv("user_logs", ["Log_Id", "Timestamp", "Action_Type", "Acting_User_Id"]);
                CsvCreator.CreateCsv("ticket", ["Ticket_Id", "Passenger_Id", "Flight_Number", "Seat_Class", "Seat_Number", "Booking_Date_Time", "Ticket_Status", "Final_Price_Paid", "Loyalty_Points_Earned"]);
                
                // 1. Admin Rows (Independent)
                LineInsert.AddRaw("admin", ["MohdAlhsni", "9922", "Mohammed Al Hasni"]);
                LineInsert.AddRaw("admin", ["SarahJones", "4411", "Sarah Jones"]);

                // 2. Airline Rows (Independent parent)
                LineInsert.AddRaw("airline", ["WY", "Oman Air", "Oman", "info@omanair.com"]);
                LineInsert.AddRaw("airline", ["EK", "Emirates", "UAE", "contact@emirates.com"]);

                // 3. Aircraft Rows (Dependent on airline.airline_IATA_code)
                LineInsert.AddRaw("aircraft", ["A9C-AM", "Boeing 787", "Boeing", "290", "30", "260", "2019", "Active", "WY"]);
                LineInsert.AddRaw("aircraft", ["A6-EEV", "Airbus A380", "Airbus", "517", "14", "503", "2015", "Active", "EK"]);

                // 4. Airport Rows (Independent parent)
                LineInsert.AddRaw("airport", ["MCT", "Muscat International Airport", "Muscat", "Oman", "4"]);
                LineInsert.AddRaw("airport", ["DXB", "Dubai International Airport", "Dubai", "UAE", "4"]);
                LineInsert.AddRaw("airport", ["LHR", "Heathrow Airport", "London", "UK", "1"]);

                // 5. Flight Rows (Dependent on airport.IATA_code & aircraft.registration_number)
                LineInsert.AddRaw("flight", ["WY101", "MCT", "LHR", "OMA", "A9C-AM", "2026-06-01 14:00:00", "2026-06-01 19:10:00", "", "", "Scheduled", "30", "260", "450.00"]);
                LineInsert.AddRaw("flight", ["EK203", "DXB", "LHR", "UAE", "A6-EEV", "2026-06-02 09:45:00", "2026-06-02 14:15:00", "", "", "Scheduled", "14", "503", "600.00"]);

                // 6. Crew Member Rows (Dependent on airline.airline_IATA_code)
                LineInsert.AddRaw("crew_member", ["EMP001", "Ali Al-Balushi", "Pilot", "Omani", "LIC-OM-9921", "OMA", "12", "Available"]);
                LineInsert.AddRaw("crew_member", ["EMP002", "Sarah Jones", "Co-Pilot", "British", "LIC-UK-4412", "UAE", "7", "Available"]);
                LineInsert.AddRaw("crew_member", ["EMP003", "John Smith", "Cabin Crew", "American", "None", "UAE", "4", "On Leave"]);

                // 7. Flight Assignments Rows (Dependent on flight.flight_number & crew_member.employee_ID)
                LineInsert.AddRaw("flight_assignments", ["WY101", "EMP001"]);
                LineInsert.AddRaw("flight_assignments", ["EK203", "EMP002"]);

                // 8. Passenger Rows (Dependent on airline.airline_IATA_code)
                LineInsert.AddRaw("passenger", ["PAS9901", "Ahmed Al-Riyami", "1990-05-12", "Omani", "A8899001", "ahmed@email.com", "+96899887766", "2024-01-15", "1500", "Gold", "pass123!"]);
                LineInsert.AddRaw("passenger", ["PAS9902", "Emma Watson", "1993-09-20", "British", "B2233445", "emma@email.com", "+447711223344", "2025-03-10", "450", "Silver", "securePwd99"]);

                // 9. Ticket Rows (Dependent on passenger.passenger_id & flight.flight_number)
                LineInsert.AddRaw("ticket", ["TCK-0001", "PAS9901", "WY101", "Economy", "12A", "2026-05-10 10:30:00", "Confirmed", "450.00", "45"]);
                LineInsert.AddRaw("ticket", ["TCK-0002", "PAS9902", "EK203", "Business", "02B", "2026-05-12 16:45:00", "Confirmed", "1200.00", "120"]);

                // 10. Baggage Rows (Dependent on ticket.ticket_id)
                LineInsert.AddRaw("baggage", ["BAG-0001", "TCK-0001", "21.5", "Checked", "Checked-In"]);
                LineInsert.AddRaw("baggage", ["BAG-0002", "TCK-0002", "8.0", "Cabin", "Hand-Carry"]);

                // 11. Promotions Rows (Independent)
                LineInsert.AddRaw("promotions", ["FLY2026", "15.0", "2026-01-01 00:00:00", "2026-12-31 23:59:59", "500", "142", "Economy", "True"]);
                LineInsert.AddRaw("promotions", ["BIZCLASS", "20.0", "2026-05-01 00:00:00", "2026-08-31 23:59:59", "100", "12", "Business", "True"]);

                // 12. User Logs Rows (Dependent on user mapping constraint: Admin ID or Passenger ID)
                LineInsert.AddRaw("user_logs", ["LOG-0001", "2026-05-19 10:00:00", "Login", "MohdAlhsni"]);
                LineInsert.AddRaw("user_logs", ["LOG-0002", "2026-05-19 10:15:00", "Ticket Booking", "PAS9901"]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in data seeding: {e.Message}");
            }
        }
    }
}
