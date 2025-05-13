using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetsystem.Shared.Data.Models
{
    public class Budget
    {
        public int BudgetID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int Month { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        // Navigation property
        public Category? Category { get; set; }
    }
}
