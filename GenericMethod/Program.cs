using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenericMethod
{
    class Program
    {
        static void Main()
        {
            var a = Program.Get("List", "String");
           
        }

        /// <summary>
        /// Gets the specified a.
        /// </summary>
        /// <param name="a">the generic type</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static object Get(string a, string b)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return null;
        }
    }
}