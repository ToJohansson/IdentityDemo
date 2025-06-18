using KassabokenApi1.Model;

namespace KassabokenApi1.DAL;

public static class DB
{
    public static List<Transaction> Transactions = new List<Transaction>
{
    new Transaction
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Grocery Shopping",
        Ammount = 150.75m,
        Date = DateTime.Now.AddDays(-3)
    },
    new Transaction
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Electricity Bill",
        Ammount = 89.99m,
        Date = DateTime.Now.AddDays(-10)
    },
    new Transaction
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Salary",
        Ammount = 2500.00m,
        Date = DateTime.Now.AddDays(-1)
    },
    new Transaction
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Coffee",
        Ammount = 3.50m,
        Date = DateTime.Now
    }
};

}
