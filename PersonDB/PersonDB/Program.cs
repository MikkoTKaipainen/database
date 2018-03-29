using System;
using PersonDB.model;
using PersonDB.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace PersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            Person person = new Person()
            {
                Name = "Terho",
                Age = 33,
                Phone = new List<Phone>
                {
                    new Phone {Number = "0504004000", Type = "Work"},
                    new Phone {Number = "0405005000", Type = "Home"}
                }
            };


            PersonRepository Repository = new PersonRepository();
            Repository.Create(person);

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
