using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api.Models
{
    public class RegisterSelectorModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
        public int Gender { get; set; }
        public string Pin { get; set; }
        public string RePin { get; set; }
    }
}
