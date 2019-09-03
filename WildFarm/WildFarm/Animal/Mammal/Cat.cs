using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string breed, string livingRegion, int food) : base(name, weight, breed, livingRegion, food)
        {
            FoodEaten.Add("Vegetable");
            FoodEaten.Add("Meat");
        }
        
        public override void GainWeight(double weight, int food)
        {
            this.Weight = weight + (0.30 * food);
        }
        public override void Talk()
        {
            Console.WriteLine("Meow!");
        }
        
    }
}
