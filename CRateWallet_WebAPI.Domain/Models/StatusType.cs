using System;
using System.Collections.Generic;
using System.Text;

namespace CRateWallet_WebAPI.Domain.Models
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
