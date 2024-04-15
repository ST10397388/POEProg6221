using System;

class Recipe
{
    // Properties
    public Ingredient[] Ingredients { get; private set; }
    public double[] OriginalQuantities { get; private set; }
    public string[] Steps { get; private set; }

    // Constructor
    public Recipe(int numIngredients, int numSteps)
    {
        // Check if numIngredients and numSteps are positive integers
        if (numIngredients <= 0 || numSteps <= 0)
        {
            throw new ArgumentException("Number of ingredients and steps must be positive integers.");
        }

        Ingredients = new Ingredient[numIngredients];
        OriginalQuantities = new double[numIngredients];
        Steps = new string[numSteps];
    }

    // Method to set original quantities of ingredients
    public void SetOriginalQuantities(double[] quantities)
    {
        if (quantities.Length != Ingredients.Length)
        {
            throw new ArgumentException("Number of quantities must match the number of ingredients.");
        }

        Array.Copy(quantities, OriginalQuantities, quantities.Length);
    }

    // Method to reset ingredient quantities to their original values
    public void ResetQuantitiesToOriginal()
    {
        Array.Copy(OriginalQuantities, Ingredients, Ingredients.Length);
    }
    //The use of arrays were adapted from: user9993 (2024). If statement logic and arrays. [online] Stack Overflow. Available at: https://stackoverflow.com/questions/18216543/if-statement-logic-and-arrays
}

