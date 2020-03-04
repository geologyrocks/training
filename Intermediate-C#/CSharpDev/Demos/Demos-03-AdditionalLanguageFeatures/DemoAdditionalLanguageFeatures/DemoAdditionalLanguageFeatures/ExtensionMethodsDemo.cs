using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;    // For Assembly class.

namespace DemoAdditionalLanguageFeatures
{
    // String extension methods.
    public static class MyStringExtensionMethods
    {
        public static int CountLetterA(this String str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A' || str[i] == 'a')
                    count++;
            }
            return count;
        }

        public static String UppercaseLetters(this String str, char tobeuppercased)
        {
            StringBuilder sb = new StringBuilder(str);

            for (int i = 0; i < str.Length; i++)
            {
                if (sb[i] == tobeuppercased)
                    sb[i] = char.ToUpper(sb[i]);
            }
            return sb.ToString();
        }
    }

    // Object extension methods.
    public static class MyObjectExtensionMethods
    {
        public static void DisplayDefiningAssembly(this object target)
        {
            Console.WriteLine("{0} lives in {1}",
                target.GetType().Name,
                Assembly.GetAssembly(target.GetType()));
        }
    }

    static class ExtensionMethodsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nAnonymousTypesDemo");
            Console.WriteLine("------------------------------------------------------");

            DemoStringExtensionMethods();
            DemoObjectExtensionMethods();
        }

        private static void DemoStringExtensionMethods()
        {
            string s = "Swansea City";

            Console.WriteLine("{0} contains {1} A's", s, s.CountLetterA());
            Console.WriteLine("{0} transformed is {1}", s, s.UppercaseLetters('a'));
        }

        private static void DemoObjectExtensionMethods()
        {
            string s = "Swansea City";
            System.Data.DataSet ds = new System.Data.DataSet();

            s.DisplayDefiningAssembly();
            ds.DisplayDefiningAssembly();
        }
    }
}
