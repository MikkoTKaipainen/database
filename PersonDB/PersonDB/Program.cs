using System;
using PersonDB.model;
using PersonDB.Repositories;
using System.Linq;
using System.Collections.Generic;
using PersonDB.ViewPerson;

namespace PersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            UIForConsoleApp();
        }

        public static void UIForConsoleApp()
        {
            ConsoleKeyInfo info;
            PersonRepository personRepository = new PersonRepository();
            do
            {
                Console.Clear();
                Console.WriteLine("Database coding - CRUD");
                Console.WriteLine("Press <ESC> to Exit");
                Console.WriteLine("C) Create");
                Console.WriteLine("R) Read All");
                Console.WriteLine("U) Update");
                Console.WriteLine("D) Delete");
                Console.WriteLine("-------------");
                Console.WriteLine("G) Get by ID");

                info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.C:
                        View.AddPerson();
                        //var person = new Person("Torsti", 25);
                        //personRepository.Create(person);
                        break;
                    case ConsoleKey.R:
                        View.PrintToScreen(personRepository.Get());
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.U:
                        Person updatePerson = personRepository.GetPersonById(4);
                        updatePerson.Name = "JohnsonTakeOver";
                        updatePerson.Age = 555;
                        personRepository.Update(1, updatePerson);
                        break;
                    case ConsoleKey.D:
                        personRepository.Delete(5);
                        break;
                    case ConsoleKey.G:
                        Console.Write("\nSyötä henkilön <id>, jonka tiedot näytetään: ");
                        int id = int.Parse(Console.ReadLine());
                        View.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (info.Key != ConsoleKey.Escape);
        }
    }
}
