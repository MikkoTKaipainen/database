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
                        var person = new Person("Masa", 25);
                        personRepository.Create(person);
                        break;
                    case ConsoleKey.R:
                        View.PrintToScreen(personRepository.Get());
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.U:
                        Person updatePerson = personRepository.GetPersonById(10);
                        updatePerson.Name = "James Bond";
                        updatePerson.Age = 55;
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
                        Console.WriteLine("\nProgram end after 3 sec!");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;
                    default:
                        Console.WriteLine("\nWrong KEY - try again!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }

            } while (info.Key != ConsoleKey.Escape);
        }
    }
}
