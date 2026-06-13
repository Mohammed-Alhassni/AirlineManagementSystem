namespace AirlineManagementSystem.FileHandling
{
    internal static class LinesRead
    {
        internal static string ReadLine(string filePath, int lineNumber = 1)
        {
            if (!File.Exists(filePath) || lineNumber < 1)
            {
                return "";
            }

            // Using 'using' ensures the file is closed properly even if an error happens
            using (StreamReader sr = new StreamReader(filePath))
            {
                string currentLine = "";

                for (int i = 1; i <= lineNumber; i++)
                {
                    currentLine = sr.ReadLine() ?? "";

                    // If the file ends before we reach the requested line
                    if (currentLine == "")
                    {
                        return "";
                    }
                }

                return currentLine;
            }
        }

        internal static List<string> ReadAllLine(string filePath)
        {
            List<string> allLines = new List<string>();

            if (!File.Exists(filePath)){ return []; }

            // Using 'using' ensures the file is closed properly even if an error happens
            using (StreamReader sr = new StreamReader(filePath))
            {
                //flag is true till the lines finish
                string line;

                while ((line = sr.ReadLine() ?? "") != "")
                {
                    allLines.Add(line);
                }
            }

            return allLines;
        }
        internal static string ReturnLineByWord(string filePath, string word)
        {
            if (!File.Exists(filePath))
            {
                return "";
            }

            // Using 'using' ensures the file is closed properly even if an error happens
            using (StreamReader sr = new StreamReader(filePath))
            {
                //flag is true till the lines finish
                string line;

                while ((line = sr.ReadLine() ?? "") != "")
                {
                    if (line.Contains(word, StringComparison.OrdinalIgnoreCase)) { return line; }
                }
            }

            return "";
        }
    }
}
