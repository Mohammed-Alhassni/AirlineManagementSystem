namespace AirlineManagementSystem.FileHandling
{
    internal static class CsvCreator
    {
        ///<summary>
        ///
        ///</summary>
        public static void CreateCsv(string fileName, string[] headers, bool isBinDirectory = false)
        {
            try
            {
                // Path.combine handles the path correctly regarding the platform 
                string folderName = "Data";
                string folderPath = folderName;
                // because by default the current dir is where the app compiled bin\Debug\net10.0, we escape 3 times to fix it 
                if (!isBinDirectory) { folderPath = Path.Combine("..", "..", "..", folderPath); }
                string filePath = Path.Combine(folderPath, $"{fileName}.csv");

                //Check if the directory exist, if not it creates it
                if (! Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Successfully created directory: {folderName}");
                }

                //Check if the file exist, if not it creates it
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close(); 

                    Console.WriteLine($"Successfully created file: {fileName}");
                }
                else
                {
                    Console.WriteLine($"{fileName}.csv already created.");
                }

                //combine the headers array into single line
                string headerLine = string.Join(',', headers);

                //read the first line, if null it will be empty string
                StreamReader sr = new StreamReader(filePath);
                string exsitingLine = sr.ReadLine() ?? "";
                sr.Close();

                //check the existing header if it is created 
                if (exsitingLine != "")
                {
                    //split the first line into array of headers to be compared to the required
                    string[] exsitingHeader = exsitingLine.Split(',');

                    if (exsitingHeader.SequenceEqual(headers))
                    {
                        Console.WriteLine($"{fileName} entity already created.");
                    }
                }
                else
                {
                    // ceate header using the combined headers (headerline)
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.WriteLine(headerLine);
                    Console.WriteLine($"Successfully created entity: {fileName}");
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating {fileName}.csv: {ex.Message}");
            }
        }
    }
}
