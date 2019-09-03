using System;
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
            List<Animal> animals = new List<Animal>();
            string[] info;

            while(true)
            {  
                info = Console.ReadLine().Split(' ');

                if (info[0] == "End")
                {
                    break;
                }
                string[] food = Console.ReadLine().Split(' ');

                string notEating = "does not eat";

                switch (info[0])
                {
                    case "Cat":
                        Cat cat = new Cat(info[1], Convert.ToDouble(info[2]), info[3], info[4], Convert.ToInt32(food[1]));
                        cat.Talk();
                        if (!cat.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            cat.Weight -= 0.30 * Convert.ToInt32(food[1]);
                            cat.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(cat);
                        break;
                    case "Tiger":
                        Tiger tiger = new Tiger(info[1], Convert.ToDouble(info[2]), info[3], info[4], Convert.ToInt32(food[1]));
                        tiger.Talk();
                        if (!tiger.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            tiger.Weight -= 1 * Convert.ToInt32(food[1]);
                            tiger.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(tiger);
                        break;
                    case "Hen":
                        Hen hen = new Hen(info[1], Convert.ToDouble(info[2]), Convert.ToDouble(info[3]), Convert.ToInt32(food[1]));
                        hen.Talk();
                        if (!hen.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            hen.Weight -= 0.35 * Convert.ToInt32(food[1]);
                            hen.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(hen);
                        break;
                    case "Owl":
                        Owl owl = new Owl(info[1], Convert.ToDouble(info[2]), Convert.ToDouble(info[3]), Convert.ToInt32(food[1]));
                        owl.Talk();
                        if (!owl.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            owl.Weight -= 0.40 * Convert.ToInt32(food[1]);
                            owl.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(owl);
                        break;
                    case "Mouse":
                        Mouse mouse = new Mouse(info[1], Convert.ToDouble(info[2]), info[3], Convert.ToInt32(food[1]));
                        mouse.Talk();
                        if (!mouse.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            mouse.Weight -= 0.10 * Convert.ToInt32(food[1]);
                            mouse.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(mouse);
                        break;
                    case "Dog":
                        Dog dog = new Dog(info[1], Convert.ToDouble(info[2]), info[3], Convert.ToInt32(food[1]));
                        dog.Talk();
                        if (!dog.FoodEaten.Contains(food[0]))
                        {
                            Console.WriteLine($"{info[0]} {notEating} {food[0]}");
                            dog.Weight -= 0.40 * Convert.ToInt32(food[1]);
                            dog.FoodQuantity -= Convert.ToInt32(food[1]);
                        }
                        animals.Add(dog);
                        break;
                    default:
                        Console.WriteLine($"{info[0]} does not exist.");
                        break;
                }
            } 

            foreach (var animal in animals)
                Console.WriteLine(animal.ToString());
        }
    }
}
