using AirlineManagementSystem.UIHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UserInterface
{
    internal class WelcomeScreen
    {
        internal static void ShowWelcomeScreen()
        {

            string[] options = ["Login", "Register", "Exit"];
            int currentSelection = 0;
            bool interacting = true;
            int timesTried = 0;

            // Hide the blinking cursor 
            Console.CursorVisible = false;

            while (interacting)
            {
                Console.Clear();

                // Pass the currentSelection so the box knows which line to highlight
                MenuElements.RenderMenuBox(
                    "Main Menu",
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
            ExecuteMenuAction(options[currentSelection], ref timesTried);
        }

        private static void ExecuteMenuAction(string selection, ref int timesTried)
        {
            switch (selection)
            {
                case "Login":
                    LoginScreen.ShowLoginScreen(ref timesTried);
                    break;
                case "Register":
                    
                    break;
                case "Exit":
                    //Display the message goodbye then after 2 secs exit
                    Console.CursorVisible =false;
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.CursorVisible = true;
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
