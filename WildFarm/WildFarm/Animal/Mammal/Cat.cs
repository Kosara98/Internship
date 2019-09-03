using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Cat : Feline
    {
        
        
        public Cat(string name, double weight, string breed, string livingRegion, int food) : base(name, weight, breed, livingRegion, food)
        {
            this.Weight = weight + (0.30 * food);
            FoodEaten.Add("Vegetable");
            FoodEaten.Add("Meat");
        }
        public override void Talk()
        {
            Console.WriteLine("Meow!");
        }
        
    }
}
