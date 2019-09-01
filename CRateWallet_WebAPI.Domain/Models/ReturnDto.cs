using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.Domain.Models
{
    public class ReturnDto<T>
    {
        public int Status { get; set; }//1 is success 2 is bad value 3 is not know
        public string Message { get; set; }
        public List<T> ListData { get; set; }
        public T Data { get; set; }
    }
}
