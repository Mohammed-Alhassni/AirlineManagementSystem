using AirlineManagementSystem.FileHandling;
using AirlineManagementSystem.IntegrityValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.HelperFunctions
{
    /// <summary>
    /// Safely adding values into entities after checking the primary and forign key 
    /// </summary>
    internal class WriteRaws
    {
        internal static void InsertValues<T>(string fileName, string[] values, bool isBinDirectory = false) where T : new()
        {
            try
            {
                Dictionary<string, string> ValuesDictionary=  DataConversion.CreateDictionary(fileName, values);

                T TargetObj = EntityMapper.MapToEntity<T>(ValuesDictionary);

                bool validFks = FKValidate.ValidateFK(TargetObj);

                if (validFks)
                {
                    LineInsert.AddLine(fileName, values, isBinDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
