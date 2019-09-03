using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize, int food) : base(name, weight, wingSize, food)
        {
            this.Weight = weight + (0.40 * food);
            FoodEaten.Add("Meat");
        }
        public override void Talk()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
