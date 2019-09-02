using CRateWallet_WebAPI.Domain.Interfaces;
using CRateWallet_WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBaseService _baseService;
        public PaymentService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ReturnDto<string>> GenerateQrCode(string username)
        {
            throw new NotImplementedException();
        }
    }
}
