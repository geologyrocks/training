using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoGenerics
{
    #region Generic classes

    public class MyCollection<T>
    { }
    
    [Serializable]  
    public class  MyQueue<T> : MyCollection<T>
    where T: struct
    { }

    #endregion

    #region Inheritance

    public class MySuperClass<T1, T2>
    { }

    public interface IMyInterface<T>
    { }

    // Closed subclass, with specific type parameters.
    public class MySub1 : MySuperClass<int, string>, IMyInterface<int>
    { }
 
    // Partially closed subclass, with some specific type parameters.
    public class MySub2<T> : MySuperClass<int, T>, IMyInterface<int>
    { }

    // Open subclass, with all type parameters still generic.
    public class MySub3<T1, T2> : MySuperClass<T1, T2>, IMyInterface<T1>
    { }

    #endregion

    #region Static fields and constructors

    public class MyClass<T>
    {
        private static int count = 0;

        static MyClass()
        {
            if (!typeof(T).IsPrimitive)
                throw new ArgumentException("T must be a primitive type");
        }

        public MyClass() 
        { 
            count++; 
        }

        public static int Count 
        { 
            get { return count; } 
        }
    }

    #endregion

    #region Overloading

    public class MyClassWithOverloading<T>
    {
        // Potential error: MyClass<string> would have two M1(string) methods.
        public void M1(T t) 
        {
            Console.WriteLine("Hello from M1(T), where T is {0}.", typeof(T));
        }
        public void M1(string s)
        {
            Console.WriteLine("Hello from M1(string).");
        }

        // OK: no type parameter for T could be string and int simultaneously.
        public void M2(T t1, T t2)
        {
            Console.WriteLine("Hello from M2(T, T), where T is {0}.", typeof(T));
        }

        public void M2(string s, int i)
        {
            Console.WriteLine("Hello from M2(string, int).");
        }

        // OK: arrays are different from scalars.
        public void M3(T t)
        {
            Console.WriteLine("Hello from M3(T), where T is {0}.", typeof(T));
        }
        public void M3(T[] a)
        {
            Console.WriteLine("Hello from M3(T[]), where T is {0}.", typeof(T));
        }
    } 

    #endregion

    #region Overriding

    // Define a generic superclass.
    public abstract class Super<T>
    {
        public virtual T M1()
        {
            return default(T);
        }

        public virtual Super<T> M2()
        {
            return default(Super<T>);
        }

        public virtual void M3(Super<T> t)
        {
            return;
        }
    }

    // Define a non-generic subclass.
    public class SubA : Super<int>
    {
        public override int M1()
        {
            return 0;
        }

        public override Super<int> M2()
        {
            return new SubA();
        }

        public override void M3(Super<int> t)
        {
            return;
        }
    }

    // Define a generic subclass.
    public class SubB<T1, T2> : Super<T1>
    {
        public override T1 M1()
        {
            return default(T1);
        }
        
        public override Super<T1> M2()
        {
            return default(Super<T1>);
        }

        // Error: T2 is potentially different to T1.
        // This would mean M3() wouldn't override superclass M3 properly.
        //   public override void M3(Super<T2> t)
        //   {
        //       return;
        //   }

        // This version is OK.
        public override void M3(Super<T1> t)
        {
            return;
        }
    }

    #endregion

    #region Nested types

    public class Tree<T>
    {
        public class TreeNode
        {
            public T data;
            public TreeNode left, right;

            public TreeNode(T data)
            {
                this.data = data;
                left = right = null;
            }
        }

        public TreeNode Head { get; set; }
        
        // Plus other members...
    }

    #endregion

    static class CloserLookAtGenericsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nCloserLookAtGenericsDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoGenericClasses();
            DemoInheritance();
            DemoStaticsAndConstructors();
            DemoOverloading();
            DemoOverriding();
            DemoNestedTypes();
        }

        private static void DemoGenericClasses()
        {
            // MyQueue's type parameter can be any kind of struct (including primitives and enums).
            MyQueue<int> queue1 = new MyQueue<int>();
            MyQueue<DateTime> queue2 = new MyQueue<DateTime>();
            MyQueue<DayOfWeek> queue3 = new MyQueue<DayOfWeek>();

            // The following won't compile, because string is a class type (not a struct type).
            //   MyQueue<String> queue4 = new MyQueue<string>(); 
        }

        private static void DemoInheritance()
        {
            // Create a MySub1 instance (0 type parameters needed).
            MySub1 obj1 = new MySub1();

            // Create a MySub2 instance (1 type parameter needed).
            MySub2<string> obj2 = new MySub2<string>();

            // Create a MySub3 instance (2 type parameters needed).
            MySub3<int, string> obj3 = new MySub3<int, string>();
        }

        private static void DemoStaticsAndConstructors()
        {
            // Create instances of MyClass<int>.
            MyClass<int> intInstance1 = new MyClass<int>();
            MyClass<int> intInstance2 = new MyClass<int>();
            MyClass<int> intInstance3 = new MyClass<int>();

            // Create instances of MyClass<double>.
            MyClass<double> doubleInstance1 = new MyClass<double>();
            MyClass<double> doubleInstance2 = new MyClass<double>();
            
            // Display static counts for each generic version of MyClass<T>.
            Console.WriteLine("Count for MyClass<int>:    {0}", MyClass<int>.Count);
            Console.WriteLine("Count for MyClass<double>: {0}", MyClass<double>.Count);

            // Can't create MyClass of non-primitive (see exception thrown in constructor).
            //   MyClass<string> stringInstance = new MyClass<string>();
        }

        private static void DemoOverloading()
        {
            // Create instance of MyClassWithOverloading<int>, and invoke various methods.
            MyClassWithOverloading<int> intInstance = new MyClassWithOverloading<int>();
            intInstance.M1(100);
            intInstance.M1("hello");
            intInstance.M2(100, 200);
            intInstance.M2("hello", 100);
            intInstance.M3(100);
            intInstance.M3(new int[] { 100, 200, 300 });

            // Create instance of MyClassWithOverloading<string>, and invoke various methods.
            MyClassWithOverloading<string> stringInstance = new MyClassWithOverloading<string>();
            stringInstance.M1("hello");
            stringInstance.M2("hello", "world");
            stringInstance.M2("hello", 100);
            stringInstance.M3("hello");
            stringInstance.M3(new string[] { "alpha", "beta", "gamma" });
        }

        private static void DemoOverriding()
        {
            // Create instance of SubA, and invoke methods on SubA instance.
            SubA a = new SubA();

            int r1 = a.M1();
            Super<int> r2 = a.M2();
            a.M3(new SubA());

            // Create instance of SubB, and invoke methods on SubB instance.
            SubB<int, string> b = new SubB<int, string>();

            // Invoke methods on SubB instance.
            r1 = b.M1();
            r2 = b.M2();
            b.M3(new SubB<int, string>());
        }

        public static void DemoNestedTypes()
        {
            Tree<int> mytree = new Tree<int>();
            Tree<int>.TreeNode myhead = mytree.Head;

            // Plus code to add/use items in tree.
        }
    }
}
