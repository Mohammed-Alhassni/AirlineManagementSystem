using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UIHelpers
{
    internal class IOHelpers
    {
        /// <summary>
        /// Helper method to collect inputs without breaking the styling workflow
        /// </summary>
        /// <param name="prompt">The prompt shown to user while asking input</param>
        /// <param name="maskInput">If MaskInputis true, it will show input as * </param>
        /// <returns></returns>
        internal static string ReadFieldInput(string prompt, bool maskInput = false)
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
