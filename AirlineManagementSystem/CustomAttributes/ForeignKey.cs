using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true, Inherited = true)]
    internal class ForeignKeyAttribute : Attribute
    {
        /// <summary>
        /// This should target csv entities as for now
        /// </summary>
        public string LinkedTable { get; }

        // Constructor forces you to provide these details when using the attribute
        public ForeignKeyAttribute(string linkedTable)
        {
            LinkedTable = linkedTable;
        }
    }
}
