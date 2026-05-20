using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AirlineManagementSystem.Mappers
{
    public static class EntityMapper
    {
        // A generic mapper function that works all classes 
        internal static T MapToEntity<T>(Dictionary<string, string> dictionary) where T : new()
        {
            // Create a brand new, empty instance of the class 
            T entity = new T();

            // Get all public properties of the class
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            // Loop through each property and search for a matching key in the dictionary
            foreach (PropertyInfo prop in properties)
            {
                // Get the property name 
                string propName = prop.Name;

                // Look for a key in the dictionary matching the property name
                // We use OrdinalIgnoreCase so "username" matches "Username"
                string matchingKey = null;
                foreach (string key in dictionary.Keys)
                {
                    if (key.Equals(propName, StringComparison.OrdinalIgnoreCase))
                    {
                        matchingKey = key;
                        break;
                    }
                }

                // If a matching key is found, assign the dictionary value to the object
                if (matchingKey != null)
                {
                    string rawValue = dictionary[matchingKey];

                    // Safely convert the string value from the dictionary to the property's target type
                    // (This handles strings, ints, decimals, etc. automatically)
                    object convertedValue = Convert.ChangeType(rawValue, prop.PropertyType);

                    prop.SetValue(entity, convertedValue);
                }
            }

            return entity;
        }
    }    
}
