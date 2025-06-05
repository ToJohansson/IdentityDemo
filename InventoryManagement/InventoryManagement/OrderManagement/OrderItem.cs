using InventoryManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.OrderManagement;

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int AmountOrdered { get; set; }

    public OrderItem(int productId, string productName, int amountOrdered)
    {
        Id = Utility.GenerateUniqueId();
        ProductId = productId;
        ProductName = productName;
        AmountOrdered = amountOrdered;
    }
    public override string ToString()
    {
        return $"OrderItem: {Id}, ProductId: {ProductId}, ProductName: {ProductName}, AmountOrdered: {AmountOrdered}";
    }
}
