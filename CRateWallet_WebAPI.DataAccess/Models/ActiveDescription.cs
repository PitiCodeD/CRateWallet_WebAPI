using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class ActiveDescription : DateTimeBase
    {
        public int ActvieStatus { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public GenderDescription GenderDescription { get; set; }
        public Admin Admin { get; set; }
        public Merchant Merchant { get; set; }
        public MerchantUserTransactions MerchantUserTransactions { get; set; }
        public AdminUserTransactions AdminUserTransactions { get; set; }
        public OtpManagement OtpManagement { get; set; }
        public PinManagement PinManagement { get; set; }
        public TypeOtpManagement TypeOtpManagement { get; set; }
        public UserToken UserToken { get; set; }
        public AdminToken AdminToken { get; set; }
        public MerchantToken MerchantToken { get; set; }
    }
}
