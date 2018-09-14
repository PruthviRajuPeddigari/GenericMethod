using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericMethods
{
    class Program
    {
        static void Main()
        {
            var a = Get("List", "String");
            if (a != null)
            {
                Console.Write(a.ToString() + "\n");
                Console.ReadKey();
            }
            var b = Get(typeof(List<>), typeof(int));
            if (b != null)
            {
                Console.Write(b.ToString() + "\n");
                Console.ReadKey();
            }

            var c = Get<List<int>, int>();
            if (c != null)
            {
                Console.Write(c.ToString()+"\n");
                Console.ReadKey();
            }

            var d = new TestClass();
            d["Id"] = 1;
            Console.WriteLine(d["Id"]);
            Console.ReadKey();
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
            var types = new List<Type>();
            foreach (var assembli in assemblies)
            {
                types.AddRange(assembli.GetTypes());
            }
            var matchedGenericType = types.FirstOrDefault(t => t.IsGenericType == true && t.Name.StartsWith(a));
            if (matchedGenericType != null)
            {
                var matchedGType = types.FirstOrDefault(t => t.Name.StartsWith(b));
                if (matchedGType != null)
                {
                    var outputType = matchedGenericType.MakeGenericType(matchedGType);
                    if (!outputType.IsAbstract && !outputType.IsInterface)
                    {
                        return Activator.CreateInstance(outputType);
                    }
                    Console.Write("Cannot initialize abstract class or interface");
                    Console.ReadKey();
                    return null;
                }
                Console.Write("2nd parameter is not a type");
                Console.ReadKey();
                return null;
            }
            Console.Write("1st parameter is not a type or not a generic type ");
            Console.ReadKey();
            return null;
        }

        public static object Get( Type generic,Type normal)
        {
            if (generic.IsGenericType)
            {
                if (normal.IsGenericType)
                {
                    Console.Write("2nd parameter should not be a generic type ");
                    Console.ReadKey();
                    return null;
                }
                var outputType = generic.MakeGenericType(normal);
                if (!outputType.IsAbstract && !outputType.IsInterface)
                {
                    return Activator.CreateInstance(outputType);
                }
                Console.Write("Cannot initialize abstract class or interface");
                Console.ReadKey();
                return null;
            }
            else
            {
                Console.Write("1st parameter is not a generic type ");
                Console.ReadKey();
                return null;
            }
        }

        public static object Get<GT,T>() where GT:ICollection<T> 
        {
            var type = typeof(GT);
            if (!type.IsAbstract && !type.IsInterface)
            {
                return Activator.CreateInstance(type);
            }
            Console.Write("Cannot initialize abstract class or interface");
            Console.ReadKey();
            return null;
        }
    }    
}
