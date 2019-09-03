using System;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize, int food) : base(name, weight,wingSize, food)
        {
            FoodEaten.Add("Vegetable");
            FoodEaten.Add("Meat");
            FoodEaten.Add("Seed");
            FoodEaten.Add("Fruit");
        }
        public override void GainWeight(double weight, int food)
        {
            this.Weight = weight + (0.35 * food);
        }
        public override void Talk()
        {
            Console.WriteLine("Cluck");
        }
    }
}
