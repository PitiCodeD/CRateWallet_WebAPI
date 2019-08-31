using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class GenderDescription : StatusBase
    {
        public GenderDescription()
        {
            User = new HashSet<User>();
        }
        public int Gender { get; set; }
        public string Description { get; set; }
        public ICollection<User> User { get; set; }
    }
}
