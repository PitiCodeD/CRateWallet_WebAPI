using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api.Models
{
    public class ChangePinSelectorModel
    {
        public string Email { get; set; }
        public string Pin { get; set; }
        public string RePin { get; set; }
    }
}
