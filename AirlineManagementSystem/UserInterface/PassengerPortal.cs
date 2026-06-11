using AirlineManagementSystem.HelperFunctions;
using AirlineManagementSystem.UIHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UserInterface
{
    internal class PassengerPortal
    {
        internal static void ShowPassengerPortal(Dictionary<string, string> user)
        {
            string[] options = { "Browse & Search Flights", "Book a Ticket", "Manage My Tickets", "My Profile", "Personalized Recommendations", "Logout" };
            int currentSelection = 0;
            bool interacting = true;
            List<string> tieresRank = new List<string> { "Bronze", "Silver", "Gold"};

            Dictionary<string, string> recentTicket = ReadRaws.ReadRawByWord("ticket", user["passenger_id"]);

            List <KeyValuePair<string, string>> userInfo = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> ("Name", user["full_name"]),
                new KeyValuePair<string, string> ("Loyality Tier", user["tier_status"]),
                new KeyValuePair<string, string> ("Points Balance", user["loyalty_points_balance"]),
            };

            List<KeyValuePair<string, string>> recentTicketInfo = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> ("Seat Class", recentTicket["seat_class"]),
                new KeyValuePair<string, string> ("Booking Date", recentTicket["booking_date_time"]),
                new KeyValuePair<string, string> ("Earned Loyality Points", recentTicket["loyalty_points_earned"]),
                new KeyValuePair<string, string> ("Seat Class", recentTicket["seat_class"])
            };

            // Hide the blinking cursor 
            Console.CursorVisible = false;

            while (interacting)
            {
                Console.Clear();

                // Pass the currentSelection so the box knows which line to highlight
                MenuElements.RenderMenuBox(
                    "Passenger Portal",
                    $"Welcome back {user["full_name"].Split(" ")[0]}. Select an option to proceed.",
                    options,
                    "Use UP/DOWN arrows to navigate, ENTER to select.",
                    currentSelection
                );

                MenuElements.DisplaySummary("summary", userInfo, 4);
                MenuElements.DisplaySummary("Recenet Ticket", recentTicketInfo, 4);
                MenuElements.DisplaySummary("summary", userInfo, 4);

                // Intercept keypress without echoing the character to the console
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection--;
                        // Wrap around to the bottom option if navigating past the top
                        if (currentSelection < 0) currentSelection = options.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        currentSelection++;
                        // Wrap around to the top option if navigating past the bottom
                        if (currentSelection >= options.Length) currentSelection = 0;
                        break;

                    case ConsoleKey.Enter:
                        interacting = false;
                        break;
                }
            }

            // Restore the cursor before leaving the menu context
            Console.CursorVisible = true;
            Console.Clear();

            // 10. Handle the action based on what they selected
            ExecuteMenuAction(options[currentSelection]);
        }

        private static void ExecuteMenuAction(string selection)
        {
            switch (selection)
            {
                case "":

                    break;
                case " ":

                    break;
                case "Logout":
                    WelcomeScreen.ShowWelcomeScreen();
                    break;
            }
        }
    }
}
