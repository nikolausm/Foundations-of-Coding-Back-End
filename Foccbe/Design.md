# Design Outline: Inventory Management System

## Tasks and Components

### 1. Main Components

- **Class `Product`**: Represents a product in the inventory.
    - Properties:
        - `string Name`
        - `decimal Price`
        - `IStock Stock`
    - Constructor: Initializes a product with name, price, and stock quantity.
- **Interface `IStock`**: Defines methods for managing the inventory.
    - Methods:
    - `void Increase(int amount)`: Increases the stock of a product.
    - `void Decrease(int amount)`: Decreases the stock of a product.
    - `void Set(int amount)`: Sets the stock of a product to a specific value.
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

```plaintext
+----------------------+
|      Show Menu       |
+----------------------+
          ↓
+----------------------+
|  Capture User Input  |
+----------------------+
          ↓
+-----------------------------+
|   Match Input in Switch     |
| (Add, Update, Display, etc) |
+-----------------------------+
          ↓
+----------------------------------+
| Execute Corresponding Method     |
| (AddProduct, UpdateStock, etc.)  |
+----------------------------------+
          ↓
+----------------------+
| Continue or Exit     |
|    (Based on Input)  |
+----------------------+
```

2. **Execution Flow**:

```plaintext
+------------------+
|   Add Product    |
+------------------+
          ↓
+-------------------------------+
|  Capture Product Details      |
|  (Name, Price, Initial Stock) |
+-------------------------------+
          ↓
+--------------------------+
| Add Product to Inventory |
+--------------------------+
          ↓
+-------------------+
| Return to Menu    |
+-------------------+

-----------------------------------

+----------------------+
|    Update Stock      |
+----------------------+
           ↓
+-------------------------------+
| Select Product by Name        |
+-------------------------------+
           ↓
+-------------------------+
| Capture Stock Change    |
| (Increase/Decrease/Set) |
+-------------------------+
           ↓
+-------------------+
| Return to Menu    |
+-------------------+
```