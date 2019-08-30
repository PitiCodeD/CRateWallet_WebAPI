using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class TypeOtpManagement : StatusBase
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public OtpManagement OtpManagement { get; set; }
    }
}
