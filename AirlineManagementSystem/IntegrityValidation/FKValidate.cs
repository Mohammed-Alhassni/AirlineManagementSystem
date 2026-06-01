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
                // Check if  property has custom ForeignKey attribute
                var fkAttribute = prop.GetCustomAttribute<ForeignKeyAttribute>();


                if (fkAttribute != null)
                {
                    // Extract the value currently stored in the property
                    string fkValue = prop.GetValue(entity).ToString();

                    // Extract the metadata from the attribute 
                    string targetTable = fkAttribute.LinkedTable;

                    if (ReadRaws.ReadRawByPk(targetTable, fkValue).Count <= 1)
                    {
                        Console.Write($"Invalid forign key for {entityType.Name}: The Primary key {fkValue} does not exist in {targetTable}");
                        return false;    
                    }

                    Console.Write($"Valid forign key for {entityType.Name}:  The Primary key {fkValue} does exist in {targetTable}...");
                    return true;
                }
            }

            return false;
        }
    }
}
