using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Machine
{
    public class MenuItem
    {
        public string Name { get; set; }    
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Dictionary<string, double> Ingredients { get; set; } // สำหรับการจัดการส่วนผสม

        public MenuItem()
        {
            Ingredients = new Dictionary<string, double>();
        }

        public double GetTotalPrice()
        {
            return Price * Quantity;
        }

        public void UseIngredients(Dictionary<string, Ingredient> availableIngredients)
        {
            foreach (var ingredient in Ingredients)
            {
                if (availableIngredients.ContainsKey(ingredient.Key))
                {
                    availableIngredients[ingredient.Key].Use(ingredient.Value * Quantity);
                }
                else
                {
                    throw new InvalidOperationException($"Ingredient {ingredient.Key} not available.");
                }
            }
        }
    }
}
