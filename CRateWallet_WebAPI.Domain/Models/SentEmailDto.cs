using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.Domain.Models
{
    public class SentEmailDto
    {
        public int SentEmailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
