using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.FileHandling
{
    internal class CsvCreator
    {
        public static void CreateCsv(string folderName, string fileName, string[] headers)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating {fileName}.csv: {ex.Message}");
            }
        }
    }
}
