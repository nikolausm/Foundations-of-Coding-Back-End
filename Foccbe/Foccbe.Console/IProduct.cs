namespace Foccbe.Console;

/// <summary>
/// Interface for Product operations
/// </summary>
public interface IProduct
{
    /// <summary>
    /// Gets the product name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the product price.
    /// </summary>
    decimal Price { get; }

    /// <summary>
    /// Gets the stock associated with the product.
    /// </summary>
    IStock Stock { get; }
}