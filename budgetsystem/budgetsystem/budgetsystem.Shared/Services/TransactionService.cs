using budgetsystem.Shared.Data;
using budgetsystem.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace budgetsystem.Shared.Services
{
    public class TransactionService
    {
        private readonly MyDbContext _db;

        public TransactionService(MyDbContext db)
        {
            _db = db;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _db.Transactions
                .Include(t => t.Category)
                .ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalExpensesAsync()
        {
            return await _db.Transactions
                .Where(t => t.Type == "expense")
                .SumAsync(t => t.Amount);
        }


        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _db.Transactions
                .Where(t => t.Type == "income")
                .SumAsync(t => t.Amount);
        }


    }
}
