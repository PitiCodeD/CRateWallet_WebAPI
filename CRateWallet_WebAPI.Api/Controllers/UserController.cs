using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRateWallet_WebAPI.Api.Models;
using CRateWallet_WebAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRateWallet_WebAPI.Api.Controllers
{
    [Route("walllet/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("otpregis")]
        public async Task<IActionResult> RequestOtpForRegis([FromBody]TextSelectorModel textSelector)
        {
            try
            {
                string email = textSelector.Text;
                if (false)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new ResultModel<string>()
                {
                    Status = 3,
                    Message = e.ToString()
                });
            }
        }

    }
}