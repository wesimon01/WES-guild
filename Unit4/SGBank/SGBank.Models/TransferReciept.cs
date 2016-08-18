using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
   public class TransferReciept
    {

        public int AccountNumberT { get; set; }
        public decimal NewBalanceT { get; set; }
        public int AccountNumberR { get; set; }
        public decimal NewBalanceR { get; set; }
        public decimal TransferAmount { get; set; }

    }
}
