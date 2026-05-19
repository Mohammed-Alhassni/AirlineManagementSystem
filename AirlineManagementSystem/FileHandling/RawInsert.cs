using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.FileHandling
{
    internal class RawInsert
    {
        public static void AddRaw(string fileName, string[] values)
        {
            /// <summary>
            /// Add new raw of values to existing entity 
            /// </summary>

            //Create the actual path for the csv file
            string filePath = Path.Combine("..", "..", "..", "Data", $"{fileName}.csv");
            //create raw line 
            string rawLine = string.Join(',', values);

            //check if the file exist 
            if (File.Exists(filePath))
            {
                //check if the entity created (header line)
                StreamReader sr = new StreamReader(filePath);
                string headerLine = sr.ReadLine() ?? "";
                sr.Close();
                if (headerLine != "")
                {
                    //create strean writer but with append to not delete existing line
                    StreamWriter sw = new StreamWriter(filePath, append: true);
                    sw.WriteLine(rawLine);
                    sw.Close();
                }
            }
            else
            {
                Console.WriteLine($"{fileName} entity is not created. ");
            }
        }
    }
}
