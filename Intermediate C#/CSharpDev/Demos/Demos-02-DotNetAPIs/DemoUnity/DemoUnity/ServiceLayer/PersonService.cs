using System;

using DemoUnity.DataAccessLayer;

namespace DemoUnity.ServiceLayer
{
    public class PersonService : IPersonService
    {
        private IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            Console.WriteLine("In PersonService constructor");
            this.personRepository = personRepository;
        }

        public void DoSomePersonStuff()
        {
            Console.WriteLine("In PersonService.DoSomePersonStuff()");
            Person p = new Person { ID = 1, Name = "Andy", Age = 21 };
            personRepository.InsertPerson(p);
        }
    }
}
