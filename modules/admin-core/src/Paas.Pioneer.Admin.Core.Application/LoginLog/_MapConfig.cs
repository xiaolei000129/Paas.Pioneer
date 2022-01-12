using AutoMapper;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;

namespace Paas.Pioneer.Admin.Core.Application.LoginLog
{
    public class _MapConfig : Profile
    {
        public _MapConfig()
        {
            CreateMap<Ad_LoginLogEntity, LoginLogOutput>();

            CreateMap<LoginLogAddInput, Ad_LoginLogEntity>();
        }
    }
}
