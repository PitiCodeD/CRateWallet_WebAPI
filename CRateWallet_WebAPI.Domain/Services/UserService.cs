using CRateWallet_WebAPI.DataAccess.Models;
using CRateWallet_WebAPI.Domain.Interfaces;
using CRateWallet_WebAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        private readonly IConfiguration _configuration;
        public UserService(IBaseService baseService, IConfiguration configuration)
        {
            _baseService = baseService;
            _configuration = configuration;
        }

        public async Task<ReturnDto<string>> CheckEmailForRegis(string email)
        {
            int checkEmail = (await _baseService.Read<User>()).Where(query => query.Email == email).Count();
            if(checkEmail == 1)
            {
                var dataUser = (await _baseService.Read<User>()).Where(query => query.Email == email).Single();
                if(dataUser.ActiveStatus == 2)
                {
                    return new ReturnDto<string>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "อีเมล์ไม่สามารถใช้งานแอพพลิเคชั่นนี้ได้โปรดติดต่อเจ้าหน้าที่"
                    };
                }
                else
                {
                    var dataOtp = (await _baseService.Read<OtpManagement>()).Where(query => query.UserId == dataUser.UserId).Single();
                    await _baseService.Update<User>(new User()
                    {
                        UserId = dataUser.UserId,
                        Balance = dataUser.Balance,
                        Email = dataUser.Email,
                        Name = dataUser.Name,
                        Surname = dataUser.Surname,
                        BirthDate = dataUser.BirthDate,
                        MobileNo = dataUser.MobileNo,
                        AccountNo = dataUser.AccountNo,
                        Gender = dataUser.Gender,
                        ActiveStatus = 3,
                        UpdateDatetime = DateTime.UtcNow
                    }, dataUser.UserId);
                    string reference = RandomValue(6);
                    string otp = RandomNumber(6);
                    await _baseService.Update<OtpManagement>(new OtpManagement()
                    {
                        OtpId = dataOtp.OtpId,
                        UserId = dataOtp.UserId,
                        Otp = otp,
                        Type = 2,
                        Reference = reference,
                        ActiveStatus = 1,
                        UpdateDatetime = DateTime.UtcNow
                    }, dataOtp.OtpId);
                    SentEmailMethod(email, 2, reference, otp);
                    return new ReturnDto<string>()
                    {
                        Status = (int)StatusType.StatusRetureData.SecondLogin,
                        Message = "สำเร็จเรียบร้อย",
                        Data = reference
                    };
                }
                
            }
            else if(checkEmail > 1)
            {
                var changeEmail = (await _baseService.Read<User>()).Where(query => query.Email == email).ToList();
                foreach(var thisEmail in changeEmail)
                {
                    await _baseService.Update<User>(new User()
                    {
                        UserId = thisEmail.UserId,
                        Balance = thisEmail.Balance,
                        Email = thisEmail.Email,
                        Name = thisEmail.Name,
                        Surname = thisEmail.Surname,
                        BirthDate = thisEmail.BirthDate,
                        MobileNo = thisEmail.MobileNo,
                        AccountNo = thisEmail.AccountNo,
                        Gender = thisEmail.Gender,
                        ActiveStatus = 2,
                        UpdateDatetime = DateTime.UtcNow
                    }, thisEmail.UserId);
                }
                return new ReturnDto<string>()
                {
                    Status = (int)StatusType.StatusRetureData.ShowMessage,
                    Message = "อีเมล์ของคุณเกิดปัญหาโปรดติดต่อผู้ดูแลโดยด่วน"
                };
            }
            else
            {
                string reference = RandomValue(6);
                string otp = RandomNumber(6);
                await UpDateOtpRegis(email);
                await _baseService.Create<OtpForRegis>(new OtpForRegis()
                {
                    Otp = otp,
                    Email = email,
                    Reference = reference
                });
                SentEmailMethod(email, 2, reference, otp);
                return new ReturnDto<string>()
                {
                    Status = (int)StatusType.StatusRetureData.Success,
                    Message = "สำเร็จเรียบร้อย",
                    Data = reference
                };
            }
        }

        public async Task<ReturnDto<bool>> CheckForRegis(string email, string otp)
        {
            var checkOtp = (await _baseService.Read<OtpForRegis>()).Where(query => query.Email == email && query.Otp == otp).SingleOrDefault();
            if(checkOtp == default)
            {
                return new ReturnDto<bool>()
                {
                    Status = (int)StatusType.StatusRetureData.ShowMessage,
                    Message = "OTP ไม่ถูกต้อง"
                };
            }
            else
            {
                if(checkOtp.ActiveStatus == 2)
                {
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "OTP ไม่สามารถใช้งานได้"
                    };
                }
                else if (checkOtp.UpdateDatetime.AddMinutes(15) < DateTime.UtcNow)
                {
                    await _baseService.Update<OtpForRegis>(new OtpForRegis
                    {
                        OtpId = checkOtp.OtpId,
                        Email = checkOtp.Email,
                        Reference = "Delete",
                        Otp = "Delete",
                        ActiveStatus = 2,
                        UpdateDatetime = DateTime.UtcNow
                    }, checkOtp.OtpId);
                    await UpDateOtpRegis(email);
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "OTP หมดอายุ"
                    };
                }
                else
                {
                    await _baseService.Update<OtpForRegis>(new OtpForRegis
                    {
                        OtpId = checkOtp.OtpId,
                        Email = checkOtp.Email,
                        Reference = "Delete",
                        Otp = "Delete",
                        ActiveStatus = 3,
                        UpdateDatetime = DateTime.UtcNow
                    }, checkOtp.OtpId);
                    await UpDateOtpRegis(email);
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.Success,
                        Message = "สำเร็จเรียบร้อย"
                    };
                }
            }
        }

        public async Task<ReturnDto<RegisDto>> Register(string email, string name, string surname, DateTime birthDate, string mobileNo, int gender, string pin)
        {
            var checkEmail = (await _baseService.Read<OtpForRegis>()).Where(query => query.Email == email && query.ActiveStatus == 3).LastOrDefault();
            var checkGender = (await _baseService.Read<GenderDescription>()).Where(query => query.Gender == gender).SingleOrDefault();
            if(checkEmail == default)
            {
                return new ReturnDto<RegisDto>()
                {
                    Status = (int)StatusType.StatusRetureData.BackToFirstPage,
                    Message = "This email doesn't Verified please check database"
                };
            }
            else if(checkGender == default)
            {
                return new ReturnDto<RegisDto>()
                {
                    Status = (int)StatusType.StatusRetureData.BackToFirstPage,
                    Message = "This Gender id " + gender + " doesn't have in database"
                };
            }
            else
            {
                await UpDateAllOtpRegis(email);
                int getLastId = (await _baseService.Read<User>()).Select(query => query.UserId).LastOrDefault() + 1;
                if(getLastId == default)
                {
                    getLastId = 1;
                }
                if(getLastId > 999999)
                {
                    return new ReturnDto<RegisDto>()
                    {
                        Status = (int)StatusType.StatusRetureData.BackToFirstPage,
                        Message = "Data base Full"
                    };
                }
                else
                {
                    string accountNo = GenerateAccountNo(StatusType.UserType.Customer, getLastId);
                    await _baseService.Create<User>(new User()
                    {
                        Email = email,
                        Name = name,
                        Surname = surname,
                        BirthDate = birthDate,
                        MobileNo = mobileNo,
                        AccountNo = accountNo,
                        Gender = gender
                    });
                    var userData = (await _baseService.Read<User>()).Where(query => query.Email == email).SingleOrDefault();
                    if (userData == null)
                    {
                        return new ReturnDto<RegisDto>()
                        {
                            Status = (int)StatusType.StatusRetureData.NotShowMessage,
                            Message = "This User id " + userData.UserId + " have a problem can't input to database"
                        };
                    }
                    else
                    {
                        if (getLastId != userData.UserId)
                        {
                            return new ReturnDto<RegisDto>()
                            {
                                Status = (int)StatusType.StatusRetureData.NotShowMessage,
                                Message = "This User id " + userData.UserId + " have a problem please delete in database"
                            };
                        }
                        else
                        {
                            var creatPass = GeneratePassword(pin);
                            await _baseService.Create<PinManagement>(new PinManagement()
                            {
                                UserId = userData.UserId,
                                Pin = creatPass.HashPass,
                                Salt = creatPass.Salt
                            });
                            await _baseService.Create<OtpManagement>(new OtpManagement()
                            {
                                UserId = userData.UserId,
                                Otp = "Delete",
                                Reference = "Delete"
                            });
                            var dataToken = GetAllToken(email, userData.AccountNo);
                            await _baseService.Create<UserToken>(new UserToken()
                            {
                                RefreshToken = dataToken.RefreshToken,
                                UserId = userData.UserId
                            });
                            return new ReturnDto<RegisDto>()
                            {
                                Status = (int)StatusType.StatusRetureData.Success,
                                Message = "สำเร็จเรียบร้อย",
                                Data = dataToken
                            };
                        }
                    }
                }
            }
        }

        public async Task<ReturnDto<bool>> CheckForChangePin(string email, string otp)
        {
            var checkEmail = (await _baseService.Read<User>()).Where(query => query.Email == email).SingleOrDefault();
            var checkOtp = (await _baseService.Read<OtpManagement>()).Where(query => query.UserId == checkEmail.UserId && query.Otp == otp).SingleOrDefault();
            if (checkOtp == default)
            {
                return new ReturnDto<bool>()
                {
                    Status = (int)StatusType.StatusRetureData.ShowMessage,
                    Message = "OTP ไม่ถูกต้อง"
                };
            }
            else
            {
                if (checkOtp.ActiveStatus == 2)
                {
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "OTP ไม่สามารถใช้งานได้"
                    };
                }
                else if (checkOtp.UpdateDatetime.AddMinutes(15) < DateTime.UtcNow)
                {
                    await _baseService.Update<OtpManagement>(new OtpManagement
                    {
                        OtpId = checkOtp.OtpId,
                        UserId = checkOtp.UserId,
                        Reference = "Delete",
                        Otp = "Delete",
                        ActiveStatus = 2,
                        Type = 1,
                        UpdateDatetime = DateTime.UtcNow
                    }, checkOtp.OtpId);
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "OTP หมดอายุ"
                    };
                }
                else
                {
                    await _baseService.Update<OtpManagement>(new OtpManagement
                    {
                        OtpId = checkOtp.OtpId,
                        UserId = checkOtp.UserId,
                        Reference = "Delete",
                        Otp = "Delete",
                        ActiveStatus = 3,
                        Type = 1,
                        UpdateDatetime = DateTime.UtcNow
                    }, checkOtp.OtpId);
                    await UpDateOtpRegis(email);
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.Success,
                        Message = "สำเร็จเรียบร้อย"
                    };
                }
            }
        }

        public async Task<ReturnDto<RegisDto>> ChangePin(string email, string pin)
        {
            var checkEmail = (await _baseService.Read<User>()).Where(query => query.Email == email && query.ActiveStatus == 3).SingleOrDefault();
            var checkOtp = (await _baseService.Read<OtpManagement>()).Where(query => query.UserId == checkEmail.UserId && query.ActiveStatus == 3).SingleOrDefault();
            if (checkEmail == default || checkOtp == default)
            {
                return new ReturnDto<RegisDto>()
                {
                    Status = (int)StatusType.StatusRetureData.NotShowMessage,
                    Message = "This Email " + email + " have a problem please contact this Email urgently"
                };
            }
            else
            {
                var checkPin = (await _baseService.Read<PinManagement>()).Where(query => query.UserId == checkEmail.UserId && query.ActiveStatus == 3).Single();
                var checkToken = (await _baseService.Read<UserToken>()).Where(query => query.UserId == checkEmail.UserId).Single();
                var creatPass = GeneratePassword(pin);
                await _baseService.Update<PinManagement>(new PinManagement()
                {
                    PinId = checkPin.PinId,
                    UserId = checkPin.UserId,
                    Pin = creatPass.HashPass,
                    Salt = creatPass.Salt,
                    ActiveStatus = 1,
                    UpdateDatetime = DateTime.UtcNow
                }, checkPin.PinId);
                await _baseService.Update<OtpManagement>(new OtpManagement
                {
                    OtpId = checkOtp.OtpId,
                    UserId = checkOtp.UserId,
                    Reference = "Delete",
                    Otp = "Delete",
                    ActiveStatus = 2,
                    Type = 1,
                    UpdateDatetime = DateTime.UtcNow
                }, checkOtp.OtpId);
                var dataToken = GetAllToken(email, checkEmail.AccountNo);
                await _baseService.Update<UserToken>(new UserToken()
                {
                    TokenId = checkToken.TokenId
                    RefreshToken = dataToken.RefreshToken,
                    UserId = checkToken.UserId,
                    ActiveStatus = 1,
                    UpdateDatetime = DateTime.UtcNow

                }, checkToken.UserId);
                return new ReturnDto<RegisDto>()
                {
                    Status = (int)StatusType.StatusRetureData.Success,
                    Message = "สำเร็จเรียบร้อย",
                    Data = dataToken
                };
            }
            throw new NotImplementedException();
        }

        private string RandomValue(int length)
        {
            Random random = new Random();
            int[] ranforindex = new int[3];
            ranforindex[0] = random.Next(length);
            for (int i = 1; i <= 2; i++)
            {
                int ranupindex = random.Next(length);
                bool check = true;
                foreach (int ran in ranforindex)
                {
                    if (ranupindex == ran)
                    {
                        check = !check;
                    }
                }
                if (check)
                {
                    ranforindex[i] = ranupindex;
                }
                else
                {
                    i--;
                }
            }
            char[] numchar = new char[length];
            numchar[ranforindex[0]] = Convert.ToChar(random.Next(48, 57));
            numchar[ranforindex[1]] = Convert.ToChar(random.Next(65, 90));
            numchar[ranforindex[2]] = Convert.ToChar(random.Next(97, 122));
            for (int k = 0; k < numchar.Length; k++)
            {
                if (k != ranforindex[0] || k != ranforindex[1] || k != ranforindex[2])
                {
                    int theNum = random.Next(3);
                    switch (theNum)
                    {
                        case 0: numchar[k] = Convert.ToChar(random.Next(48, 58)); break;
                        case 1: numchar[k] = Convert.ToChar(random.Next(65, 91)); break;
                        default: numchar[k] = Convert.ToChar(random.Next(97, 123)); break;
                    }
                }
            }
            string result = "";
            foreach (char c in numchar)
            {
                result += c.ToString();
            }
            return result;
        }

        private string RandomNumber(int length)
        {
            Random random = new Random();
            string num = "";
            for(int i = 1;i<= length; i++)
            {
                num += Convert.ToChar(random.Next(48, 58));
            }
            return num;
        }

        private void SentEmailMethod(string email, int sentby, string refe, string value)//1 Sent OTP E-mail & 2 Sent Password
        {
            List<SentEmailDto> sents = new List<SentEmailDto>()
            {
                new SentEmailDto()
                {
                    SentEmailId = 2,
                    Title = "OTP for verify oneself your e-mail",
                    Description = $@"OTP for Verify oneself your E-mail in CRateWallet application
Reference : {refe}
OTP : {value}
This OTP is expiry 15 minutes from now
This email is an automatic response. Don't send any messages back
Thank you CRateWallet"
                },
                new SentEmailDto()
                {
                    SentEmailId = 1,
                    Title = "OTP for verify oneself your password",
                    Description = $@"OTP for Verify oneself your password in CRateWallet application
Reference : {refe}
New Password : {value}
This OTP is expiry 15 minutes from now
This email is an automatic response. Don't send any messages back
Thank you CRateWallet"
                }
            };
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("622707130011@dpu.ac.th");
            mail.To.Add(email);
            mail.Subject = sents.Where(queue => queue.SentEmailId == sentby).Select(queue => queue.Title).SingleOrDefault();
            mail.Body = sents.Where(queue => queue.SentEmailId == sentby).Select(queue => queue.Description).SingleOrDefault();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("622707130011@dpu.ac.th", "1101700205967");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private async Task UpDateOtpRegis(string email)
        {
            var bannedEmail = (await _baseService.Read<OtpForRegis>()).Where(query => query.Email == email && query.ActiveStatus == 1).ToList();
            foreach (var bannned in bannedEmail)
            {
                await _baseService.Update<OtpForRegis>(new OtpForRegis
                {
                    OtpId = bannned.OtpId,
                    Email = bannned.Email,
                    Reference = "Delete",
                    Otp = "Delete",
                    ActiveStatus = 2,
                    UpdateDatetime = DateTime.UtcNow
                }, bannned.OtpId);
            }
        }

        private async Task UpDateAllOtpRegis(string email)
        {
            var bannedEmail = (await _baseService.Read<OtpForRegis>()).Where(query => query.Email == email && query.ActiveStatus != 2).ToList();
            foreach (var bannned in bannedEmail)
            {
                await _baseService.Update<OtpForRegis>(new OtpForRegis
                {
                    OtpId = bannned.OtpId,
                    Email = bannned.Email,
                    Reference = "Delete",
                    Otp = "Delete",
                    ActiveStatus = 2,
                    UpdateDatetime = DateTime.UtcNow
                }, bannned.OtpId);
            }
        }

        private string GenerateAccountNo(StatusType.UserType type, int id)
        {
            return $"{(int)type}-000-" + GenerateAccountUserNo(id);
        }

        private string GenerateAccountUserNo(int id)
        {
            string sId = id.ToString("000000");
            string result = "";
            for (int i = 0; i < sId.Length; i++)
            {
                string num = sId.Substring(i, 1);
                num = ((Int32.Parse(num) + i * i) % 10).ToString();
                result += num;
            }
            return result;
        }

        private string HashPassword(string password, string salt)
        {
            string beforPass = salt.Substring(0, 5);
            string afterPass = salt.Substring(5);
            string preHash = beforPass + password + afterPass;
            byte[] bytes = Encoding.Unicode.GetBytes(preHash);
            SHA256Managed hashObj = new SHA256Managed();
            byte[] byteHash = hashObj.ComputeHash(bytes);
            string hashPass = "";
            foreach (byte x in byteHash)
            {
                hashPass = hashPass + String.Format("{0:x2}", x);
            }
            return hashPass;
        }

        private GenPassDto GeneratePassword(string password)
        {
            string salt = RandomValue(10);
            string hashPass = HashPassword(password, salt);
            return new GenPassDto()
            {
                HashPass = hashPass,
                Salt = salt
            };
        }

        private string GetToken(string username, string accountNo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], username+"*"+accountNo, expires: DateTime.UtcNow.AddMinutes(Int32.Parse(_configuration["Jwt:Expire"])), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RegisDto GetAllToken(string username, string accountNo)
        {
            string refreshToken = RandomValue(20);
            string accessToken = GetToken(username, accountNo);
            return new RegisDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
