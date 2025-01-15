namespace Foccbe.Console;

/// <summary>
/// Represents a product with a name, price, and associated stock.
/// </summary>
public record Product(string Name, decimal Price, IStock Stock) : IProduct
{
    /// <summary>
    /// Returns a string representation of the product details.
    /// </summary>
    /// <returns>A string representation of the product.</returns>
    public override string ToString()
    {
        return $"{Name}, Price: {Price:C}, In Stock: {Stock}";
    }
}