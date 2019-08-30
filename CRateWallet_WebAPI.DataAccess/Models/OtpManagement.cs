using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class OtpManagement : UserBase
    {
        public int OtpId { get; set; }
        public string Otp { get; set; }
        public int Type { get; set; }
        public TypeOtpManagement TypeOtpManagement { get; set; }
    }
}
