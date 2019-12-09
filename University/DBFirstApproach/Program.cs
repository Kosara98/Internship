using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    class Program
    {
        static string choosenOption;
        static Professeur prof = new Professeur();

        static void Main(string[] args)
        {
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
            choosenOption = Console.ReadLine();

            //var subjects = new List<StudentsSubjects>();

            //using (var db = new UniversityProgramContext())
            //{
            //    subjects = db.StudentsSubjects.Include(item => item.Subject).Include(i => i.Student).ToList();
            //}

            //foreach (var item in subjects)
            //    Console.WriteLine($"{item.Student.Name} - {item.Subject.Name}");
            if (choosenTable == "1")
                Professeurs();
            else if (choosenTable == "2")
                Students();
            else if (choosenTable == "3")
                Subjects();
            else
                Console.WriteLine("Choose number between 1 and 3");
        }

        public static void Students()
        {
            var student = new Student();

            switch (choosenOption)
            {
                case "1":
                    Console.WriteLine("All the students are:");
                    List<Student> students = student.GetAll();
                    List<StudentsSubjects> subjects = student.Subjects();

                    foreach (var item in students)
                    {
                        Console.WriteLine($"{item.Name} - {item.FacultyNumber}");
                        foreach (var i in subjects)
                            if (i.Student.Id == item.Id)
                             Console.WriteLine($"{i.Subject.Name}");
                    }   
                    break;
                case "2":
                    var newStudent = new Student();

                    Console.WriteLine("Name of the student:");
                    newStudent.Name = Console.ReadLine();
                    Console.WriteLine("Faculty number:");
                    newStudent.FacultyNumber = Console.ReadLine();

                    newStudent.Add();
                    break;
                case "3":
                    break;
                case "4":
                    Console.WriteLine("Student you want to delete");
                    string deleteName = Console.ReadLine();
                    List<Student> deleteStudent = student.Search(deleteName);
                    int deleteId = 0;

                    if (deleteStudent.Count > 1)
                    {
                        foreach (var item in deleteStudent)
                            Console.WriteLine($"{item.Id} - {item.Name}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    deleteStudent[deleteId].Delete();
                    break;
                case "5":
                    Console.WriteLine("Enter the name of the student you want to find");
                    string searchName = Console.ReadLine();

                    Console.WriteLine("Results:");
                    List<Student> searchResult = student.Search(searchName);

                    foreach (var item in searchResult)
                        Console.WriteLine($"{item.Name} - {item.FacultyNumber}");
                    break;
                default:
                    Console.WriteLine("There is not such option");
                    break;
            }
        }

        public static void Subjects()
        {
            var subject = new Subject();

            switch (choosenOption)
            {
                case "1":
                    Console.WriteLine("All the subjects are:");
                    List<Subject> subjects = subject.GetAll();

                    foreach (var item in subjects)
                        Console.WriteLine($"{item.Name} - {item.Description} - {item.Professeur.FirstName} {item.Professeur.LastName}");
                    break;
                case "2":
                    var newSubject = new Subject();

                    Console.WriteLine("Name of the subject:");
                    newSubject.Name = Console.ReadLine();
                    Console.WriteLine("Description:");
                    newSubject.Description = Console.ReadLine();
                    Console.WriteLine("Professeur's name");
                    string[] name = Console.ReadLine().Split(' ');
                    Professeur lector = prof.Search(name[0]).FirstOrDefault(item => item.LastName == name[1]);
                    newSubject.ProfesseurId = lector.Id;

                    newSubject.Add();
                    break;
                case "3":
                    
                    break;
                case "4":
                    Console.WriteLine("Name you want to delete");
                    string deleteName = Console.ReadLine();
                    List<Subject> deleteSubjects = subject.Search(deleteName);
                    int deleteId = 0;

                    if (deleteSubjects.Count > 1)
                    {
                        foreach (var item in deleteSubjects)
                            Console.WriteLine($"{item.Id} - {item.Name}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    deleteSubjects[deleteId].Delete();
                    break;
                case "5":
                    Console.WriteLine("Enter name:");
                    string subjectName = Console.ReadLine();

                    Console.WriteLine("All the subjects are:");
                    List<Subject> searchResult = subject.Search(subjectName);
                    
                    foreach (var item in searchResult)
                        Console.WriteLine($"{item.Name} - {item.Professeur.FirstName} {item.Professeur.LastName} - {item.Description}");
                    break;
                default:
                    Console.WriteLine("There is not such option");
                    break;
            }
        }

        public static void Professeurs()
        {
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

                    newProf.Add();
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

                    profTarget[0].Update( updateProf);
                    break;
                case "4":
                    Console.WriteLine("Which one do you want to delete?");
                    string deleteTarget = Console.ReadLine();
                    List<Professeur> professeurs = prof.Search(deleteTarget);
                    int deleteId = 0;

                    if (professeurs.Count > 1)
                    {
                        foreach (var item in professeurs)
                            Console.WriteLine($"{item.Id} - {item.FirstName} {item.LastName}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    professeurs[deleteId].Delete();
                    break;
                case "5":
                    Console.WriteLine("Enter first name:");
                    string name = Console.ReadLine();

                    List<Professeur> searchResult = prof.Search(name);

                    foreach (var item in searchResult)
                        Console.WriteLine($"{item.FirstName} {item.LastName}");
                    break;
                default:
                    Console.WriteLine("There is not such option");
                    break;
            }
        }
    }
}
