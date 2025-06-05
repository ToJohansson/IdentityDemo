using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InventoryManagement.Utilities;
namespace InventoryManagement.OrderManagement;

public class Order
{
    public static int Id { get; private set; }
    private DateTime _orderDate;
    public bool IsCompleted { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public DateTime OrderDate
    {
        get { return _orderDate; }
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Order date cannot be in the future");
            _orderDate = value;
        }
    }

    public Order(List<OrderItem> orderItems)
    {
        Id = Utility.GenerateUniqueId();
        IsCompleted = false;
        _orderDate = DateTime.Now; // Correctly initialize with the current date  
        OrderItems = orderItems ?? new List<OrderItem>();
    }

    // set order to completed  
    private void CompleteOrder()
    {
        IsCompleted = true;
    }

    // add order item  
    public void AddOrderItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null");
        OrderItems.Add(orderItem);
    }

    public void ProcessOrder()
    {
        Console.WriteLine("Processing order...");
        Thread.Sleep(4000);
        CompleteOrder();
        Console.WriteLine("Order processed successfully.");
    }

    // show order details  
    public void ShowOrderDetails()
    {
        Console.WriteLine($"Order ID: {Id}");
        Console.WriteLine($"Order Date: {OrderDate:dd/MM/yyyy}"); // Format date as day/month/year  
        Console.WriteLine($"Is Completed: {IsCompleted}");
        Console.WriteLine("Order Items:");
        foreach (var item in OrderItems)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
