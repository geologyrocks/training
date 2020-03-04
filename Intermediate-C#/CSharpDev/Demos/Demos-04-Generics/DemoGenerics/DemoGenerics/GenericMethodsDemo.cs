using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoGenerics
{
    #region Simple generic methods

    public static class MyUtilClass
    {
        // Search an array, looking for a particular item.
        // Return the index of that item, or -1 if not found.
        public static int FindElement<T>(T[] array, T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                    return i;
            }
            return -1;
        }
    }

    #endregion

    #region Overloading generic methods

    public class MyClassWithOverloadedGenericMethods
    {
        // Error: the Method1 methods are ambiguous, 
        // because return types and type parameter names are not significant.
        //   public T Method1<T>(T[] array, T item) { return default(T); }
        //   public void Method1<U>(U[] array, U item) { }

        // OK: the Method2 methods are not ambiguous,
        // because the number of type parameters is part of the signature.
        public void Method2(string s)
        {
            Console.WriteLine("In Method2 with parameter {0}.", s);
        }
        public void Method2<T>(string s) 
        {
            Console.WriteLine("In Method2<T> with parameter {0}, where T is {1}.", s, typeof(T));
        }
    }

    #endregion

    #region Generic methods and inheritance

    public abstract class MySuperClassWithGenericMethods
    {
        public abstract T Method1<T>(T[] array, T item);

        public virtual U Method2<U>(U param)
        {
            return param;
        }
    }

    public class MySubClassWithGenericMethods : MySuperClassWithGenericMethods
    {
        public override X Method1<X>(X[] array, X item)
        {
            return array[0];
        }

        public override Y Method2<Y>(Y param)
        {
            return param;
        }
    }

    #endregion

    #region Calling generic methods

    public class MyClassToDemoCalls
    {
        public void Method1<T>(int arg1, T arg2)
        {
            Console.WriteLine("Hello from Method1(int, T) where T is {0}.", typeof(T));
        }

        public void Method1<T>(T arg1, long arg2)
        {
            Console.WriteLine("Hello from Method1(T, long) where T is {0}.", typeof(T));
        }
    }

    #endregion

    static class GenericMethodsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nGenericMethodsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoSimpleGenericMethods();
            DemoOverloadingGenericMethods();
            DemoGenericMethodsAndInheritance();
            DemoCallingGenericMethods();
        }

        private static void DemoSimpleGenericMethods()
        {
            int[] examMarks = new int[] { 90, 75, 87, 73, 59, 92 };
            Console.WriteLine("Index of exam mark 73: {0}", MyUtilClass.FindElement(examMarks, 73));
            Console.WriteLine("Index of exam mark 21: {0}", MyUtilClass.FindElement(examMarks, 21));

            string[] countries = new string[] { "England", "Scotland", "Wales", "N Ireland" };
            Console.WriteLine("Index of Wales: {0}", MyUtilClass.FindElement(countries, "Wales"));
            Console.WriteLine("Index of Italy: {0}", MyUtilClass.FindElement(countries, "Italy"));
        }

        private static void DemoOverloadingGenericMethods()
        {
            MyClassWithOverloadedGenericMethods obj = new MyClassWithOverloadedGenericMethods();

            obj.Method2("Hello");
            obj.Method2<int>("Bonjour");
        }

        private static void DemoGenericMethodsAndInheritance()
        {
            MySuperClassWithGenericMethods obj = new MySubClassWithGenericMethods();

            int result1 = obj.Method1(new int[] { 10, 20, 30 }, 10);
            int result2 = obj.Method2(42);

            Console.WriteLine("Result1 is {0}, result2 is {1}.", result1, result2);
        }

        private static void DemoCallingGenericMethods()
        {
            MyClassToDemoCalls obj = new MyClassToDemoCalls();

            obj.Method1<int>(10, 20);
            obj.Method1<short>(10, 20);
            // obj.Method1<double>(10, 20); // This call is ambiguous.

            obj.Method1(10, 20);
            obj.Method1(3.14, 20);
            // obj.Method1(10, 20L);        // This call is also ambiguous.
        }
    }
}
