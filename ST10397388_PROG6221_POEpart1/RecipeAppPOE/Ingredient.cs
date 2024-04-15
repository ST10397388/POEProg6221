// Define the Ingredient class to represent ingredients of a recipe
class Ingredient
{
    // Properties
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }

    // Constructor
    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}
