using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoGenerics
{
    // Raw (i.e. non-generic) queue class. This is not type-safe.
    public class RawQueue
    {
        private object[] elems;
        private int numElems;
        private int maxElems;

        public RawQueue(int size)
        {
            elems = new object[size];
            numElems = 0;
            maxElems = size;
        }

        public void AddItem(object item)
        {
            if (numElems < maxElems)
            {
                elems[numElems++] = item;
            }
        }

        public object RemoveItem()
        {
            if (numElems != 0)
            {
                // Get first element in array.
                object returnValue = elems[0];

                // Shunt elements down one slot in the array, to implement "removal" behaviour.
                for (int i = 0; i < numElems; i++)
                {
                    elems[i] = elems[i + 1];
                }
                numElems--;

                // Return what was at the start of the queue.
                return returnValue;
            }
            else
            {
                return null;
            }
        }
    }

    // Generic queue class. This is type-safe.
    public class GenQueue<T>
    {
        private T[] elems;
        private int numElems;
        private int maxElems;

        public GenQueue(int size)
        {
            elems = new T[size];
            numElems = 0;
            maxElems = size;
        }

        public void AddItem(T item)
        {
            if (numElems < maxElems)
            {
                elems[numElems++] = item;
            }
        }

        public T RemoveItem()
        {
            if (numElems != 0)
            {
                // Get first element in array.
                T returnValue = elems[0];

                // Shunt elements down one slot in the array, to implement "removal" behaviour.
                for (int i = 0; i < numElems; i++)
                {
                    elems[i] = elems[i + 1];
                }
                numElems--;

                // Return what was at the start of the queue.
                return returnValue;
            }
            else
            {
                return default(T);  // default(T) generates the appropriate default value (null or zero)
            }
        }
    }

    // Generic dictionary class, with two type parameters (for the "key type" and the "value type".
    public class GenDictionary<K, V>
    {
        // Nested class, to represent one key/value entry in the dictionary.
        struct Entry
        {
            public K key;
            public V value;

            public Entry(K key, V value)
            {
                this.key = key;
                this.value = value;
            }
        };

        // The dictionary holds an array of entries. Each entry has a key and a value.
        private Entry[] entries;
        private int numEntries;
        private int maxEntries;

        public GenDictionary(int size)
        {
            entries = new Entry[size];
            numEntries = 0;
            maxEntries = size;
        }

        public bool Contains(K key)
        {
            // Loop through all entries, to find a key that matches the parameter key.
            foreach (Entry entry in entries)
            {
                if (entry.key.Equals(key))
                    return true;
            }
            return false;
        }

        public V this[K key]
        {
            get
            {
                // Loop through all entries, to find a key that matches the parameter key. Return the value for that entry.
                foreach (Entry entry in entries)
                {
                    if (entry.key.Equals(key))
                        return entry.value;
                }
                // Key not found, so return default value for the "value type".
                return default(V);
            }
            set
            {
                // Loop through all entries, to find a key that matches the parameter key. Set the value for that entry.
                for (int i = 0; i < numEntries; i++)
                {
                    Entry entry = entries[i];
                    if (entry.key.Equals(key))
                    {
                        entry.value = value;
                        return;
                    }
                }
                // Key not found, so add new entry at end of array (if not already full).
                if (numEntries < maxEntries)
                {
                    entries[numEntries++] = new Entry(key, value);
                }
            }
        }
    }

    public class Employee
    {
        private string name;

        public Employee(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    static class GenericsEssentialsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("GettingStartedWithGenericsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoRawQueue();
            DemoGenericQueue();
            DemoGenericDictionary();
        }

        private static void DemoRawQueue()
        {
            // Create a RawQueue instance (can contain anything).
            RawQueue myQueue = new RawQueue(10);

            // Can add any type of items.
            myQueue.AddItem(42);                        
            myQueue.AddItem("Hello world");             

            // Must cast items on retrieval.
            int x = (int)myQueue.RemoveItem();          
            Console.WriteLine("In RawQueue, removed int: {0}.", x);

            string s = (string)myQueue.RemoveItem();    
            Console.WriteLine("In RawQueue, removed string: {0}.", s);
        }

        private static void DemoGenericQueue()
        {
            // Create a GenQueue instance that can only contain integers.
            GenQueue<int> myQueue = new GenQueue<int>(10);

            // This GenQueue instance only accepts integers for AddItem().
            myQueue.AddItem(42);                        // OK

            // This GenQueue instance returns an integer from RemoveItem().
            int x = myQueue.RemoveItem();               // OK
            Console.WriteLine("In GenQueue, removed int: {0}.", x);

            // myQueue.AddItem("Oh no you don't");      // Type mismatch error.
            // string s = myQueue.RemoveItem();         // Type mismatch error.
        }

        private static void DemoGenericDictionary()
        {
            // Create a dictionary of employees, keyed on their staff number.
            GenDictionary<string, Employee> staff = new GenDictionary<string, Employee>(100);

            // Add some employees.
            staff["007"] = new Employee("James Bond");
            staff["010"] = new Employee("Andre Ayew");

            // Get an employee.
            Employee emp = staff["010"];
            Console.WriteLine("In GenDictionary, Employee 010 is {0}.", emp);
        }
    }
}
