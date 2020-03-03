using System;
using System.Collections.Generic;
using System.Text;

namespace NullableReferenceTypes
{
#nullable enable

    // This code block has "nullable reference types" enabled, so reference types are non-nullable by default.
    class CodeWithNullableChecks
    {
        public static void DoDemo()
        {
            // Some non-nullable variables.
            Employee emp1 = new Employee { Name = "John" };
            Employee emp2 = null;    // Warning

            // Some nullable variables.
            Employee? emp3 = new Employee { Name = "Mary" };
            Employee? emp4 = null;   // OK

            // Invoke a function that takes a non-nullable parameter.
            UseNonNullable(emp1);
            UseNonNullable(emp2);    // Static code analysis sees emp2 is null, so warning here.
            UseNonNullable(emp3);    // Static code analysis sees emp3 isn't null, so no warning here.
            UseNonNullable(emp4);    // Static code analysis sees emp4 is null, so warning here.

            // Invoke a function that takes a non-nullable parameter. No warnings because null is allowed.
            UseNullable(emp1);     
            UseNullable(emp2);
            UseNullable(emp3);
            UseNullable(emp4);
        }

        private static void UseNonNullable(Employee emp)
        {
            // No need for null test, because emp can't be null.
            emp.PayRise(1000);
        }

        private static void UseNullable(Employee? emp)
        {
            // Warning here, because emp could be null, so the code should cater for that possibility.
            emp.PayRise(2000);
        
            // To avoid warning, wrap code in null-test as shown here.
            if (emp != null)
            {
                emp.PayRise(3000);
            }

            // Can also use the safe navigation operator.
            emp?.PayRise(4000);

            // Warning here, trying to invoke a function that doesn't expect nulls.
            UseNonNullable(emp);
        }
    }
#nullable restore
}
