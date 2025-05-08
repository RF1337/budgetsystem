using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetsystem.Shared.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // 🔁 Tilbage-reference (valgfri)
        public List<Transaction> Transactions { get; set; }
    }
}
