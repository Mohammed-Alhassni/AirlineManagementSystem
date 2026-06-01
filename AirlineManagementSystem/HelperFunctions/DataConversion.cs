using AirlineManagementSystem.FileHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.HelperFunctions
{
    internal class DataConversion
    {
        internal static Dictionary<string, string> CreateDictionary(string fileName, string[] values, bool isBinDirectory = false)
        {
            try
            {
                Dictionary<string, string> record = new Dictionary<string, string>();

                string filePath = Path.Combine("Data", $"{fileName}.csv");
                if (!isBinDirectory) { filePath = Path.Combine("..", "..", "..", filePath); }

                string headerLine = LinesRead.ReadLine(filePath);

                string[] headers = headerLine.Split(",");

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
