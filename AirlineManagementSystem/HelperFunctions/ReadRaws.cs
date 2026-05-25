using AirlineManagementSystem.FileHandling;

namespace AirlineManagementSystem.HelperFunctions
{
    internal class ReadRaws
    {
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
    }
}
