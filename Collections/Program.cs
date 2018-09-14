using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectionCmds();
            LinkedCollectionCmds();
        }

        static void CollectionCmds()
        {
            var a = new CustomCollection<int>(10);
            a.Add(1);
            a.Add(2);
            a[2] = 3;
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine(a.Count);
            Console.WriteLine(a.Contains(1));
            Console.WriteLine(a.IndexOf(2));
            a.Remove();
            Console.WriteLine("last value removed");
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            a[2] = 3;
            a.Remove(2);
            Console.WriteLine("List after removing 2");
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            a.Clear();
            Console.WriteLine(a.Count > 0 ? "not cleared" : "cleared");
            Console.WriteLine();
            Console.ReadKey();
        }

        static void LinkedCollectionCmds()
        {
            var a = new CustomLinkedCollection<int>();
            a.Add(1);
            a.Add(2);
            a.Add(6);
            a[2] = 3;
            a[1] = 4;
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine(a[1] == a[2] ? "true" : "false");
            a.Remove();
            Console.ReadKey();
        }
    }
}
