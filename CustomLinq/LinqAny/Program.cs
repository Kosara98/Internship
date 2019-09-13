using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { LastName = "Haas",PetName = "Barley"},                        
                new Person { LastName = "Fakhouri",PetName = "Snowball"},
                new Person { LastName = "Antebi",PetName = "" },
                new Person { LastName = "Philips",PetName = "Sweetie"}                       
            };

            Pet[] pets =
            {
                new Pet { Name="Barley", Age=8, Vaccinated=false },
                new Pet { Name="Boots", Age=4, Vaccinated=false },
                new Pet { Name="Whiskers", Age=1, Vaccinated=false }
            };

            //Any 
            var names = from person in people
                        where person.PetName.CustomAny()
                        select person.LastName;

            var result = pets.Any(p => p.Age > 1 && p.Vaccinated == false);
            var customResult = pets.CustomAny(p => p.Age > 1 && p.Vaccinated == false);

            Console.WriteLine(result);
            Console.WriteLine(customResult);
            
            // First or Default
            Console.WriteLine("----------");
            var firstName = people.CustomFirstOrDefault();
            Console.WriteLine(firstName.LastName);

            List<int> nums = new List<int>();
            Console.WriteLine(nums.CustomFirstOrDefault());

            var firstPetOverOne = pets.CustomFirstOrDefault(x => x.Age > 1);
            Console.WriteLine(firstPetOverOne.Name);

            //First
            Console.WriteLine("----------");
            var firstResult = people.CustomFirst(x => x.PetName == "");
            Console.WriteLine(firstResult.LastName);

            //Reverse
            char[] apple = { 'a', 'p', 'p', 'l', 'e' };
            char[] reversed = apple.CustomReverse().ToArray();

            foreach (char chr in reversed)
                Console.Write(chr);

            //Contains
            var doesItContains = apple.Contains('p');
            Console.WriteLine(doesItContains);

            //Concats
            List<int> numbers = new List<int>();
            for (int i = 0; i < 10; i++)
                numbers.Add(i);

            for (int i = 0; i < 4; i++)
                nums.Add(i);

            var numsAndNumbers = numbers.CustomConcat(nums).ToArray();

            Console.WriteLine("--------");

            foreach (var item in numsAndNumbers)
                Console.WriteLine(item);

            //Skip
            var skipTwoNumbers = numbers.OrderBy(x => x).CustomSkip(2);
            Console.WriteLine("-----------");

            //foreach (var item in skipTwoNumbers)
            //    Console.WriteLine(item);

            //Take
            var takeTwoNumbers = numbers.CustomTake(2);

            foreach (var item in takeTwoNumbers)
                Console.WriteLine(item);

            //OfType
            ArrayList fruits = new ArrayList(3);
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);

            var onlyFruits = fruits.CustomOfType<string>();

            foreach (var item in onlyFruits)
                Console.WriteLine(item);

            //Intersect
            var numResult = numbers.CustomIntersect(nums);

            foreach (var item in numResult)
                Console.WriteLine(item);

            //Where
            var personWithoutPet = people.CustomWhere(x => x.PetName == "");

            foreach (var item in personWithoutPet)
                Console.WriteLine(item.LastName);
        }
    }
}
