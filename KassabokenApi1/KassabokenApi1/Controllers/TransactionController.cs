using KassabokenApi1.Model;
using Microsoft.AspNetCore.Mvc;
using KassabokenApi1.DAL;

namespace KassabokenApi1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{

    [HttpGet]
    public async Task<List<Transaction>> GetAllTransactions()
    {
        return await TransactionManager.GetAllTransactions();
    }
    [HttpGet("{id}")]
    public async Task<Transaction> GetTransactionById(string id)
    {
        return await TransactionManager.GetTransactionById(id);
    }
    [HttpPost]
    public async Task CreateTransaction([FromBody] Transaction transaction)
    {
        await TransactionManager.CreateTransaction(transaction);

    }
    [HttpDelete("{id}")]
    public async Task DeleteTransaction(string id)
    {
        await TransactionManager.DeleteTransactionById(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(string id, [FromBody] Transaction transaction)
    {
        try
        {
            await TransactionManager.UpdateTransaction(id, transaction);
            return NoContent();
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Log ex if needed
            return NotFound(ex.Message);
        }
    }

}
