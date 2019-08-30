using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class StatusBase : DateTimeBase
    {
        public int ActiveStatus { get; set; }

        public ActiveDescription ActiveDescription { get; set; }
    }
}
