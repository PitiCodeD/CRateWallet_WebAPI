using CRateWallet_WebAPI.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class MerchantToken : TokenBase
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
    }
}
