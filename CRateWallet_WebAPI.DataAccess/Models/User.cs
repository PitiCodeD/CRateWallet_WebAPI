using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class User : StatusBase
    {
        public User()
        {
            MerchantUserTransactions = new HashSet<MerchantUserTransactions>();
            AdminUserTransactions = new HashSet<AdminUserTransactions>();
        }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public int Gender { get; set; }
        public decimal Balance { get; set; }
        public GenderDescription GenderDescription { get; set; }
        public ICollection<MerchantUserTransactions> MerchantUserTransactions { get; set; }
        public ICollection<AdminUserTransactions> AdminUserTransactions { get; set; }
        public OtpManagement OtpManagement { get; set; }
        public PinManagement PinManagement { get; set; }
        public UserToken UserToken { get; set; }
    }
}
