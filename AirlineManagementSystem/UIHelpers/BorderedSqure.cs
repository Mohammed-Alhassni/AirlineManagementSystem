using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UIHelpers
{
    internal class BorderedSqure
    {
        internal static void RenderMenuBox(string title, string description, string[] options, string instructions, int selectedIndex)
        {
            // Force UTF8 encoding so all double-line characters render perfectly
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Setup Theme Colors
            ConsoleColor borderAndTitleColor = ConsoleColor.Cyan;
            ConsoleColor textColor = ConsoleColor.Gray;
            ConsoleColor instructionsColor = ConsoleColor.DarkGray;
            ConsoleColor highlightBg = ConsoleColor.White;
            ConsoleColor highlightFg = ConsoleColor.Black;

            int sidePadding = 4;

            // 1. Find the longest string among all elements to determine the required internal width
            int maxTextLength = title?.Length ?? 0;
            if (!string.IsNullOrEmpty(description) && description.Length > maxTextLength)
                maxTextLength = description.Length;
            if (!string.IsNullOrEmpty(instructions) && instructions.Length > maxTextLength)
                maxTextLength = instructions.Length;

            if (options != null && options.Length > 0)
            {
                // Account for the "[X] " prefix padding in option length calculations
                int maxOptionLength = options.Max(o => o.Length) + 4;
                if (maxOptionLength > maxTextLength) maxTextLength = maxOptionLength;
            }

            // Calculate total box dimensions
            int internalWidth = maxTextLength + (sidePadding * 2);
            int totalBoxWidth = internalWidth + 2;

            // 2. Dynamically calculate center offset based on window size
            int currentScreenWidth = Console.WindowWidth;
            int leftOffset = Math.Max(0, (currentScreenWidth - totalBoxWidth) / 2);
            string leftRightSpaces = new string(' ', leftOffset);

            // ====================================================================
            // 3. Render System Header Text ABOVE the Box
            // ====================================================================
            string headerText = "AIRLINE MANAGEMENT SYSTEM";
            int headerOffset = Math.Max(0, (currentScreenWidth - headerText.Length) / 2);

            Console.WriteLine(); // Blank line at the absolute top
            Console.ForegroundColor = ConsoleColor.Yellow; // Bold standout color
            Console.WriteLine(new string(' ', headerOffset) + headerText);
            Console.ResetColor();
            Console.WriteLine(); // Small spacer gap before the box starts

            // 4. Create border blocks
            string horizontalLine = new string('═', internalWidth);
            string emptyLine = new string(' ', internalWidth);
            string dividerLine = new string('╌', internalWidth);

            // Helper to print standard structural lines (borders, dividers)
            void PrintStructure(string borderLeft, string content, string borderRight)
            {
                Console.ForegroundColor = borderAndTitleColor;
                Console.Write(leftRightSpaces + borderLeft);
                Console.Write(content);
                Console.WriteLine(borderRight);
            }

            // 5. Render Top Border
            PrintStructure("╔", horizontalLine, "╗");

            // 6. Render Title (Centered & Uppercase)
            if (!string.IsNullOrEmpty(title))
            {
                int totalPaddingNeeded = internalWidth - title.Length;
                string leftPad = new string(' ', totalPaddingNeeded / 2);
                string rightPad = new string(' ', totalPaddingNeeded - leftPad.Length);

                Console.ForegroundColor = borderAndTitleColor;
                Console.Write($"{leftRightSpaces}║{leftPad}");
                Console.Write(title.ToUpper());
                Console.WriteLine($"{rightPad}║");

                PrintStructure("╠", dividerLine, "╣");
            }

            // 7. Render Description
            if (!string.IsNullOrEmpty(description))
            {
                int totalPaddingNeeded = internalWidth - description.Length;
                string leftPad = new string(' ', sidePadding);
                string rightPad = new string(' ', totalPaddingNeeded - sidePadding);

                Console.ForegroundColor = borderAndTitleColor;
                Console.Write($"{leftRightSpaces}║");
                Console.ForegroundColor = textColor;
                Console.Write($"{leftPad}{description}{rightPad}");
                Console.ForegroundColor = borderAndTitleColor;
                Console.WriteLine("║");

                PrintStructure("║", emptyLine, "║");
            }

            // 8. Render Options
            if (options != null && options.Length > 0)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    bool isSelected = (i == selectedIndex);
                    string optionText = $"[{i + 1}] {options[i]}";

                    int totalPaddingNeeded = internalWidth - optionText.Length;
                    string leftPad = new string(' ', sidePadding);
                    string rightPad = new string(' ', totalPaddingNeeded - sidePadding);

                    // Left Border
                    Console.ForegroundColor = borderAndTitleColor;
                    Console.Write($"{leftRightSpaces}║");

                    if (isSelected)
                    {
                        // Swap colors for the entire background block of this option line
                        Console.BackgroundColor = highlightBg;
                        Console.ForegroundColor = highlightFg;
                        Console.Write($"{leftPad}{optionText}{rightPad}");

                        // Reset colors immediately after printing text block
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = textColor;
                        Console.Write($"{leftPad}{optionText}{rightPad}");
                    }

                    // Right Border
                    Console.ForegroundColor = borderAndTitleColor;
                    Console.WriteLine("║");
                }
            }

            // 9. Render Instructions
            if (!string.IsNullOrEmpty(instructions))
            {
                PrintStructure("╠", dividerLine, "╣");

                int totalPaddingNeeded = internalWidth - instructions.Length;
                string leftPad = new string(' ', sidePadding);
                string rightPad = new string(' ', totalPaddingNeeded - sidePadding);

                Console.ForegroundColor = borderAndTitleColor;
                Console.Write($"{leftRightSpaces}║");
                Console.ForegroundColor = instructionsColor;
                Console.Write($"{leftPad}{instructions}{rightPad}");
                Console.ForegroundColor = borderAndTitleColor;
                Console.WriteLine("║");
            }

            // 10. Render Bottom Border
            PrintStructure("╚", horizontalLine, "╝");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
