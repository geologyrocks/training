using System;
using System.Collections.Generic;
using System.Text;

namespace NullableReferenceTypes
{
    // This code block doesn't have "nullable reference types" enabled, so all reference types could possibly be null.
    class CodeWithoutNullableChecks
    {
        public static void DoDemo()
        {
            // Because we haven't enabled "nullable reference types", all reference types could be null.
            Employee emp1 = new Employee { Name = "John" };
            Employee emp2 = null;

            // Invoke a function that takes a reference parameter and does NOT check for nulls.
            UseNullableUnsafe(emp1);
            UseNullableUnsafe(emp2);

            // Invoke a function that takes a reference parameter and checks for nulls.
            UseNullableSafe(emp1);
            UseNullableSafe(emp2);
        }

        private static void UseNullableUnsafe(Employee emp)
        {
            // emp could be a null reference, so the following could cause a NullReferenceException.
            emp.PayRise(1000);
            Console.WriteLine(emp);
        }

        private static void UseNullableSafe(Employee emp)
        {
            // emp could be a null reference, so the safe approach is to test for null.
            if (emp != null)
            {
                emp.PayRise(2000);
            }

            // Can also use the safe navigation operator.
            emp?.PayRise(3000);

            Console.WriteLine(emp);
        }
    }
}
