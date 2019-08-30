using CRateWallet_WebAPI.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class AdminToken : TokenBase
    {
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
