using System;
using System.Collections.Generic;

namespace DBFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            var prof = new Professeur();
            var subj = new Subject();

            Console.WriteLine("Pick a number:");
            Console.WriteLine("1.Professuers");
            Console.WriteLine("2.Students");
            Console.WriteLine("3.Subjects");
            string choosenTable = Console.ReadLine();

            Console.WriteLine("Choose action:");
            Console.WriteLine("1.Show all");
            Console.WriteLine("2.Add new");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");
            Console.WriteLine("5.Search");
            string choosenOption = Console.ReadLine();

            switch (choosenOption)
            {
                case "1":
                    Console.WriteLine("All the professeurs are:");
                    List<Professeur> profs = prof.GetAll();

                    foreach (var item in profs)
                        Console.WriteLine($"{item.FirstName} {item.LastName}");
                    break;
                case "2":
                    var newProf = new Professeur();

                    Console.WriteLine("First name:");
                    newProf.FirstName = Console.ReadLine();
                    Console.WriteLine("Last name:");
                    newProf.LastName = Console.ReadLine();

                    prof.Add(newProf);
                    Console.WriteLine("Succsefull");
                    break;
                case "3":
                    var updateProf = new Professeur();

                    Console.WriteLine("Which one do you want to update?");
                    string updateTarget = Console.ReadLine();
                    List<Professeur> profTarget = prof.Search(updateTarget);

                    Console.WriteLine("New first name:");
                    updateProf.FirstName = Console.ReadLine();
                    Console.WriteLine("New last name:");
                    updateProf.LastName = Console.ReadLine();

                    prof.Update(profTarget[0], updateProf);
                    break;
                case "4":
                    Console.WriteLine("Which one do you want to delete?");
                    string deleteTarget = Console.ReadLine();
                    List<Professeur> professeurs = prof.Search(deleteTarget);

                    prof.Delete(professeurs[0]);
                    break;
                case "5":
                    Console.WriteLine("Enter first name:");
                    string name = Console.ReadLine();

                    List<Professeur> searchResult = prof.Search(name);

                    foreach (var item in searchResult)
                        Console.WriteLine($"{item.FirstName} {item.LastName}");
                    break;
                default:
                    break;
            }
        }
    }
}
