using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PersonDB.model;

namespace PersonDB.Repositories
{
    interface IPersonRepository
    {
        List<Person> Get();
        Person GetPersonById(int id);
        void Create(Person person);
        void Update(int id, Person person);
        void Delete(int id);
    }
}
