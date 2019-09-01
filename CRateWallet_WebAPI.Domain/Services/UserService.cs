using CRateWallet_WebAPI.DataAccess.Models;
using CRateWallet_WebAPI.Domain.Interfaces;
using CRateWallet_WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public async Task<ReturnDto<string>> CheckEmailForRegis(string email)
        {
            int checkEmail = (await _baseService.Read<User>()).Where(query => query.Email == email).Count();
            if(checkEmail != 0)
            {
                return new ReturnDto<string>()
                {
                    Status = 2,
                    Message = "This email has already been used."
                };
            }
            string reference = RandomValue(6);
            string otp = RandomNumber(6);
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
            await _baseService.Create<OtpForRegis>(new OtpForRegis()
            {
                Otp = otp,
                Email = email,
                Reference = reference
            });
            SentEmailMethod(email, 1, reference, otp);
            return new ReturnDto<string>()
            {
                Status = 1,
                Message = "Success",
                Data = reference
            };
        }

        public async Task<ReturnDto<bool>> CheckForRegis(string email, string otp)
        {
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
                    SentEmailId = 1,
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
    }
}
