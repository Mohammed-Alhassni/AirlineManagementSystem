using AirlineManagementSystem.UIHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UserInterface
{
    internal class PassengerPortal
    {
        internal static void ShowPassengerPortal()
        {
            string[] options = { "Browse & Search Flights", "Book a Ticket", "Manage My Tickets", "My Profile", "Personalized Recommendations", "Logout" };
            int currentSelection = 0;
            bool interacting = true;

            // Hide the blinking cursor 
            Console.CursorVisible = false;

            while (interacting)
            {
                Console.Clear();

                // Pass the currentSelection so the box knows which line to highlight
                MenuElements.RenderMenuBox(
                    "Admin Dashboard",
                    "Welcome back. Select an option to proceed.",
                    options,
                    "Use UP/DOWN arrows to navigate, ENTER to select.",
                    currentSelection
                );

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
