using System;
using PersonDB.model;
using PersonDB.Repositories;
using System.Linq;

namespace PersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            Person person = new Person("Mikko", 25);
            PersonRepository Repository = new PersonRepository();
            PersonRepository.Create(person);

            var persons = Repository.Get();
            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
