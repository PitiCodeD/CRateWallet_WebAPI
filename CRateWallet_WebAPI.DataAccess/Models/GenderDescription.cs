using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class GenderDescription : StatusBase
    {
        public int Gender { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
