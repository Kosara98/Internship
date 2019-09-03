namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed, int food) : base(name, weight, livingRegion, food)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            return $"[ {this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodQuantity}]";
        }
    }
}
