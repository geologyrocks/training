using System.Collections.Generic;

namespace DemoUnity.DataAccessLayer
{
    public interface IPersonRepository
    {
        List<Person> GetAllPersons();
        Person GetPersonByID(int id);
        void InsertPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}
