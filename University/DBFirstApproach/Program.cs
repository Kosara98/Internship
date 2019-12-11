using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    class Program
    {
        static string choosenOption;
        static ProfesseurRepository prof = new ProfesseurRepository();

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
            choosenOption = Console.ReadLine();

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
            var student = new StudentRepository();

            switch (choosenOption)
            {
                case "1":
                    var students = new List<Student>();
                    Console.WriteLine("All the students are:");
                    students.AddRange(student.GetAll());
                    //List<StudentsSubjects> subjects = student.Subjects();

                    foreach (var item in students)
                    {
                        Console.WriteLine($"{item.Name} - {item.FacultyNumber}");
                        //foreach (var i in subjects)
                        //    if (i.Student.Id == item.Id)
                        //     Console.WriteLine($"{i.Subject.Name}");
                    }   
                    break;
                case "2":
                    var newStudent = new Student();

                    Console.WriteLine("Name of the student:");
                    newStudent.Name = Console.ReadLine();
                    Console.WriteLine("Faculty number:");
                    newStudent.FacultyNumber = Console.ReadLine();

                    student.Add(newStudent);
                    break;
                case "3":
                    break;
                case "4":
                    var deleteStudent = new List<Student>();
                    Console.WriteLine("Student you want to delete");
                    string deleteName = Console.ReadLine();
                    //deleteStudent.AddRange(student.Search(deleteName));
                    int deleteId = 0;

                    if (deleteStudent.Count > 1)
                    {
                        foreach (var item in deleteStudent)
                            Console.WriteLine($"{item.Id} - {item.Name}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    student.Delete(deleteStudent[deleteId]);
                    break;
                default:
                    Console.WriteLine("There is not such option");
                    break;
            }
        }

        public static void Subjects()
        {
            var subject = new SubjectRepository();

            switch (choosenOption)
            {
                case "1":
                    var subjects = new List<Subject>();
                    Console.WriteLine("All the subjects are:");
                    subjects.AddRange(subject.GetAll());

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
                    //Professeur lector = prof.Search(name[0]).FirstOrDefault(item => item.LastName == name[1]);
                    //newSubject.ProfesseurId = lector.Id;

                    subject.Add(newSubject);
                    break;
                case "3":
                    break;
                case "4":
                    var deleteSubjects = new List<Subject>();
                    Console.WriteLine("Name you want to delete");
                    string deleteName = Console.ReadLine();
                    //List<Subject> deleteSubjects = subject.Search(deleteName);
                    int deleteId = 0;

                    if (deleteSubjects.Count > 1)
                    {
                        foreach (var item in deleteSubjects)
                            Console.WriteLine($"{item.Id} - {item.Name}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    subject.Delete(deleteSubjects[deleteId]);
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
                    var profs = new List<Professeur>();
                    Console.WriteLine("All the professeurs are:");
                    profs.AddRange(prof.GetAll());

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
                    var profTarget = new List<Professeur>();
                    Console.WriteLine("Which one do you want to update?");
                    string updateTarget = Console.ReadLine();
                    profTarget.AddRange(prof.Search(updateTarget));

                    Console.WriteLine("New first name:");
                    updateProf.FirstName = Console.ReadLine();
                    Console.WriteLine("New last name:");
                    updateProf.LastName = Console.ReadLine();

                    prof.Update(profTarget[0],updateProf);
                    break;
                case "4":
                    var professeurs = new List<Professeur>();
                    Console.WriteLine("Which one do you want to delete?");
                    string deleteTarget = Console.ReadLine();
                    professeurs.AddRange(prof.Search(deleteTarget));
                    int deleteId = 0;

                    if (professeurs.Count > 1)
                    {
                        foreach (var item in professeurs)
                            Console.WriteLine($"{item.Id} - {item.FirstName} {item.LastName}");
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }

                    prof.Delete(professeurs[deleteId]);
                    break;
                default:
                    Console.WriteLine("There is not such option");
                    break;
            }
        }
    }
}
