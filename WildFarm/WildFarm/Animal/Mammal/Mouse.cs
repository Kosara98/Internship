using System;

namespace WildFarm
{
    public class  Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion, int food) : base(name, weight, livingRegion, food)
        {
            this.Weight = weight + (0.10 * food);
            FoodEaten.Add("Vegetable");
            FoodEaten.Add("Fruit");
        }
        public override void Talk()
        {
            Console.WriteLine("Squeak!");
        }
    }
}
