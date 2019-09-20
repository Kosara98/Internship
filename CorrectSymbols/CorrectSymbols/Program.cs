using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the template string with * and ?");
            string template = Console.ReadLine();

            Console.WriteLine("Write the sequence you want to check");
            string source = Console.ReadLine();

            Console.WriteLine(CheckForSymbols(template, source));
        }

        public static bool CheckForSymbols(string template, string source)
        {
            int index = 0;
            int templateIndex = 0;
            int countSymbols = 0;

            while (source[index].Equals(template[index]))
            {
                index++;

                if (index > template.Length - 1)
                    return true;
            }
            
            AnotherCase:
            if (template[index] == '*')
            {
                for (int i = index; i < template.Length; i++)
                {
                    if (template[i].Equals('*'))
                        templateIndex++;

                    if (i + 1 < template.Length)
                    {
                        if (!template[i + 1].Equals('*'))
                            break;
                    }
                }
                templateIndex += index;

                do
                {
                    index++;

                    if (templateIndex == template.Length)
                        return true;
                    if (index == source.Length && templateIndex != template.Length)
                        return false;

                } while (!source[index].Equals(template[templateIndex]));

                if (source[index].Equals(template[templateIndex]))
                    return true;
            }
            if (template.Contains("?"))
            {
                if (template[index + 1] == '*')
                {
                    index++;
                    goto AnotherCase;
                }
                

                if (template[index] == '?')
                {
                    for (int i = index; i < template.Length; i++)
                    {
                        if (template[i].Equals('?'))
                            countSymbols++;

                        if(i + 1 < template.Length)
                        {
                            if (!template[i + 1].Equals('?'))
                                break;
                        }
                    }

                    templateIndex = index + countSymbols;

                    if (templateIndex < template.Length)
                    {
                        if (!template[templateIndex].Equals(source[templateIndex]))
                            return false;
                   
                        if (templateIndex == template.Length - 1 && templateIndex == source.Length - 1)
                            return true;
                       
                        for (int i = templateIndex; i < source.Length; i++)
                        {
                            if (i == template.Length - 1)
                                break;

                            if (template[i].Equals('*'))
                            {
                                index = templateIndex;
                                templateIndex = 0;
                                goto AnotherCase;
                            }

                            if (i == source.Length - 1)
                                return false;
                        }
                        if (source.Length - 1 == templateIndex)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
