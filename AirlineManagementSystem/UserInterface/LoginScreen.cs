using AirlineManagementSystem.FileHandling;
using AirlineManagementSystem.HelperFunctions;
using AirlineManagementSystem.UIHelpers;

namespace AirlineManagementSystem.UserInterface
{
    internal class LoginScreen
    {
        internal static void ShowLoginScreen(ref int timesTried)
        {
            string[] fields = ["Email", "Password"];
            string[] buttons = ["Login", "Exit"];

            int currentSelection = 0;
            int totalElements = fields.Length + buttons.Length;

            bool isAdmin= false;
            string email = "";
            string password = "";
            bool interacting = true;
            string token = "";

            while (interacting)
            {
                Console.CursorVisible = false;
                Console.Clear();

                string[] currentDisplayFields = [
                    $"{fields[0]}: {email}",
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
                        if (currentSelection == 0) // Email field
                        {
                            Console.CursorVisible = true;
                            string temp = IOHelpers.ReadFieldInput("Enter Email: ");
                            if (ReadRaws.ReadRawByWord("admin", temp).Count > 0)
                            {
                                isAdmin = true;
                                email= temp;
                            }
                            else if (ReadRaws.ReadRawByWord("passenger", temp).Count > 0)
                            {
                                isAdmin=false;
                                email = temp;
                            }
                            else
                            {
                                Console.CursorVisible=false;
                                Console.WriteLine($"The email \"{temp}\" does not exist.");
                                Thread.Sleep(2000);
                                Console.CursorVisible = true;
                            }
                        }
                        else if (currentSelection == 1) // Password field
                        {
                            Console.CursorVisible = true;
                            if (email != "")
                            {
                                password = IOHelpers.ReadFieldInput("Enter Password: ", maskInput: true);
                            }
                            else
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine($"Enter your email first !");
                                Thread.Sleep(2000);
                                Console.CursorVisible = true;
                            }
                        }
                        else if (currentSelection == 2) // [ Login ] button
                        {
                            string entity = isAdmin ? "admin" : "passenger";
                            if (ReadRaws.ReadRawByWord(entity, email)["password"].Equals(password) && timesTried <= 3)
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine("Login Success.");
                                token = "PlaceHolder";
                                Thread.Sleep(2000);
                                Console.CursorVisible = true;
                            }
                            else
                            {
                                timesTried++;
                                if (timesTried <= 3)
                                {
                                    Console.WriteLine("Invalid Credentials");
                                    Thread.Sleep(2000);
                                }

                                if (timesTried > 3)
                                {
                                    Console.WriteLine("Account locked: Too many login trails. ");
                                    Thread.Sleep(2000);
                                }
                            }

                            if (isAdmin && token.Equals("PlaceHolder"))
                            {
                                interacting = false;
                                AdminDashboard.ShowAdminDashboard();
                                
                            }
                            else if (token.Equals("PlaceHolder"))
                            {
                                interacting = false;
                                PassengerPortal.ShowPassengerPortal();
                                
                            } 
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
    }
}

