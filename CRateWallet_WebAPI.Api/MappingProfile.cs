using AutoMapper;
using CRateWallet_WebAPI.Api.Models;
using CRateWallet_WebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReturnDto<string>, ResultModel<string>>();
            CreateMap<ReturnDto<bool>, ResultModel<bool>>();
            CreateMap<ReturnDto<RegisDto>, ResultModel<RegisModel>>();
        }
    }
}
