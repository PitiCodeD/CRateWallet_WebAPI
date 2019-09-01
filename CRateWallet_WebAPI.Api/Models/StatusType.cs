using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api.Models
{
    static class StatusType
    {
        public enum UserType
        {
            Null,
            Customer,
            Merchant,
            Admin
        }

        public enum StatusRetureData
        {
            Null,
            Success,
            ShowMessage,
            NotShowMessage,
            BackToFirstPage,
        }
    }
}
