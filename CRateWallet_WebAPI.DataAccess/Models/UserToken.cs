using CRateWallet_WebAPI.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class UserToken : TokenBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
