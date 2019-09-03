using System;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed, int food) : base(name, weight, livingRegion, breed, food)
        {
            this.Weight = weight + (1.00 * food);
            FoodEaten.Add("Meat");
        }
        public override void Talk()
        {
            Console.WriteLine("ROAR!");
        }
    }
}
