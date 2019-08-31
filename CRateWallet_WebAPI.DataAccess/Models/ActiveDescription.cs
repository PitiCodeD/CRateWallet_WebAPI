using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class ActiveDescription : DateTimeBase
    {
        public ActiveDescription()
        {
            User = new HashSet<User>();
            GenderDescription = new HashSet<GenderDescription>();
            Admin = new HashSet<Admin>();
            Merchant = new HashSet<Merchant>();
            MerchantUserTransactions = new HashSet<MerchantUserTransactions>();
            AdminUserTransactions = new HashSet<AdminUserTransactions>();
            OtpManagement = new HashSet<OtpManagement>();
            PinManagement = new HashSet<PinManagement>();
            TypeOtpManagement = new HashSet<TypeOtpManagement>();
            UserToken = new HashSet<UserToken>();
            AdminToken = new HashSet<AdminToken>();
            MerchantToken = new HashSet<MerchantToken>();
        }
        public int ActvieStatus { get; set; }
        public string Description { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<GenderDescription> GenderDescription { get; set; }
        public ICollection<Admin> Admin { get; set; }
        public ICollection<Merchant> Merchant { get; set; }
        public ICollection<MerchantUserTransactions> MerchantUserTransactions { get; set; }
        public ICollection<AdminUserTransactions> AdminUserTransactions { get; set; }
        public ICollection<OtpManagement> OtpManagement { get; set; }
        public ICollection<PinManagement> PinManagement { get; set; }
        public ICollection<TypeOtpManagement> TypeOtpManagement { get; set; }
        public ICollection<UserToken> UserToken { get; set; }
        public ICollection<AdminToken> AdminToken { get; set; }
        public ICollection<MerchantToken> MerchantToken { get; set; }
    }
}
