using System.Reflection;
using System.Text.RegularExpressions;

namespace AirlineManagementSystem.HelperFunctions
{
    public class EntityMethods
    {
        internal static List<string> ExtractVaribles<T>(bool cleanString = true) where T : new()
        {
            List<string> variblesNames = new List<string>();
            // Get all public properties of the class
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();


            foreach (PropertyInfo prop in properties)
            {
                string name = prop.Name;

                if (cleanString)
                {
                    name = Regex.Replace(name, "(?<!^)(?=[A-Z])", " ");
                }

                variblesNames.Add(name);
            }

            return variblesNames;
        }
    }
}