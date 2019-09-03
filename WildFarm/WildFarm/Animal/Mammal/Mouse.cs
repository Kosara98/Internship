using System;

namespace WildFarm
{
    public class  Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion, int food) : base(name, weight, livingRegion, food)
        {
            FoodEaten.Add("Vegetable");
            FoodEaten.Add("Fruit");
        }
        public override void GainWeight(double weight, int food)
        {
            this.Weight = weight + (0.10 * food);
        }
        public override void Talk()
        {
            Console.WriteLine("Squeak!");
        }
    }
}
