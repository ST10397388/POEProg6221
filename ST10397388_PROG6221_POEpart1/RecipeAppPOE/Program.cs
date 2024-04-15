using System;

class Program
{
    static Recipe recipe; // Declare recipe as a class-level variable
    static double[] originalQuantities; // Declare an array to store original ingredient quantities

    static void Main(string[] args)
    {
        
        Console.WriteLine("Recipe App");

        // Start the program loop
        StartProgram();
    }

    static void StartProgram()
    {
        // Get number of ingredients and steps from user
        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());
        //Tutorialspoint.com. (2020). C# int.Parse Method. [online] Available at: https://www.tutorialspoint.com/chash-int-parse-method

        // Create a new recipe instance
        recipe = new Recipe(numIngredients, numSteps);
        originalQuantities = new double[numIngredients]; // Initialize originalQuantities array

        // Get ingredient details from user
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter details for ingredient {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            double quantity = double.Parse(Console.ReadLine());
            //dotnet-bot (2024). Double.Parse Method (System). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.double.parse?view=net-8.0
            Console.Write("Unit: ");
            string unit = Console.ReadLine();

            // Create a new ingredient instance and add it to the recipe
            recipe.Ingredients[i] = new Ingredient(name, quantity, unit);
            originalQuantities[i] = quantity; // Store original quantity
        }

        // Get step details from user
        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            recipe.Steps[i] = Console.ReadLine();
        }

        // Display the recipe
        DisplayRecipe(recipe);

        // Allow user to scale, reset, or clear the recipe
        bool continueEditing = true;
        while (continueEditing)
        {
            // Display options
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Scale recipe");
            Console.WriteLine("2. Reset quantities");
            Console.WriteLine("3. Clear data and enter a new recipe");
            Console.WriteLine("4. Exit");
            //Wells, B. (2019). Create a Menu in C# Console Application | C# Tutorials Blog. [online] C# Tutorials Blog. Available at: https://wellsb.com/csharp/beginners/create-menu-csharp-console-application

            // Get user choice
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Process user choice
            //Chand, M. (2023). C# Switch With Examples. [online] C-sharpcorner.com. Available at: https://www.c-sharpcorner.com/article/c-sharp-switch-statement/
            switch (choice)
            {
                case 1:
                    ScaleRecipe(recipe);
                    DisplayRecipe(recipe);
                    break;
                case 2:
                    ResetQuantities();
                    DisplayRecipe(recipe);
                    break;
                case 3:
                    ClearData();
                    break;
                case 4:
                    continueEditing = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    // Function to display the recipe
    static void DisplayRecipe(Recipe recipe)
    {
        Console.WriteLine("\nRecipe:");

        // Display ingredients
        Console.WriteLine("\nIngredients:");
        foreach (Ingredient ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
        }

        // Display steps
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
        }
    }

    // Function to scale the recipe
    static void ScaleRecipe(Recipe recipe)
    {
        Console.Write("Enter scaling factor (Example: 0.5 for half, 2 for double, 3 for triple): ");
        double factor = double.Parse(Console.ReadLine());

        // Scale each ingredient quantity
        foreach (Ingredient ingredient in recipe.Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Function to clear the quantities of ingredients and prompt the user to input new quantities
    static void ResetQuantities()
    {
        // Reset each ingredient quantity to its original value
        for (int i = 0; i < recipe.Ingredients.Length; i++)
        {
            recipe.Ingredients[i].Quantity = originalQuantities[i];
        }
    }

    // Function to clear all data and enter a new recipe
    static void ClearData()
    {
        Console.Clear(); // Clear console
        StartProgram(); // Restart the program
    }
    //foreach method : S, R.A. (2021). C# Foreach: what it is, How it works, Syntax and Example Code. [online] Simplilearn.com. Available at: https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/csharp-foreach
}