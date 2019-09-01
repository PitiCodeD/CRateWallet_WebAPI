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
            if(checkEmail != 0)
            {
                return new ReturnDto<string>()
                {
                    Status = (int)StatusType.StatusRetureData.ShowMessage,
                    Message = "อีเมลนี้ถถูกใช้งานแล้ว"
                };
            }
            string reference = RandomValue(6);
            string otp = RandomNumber(6);
            await UpDateOtpRegis(email);
            await _baseService.Create<OtpForRegis>(new OtpForRegis()
            {
                Otp = otp,
                Email = email,
                Reference = reference
            });
            SentEmailMethod(email, 3, reference, otp);
            return new ReturnDto<string>()
            {
                Status = (int)StatusType.StatusRetureData.Success,
                Message = "สำเร็จเรียบร้อย",
                Data = reference
            };
        }

        public async Task<ReturnDto<bool>> CheckForRegis(string email, string otp)
        {
            var checkOtp = (await _baseService.Read<OtpForRegis>()).Where(query => query.Email == email && query.Otp == otp).SingleOrDefault();
            if(checkOtp == default)
            {
                return new ReturnDto<bool>()
                {
                    Status = (int)StatusType.StatusRetureData.ShowMessage,
                    Message = "OTP นี้ไม่มีในระบบ\nโปรดกด \"ส่ง OTP อีกครั้ง\" เพื่อรับ OTP อีกครั้ง"
                };
            }
            else
            {
                if(checkOtp.ActiveStatus == 2)
                {
                    return new ReturnDto<bool>()
                    {
                        Status = (int)StatusType.StatusRetureData.ShowMessage,
                        Message = "OTP ไม่สามารถใช้งานได้\nโปรดกด \"ส่ง OTP อีกครั้ง\" เพื่อรับ OTP อีกครั้ง"
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
                        Message = "OTP หมดอายุ\nโปรดกด \"ส่ง OTP อีกครั้ง\" เพื่อรับ OTP อีกครั้ง"
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
                string accountNo = GenerateAccountNo(StatusType.UserType.Customer, getLastId);
                await _baseService.Create<User>(new User()
                {
                    Email = email,
                    Name = name,
                    Surname = surname,
                    BirthDate = birthDate,
                    MobileNo = mobileNo,
                    Gender = gender
                });
                var userData = (await _baseService.Read<User>()).Where(query => query.Email == email).SingleOrDefault();
                if(userData == null)
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
                        string refreshToken = RandomValue(20);
                        await _baseService.Create<UserToken>(new UserToken()
                        {
                            RefreshToken = refreshToken,
                            UserId = userData.UserId
                        });
                        string accessToken = GetToken(email);
                        return new ReturnDto<RegisDto>()
                        {
                            Status = (int)StatusType.StatusRetureData.Success,
                            Message = "สำเร็จเรียบร้อย",
                            Data = new RegisDto()
                            {
                                AccessToken = accessToken,
                                RefreshToken = refreshToken
                            }
                        };
                    }
                }
            }
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
                    SentEmailId = 3,
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
                    SentEmailId = 2,
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

        private string GetToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], username, expires: DateTime.UtcNow.AddMinutes(Int32.Parse(_configuration["Jwt:Expire"])), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
