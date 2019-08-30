using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class UserBase : StatusBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
