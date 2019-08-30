using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class Merchant : NonUserBase
    {
        public Merchant()
        {
            MerchantUserTransactions = new HashSet<MerchantUserTransactions>();
        }
        public int MerchantId { get; set; }
        public string Partnership { get; set; }
        public string MerchantAccountNo { get; set; }
        public string MerchantName { get; set; }
        public ICollection<MerchantUserTransactions> MerchantUserTransactions { get; set; }
        public MerchantToken MerchantToken { get; set; }
    }
}
