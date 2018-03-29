using System;
using System.Collections.Generic;
using System.Text;
using PersonDB.model;
using PersonDB.Repositories;

namespace PersonDB.ViewPerson
{
    class View
    {
        public static void PrintToScreen(List<Person> persons)
        {
            Console.WriteLine("Id, Name, Age\n" +
                              "-------------------\n");
            foreach (var p in persons)
            {
                Console.WriteLine(p.ShowData());
            }
        }

        public static void PrintToScreen(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
            if (person.Phone.Count == 0)
                Console.WriteLine("Ei puhelinta!");
            foreach (var phnPhone in person.Phone)
            {
                Console.WriteLine($"\n   {phnPhone.ToString()}");
            }
            Console.WriteLine("\n-------------\n");
        }

        public static void AddPerson()
        {
            Console.Write("Type your name:  ");
            string name = Console.ReadLine();
            Console.Write("Type your age:  ");
            short age = short.Parse(Console.ReadLine());

            List<Phone> phones = new List<Phone>();
            string addAnotherPhone = "Y";
            do
            {
                Console.Write("Type your phone:  ");
                string addPhone = Console.ReadLine();
                Console.Write("Your phone type <Home/Work>:  ");
                string addType = Console.ReadLine();
                Console.Write("Add another phone? <Y/N>");
                addAnotherPhone = Console.ReadLine().ToUpper();
            }
            while (addAnotherPhone == "Y");

            var addPerson = new Person(name, age, phones);
            PersonRepository personRepository = new PersonRepository();
            personRepository.Create(addPerson);
        }
    }
}