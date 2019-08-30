using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models.Base
{
    public class TokenBase : StatusBase
    {
        public int TokenId { get; set; }
        public string RefreshToken { get; set; }
    }
}
