using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false, Inherited = true)]
    internal class ForeignKeyAttribute : Attribute
    {
        /// <summary>
        /// This should target csv entities as for now
        /// </summary>
        public string LinkedTable { get; }
        public string LinkedColumn { get; }

        // Constructor forces you to provide these details when using the attribute
        public ForeignKeyAttribute(string linkedTable, string linkedColumn)
        {
            LinkedTable = linkedTable;
            LinkedColumn = linkedColumn;
        }
    }
}
