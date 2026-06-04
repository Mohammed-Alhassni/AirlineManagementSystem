using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.UIHelpers
{
    internal class MenuElements
    {
        /// <summary>
        /// Renders a responsive, centered layout box with double borders to the console window. 
        /// Supports standard navigation menu lists or a distinct interactive data-entry form context.
        /// </summary>
        /// <param name="title">The primary visual header string centered at the top of the box layout.</param>
        /// <param name="description">An optional instructional summary string displayed immediately beneath the title region.</param>
        /// <param name="options">An array of core textual menu options or data field lines to map into the primary interactive stack.</param>
        /// <param name="instructions">An optional small status bar context message pinned dynamically above the base line of the frame structure.</param>
        /// <param name="selectedIndex">The unified layout array tracker index denoting the currently active or focused selectable line block.</param>
        /// <param name="isInputMode">Determines form presentation characteristics; transforms numeric ordered menus into plain string selectors and activates button rendering loops if true.</param>
        /// <param name="buttons">An optional array of strings defining individual action flags (such as Submit or Back) spaced beneath input regions.</param>
        internal static void RenderMenuBox(string title, string description, string[] options, string instructions, int selectedIndex, bool isInputMode = false, string[] buttons = null)
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
            int minWidth = 60;

            // 1. Calculate length limits including input options
            int maxTextLength = title?.Length ?? 0;
            if (!string.IsNullOrEmpty(description) && description.Length > maxTextLength)
                maxTextLength = description.Length;
            if (!string.IsNullOrEmpty(instructions) && instructions.Length > maxTextLength)
                maxTextLength = instructions.Length;

            if (options != null && options.Length > 0)
            {
                //4 because we add [] when display 
                //2 beacuse we add > when display 
                int maxOptionLength = options.Max(o => o.Length) + (isInputMode ? 2 : 4);
                if (maxOptionLength > maxTextLength) maxTextLength = maxOptionLength;
            }

            // Include button length requirements if they exist
            if (buttons != null && buttons.Length > 0)
            {
                int maxButtonLength = buttons.Max(b => b.Length);
                if (maxButtonLength > maxTextLength) maxTextLength = maxButtonLength;
            }

            int internalWidth = Math.Max(minWidth, maxTextLength + (sidePadding * 2));
            int totalBoxWidth = internalWidth + 2;

            int currentScreenWidth = Console.WindowWidth;
            int leftOffset = Math.Max(0, (currentScreenWidth - totalBoxWidth) / 2);
            string leftRightSpaces = new string(' ', leftOffset);

            // 3. Render System Header Text ABOVE the Box
            string headerText = "AIRLINE MANAGEMENT SYSTEM";
            int headerOffset = Math.Max(0, (currentScreenWidth - headerText.Length) / 2);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', headerOffset) + headerText);
            Console.ResetColor();
            Console.WriteLine();

            // 4. Create border blocks
            string horizontalLine = new string('═', internalWidth);
            string emptyLine = new string(' ', internalWidth);
            string dividerLine = new string('╌', internalWidth);

            void PrintStructure(string borderLeft, string content, string borderRight)
            {
                Console.ForegroundColor = borderAndTitleColor;
                Console.Write(leftRightSpaces + borderLeft);
                Console.Write(content);
                Console.WriteLine(borderRight);
            }

            // 5. Render Top Border
            PrintStructure("╔", horizontalLine, "╗");

            // 6. Render Title
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

            // 8. Render Input Fields or Options
            int optionsCount = options?.Length ?? 0;
            if (options != null && optionsCount > 0)
            {
                for (int i = 0; i < optionsCount; i++)
                {
                    bool isSelected = (i == selectedIndex);
                    string optionText = isInputMode ? $"> {options[i]}" : $"[{i + 1}] {options[i]}";

                    int totalPaddingNeeded = internalWidth - optionText.Length;
                    string leftPad = new string(' ', sidePadding);
                    string rightPad = new string(' ', totalPaddingNeeded - sidePadding);

                    Console.ForegroundColor = borderAndTitleColor;
                    Console.Write($"{leftRightSpaces}║");

                    if (isSelected)
                    {
                        Console.BackgroundColor = highlightBg;
                        Console.ForegroundColor = highlightFg;
                        Console.Write($"{leftPad}{optionText}{rightPad}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = textColor;
                        Console.Write($"{leftPad}{optionText}{rightPad}");
                    }

                    Console.ForegroundColor = borderAndTitleColor;
                    Console.WriteLine("║");
                }
            }

            // 8b. Render Action Buttons (Input Mode specific layout - Left-Aligned)
            if (isInputMode && buttons != null && buttons.Length > 0)
            {
                // One blank separator line between fields and the first button
                PrintStructure("║", emptyLine, "║");

                for (int b = 0; b < buttons.Length; b++)
                {
                    bool isSelected = ((optionsCount + b) == selectedIndex);
                    string buttonText = buttons[b];

                    // Use consistent side padding to align exactly with input fields
                    int totalPaddingNeeded = internalWidth - buttonText.Length;
                    string leftPad = new string(' ', sidePadding);
                    string rightPad = new string(' ', totalPaddingNeeded - sidePadding);

                    Console.ForegroundColor = borderAndTitleColor;
                    Console.Write($"{leftRightSpaces}║");

                    if (isSelected)
                    {
                        Console.BackgroundColor = highlightBg;
                        Console.ForegroundColor = highlightFg;
                        Console.Write($"{leftPad}{buttonText}{rightPad}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = textColor;
                        Console.Write($"{leftPad}{buttonText}{rightPad}");
                    }

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
