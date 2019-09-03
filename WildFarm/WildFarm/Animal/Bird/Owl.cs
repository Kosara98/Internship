using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize, int food) : base(name, weight, wingSize, food)
        {
            FoodEaten.Add("Meat");
        }
        public override void GainWeight(double weight, int food)
        {
            this.Weight = weight + (0.40 * food);
        }
        public override void Talk()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
