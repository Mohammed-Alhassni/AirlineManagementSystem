namespace InteractiveTesting
{
    internal class Program
    {
        static void Main()
        {
            // Hide the blinking cursor for a cleaner look
            Console.CursorVisible = false;

            string[] menuOptions = { "Start Game", "Load Save", "Settings", "Exit" };
            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== MAIN MENU ===");
                Console.ResetColor();
                Console.WriteLine("Use Up/Down Arrows to navigate, Enter to select.\n");

                // Render the menu items
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        // Highlight the currently selected option
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {menuOptions[i]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {menuOptions[i]}");
                    }
                }

                // Capture user input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        // Wrap around to the bottom if we go past the top
                        if (selectedIndex < 0) selectedIndex = menuOptions.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        // Wrap around to the top if we go past the bottom
                        if (selectedIndex >= menuOptions.Length) selectedIndex = 0;
                        break;

                    case ConsoleKey.Enter:
                        running = false; // Break the loop on selection
                        break;
                }
            }

            // Action based on choice
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You selected: {menuOptions[selectedIndex]}");
            Console.ResetColor();

            Console.CursorVisible = true; // Bring the cursor back
        }
    }
}
