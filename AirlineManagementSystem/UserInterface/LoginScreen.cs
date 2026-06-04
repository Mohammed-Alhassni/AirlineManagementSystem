using AirlineManagementSystem.UIHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UserInterface
{
    internal class LoginScreen
    {
        internal static void ShowLoginScreen()
        {
            string[] fields = ["Username", "Password"];
            string[] buttons = ["Login", "Exit"];

            int currentSelection = 0;
            int totalElements = fields.Length + buttons.Length; 

            string username = "";
            string password = "";
            bool interacting = true;

            while (interacting)
            {
                Console.CursorVisible = false;
                Console.Clear();

                string[] currentDisplayFields = [
                    $"{fields[0]}: {username}",
                    $"{fields[1]}: {new string('*', password.Length)}"
                ];

                // Pass fields and buttons together
                MenuElements.RenderMenuBox(
                    "Secure Login",
                    "Fill fields and select an option below.",
                    currentDisplayFields,
                    "UP/DOWN to navigate, ENTER to activate.",
                    currentSelection,
                    isInputMode: true,
                    buttons: buttons
                );

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection = (currentSelection == 0) ? totalElements - 1 : currentSelection - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        currentSelection = (currentSelection == totalElements - 1) ? 0 : currentSelection + 1;
                        break;

                    case ConsoleKey.Enter:
                        if (currentSelection == 0) // Username field
                        {
                            Console.CursorVisible = true;
                            username = ReadFieldInput("Enter Username: ");
                        }
                        else if (currentSelection == 1) // Password field
                        {
                            Console.CursorVisible = true;
                            password = ReadFieldInput("Enter Password: ", maskInput: true);
                        }
                        else if (currentSelection == 2) // [ Login ] button
                        {
                            // Run validation logic
                        }
                        else if (currentSelection == 3) // [ Exit ] button
                        {
                            interacting = false;
                            WelcomeScreen.ShowWelcomeScreen();
                        }
                        break;
                }
            }
        }

        // Helper method to collect inputs without breaking the styling workflow
        private static string ReadFieldInput(string prompt, bool maskInput = false)
        {
            Console.WriteLine($"\n   {prompt}");
            Console.Write("   > ");

            if (!maskInput)
            {
                return Console.ReadLine() ?? "";
            }

            // Masked password input logic
            string pass = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
            }
            return pass;
        }
    }
}
