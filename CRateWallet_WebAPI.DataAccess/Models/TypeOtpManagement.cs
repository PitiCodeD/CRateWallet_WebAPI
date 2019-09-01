using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class TypeOtpManagement : StatusBase
    {
        public TypeOtpManagement()
        {
            OtpManagement = new HashSet<OtpManagement>();
        }
        public int Type { get; set; }
        public string Description { get; set; }
        public ICollection<OtpManagement> OtpManagement { get; set; }
    }
}
