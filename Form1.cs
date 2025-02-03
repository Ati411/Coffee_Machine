namespace Coffee_Machine
{
    public partial class Form1 : Form
    {
        MenuItem itemBlackCoffee = new MenuItem();
        MenuItem itemMocha = new MenuItem();
        MenuItem itemLatte = new MenuItem();
        MenuItem itemChocolate = new MenuItem();
        MenuItem itemWater = new MenuItem();
        MenuItem itemCoffee = new MenuItem();
        MenuItem itemMilk = new MenuItem();
        MenuItem itemChocolatMix = new MenuItem();  

        public Form1()
        {
            InitializeComponent();

            itemBlackCoffee.Name = "BlackCoffee";
            itemBlackCoffee.Price = 150;
            itemBlackCoffee.Quantity = 0;
            itemBlackCoffee.Ingredients.Add("Water", 300);  
            itemBlackCoffee.Ingredients.Add("Coffee", 20);

            itemMocha.Name = "Mocha";
            itemMocha.Price = 175;
            itemMocha.Quantity = 0;
            itemMocha.Ingredients.Add("Water", 300);
            itemMocha.Ingredients.Add("Coffee", 20);
            itemMocha.Ingredients.Add("Milk", 10);

            itemLatte.Name = "Latte";
            itemLatte.Price = 120;
            itemLatte.Quantity = 0;
            itemLatte.Ingredients.Add("Water", 300);
            itemLatte.Ingredients.Add("Coffee", 20);
            itemLatte.Ingredients.Add("Chocolate", 10);

            itemChocolate.Name = "Chocolate";
            itemChocolate.Price = 100;
            itemChocolate.Quantity = 0;
            itemChocolate.Ingredients.Add("Water", 300);
            itemChocolate.Ingredients.Add("Chocolate", 20);


            tbBlackCoffeePrice.Text = itemBlackCoffee.Price.ToString();
            tbBlackCoffeeQuantity.Text = itemBlackCoffee.Quantity.ToString();

            tbMochaPrice.Text = itemMocha.Price.ToString();
            tbMochaQuantity.Text = itemMocha.Quantity.ToString();

            tbLattePrice.Text = itemLatte.Price.ToString();
            tbLatteQuantity.Text = itemChocolate.Quantity.ToString();

            tbChocolatePrice.Text = itemChocolate.Price.ToString();
            tbChocolateQuantity.Text = itemChocolate.Quantity.ToString();

            itemWater.Name = "Water";
            itemWater.Quantity = 100000;

            itemCoffee.Name = "CoffeeMix";
            itemCoffee.Quantity = 100000;

            itemMilk.Name = "Milk";
            itemMilk.Quantity = 100000;

            itemChocolatMix.Name = "ChocolatMix";
            itemChocolatMix.Quantity = 100000;

            tbWater.Text = itemWater.Quantity.ToString();
            tbCoffeeMix.Text = itemCoffee.Quantity.ToString();
            tbMilk.Text = itemMilk.Quantity.ToString();
            tbChocolateMix.Text = itemChocolatMix.Quantity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tbCash.Text);
                double dTotal = 0;

                Dictionary<string, Ingredient> availableIngredients = new Dictionary<string, Ingredient>
                {
                    { "Water", new Ingredient("Water", 100000) },
                    { "Coffee", new Ingredient("Coffee", 100000) },
                    { "Milk", new Ingredient("Milk", 100000) },
                    { "Chocolate", new Ingredient("Chocolate", 100000) }
                };


                if (chbBlackCoffee.Checked)
                {
                    itemBlackCoffee.Quantity = int.Parse(tbBlackCoffeeQuantity.Text);
                    dTotal += itemBlackCoffee.GetTotalPrice();
                    itemBlackCoffee.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeeMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                }

                if (chbMocha.Checked)
                {
                    itemMocha.Quantity = int.Parse(tbMochaQuantity.Text);
                    dTotal += itemMocha.GetTotalPrice();
                    itemMocha.UseIngredients(availableIngredients);


                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeeMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (chbLatte.Checked)
                {
                    itemLatte.Quantity = int.Parse(tbMochaQuantity.Text);
                    dTotal += itemLatte.GetTotalPrice();
                    itemLatte.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbCoffeeMix.Text = availableIngredients["Coffee"].Quantity.ToString();
                    tbMilk.Text = availableIngredients["Milk"].Quantity.ToString();

                }

                if (chbChocolate.Checked)
                {
                    itemChocolate.Quantity = int.Parse(tbChocolateQuantity.Text);
                    dTotal += itemChocolate.GetTotalPrice();
                    itemChocolate.UseIngredients(availableIngredients);

                    tbWater.Text = availableIngredients["Water"].Quantity.ToString();
                    tbChocolateMix.Text = availableIngredients["Chocolate"].Quantity.ToString();
                }

                if (dCash < dTotal)
                {
                    MessageBox.Show("เงินสดไม่เพียงพอ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dTotal;

                //Display
                tbTotal.Text = dTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }

            catch (FormatException)
            {
                MessageBox.Show("กรุณากรอกข้อมูลตัวเลขให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb1000.Text = changeCount[0].ToString();
            tb500.Text = changeCount[1].ToString();
            tb100.Text = changeCount[2].ToString();
            tb50.Text = changeCount[3].ToString();
            tb20.Text = changeCount[4].ToString();
            tb10.Text = changeCount[5].ToString();
            tb05.Text = changeCount[6].ToString();
            tb01.Text = changeCount[7].ToString();
            tb050.Text = changeCount[8].ToString();
            tb025.Text = changeCount[9].ToString();
        }
    }
}
