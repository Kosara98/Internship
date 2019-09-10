using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringArray();
            QueryIntArray();
            QueryArrayList();
            QueryCollection();
            QueryAnimalData();
        }

        static void QueryStringArray()
        {
            string[] dogs = { "K 9", "Brian Grifin", "Scooby Doo" };

            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }
        }

        static int[] QueryIntArray()
        {
            int[] nums = { 5, 12, 124, 543, 23, 11, 24, 55 };

            var gt20 = from num in nums
                       where num > 20
                       orderby num
                       select num;
            foreach (var item in gt20)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");

            Console.WriteLine($"Get Type : {gt20.GetType()}");

            var listGt20 = gt20.ToList<int>();
            var arrayGt20 = gt20.ToArray();

            nums[0] = 40;

            foreach (var item in gt20)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");
            return arrayGt20;
        }

        static void QueryArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                new Animal
                {
                    Name = "Heidi",
                    Height = 1,
                    Weight = 15
                },

                new Animal
                {
                    Name = "Shrek",
                    Height = 4,
                    Weight = 120
                },

                new Animal
                {
                    Name = "Congo",
                    Height = 3.2,
                    Weight = 90
                }
            };

            var famAnimalEnum = famAnimals.OfType<Animal>();
            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;
            foreach (var animal in smAnimals)
            {
                Console.WriteLine($"{animal.Name} weighs {animal.Weight}lbs");
            }
            Console.WriteLine("---------");
        }

        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200
                }
            };

            var bigDogs = from dog in animalList
                          where (dog.Weight > 70) && (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            foreach (var item in bigDogs)
            {
                Console.WriteLine($"A {item.Name} weighs {item.Weight}");
            }
            Console.WriteLine("---------------");
        }

        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77,
                    AnimalID = 1
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4,
                    AnimalID = 2
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight =  200,
                    AnimalID = 3
                }
            };

            Owner[] owners = new[]
            {
                new Owner
                {
                    Name = "Doug Parks",
                    OwnerID = 1
                },
                new Owner
                {
                    Name = "Sally Smith",
                    OwnerID = 2
                },
                new Owner
                {
                    Name = "Paul Brooks",
                    OwnerID = 3
                }
            };

            var nameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };

            Array arrNameHeight = nameHeight.ToArray();

            foreach (var item in arrNameHeight)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------");

            var innerJoin = from animal in animals
                            join owner in owners on animal.AnimalID equals owner.OwnerID
                            select new
                            {
                                OwnerName = owner.Name,
                                AnimalName = animal.Name
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"{item.OwnerName} owns {item.AnimalName}");
            }
            Console.WriteLine("------");

            var groupJoin = from owner in owners
                            orderby owner.OwnerID
                            join animal in animals
                            on owner.OwnerID
                            equals animal.AnimalID
                            into ownerGroup
                            select new
                            {
                                Owner = owner.Name,
                                Animals = from owner2 in ownerGroup
                                          orderby owner2.Name
                                          select owner2
                            };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.Owner);
                foreach (var i in item.Animals)
                {
                    Console.WriteLine($"* {i.Name}");
                }
            }
        }
    }
}
