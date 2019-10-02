namespace FurnitureShop
{
    public class Products
    {
        public Products(string name, string description, double weight, string barcode, double price)
        {
            this.Name = name;
            this.Descripton = description;
            this.Weight = weight;
            this.Barcode = barcode;
            this.Price = price;
        }

        public string Name { get; set; }
        public string Descripton { get; set; }
        public double Weight { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
    }
}
