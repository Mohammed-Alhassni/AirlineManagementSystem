using AirlineManagementSystem.FileHandling;
using AirlineManagementSystem.Models;
using System.Reflection;
using AirlineManagementSystem.HelperFunctions;

namespace AirlineManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSeed.DataInitialize();

            Airline myObj = EntityMapper.MapToEntity<Airline>(ReadRaws.ReadRawByPk("airline", "EK"));

            Type type = myObj.GetType();

            // 2. Fetch all public instance properties
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // 3. Loop through and display them
            foreach (PropertyInfo prop in properties)
            {
                string name = prop.Name;
                object value = prop.GetValue(myObj, null) ?? "null"; // Handle potential null values safely

                Console.WriteLine($"{name}: {value}");
            }
            
            List<string> varibles= EntityMethods.ExtractVaribles<Airline>();

            foreach (string varible in varibles)
            {
                Console.WriteLine(varible);
            }
        }
    }
}
