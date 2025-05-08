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

        public async Task<List<Budget>> GetAllAsync()
        {
            return await _db.Budgets
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task AddAsync(Budget budget)
        {
            _db.Budgets.Add(budget);
            await _db.SaveChangesAsync();
        }
    }
}
