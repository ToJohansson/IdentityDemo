using InventoryManagement.General;
using InventoryManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ProductManagement;

public partial class Product
{
    private int id;
    private string name;
    private string description;
    private int maxItemsInStock;
    public int AmountInStock { get; set; }
    public bool IsBelowStockTreshold { get; set; }
    public UnitType UnitType { get; set; }
    public Price Price { get; set; }

    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Id must be greater than 0");
            id = value;
        }
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            name = value;
        }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int MaxItemsInStock
    {
        get { return maxItemsInStock; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("MaxItemsInStock must be greater than 0");
            maxItemsInStock = value;
        }
    }

    public Product(string name, string description, int maxItemsInStock, UnitType unitType, Price price)
    {
        Id = Id = Utility.GenerateUniqueId();
        Name = name;
        Description = description;
        MaxItemsInStock = maxItemsInStock;
        UnitType = unitType;
        Price = price;
    }


}
