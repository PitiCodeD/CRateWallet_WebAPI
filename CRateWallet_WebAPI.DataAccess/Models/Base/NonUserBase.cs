using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class NonUserBase : StatusBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
