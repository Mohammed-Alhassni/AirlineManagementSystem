using AirlineManagementSystem.FileHandling;

namespace AirlineManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CsvCreator.CreateCsv("Data", "administrative_user", ["username", "password", "name"]);
        }
    }
}
