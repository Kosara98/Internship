﻿using System.Collections.Generic;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodQuantity)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodQuantity = foodQuantity;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodQuantity { get; set; }
        public List<string> FoodEaten { get; set; } = new List<string>();

        public abstract void Talk();
    }
}
