using System;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion, int food) : base(name, weight, livingRegion, food )
        {
            FoodEaten.Add("Meat");
        }
        public override void GainWeight(double weight, int food)
        {
            this.Weight = weight + (0.40 * food);
        }
        public override void Talk()
        {
            Console.WriteLine("Woof!");
        }
    }
}
