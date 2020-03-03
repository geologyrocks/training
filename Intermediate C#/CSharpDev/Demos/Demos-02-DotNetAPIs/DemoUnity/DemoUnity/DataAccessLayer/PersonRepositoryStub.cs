using System;
using System.Collections.Generic;

namespace DemoUnity.DataAccessLayer
{
    public class PersonRepositoryStub : IPersonRepository
    {
        public PersonRepositoryStub(string param = "[Default]")
        {
            Console.WriteLine($"In PersonRepositoryStub constructor with param={param}");
        }

        public List<Person> GetAllPersons()
        {
            Console.WriteLine("In PersonRepositoryStub.GetAllPersons()");
            return new List<Person>();
        }

        public Person GetPersonByID(int id)
        {
            Console.WriteLine("In PersonRepositoryStub.GetPersonByID()");
            return new Person();
        }

        public void InsertPerson(Person person)
        {
            Console.WriteLine("In PersonRepositoryStub.InsertPerson()");
        }

        public void UpdatePerson(Person person)
        {
            Console.WriteLine("In PersonRepositoryStub.UpdatePerson()");
        }

        public void DeletePerson(int id)
        {
            Console.WriteLine("In PersonRepositoryStub.DeletePerson()");
        }
    }
}
