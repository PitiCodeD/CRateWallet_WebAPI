using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class Admin : NonUserBase
    {
        public Admin()
        {
            AdminUserTransactions = new HashSet<AdminUserTransactions>();
        }
        public int AdminId { get; set; }
        public string AdminAccountNo { get; set; }
        public string AdminName { get; set; }
        public ICollection<AdminUserTransactions> AdminUserTransactions { get; set; }
        public AdminToken AdminToken { get; set; }
    }
}
