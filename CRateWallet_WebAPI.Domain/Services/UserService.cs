using CRateWallet_WebAPI.Domain.Interfaces;
using CRateWallet_WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ReturnDto<string>> CheckEmailForRegis(string email)
        {

            throw new NotImplementedException();
        }
    }
}
