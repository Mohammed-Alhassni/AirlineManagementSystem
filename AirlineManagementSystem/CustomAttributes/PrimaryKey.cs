using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementSystem.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property ,AllowMultiple = false, Inherited = true)]
    internal class PrimaryKeyAttribute : Attribute
    {

    }
}
