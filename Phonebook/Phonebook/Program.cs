using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while(true)
            {
                input = Console.ReadLine().Split(' ');
                if (input[0] == "End" || input[0] == "END")
                    break;

                string name = input[1];
                switch (input[0])
                {
                    case "A":
                        if (phonebook.ContainsKey(name))
                            Console.WriteLine("The name already exist.");
                        else
                            phonebook.Add(name, input[2]);
                        break;
                    case "S":
                        if (phonebook.ContainsKey(name))
                            Console.WriteLine($"{name} -> {phonebook[name]}");
                        else
                            Console.WriteLine($"Contact {name} does not exist.");
                        break;
                    default:
                        Console.WriteLine("The commands are A for Add and S for Search");
                        break;
                }
            }
            
            
        }
    }
}
