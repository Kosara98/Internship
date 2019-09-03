using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info;
            List<Animal> animals = new List<Animal>();
            while (true)
            {  
                info = Console.ReadLine().Split(' ');

                if (info[0] == "End")
                {
                    break;
                }
                string[] food = Console.ReadLine().Split(' ');
                Animal animal = null;
                switch (info[0])
                {
                    case "Cat":
                        animal = new Cat(info[1], Convert.ToDouble(info[2]), info[3], info[4], Convert.ToInt32(food[1]));
                        break;
                    case "Tiger":
                        animal = new Tiger(info[1], Convert.ToDouble(info[2]), info[3], info[4], Convert.ToInt32(food[1]));
                        break;
                    case "Hen":
                        Hen hen = new Hen(info[1], Convert.ToDouble(info[2]), Convert.ToDouble(info[3]), Convert.ToInt32(food[1]));
                        break;
                    case "Owl":
                        Owl owl = new Owl(info[1], Convert.ToDouble(info[2]), Convert.ToDouble(info[3]), Convert.ToInt32(food[1]));
                        break;
                    case "Mouse":
                        Mouse mouse = new Mouse(info[1], Convert.ToDouble(info[2]), info[3], Convert.ToInt32(food[1]));
                        break;
                    case "Dog":
                        Dog dog = new Dog(info[1], Convert.ToDouble(info[2]), info[3], Convert.ToInt32(food[1]));;
                        break;
                    default:
                        Console.WriteLine($"{info[0]} does not exist.");
                        break;
                }
                animal.Talk();
                animal.Eat(food[0], food[1],animal);
                animals.Add(animal);
            }

            foreach (var animal in animals)
              Console.WriteLine(animal.ToString());
           
        }
    }
}
