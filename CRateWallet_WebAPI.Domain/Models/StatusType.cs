using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.Domain.Models
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
            BackToFirstPage
        }
    }
}
