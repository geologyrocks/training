using System;
using System.Collections.Generic;
using System.Text;

namespace NullableReferenceTypes
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; } = 0.0;

        public void PayRise(double amount) => Salary += amount;

        public override string ToString()
        {
            return $"{Name} earns {Salary:c}";
        }
    }
}
