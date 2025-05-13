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

        // Create a transaction

        public async Task AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
        }

        // Update a transaction
        public async Task UpdateAsync(Transaction updatedTransaction)
        {
            var existing = await _db.Transactions.FindAsync(updatedTransaction.TransactionID);

            if (existing is not null)
            {
                existing.Description = updatedTransaction.Description;
                existing.Amount = updatedTransaction.Amount;
                existing.CategoryId = updatedTransaction.CategoryId;
                existing.Type = updatedTransaction.Type;
                existing.TransactionDate = updatedTransaction.TransactionDate;
                existing.UserID = updatedTransaction.UserID;

                await _db.SaveChangesAsync();
            }
        }

        // Delete a transaction
        public async Task DeleteAsync(int transactionId)
        {
            var transaction = await _db.Transactions.FindAsync(transactionId);
            if (transaction != null)
            {
                _db.Transactions.Remove(transaction);
                await _db.SaveChangesAsync();
            }
        }


        public async Task<decimal> GetTotalExpensesAsync()
        {
            return await _db.Transactions
                .Where(t => t.Type == "Expense")
                .SumAsync(t => t.Amount);
        }


        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _db.Transactions
                .Where(t => t.Type == "Income")
                .SumAsync(t => t.Amount);
        }


    }
}
