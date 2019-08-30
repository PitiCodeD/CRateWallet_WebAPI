using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class AdminUserTransactions : TransactionsBase
    {
        public int AdminUserTransactionsId { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
