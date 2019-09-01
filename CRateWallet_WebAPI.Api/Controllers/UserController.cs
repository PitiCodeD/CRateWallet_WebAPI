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
                            Status = (int)StatusType.StatusRetureData.NotShowMessage,
                            Message = "Don't have return data from service"
                        });
                    }
                    else
                    {
                        if (checkEmailResult.Status == (int)StatusType.StatusRetureData.Success)
                        {
                            return new OkObjectResult(_mapper.Map<ResultModel<string>>(checkEmailResult));
                        }
                        else if(checkEmailResult.Status == (int)StatusType.StatusRetureData.ShowMessage)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<string>>(checkEmailResult));
                        }
                        else
                        {
                            return new BadRequestObjectResult(new ResultModel<string>()
                            {
                                Status = (int)StatusType.StatusRetureData.NotShowMessage,
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
                    Status = (int)StatusType.StatusRetureData.NotShowMessage,
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
                            Status = (int)StatusType.StatusRetureData.NotShowMessage,
                            Message = "Don't have return data from service"
                        });
                    }
                    else
                    {
                        if (verifiedResult.Status == (int)StatusType.StatusRetureData.Success)
                        {
                            return new OkObjectResult(_mapper.Map<ResultModel<bool>>(verifiedResult));
                        }
                        else if (verifiedResult.Status == (int)StatusType.StatusRetureData.ShowMessage)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<bool>>(verifiedResult));
                        }
                        else
                        {
                            return new BadRequestObjectResult(new ResultModel<bool>()
                            {
                                Status = (int)StatusType.StatusRetureData.NotShowMessage,
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
                    Status = (int)StatusType.StatusRetureData.NotShowMessage,
                    Message = e.ToString()
                });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterSelectorModel registerSelector)
        {
            try
            {
                string email = registerSelector.Email;
                string name = registerSelector.Name;
                string surname = registerSelector.Surname;
                DateTime birthDate = registerSelector.BirthDate;
                string mobileNo = registerSelector.MobileNo;
                int gender = registerSelector.Gender;
                string pin = registerSelector.Pin;
                string rePin = registerSelector.RePin;
                if (pin != rePin)
                {
                    return new BadRequestObjectResult(new ResultModel<RegisModel>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "รหัสใหม่ที่ใส่ไม่ตรงกับรหัสก่อนหน้า"
                    });
                }
                else
                {
                    var regisResult = await _userService.Register(email, name, surname, birthDate, mobileNo, gender, pin);
                    if (regisResult == null)
                    {
                        return new BadRequestObjectResult(new ResultModel<RegisModel>()
                        {
                            Status = (int)StatusType.StatusRetureData.NotShowMessage,
                            Message = "Don't have return data from service"
                        });
                    }
                    else
                    {
                        if (regisResult.Status == (int)StatusType.StatusRetureData.Success)
                        {
                            return new OkObjectResult(_mapper.Map<ResultModel<RegisModel>>(regisResult));
                        }
                        else if (regisResult.Status == (int)StatusType.StatusRetureData.ShowMessage)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<RegisModel>>(regisResult));
                        }
                        else if (regisResult.Status == (int)StatusType.StatusRetureData.BackToFirstPage)
                        {
                            return new BadRequestObjectResult(_mapper.Map<ResultModel<RegisModel>>(regisResult));
                        }
                        else
                        {
                            return new BadRequestObjectResult(new ResultModel<RegisModel>()
                            {
                                Status = (int)StatusType.StatusRetureData.NotShowMessage,
                                Message = "Server Code Errror!!!"
                            });
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new ResultModel<RegisModel>()
                {
                    Status = (int)StatusType.StatusRetureData.NotShowMessage,
                    Message = e.ToString()
                });
            }
        }
    }
}