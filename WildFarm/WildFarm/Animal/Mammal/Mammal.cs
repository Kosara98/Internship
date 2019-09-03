namespace WildFarm
{

    public abstract class Mammal :  Animal
    {
        public Mammal(string name, double weight, string livingRegion, int food) : base(name, weight, food)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"[ {this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodQuantity} ]";
        }
    }
}
