// See https://aka.ms/new-console-template for more information

using InventoryManagement.General;
using InventoryManagement.OrderManagement;
using InventoryManagement.ProductManagement;

Price bananaPrice = new Price(1.5, Currency.EUR);
Price orangePrice = new Price(2.0, Currency.EUR);
Price applePrice = new Price(1.2, Currency.EUR);
Price mangoPrice = new Price(5.0, Currency.EUR);
Price grapePrice = new Price(4.5, Currency.EUR);
Price watermelonPrice = new Price(3.0, Currency.EUR);

Product banana = new Product("Banana", "Fresh bananas", 100, UnitType.PerKg, bananaPrice);
Product orange = new Product("Orange", "Fresh oranges", 50, UnitType.PerKg, orangePrice);
Product apple = new Product("Apple", "Fresh apples", 200, UnitType.PerKg, applePrice);
Product mango = new Product("Mango", "Fresh mangoes", 30, UnitType.PerBox, mangoPrice);
Product grape = new Product("Grape", "Fresh grapes", 80, UnitType.PerBox, grapePrice);
Product watermelon = new Product("Watermelon", "Fresh watermelons", 20, UnitType.PerItem, watermelonPrice);

OrderItem orderItem1 = new OrderItem(banana.Id, banana.Name, 10);
OrderItem orderItem2 = new OrderItem(orange.Id, orange.Name, 5);
OrderItem orderItem3 = new OrderItem(apple.Id, apple.Name, 20);
OrderItem orderItem4 = new OrderItem(mango.Id, mango.Name, 2);
OrderItem orderItem5 = new OrderItem(grape.Id, grape.Name, 15);
OrderItem orderItem6 = new OrderItem(watermelon.Id, watermelon.Name, 3);
OrderItem orderItem7 = new OrderItem(banana.Id, banana.Name, 10);
OrderItem orderItem8 = new OrderItem(orange.Id, orange.Name, 5);
OrderItem orderItem9 = new OrderItem(apple.Id, apple.Name, 20);
OrderItem orderItem10 = new OrderItem(mango.Id, mango.Name, 2);
OrderItem orderItem11 = new OrderItem(grape.Id, grape.Name, 15);
OrderItem orderItem12 = new OrderItem(watermelon.Id, watermelon.Name, 3);

List<OrderItem> orderItems1 = new List<OrderItem>
{
    orderItem1,
    orderItem2,
    orderItem3,
    orderItem4,
    orderItem5,
    orderItem6
};
Order order1 = new Order(orderItems1);

List<OrderItem> orderItems2 = new List<OrderItem>
{
    orderItem7,
    orderItem8
};
Order order2 = new Order(orderItems2);

order1.AddOrderItem(orderItem7);
order1.ProcessOrder();
order1.ShowOrderDetails();

order2.AddOrderItem(orderItem8);
order2.AddOrderItem(orderItem9);
order2.AddOrderItem(orderItem10);
order2.AddOrderItem(orderItem11);
order2.AddOrderItem(orderItem12);
order2.ProcessOrder();
order2.ShowOrderDetails();
