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
                // because by default the current dir is where the app compiled bin\Debug\net10.0, we escape 3 times to fix it 
                // Path.combine handles the path correctly regarding the platform 
                string folderPath = Path.Combine("..", "..", "..", folderName);
                string filePath = Path.Combine(folderPath, $"{fileName}.csv");

                //Check if the directory exist, if not it creates it
                if (! Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Successfully created directory: {folderName}");
                }
                else
                {
                    Console.WriteLine($"{folderName} folder already created.");
                }

                //Check if the file exist, if not it creates it
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                    Console.WriteLine($"Successfully created file: {fileName}");
                }
                else
                {
                    Console.WriteLine($"{fileName}.csv already created.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating {fileName}.csv: {ex.Message}");
            }
        }
    }
}
