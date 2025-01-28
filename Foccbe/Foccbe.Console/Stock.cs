namespace Foccbe.Console;

/// <summary>
/// Represents immutable stock management functionality.
/// </summary>
public sealed class Stock : IStock
{
    /// <summary>
    /// Gets the current stock quantity.
    /// </summary>
    public int Quantity { get; private set; }

    
    /// <summary>
    /// Initializes a new instance of the <see cref="Stock"/> class with an optional initial quantity.
    /// </summary>
    /// <param name="quantity">The initial stock quantity. Default is 0.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the initial quantity is negative.</exception>
    public Stock(int quantity = 0)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Stock quantity cannot be negative.");
        }
        Quantity = quantity;
    }

    /// <summary>
    /// Increases the stock by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to increase the stock by.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the amount is negative.</exception>
    public void Increase(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Increase amount cannot be negative.");
        }
        Quantity += amount;
    }

    /// <summary>
    /// Decreases the stock by the specified amount.
    /// </summary>
    /// <param name="amount">The amount to decrease the stock by.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the amount is negative.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the amount to decrease is greater than the current stock quantity.</exception>
    public void Decrease(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Decrease amount cannot be negative.");
        }

        if (amount > Quantity)
        {
            throw new InvalidOperationException("Cannot decrease more than the available stock.");
        }
        Quantity -= amount;
    }

    /// <summary>
    /// Sets the stock to a specific quantity.
    /// </summary>
    /// <param name="quantity">The new stock quantity.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the new quantity is negative.</exception>
    public void Set(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Stock quantity cannot be negative.");
        }
        Quantity = quantity;
    }

    /// <summary>
    /// Returns a string representation of the stock.
    /// </summary>
    /// <returns>A string representing the stock quantity.</returns>
    public override string ToString()
    {
        return Quantity.ToString();
    }
}