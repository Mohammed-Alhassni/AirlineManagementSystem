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
                // Get the property name and standardize the C# property name by stripping underscores and convert to lowercase
                string propName = prop.Name.Replace("_", "").ToLower();
                
                // Look for a key in the dictionary matching the property name
                // We use OrdinalIgnoreCase so "username" matches "Username"
                string matchingKey = null;
                foreach (string key in dictionary.Keys)
                {
                    // Standardize the CSV column header by stripping its underscores and convert to lowercase 
                    // Save to new string as Foreach iteration variable 'key' is immutable. The assignment target must be an assignable variable, property, or indexer
                    string cleanCsvKey = key.Replace("_", "").ToLower();
                    
                    if (cleanCsvKey.Equals(propName, StringComparison.OrdinalIgnoreCase))
                    {
                        matchingKey = key;
                        break;
                    }
                }

                // If a matching key is found, assign the dictionary value to the object
                if (matchingKey != null)
                {
                    string rawValue = dictionary[matchingKey];

                    // Determine the true underlying target type (unwraps Nullable<T> types if necessary)
                    Type targetType = prop.PropertyType;
                    bool isNullable = targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>);
    
                    if (isNullable)
                    {
                        // Extract the actual inner type (e.g., extracts 'DateTime' out of 'DateTime?')
                        targetType = Nullable.GetUnderlyingType(targetType);
                    }

                    // Guardrail: If the value is completely empty and the property accepts nulls, assign null safely
                    if (string.IsNullOrWhiteSpace(rawValue))
                    {
                        if (isNullable || !targetType.IsValueType)
                        {
                            prop.SetValue(entity, null);
                            continue; // Skip conversion logic safely and move to the next field
                        }
                        else
                        {
                            // If it's a non-nullable value type (like an empty flight base price), handle or throw an alert
                            Console.WriteLine($"[Warning] Found empty value for non-nullable property: {propName}");
                            continue;
                        }
                    }

                    try
                    {
                        // Perform the type conversion cleanly using the true target data type
                        object convertedValue = Convert.ChangeType(rawValue, targetType);
                        prop.SetValue(entity, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Mapper Error] Failed converting value '{rawValue}' to {targetType.Name} for property {propName}: {ex.Message}");
                    }
                }
            }

            return entity;
        }
    }    
}
