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
                if (input[0].Equals("end",StringComparison.InvariantCultureIgnoreCase))
                    break;

                //string name = input[1];
                switch (input[0])
                {
                    case "A":
                        if (phonebook.ContainsKey(input[1]))
                            Console.WriteLine("The name already exist.");
                        else
                            phonebook.Add(input[1], input[2]);
                        break;
                    case "S":
                        if (phonebook.ContainsKey(input[1]))
                            Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                        else
                            Console.WriteLine($"Contact {input[1]} does not exist.");
                        break;
                    case "ListAll":
                        foreach (KeyValuePair<string, string> item in phonebook)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                        }
                        break;
                    default:
                        Console.WriteLine("The commands are A for Add and S for Search");
                        break;
                }
            }
            
            
        }
    }
}
