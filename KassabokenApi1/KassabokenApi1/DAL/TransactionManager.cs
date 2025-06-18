using KassabokenApi1.DAL;
using KassabokenApi1.Model;

public class TransactionManager
{
    public async static Task<List<Transaction>> GetAllTransactions()
    {
        try
        {
            await Task.Delay(50);
            return DB.Transactions;
        }
        catch (Exception)
        {
            // Log exception if needed
            throw new Exception("Failed to retrieve transactions.");
        }
    }

    public async static Task<Transaction> GetTransactionById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "Transaction id must not be null or empty.");

        try
        {
            await Task.Delay(50);
            var transaction = DB.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                throw new InvalidOperationException($"Transaction with id '{id}' not found.");
            return transaction;
        }
        catch (Exception)
        {
            throw new Exception($"Failed to retrieve transaction with id '{id}'.");
        }
    }

    public async static Task CreateTransaction(Transaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction), "Transaction must not be null.");
        if (string.IsNullOrWhiteSpace(transaction.Title))
            throw new ArgumentException("Transaction title must not be empty.", nameof(transaction.Title));
        if (transaction.Ammount <= 0)
            throw new ArgumentException("Transaction amount must be greater than zero.", nameof(transaction.Ammount));

        try
        {
            await Task.Delay(50);
            transaction.Id = Guid.NewGuid().ToString();
            DB.Transactions.Add(transaction);
        }
        catch (Exception)
        {
            throw new Exception("Failed to create transaction.");
        }
    }

    public async static Task DeleteTransactionById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "Transaction id must not be null or empty.");

        try
        {
            await Task.Delay(50);
            var transaction = DB.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                throw new InvalidOperationException($"Transaction with id '{id}' not found.");
            DB.Transactions.Remove(transaction);
        }
        catch (Exception)
        {
            throw new Exception($"Failed to delete transaction with id '{id}'.");
        }
    }
    public async static Task UpdateTransaction(string id, Transaction updatedTransaction)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id));
        if (updatedTransaction == null)
            throw new ArgumentNullException(nameof(updatedTransaction));
        if (string.IsNullOrWhiteSpace(updatedTransaction.Title))
            throw new ArgumentException("Transaction title must not be empty.", nameof(updatedTransaction.Title));
        if (updatedTransaction.Ammount <= 0)
            throw new ArgumentException("Transaction amount must be greater than zero.", nameof(updatedTransaction.Ammount));

        try
        {
            await Task.Delay(50);
            var existing = DB.Transactions.FirstOrDefault(t => t.Id == id);
            if (existing == null)
                throw new Exception("Transaction not found.");

            // Update properties
            existing.Title = updatedTransaction.Title;
            existing.Ammount = updatedTransaction.Ammount;
            existing.Date = updatedTransaction.Date;
        }
        catch (Exception)
        {
            throw new Exception("Failed to update transaction.");
        }
    }

}
