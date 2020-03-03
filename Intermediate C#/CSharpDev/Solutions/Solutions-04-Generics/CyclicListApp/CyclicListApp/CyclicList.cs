using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicListApp
{
    class CyclicList<T>
    // where T:struct       // This would cause CyclicList<string> to fail.
    // where T:class        // This would cause CyclicList<int> to fail.
    {
        private List<T> elements;
        private int currentPosition;
        private int maxElements;

        public CyclicList(int size)
        {
            elements = new List<T>();
            currentPosition = 0;
            maxElements = size;

            // Pre-populate collection with default values.
            for (int i = 0; i < maxElements; i++)
            {
                elements.Add(default(T));
            }
        }

        public void Add(T item)
        {
            elements[currentPosition] = item;
            if (++currentPosition == maxElements)
            {
                currentPosition = 0;
            }
        }

        public T this[int position]
        {
            get
            {
                if (position >= maxElements)
                {
                    throw new IndexOutOfRangeException("Indexed beyond end of CyclicList");
                }
                else
                {
                    return elements[position];
                }
            }
        }

        public void Display()
        {
            foreach (T item in elements)
            {
                if (item.Equals(default(T)))
                    Console.Write("[default] ");
                else
                    Console.Write(item.ToString() + " ");
            }
        }
    }
}
