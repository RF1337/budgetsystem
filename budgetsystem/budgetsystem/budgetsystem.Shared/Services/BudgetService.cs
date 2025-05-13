using budgetsystem.Shared.Data;
using budgetsystem.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace budgetsystem.Shared.Services
{
    public class BudgetService
    {
        private readonly MyDbContext _db;

        public BudgetService(MyDbContext db)
        {
            _db = db;
        }

        public async Task<Budget?> GetFirstAsync()
        {
            return await _db.Budgets
                .Include(b => b.Category)
                .FirstOrDefaultAsync();
        }

        // Read Budgets
        public async Task<List<Budget>> GetAllAsync()
        {
            return await _db.Budgets
                .Include(b => b.Category)
                .ToListAsync();
        }

        // Create Budget
        public async Task AddAsync(Budget budget)
        {
            _db.Budgets.Add(budget);
            await _db.SaveChangesAsync();
        }

        // Update Budget
        public async Task UpdateAsync(Budget budget)
        {
            var existing = await _db.Budgets.FindAsync(budget.BudgetID);

            if (existing is not null)
            {
                existing.Amount = budget.Amount;
                existing.CategoryId = budget.CategoryId;
                existing.DateCreated = budget.DateCreated;
                existing.UserID = budget.UserID;

                await _db.SaveChangesAsync();
            }
        }

        // Delete Budget
        public async Task DeleteAsync(int budgetId)
        {
            var budget = await _db.Budgets.FindAsync(budgetId);
            if (budget is not null)
            {
                _db.Budgets.Remove(budget);
                await _db.SaveChangesAsync();
            }
        }

    }
}
