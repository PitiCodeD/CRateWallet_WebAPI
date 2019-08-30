using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class MerchantUserTransactions : TransactionsBase
    {
        public int MerchantUserTransactionsId { get; set; }
        public int MerchantId { get; set; }
        public int MyProperty { get; set; }
        public Merchant Merchant { get; set; }
    }
}
