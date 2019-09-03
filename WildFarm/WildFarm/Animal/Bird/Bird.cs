namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name,double weight, double wingSize, int food) : base(name, weight, food)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"[ {this.Name}, {this.WingSize}, {this.Weight}, {this.FoodQuantity} ]";
        }
    }
}
