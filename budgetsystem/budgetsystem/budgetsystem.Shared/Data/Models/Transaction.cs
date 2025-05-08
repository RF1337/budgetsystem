using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetsystem.Shared.Data.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public int CategoryId { get; set; }   // ✅ ADD THIS LINE

        // 🔽 Dette er det vigtige:
        public Category Category { get; set; }  // Navigation property
    }
}
