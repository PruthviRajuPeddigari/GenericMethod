using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class CustomLinkedCollection<T> where T:new()
    {
        public CustomLinkedCollection()
        {
            this.List = new LinkedList<T>();
        }
        public LinkedList<T> List { get; set; }

        public T this[int index]
        {
            get { return List.ElementAt(index); }
            set
            {
                if (Count > index) {
                    var elem = List.ElementAt(index);
                    List.Find(elem).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count
        {
            get
            {
                return this.List.Count;
            }
        }

        public void Add(T item)
        {
            this.List.AddLast(item);
        }

        public void Remove(T item)
        {
            this.List.Remove(item);
        }

        public bool Remove()
        {
            var length = List.Count;
             this.List.RemoveLast();
            if (List.Count < length)
            {
                return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            foreach (var p in List.Select((c, i) => new { listItem = c, Index = i }))
            {
                if(p.listItem.Equals(item))
                {
                    return p.Index;
                }
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            var collection = obj as CustomLinkedCollection<T>;
            return collection != null &&
                   EqualityComparer<LinkedList<T>>.Default.Equals(List, collection.List);
        }

        public override int GetHashCode()
        {
            return -2004394551 + EqualityComparer<LinkedList<T>>.Default.GetHashCode(List);
        }

        public static bool operator ==(CustomLinkedCollection<T> a, CustomLinkedCollection<T> b) 
        {
            return a.Equals(b);
        }

        public static bool operator !=(CustomLinkedCollection<T> a, CustomLinkedCollection<T> b)
        {
            return a.Equals(b);
        }
    }
}
