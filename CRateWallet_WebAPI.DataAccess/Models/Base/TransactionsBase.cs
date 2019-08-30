using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class TransactionsBase : UserBase
    {
        public string Reference { get; set; }
        public decimal OldBalance { get; set; }
        public decimal BalanceChange { get; set; }
        public decimal NewBalance { get; set; }
    }
}
