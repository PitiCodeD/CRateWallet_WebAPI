using CRateWallet_WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ReturnDto<string>> CheckEmailForRegis(string email);
        Task<ReturnDto<bool>> CheckForRegis(string email, string otp);
    }
}
