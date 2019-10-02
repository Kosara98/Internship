namespace FurnitureShop
{
    public class Clietns
    {
        public Clietns(string name, string address, string bulstat, bool registeredVat, string mol)
        {
            this.Name = name;
            this.Address = address;
            this.Bulstat = bulstat;
            this.RegisteredVat = registeredVat;
            this.Mol = mol;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Bulstat { get; set; }
        public bool RegisteredVat { get; set; }
        public string Mol { get; set; }
    }
}
