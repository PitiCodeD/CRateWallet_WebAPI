using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api.Models
{
    public class VerifiedEmailSelectorModel
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
