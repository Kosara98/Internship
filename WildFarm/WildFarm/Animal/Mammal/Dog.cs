using System;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion, int food) : base(name, weight, livingRegion, food)
        {
            this.Weight = weight + (0.40 * food);
            FoodEaten.Add("Meat");
        }
        public override void Talk()
        {
            Console.WriteLine("Woof!");
        }
    }
}
