using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
                    var checkEmailResult = await _userService.CheckEmailForRegis(email);
                    if(checkEmailResult == null)
                    {
                        return new BadRequestObjectResult(new ResultModel<string>()
                        {
                            Status = 3,
                            Message = "Don't have return data from service"
                        });
                    }
                    else
                    {
                        if (checkEmailResult.Status == 1)
                        {
                            return new OkObjectResult(_mapper.Map<ResultModel<string>>(checkEmailResult));
                        }
                        else if(checkEmailResult.Status == 2)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<string>>(checkEmailResult));
                        }
                        else
                        {
                            return new BadRequestObjectResult(new ResultModel<string>()
                            {
                                Status = 3,
                                Message = "Server Code Errror!!!"
                            });
                        }
                    }
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

        [HttpPost("checkemail")]
        public async Task<IActionResult> VerifiedEmailForRegis([FromBody]VerifiedEmailSelectorModel verifiedEmailSelector)
        {
            try
            {
                string email = verifiedEmailSelector.Email;
                string otp = verifiedEmailSelector.Otp;
                if (false)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var verifiedResult = await _userService.CheckForRegis(email, otp);
                    if (verifiedResult == null)
                    {
                        return new BadRequestObjectResult(new ResultModel<bool>()
                        {
                            Status = 3,
                            Message = "Don't have return data from service"
                        });
                    }
                    else
                    {
                        if (verifiedResult.Status == 1)
                        {
                            return new OkObjectResult(_mapper.Map<ResultModel<bool>>(verifiedResult));
                        }
                        else if (verifiedResult.Status == 2)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<bool>>(verifiedResult));
                        }
                        else
                        {
                            return new BadRequestObjectResult(new ResultModel<bool>()
                            {
                                Status = 3,
                                Message = "Server Code Errror!!!"
                            });
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new ResultModel<bool>()
                {
                    Status = 3,
                    Message = e.ToString()
                });
            }
        }
    }
}