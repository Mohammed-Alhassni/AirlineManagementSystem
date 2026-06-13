using AirlineManagementSystem.FileHandling;

namespace AirlineManagementSystem.HelperFunctions
{
    internal static class ReadRaws
    {
        internal static List<string> ReadAllRaws(string fileName, bool isBinDirectory = false)
        {
            try
            {
                string filePath = Path.Combine("Data", $"{fileName}.csv");
                if (!isBinDirectory) { filePath = Path.Combine("..", "..", "..", filePath); }


                return LinesRead.ReadAllLine(filePath);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading {fileName}: {ex.Message}");
                return new List<string> { };
            }
        }

        internal static Dictionary<string, string> ReadRawByPk(string fileName, string primaryKey, bool isBinDirectory = false)
        {
            try
            {
                Dictionary<string, string> record = new Dictionary<string, string>();

                string filePath = Path.Combine("Data", $"{fileName}.csv");
                if (! isBinDirectory) { filePath = Path.Combine("..", "..", "..", filePath); }

                string headerLine = LinesRead.ReadLine(filePath);
                string raw = LinesRead.ReturnLineByWord(filePath, primaryKey);

                string[] headers = headerLine.Split(",");
                string[] values = raw.Split(",");

                if (!values[0].Equals(primaryKey))
                {
                    Console.WriteLine($"Primary Key: {primaryKey} does not exist in {fileName}");
                    return new Dictionary<string, string>();
                }

                for (int i= 0; i < headers.Length && i < values.Length; i++)
                {
                    record.Add(headers[i], values[i]);
                }

                return record;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading {fileName}: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }

        internal static Dictionary<string, string> ReadRawByWord(string fileName, string word, bool isCaseSen= false, bool isBinDirectory = false)
        {
            try
            {
                Dictionary<string, string> record = new Dictionary<string, string>();

                string filePath = Path.Combine("Data", $"{fileName}.csv");
                if (!isBinDirectory) { filePath = Path.Combine("..", "..", "..", filePath); }

                string headerLine = LinesRead.ReadLine(filePath);
                string raw = LinesRead.ReturnLineByWord(filePath, word);

                string[] headers = headerLine.Split(",");
                string[] values = raw.Split(",");

                // Determine the correct comparer based on the isCaseSen flag
                var comparer = isCaseSen ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
                
                if (!values.Contains(word, comparer))
                {
                    foreach (var header in headers)
                    {
                        record.Add(header, "");
                    }
                    return record;
                }
                
                for (int i = 0; i < headers.Length && i < values.Length; i++)
                {
                    record.Add(headers[i], values[i]);
                }

                return record;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading {fileName}: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }
    }
}
