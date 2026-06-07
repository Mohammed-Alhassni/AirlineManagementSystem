using AirlineManagementSystem.CustomAttributes;
using AirlineManagementSystem.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AirlineManagementSystem.IntegrityValidation
{
    internal class FKValidate
    {
        public static bool ValidateFK(object entity)
        {
            Type entityType = entity.GetType();
            PropertyInfo[] properties = entityType.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                // Fetch all custom ForeignKeyAttributes applied to this property
                var fkAttributes = prop.GetCustomAttributes<ForeignKeyAttribute>();

                // If the property has at least one ForeignKeyAttribute, validate them
                if (fkAttributes != null && fkAttributes.Any())
                {
                    string fkValue = prop.GetValue(entity).ToString();

                    bool anyValid = false;

                    // Loop through all found attributes on this property
                    foreach (var fkAttribute in fkAttributes)
                    {
                        string targetTable = fkAttribute.LinkedTable;

                        // Check if the key exists in the current target table
                        if (ReadRaws.ReadRawByPk(targetTable, fkValue).Count > 0)
                        {
                            Console.WriteLine($"Valid foreign key for {entityType.Name}: The Primary key {fkValue} does exists in {targetTable}.");
                            anyValid = true;
                            break; // Found a match
                        }
                    }

                    // If NONE of the attributes matched
                    if (!anyValid)
                    {
                        // Listing the attempted tables in the error log for better debugging
                        string attemptedTables = string.Join(", ", fkAttributes.Select(a => a.LinkedTable));
                        Console.WriteLine($"Invalid foreign key for {entityType.Name}: The Primary key '{fkValue}' does not exist in any of the target tables ({attemptedTables}).");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
