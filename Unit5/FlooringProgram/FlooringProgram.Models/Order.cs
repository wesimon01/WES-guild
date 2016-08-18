using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string productType { get; set; }
        public decimal Area { get; set; }
        public decimal CostFt2 { get; set; }
        public decimal LaborFt2 { get; set; }
        public decimal materialCost { get; set; }
        public decimal laborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime date { get; set; }

    }
}
