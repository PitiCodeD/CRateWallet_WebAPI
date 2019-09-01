using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.Domain.Models
{
    public class GenPassDto
    {
        public string HashPass { get; set; }
        public string Salt { get; set; }
    }
}
