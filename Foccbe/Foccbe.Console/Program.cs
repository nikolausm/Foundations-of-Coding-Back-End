namespace Foccbe.Console;

class Program
{
    /// <summary>
    /// Static list to store all products in the inventory
    /// </summary>
    private static readonly List<Product> s_inventory = new();

    /// <summary>
    /// Entry point of the program. Displays a welcome message and starts the menu loop.
    /// </summary>
    static void Main(string[] _)
    {
        
        System.Console.WriteLine("Welcome to the Inventory Management System!");
        
        ShowMenu();
    }

    /// <summary>
    /// Displays the menu and handles user input for various inventory management actions.
    /// </summary>
    private static void ShowMenu()
    {
        while (true)
        {
            // Display available actions
            System.Console.WriteLine("\nMenu:");
            System.Console.WriteLine("1. Add Product");
            System.Console.WriteLine("2. Update Product Stock");
            System.Console.WriteLine("3. Increase Stock Quantity");
            System.Console.WriteLine("4. Decrease Stock Quantity");
            System.Console.WriteLine("5. Display Inventory");
            System.Console.WriteLine("6. Remove Product");
            System.Console.WriteLine("7. Exit");

            System.Console.Write("Enter your choice: ");
            string? choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    IncreaseStock();
                    break;
                case "4":
                    DecreaseStock();
                    break;
                case "5":
                    DisplayInventory();
                    break;
                case "6":
                    RemoveProduct();
                    break;
                case "7":
                    System.Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    System.Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Adds a new product to the inventory.
    /// </summary>
    private static void AddProduct()
    {
        System.Console.WriteLine("\n[AddProduct] Adding new product...");

        // Get product name
        string? name;
        while (true)
        {
            System.Console.Write("Enter Product Name: ");
            name = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Check for duplicates
                if (s_inventory.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    System.Console.WriteLine($"Product with name '{name}' already exists. Please enter a unique name.");
                    continue;
                }
                break;
            }
            System.Console.WriteLine("Product name cannot be null or empty. Please enter a valid name.");
        }

        // Get product price
        decimal price;
        while (true)
        {
            System.Console.Write("Enter Product Price: ");
            if (decimal.TryParse(System.Console.ReadLine(), out price) && price >= 0)
            {
                break;
            }

            System.Console.WriteLine("Invalid price. Please enter a positive decimal value.");
        }

        // Get stock quantity
        int stock;
        while (true)
        {
            System.Console.Write("Enter Stock Quantity: ");
            if (int.TryParse(System.Console.ReadLine(), out stock) && stock >= 0)
            {
                break;
            }

            System.Console.WriteLine("Invalid stock quantity. Please enter a positive integer value.");
        }

        // Create a new Product object
        Product product = new Product(name, price, new Stock(stock));

        // Add product to the inventory
        s_inventory.Add(product);

        System.Console.WriteLine($"Product '{name}' added successfully!");
    }

    /// <summary>
    /// Displays all products in the inventory.
    /// </summary>
    private static void DisplayInventory()
    {
        System.Console.WriteLine("\n[DisplayInventory] Current Products in Inventory:");

        // Check if inventory is empty
        if (s_inventory.Count == 0)
        {
            System.Console.WriteLine("No products in the inventory.");
            return;
        }

        // Display all products
        foreach (var product in s_inventory)
        {
            System.Console.WriteLine(product.ToString());
        }
    }

    /// <summary>
    /// Updates the stock of a product selected by the user.
    /// </summary>
    private static void UpdateStock()
    {
        System.Console.WriteLine("\n[UpdateStock] Updating stock...");

        // Check if inventory is empty
        if (s_inventory.Count == 0)
        {
            System.Console.WriteLine("No products available to update stock.");
            return;
        }

        // Display the 10 products with the lowest stock
        var lowStockProducts = s_inventory
            .OrderBy(p => p.Stock.Quantity)
            .Take(10)
            .ToList();

        System.Console.WriteLine("\nThe 10 products with the lowest stock:");
        for (int i = 0; i < lowStockProducts.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {lowStockProducts[i].Name}, Stock: {lowStockProducts[i].Stock.Quantity}");
        }

        // Choose a product by number or name
        Product? selectedProduct = null;
        while (selectedProduct is null)
        {
            System.Console.Write("\nEnter the number or name of the product to update: ");
            string? input = System.Console.ReadLine();

            if (int.TryParse(input, out int index) && index > 0 && index <= lowStockProducts.Count)
            {
                selectedProduct = lowStockProducts[index - 1];
            }
            else
            {
                selectedProduct = s_inventory.Find(p => p.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
            }

            if (selectedProduct is null)
            {
                System.Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Get the new stock quantity
        int newStock;
        while (true)
        {
            System.Console.Write("Enter New Stock Quantity: ");
            if (int.TryParse(System.Console.ReadLine(), out newStock) && newStock >= 0)
            {
                break;
            }

            System.Console.WriteLine("Invalid stock quantity. Please enter a positive integer value.");
        }

        // Update stock quantity
        selectedProduct.Stock.Set(newStock);

        System.Console.WriteLine($"Stock for product '{selectedProduct.Name}' updated successfully!");
    }

    /// <summary>
    /// Increases the stock quantity of a selected product.
    /// </summary>
    private static void IncreaseStock()
    {
        System.Console.WriteLine("\n[IncreaseStock] Increasing stock...");

        // Check if inventory is empty
        if (s_inventory.Count == 0)
        {
            System.Console.WriteLine("No products available.");
            return;
        }

        // Select product by name
        Product? selectedProduct = null;
        while (selectedProduct is null)
        {
            System.Console.Write("Enter Product Name: ");
            string? name = System.Console.ReadLine();
            selectedProduct = s_inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (selectedProduct is null)
            {
                System.Console.WriteLine("Product not found. Please try again.");
            }
        }

        // Get stock increase quantity
        int amount;
        while (true)
        {
            System.Console.Write("Enter Amount to Increase: ");
            if (int.TryParse(System.Console.ReadLine(), out amount) && amount > 0)
            {
                break;
            }

            System.Console.WriteLine("Invalid amount. Please enter a positive integer.");
        }

        selectedProduct.Stock.Increase(amount);
        System.Console.WriteLine($"Stock for product '{selectedProduct.Name}' increased successfully!");
    }

    /// <summary>
    /// Decreases the stock quantity of a selected product.
    /// </summary>
    private static void DecreaseStock()
    {
        System.Console.WriteLine("\n[DecreaseStock] Decreasing stock...");

        // Check if inventory is empty
        if (s_inventory.Count == 0)
        {
            System.Console.WriteLine("No products available.");
            return;
        }

        // Select product by name
        Product? selectedProduct = null;
        while (selectedProduct is null)
        {
            System.Console.Write("Enter Product Name: ");
            string? name = System.Console.ReadLine();
            selectedProduct = s_inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (selectedProduct is null)
            {
                System.Console.WriteLine("Product not found. Please try again.");
            }
        }

        // Get stock decrease quantity
        int amount;
        while (true)
        {
            System.Console.Write("Enter Amount to Decrease: ");
            if (int.TryParse(System.Console.ReadLine(), out amount) && amount > 0)
            {
                if (amount <= selectedProduct.Stock.Quantity)
                {
                    break;
                }

                System.Console.WriteLine("Cannot decrease more than the current stock. Please try again.");
            }
            else
            {
                System.Console.WriteLine("Invalid amount. Please enter a positive integer.");
            }
        }

        selectedProduct.Stock.Decrease(amount);
        System.Console.WriteLine($"Stock for product '{selectedProduct.Name}' decreased successfully!");
    }

    /// <summary>
    /// Removes a product from the inventory by name.
    /// </summary>
    private static void RemoveProduct()
    {
        System.Console.WriteLine("\n[RemoveProduct] Removing a product...");

        // Check if inventory is empty
        if (s_inventory.Count == 0)
        {
            System.Console.WriteLine("No products available to remove.");
            return;
        }

        // Get the product name to remove
        string? name;
        while (true)
        {
            System.Console.Write("Enter Product Name: ");
            name = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                break;
            }
            System.Console.WriteLine("Product name cannot be null or empty. Please enter a valid name.");
        }

        // Find the product in the inventory
        var product = s_inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // If not found, display a message
        if (product is null)
        {
            System.Console.WriteLine($"Product '{name}' not found.");
            return;
        }

        // Remove the product
        s_inventory.Remove(product);

        System.Console.WriteLine($"Product '{name}' removed successfully!");
    }
}