using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> listOfResources = new Dictionary<string, int>();

            while (true)
            {
                string resources = Console.ReadLine();
                if (resources == "stop")
                    break;

                int quantity = Int32.Parse(Console.ReadLine());
                if (quantity <= 0 || quantity > 2000000000)
                    Console.WriteLine("The quantity is out of the range (1, 2 000 000 000)");

                if (listOfResources.ContainsKey(resources))
                    listOfResources[resources] +=  quantity;
                else
                    listOfResources.Add(resources, quantity);
            }

            foreach (KeyValuePair<string, int> item in listOfResources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
