using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonDB.model;

namespace PersonDB.Repositories
{
    class PersonRepository
    {
        private static Tehtävä1Context _context = new Tehtävä1Context();

        public static void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public static List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
                return persons;
        }

        public static Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public static void Update(int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }

        public static void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
                _context.Person.Remove(delPerson);
            _context.SaveChanges();
        }
    }
}
