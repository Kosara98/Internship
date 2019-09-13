using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAny
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                nums.Add(i);
            }

            Console.WriteLine(nums.Any());
            Console.WriteLine(nums.CustomAny());

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

            var names = from person in people
                        where person.PetName.CustomAny()
                        select person.LastName;

            var result = pets.Any(p => p.Age > 1 && p.Vaccinated == false);
            var customResult = pets.CustomAny(p => p.Age > 1 && p.Vaccinated == false);

            Console.WriteLine(result);
            Console.WriteLine(customResult);

        }
    }
}
