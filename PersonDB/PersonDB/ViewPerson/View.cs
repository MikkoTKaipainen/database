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
    }
}