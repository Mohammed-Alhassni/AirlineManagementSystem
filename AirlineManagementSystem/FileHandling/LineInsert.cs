namespace AirlineManagementSystem.FileHandling
{
    internal class LineInsert
    {
        /// <summary>
        /// Adds new raw of values to existing entity 
        /// </summary>
        public static void AddLine(string fileName, string[] values, bool isBinDirectory = false)
        {
            
            try
            {
                //Create the actual path for the csv file
                string filePath = Path.Combine("Data", $"{fileName}.csv");
                // because by default the current dir is where the app compiled bin\Debug\net10.0, we escape 3 times to fix it 
                if (!isBinDirectory) { filePath = Path.Combine("..", "..", "..", filePath); }
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
                        string[] headers = headerLine.Split(',');
                        if (headers.Length == values.Length) 
                        {
                            //create strean writer but with append to not delete existing line
                            StreamWriter sw = new StreamWriter(filePath, append: true);
                            sw.WriteLine(rawLine);
                            sw.Close();
                            Console.WriteLine($"Raw added to {fileName}. ");
                        }
                        else
                        {
                            Console.WriteLine($"{fileName} header is incompatible with the raw. ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{fileName} entity is not created. ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inerting raw to {fileName}.csv: {e.Message}");
            }
        }
    }
}
