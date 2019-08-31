using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class OtpForRegis : StatusBase
    {
        public int OtpId { get; set; }
        public string Otp { get; set; }
        public string Email { get; set; }
        public string Reference { get; set; }
    }
}
