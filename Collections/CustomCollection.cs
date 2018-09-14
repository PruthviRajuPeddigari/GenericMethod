using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class CustomCollection<T> 
    {
        public CustomCollection(int size)
        {
            this.Size = size;
            this.List = new T[size];
        }
        private T[] List { get; set; }

        public T this[int index]
        {
            get
            {
                if (Index > index)
                {
                    return this.List[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set {
                if (Index >= index)
                {
                    this.List[index] = value;
                    Index++;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public int Count { get { return this.Index; } }

        private int Size { get; set; }

        private int Index { get; set; }

        public void Add(T item)
        {
            if (Index <= Size)
            {
                this.List.SetValue(item, Index);
                Index++;
            }
        }

        public void Clear()
        {
            this.List = new T[Size];
            Index = 0;
        }

        public bool Contains(T item)
        {
            return this.List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            if (array.Length >= Size)
            {
                this.List.CopyTo(array, arrayIndex);
            }
        }
        

        public int IndexOf(T item)
        {
            return Array.IndexOf(List, item);
        }

        public void InsertAt(int index, T item)
        {
            if (index <= Index)
            {
                this.List.SetValue(item, index);
            }
        }

        public void Remove()
        {
            Index--;
        }
        public bool Remove(T item)
        {
            var j = 0;
            var isIdentified = false;
            for (int i = 0; i < Index; i++)
            {
                if (List[i].Equals(item)&&!isIdentified)
                {
                    isIdentified = true;
                    j++;
                }
                List[i] = List[j];
                j++;
            }
            Index--;
            return isIdentified;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Index; i++)
            {
                List[i] = List[i + 1];
            }
            Index--;
        }
    }
}
