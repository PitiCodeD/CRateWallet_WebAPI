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
            Customer,
            Merchant,
            Admin
        }

        public enum StatusRetureData
        {
            Success,
            ShowMessage,
            NotShowMessage,
            BackToFirstPage
        }
    }
}
