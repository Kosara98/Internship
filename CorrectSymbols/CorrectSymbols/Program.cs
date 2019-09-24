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
            
            Console.WriteLine(CheckForSymbols(template,source));
        }

        public static bool CheckForSymbols(string template, string source)
        {
            int inputIndex = 0;
            int templateIndex = 0;
            int countSymbols = 0;
            string nextPartTemplate = null;
            string nextPartSource = null;

            do
            {
                if (source.Length > 0)
                {
                    while (source[inputIndex].Equals(template[inputIndex]))
                    {
                        inputIndex++;

                        if (inputIndex == template.Length - 1 && inputIndex == source.Length - 1)
                            return true;
                        if (inputIndex == source.Length - 1 && inputIndex == template.Length)
                            return false;
                    }

                    if (template[inputIndex] == '*' || template[inputIndex] == '?')
                    {
                        for (int i = inputIndex; i < template.Length; i++)
                        {
                            if (template[i].Equals('*'))
                            {
                                templateIndex++;
                                if (i + 1 < template.Length - 1)
                                {
                                    if (template[i + 1].Equals('?') || template[i + 1].Equals('*'))
                                    {
                                        do
                                        {
                                            templateIndex++;
                                            i++;

                                            if (i + 1 == template.Length)
                                            {
                                                templateIndex--;
                                                break;
                                            }

                                        } while ( template[i].Equals('?') || template[i].Equals('*'));
                                    }
                                }
                                
                                if (i + 1 < template.Length)
                                {
                                    if (!template[i + 1].Equals('*'))
                                        break;
                                }
                            }

                            if (template[i].Equals('?'))
                            {
                                countSymbols++;

                                if (i + 1 < template.Length - 1)
                                {
                                    if (template[i + 1].Equals('*'))
                                    {
                                        inputIndex += countSymbols;
                                        countSymbols = 0;
                                    }
                                                                                
                                }

                                if (i + 1 < template.Length)
                                {
                                    if (!template[i + 1].Equals('?'))
                                        break;
                                }
                            }
                        }

                        templateIndex += inputIndex + countSymbols;

                        if (template[inputIndex] == '*')
                        {
                            if (templateIndex >= template.Length)
                                return true;

                            if (countSymbols > 0)
                                inputIndex += countSymbols;

                            do
                            {
                                inputIndex++;

                                if (inputIndex == source.Length && templateIndex == template.Length - 1  )
                                    return true;
                                if (inputIndex >= source.Length && templateIndex <= template.Length - 1 || source.Length < template.Length)
                                {
                                    if (template[template.Length- 1].Equals(source[source.Length - 1]))
                                        return true;

                                    return false;
                                }
                            } while (!source[inputIndex].Equals(template[templateIndex]));

                            for (int i = templateIndex; i < template.Length; i++)
                                nextPartTemplate += template[i];

                            if (!nextPartTemplate.Contains("?") && !nextPartTemplate.Contains("*"))
                                return true;

                            templateIndex = inputIndex;
                        }
                        else if (template[inputIndex] == '?')
                        {
                            if (templateIndex == template.Length && templateIndex == source.Length)
                                return true;

                            if (templateIndex < template.Length && templateIndex < source.Length)
                            {   
                                while (source[templateIndex].Equals(template[templateIndex]))
                                {
                                    templateIndex++;
                                    if (templateIndex == template.Length && templateIndex == source.Length)
                                        return true;

                                    if (template[templateIndex].Equals('?') || template[templateIndex].Equals('*'))
                                    {
                                        for (int i = templateIndex; i < template.Length; i++)
                                            nextPartTemplate += template[i];

                                        break;
                                    }
                                }
                            }

                            if (nextPartTemplate == null)
                                return false;
                        }

                        for (int i = templateIndex; i < source.Length; i++)
                            nextPartSource += source[i];

                        inputIndex = 0;
                        templateIndex = 0;
                        countSymbols = 0;
                        template = nextPartTemplate;
                        source = nextPartSource;
                        nextPartTemplate = null;
                        nextPartSource = null;
                    }
                    else
                        return false;
                }
                else
                    return false;

            } while (template.Length > 0);

            return true;
        }
    }
}
