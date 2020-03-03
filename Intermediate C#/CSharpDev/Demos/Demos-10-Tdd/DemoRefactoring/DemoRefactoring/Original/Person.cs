using System;

namespace DemoRefactoring.Original
{
    public class Person
    {
        private String name;
        private int age;
        private String mobileTel;
        private String homeTel;
        private String email;

        public Person(String name, int age, String mobileTel, String homeTel, String email)
        {
            this.name = name;
            this.age = age;
            this.mobileTel = mobileTel;
            this.homeTel = homeTel;
            this.email = email;
        }

        public override String ToString()
        {
            return $"Person [name={name}, age={age}, mobileTel={mobileTel}, homeTel={homeTel}, email{email}]";
        }
    }
}
