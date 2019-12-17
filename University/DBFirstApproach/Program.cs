using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBFirstApproach
{
    class Program
    {
        static string choosenOption;
        static ProfessorRepository profRepo = new ProfessorRepository();
        static StudentRepository studentRepo = new StudentRepository();
        static SubjectRepository subjectRepo = new SubjectRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1.Professors");
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
                Options(profRepo);
            else if (choosenTable == "2")
                Options(studentRepo);
            else if (choosenTable == "3")
                Options(subjectRepo);
            else
                Console.WriteLine("Choose number between 1 and 3");
        }

        public static void Options<T>(UniRepository<T> repository) where T: BaseModel
        {
            var student = new Student();
            var subject = new Subject();

            switch (choosenOption)
            {
                case "1":
                    Console.WriteLine($"All are:");
                    var all = repository.GetAll();

                    foreach (var item in all)
                            Console.WriteLine(item.ToString());
                    break;
                case "2":
                    if (repository.GetType() == studentRepo.GetType())
                        NewStudent();
                    else if (repository.GetType() == subjectRepo.GetType())
                        NewSubject();
                    else
                    {
                        var newProf = new Professor();
                        Console.WriteLine("Name");
                        newProf.Name = Console.ReadLine();
                        profRepo.Add(newProf);
                    }
                    break;
                case "3":
                    Console.WriteLine("Which do you want to update?");
                    string nameTarget = Console.ReadLine();
                    var updatedItem = repository.GetAll().FirstOrDefault(item => item.Name == nameTarget);

                    if (updatedItem.GetType() == student.GetType())
                        nameTarget = ""; //NewStudent();
                    else if (updatedItem.GetType() == subject.GetType())
                        nameTarget = ""; //NewSubject();
                    else
                    {
                        Console.WriteLine("Name");
                        updatedItem.Name = Console.ReadLine();
                    }

                    repository.Update(updatedItem);
                    break;
                case "4":
                    Console.WriteLine("Which one do you want delete?");
                    string target = Console.ReadLine();
                    var deleteItem = repository.GetAll().FirstOrDefault(item => item.Name == target);
                    repository.Delete(deleteItem);
                    break;
                default:
                    Console.WriteLine("Pick number between 1 and 4");
                    break;
            }
            Console.WriteLine("Successful");
        }

        public static void UpdateStudent(Student student)
        {
            Console.WriteLine("Name:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Faculty number:");
            student.FacultyNumber = Console.ReadLine();
        }

        public static void NewStudent()
        {
            var student = new Student();

            Console.WriteLine("Name");
            student.Name = Console.ReadLine();
            Console.WriteLine("Faculty number:");
            student.FacultyNumber = Console.ReadLine();
            studentRepo.Add(student);
        }

        public static void NewSubject()
        {
            var subject = new Subject();

            Console.WriteLine("Name");
            subject.Name = Console.ReadLine();
            Console.WriteLine("Description:");
            subject.Description = Console.ReadLine();
            Console.WriteLine("Professor:");
            string profName = Console.ReadLine();
            var professor = profRepo.GetAll().FirstOrDefault(item => item.Name == profName);
            subject.ProfessorId = professor.Id;

            subjectRepo.Add(subject);
        }
    }
}
