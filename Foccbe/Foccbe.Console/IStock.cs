namespace Foccbe.Console;

/// <summary>
/// Interface for Stock operations
/// </summary>
public interface IStock
{
    /// <summary>
    /// Gets the current stock quantity.
    /// </summary>
    int Quantity { get; }

    /// <summary>
    /// Increases the stock by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to increase the stock by.</param>
    void Increase(int amount);

    /// <summary>
    /// Decreases the stock by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to decrease the stock by.</param>
    void Decrease(int amount);

    /// <summary>
    /// Sets the stock to a specific quantity.
    /// </summary>
    /// <param name="quantity">The new stock quantity.</param>
    void Set(int quantity);
}