using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.FileHandling
{
    internal class DataSeed
    {
        public static void DataInitialize()
        {
            /// <summary>
            /// Generates all schema CSV files from the SkyTrack ERD.
            /// </summary>
            CsvCreator.CreateCsv("Data", "administrative_user", ["username", "password", "name"]);
            CsvCreator.CreateCsv("Data", "airline", ["IATA_code", "name", "country_of_registration", "contact_information"]);
            CsvCreator.CreateCsv("Data", "aircraft", ["registration_number", "model", "manufacturer", "total_seat_capacity", "business_class_seat_count", "economy_class_seat_count", "manufacturing_year", "operational_status", "airline_IATA_code"]);
            CsvCreator.CreateCsv("Data", "airport", ["IATA_code", "full_name", "city", "country", "GMT_time_offset"]);
            CsvCreator.CreateCsv("Data", "flight", ["flight_number", "origin_airport_IATA", "destination_airport_IATA", "aircraft_registration", "scheduled_departure_datetime", "scheduled_arrival_datetime", "actual_departure_datetime", "actual_arrival_datetime", "status", "available_business_seats", "available_economy_seats", "base_price"]);
            CsvCreator.CreateCsv("Data", "crew_member", ["employee_ID", "full_name", "role", "nationality", "passport_number", "contact_information", "airline_IATA_code", "availability_status"]);
            CsvCreator.CreateCsv("Data", "flight_assignments", ["flight_number", "employee_id"]);
            CsvCreator.CreateCsv("Data", "passenger", ["passenger_id", "full_name", "date_of_birth", "nationality", "passport_number", "contact_information", "email", "registration_date", "loyalty_points_balance", "airline_IATA_code", "password"]);
            CsvCreator.CreateCsv("Data", "ticket", ["ticket_id", "passenger_id", "flight_number", "seat_number", "booking_date_time", "travel_class", "final_price_paid", "loyalty_points_earned"]);
            CsvCreator.CreateCsv("Data", "luggage", ["luggage_id", "ticket_id", "weight_kg", "baggage_type", "status"]);
            CsvCreator.CreateCsv("Data", "promotions", ["promo_code", "discount_percentage", "validity_start_date", "validity_end_date", "minimum_usage_count", "applicable_flight_class", "active_status"]);
            CsvCreator.CreateCsv("Data", "user_logs", ["log_id", "timestamp", "action_details", "active_user_id"]);
        }
    }
}
