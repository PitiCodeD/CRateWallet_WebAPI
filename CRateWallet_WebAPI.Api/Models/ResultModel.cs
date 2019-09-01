using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api.Models
{
    public class ResultModel<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> ListData { get; set; }
    }
}
