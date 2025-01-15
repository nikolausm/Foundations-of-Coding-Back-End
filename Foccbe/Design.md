# Design Outline: Inventory Management System

## Tasks and Components

### 1. Main Components
- **Class `Product`**: Represents a product in the inventory.
    - Properties:
        - `string Name`
        - `decimal Price`
        - `int InStock`
    - Constructor: Initializes a product with name, price, and stock quantity.
- **Application Methods**:
    - `void AddProduct()`:
        - Allows users to add new products to the inventory.
    - `void UpdateStock()`:
        - Updates the stock of an existing product.
    - `void DisplayInventory()`:
        - Displays a table of all products with their details.
    - `void RemoveProduct()`:
        - Removes a product by its name.
    - `void ShowMenu()`:
        - Displays the menu system and handles user input.

### 2. Control Structures
- The menu system will use a `switch` statement to handle user selections.
- A `while` loop will ensure the menu runs continually until the user chooses to exit the program.

### 3. Data Flow
- Products will be stored in a `List<Product>` object to allow dynamic management of the inventory.

### 4. Example Workflow
1. The program starts with a welcome message and the main menu.
2. The user chooses an option (e.g., add product, update stock).
3. The program performs the requested action.
4. The menu is displayed again until the user exits.

## Optional Flowchart (Describe or Create)
1. **Menu System**:
    - Displays menu options.
    - Waits for user input.
2. Based on user input:
    - Call the appropriate method (`AddProduct`, `UpdateStock`, etc.).
    - Repeat until the user exits.