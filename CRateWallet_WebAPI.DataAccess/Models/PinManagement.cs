using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class PinManagement : UserBase
    {
        public int PinId { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }
    }
}
