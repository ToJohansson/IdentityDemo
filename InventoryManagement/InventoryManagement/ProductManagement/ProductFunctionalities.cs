using InventoryManagement.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagement.ProductManagement;

public partial class Product
{
    // Create Simple Product Representation
    public string GetSimpleProductRepresentation()
    {
        return $"ID: {Id}, Name: {Name}, Description: {Description}, Max Items in Stock: {MaxItemsInStock}, Unit Type: {UnitType}, Price: {Price.ItemPrice} {Price.Currency}";
    }
    // Decrese Stock
    public void DecreaseStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0");
        if (AmountInStock - amount < 0)
            throw new InvalidOperationException("Not enough stock to decrease");
        AmountInStock -= amount;

        UpdateLowStock();
    }
    // Increase Stock
    public void IncreaseStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0");
        if (AmountInStock + amount > MaxItemsInStock)
            throw new InvalidOperationException("Exceeding max stock limit");
        AmountInStock += amount;

        UpdateLowStock();
    }
    // display details full ( 1+ overload)
    public string GetFullProductRepresentation()
    {
        return $"ID: {Id}, Name: {Name}, Description: {Description}, Max Items in Stock: {MaxItemsInStock}, Unit Type: {UnitType}, Price: {Price.ItemPrice} {Price.Currency}, Amount in Stock: {AmountInStock}";
    }
    // display details short ( 1+ overload)
    public string GetShortProductRepresentation()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price.ItemPrice} {Price.Currency}";
    }
    // update low stock
    private void UpdateLowStock()
    {
        IsBelowStockTreshold = AmountInStock < MaxItemsInStock * 0.2; // Assuming 20% is the threshold
        if (IsBelowStockTreshold)
        {
            Console.WriteLine($"Warning: Stock for {Name} is below the threshold.");
        }
    }
    // use product
    public void UseProduct(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0");
        if (AmountInStock - amount < 0)
            throw new InvalidOperationException("Not enough stock to use");
        AmountInStock -= amount;
        UpdateLowStock();
    }
}
