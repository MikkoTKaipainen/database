using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonDB.model;

namespace PersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private Tehtävä1Context _context = new Tehtävä1Context();

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
                return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public void Update(int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                updatePerson.Name = person.Name;
                updatePerson.Age = person.Age;
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
                _context.Person.Remove(delPerson);
            _context.SaveChanges();
        }

        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _context.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }
    }
}
