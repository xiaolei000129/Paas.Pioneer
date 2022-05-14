using Paas.Pioneer.Admin.Core.Application.Contracts.Dictionary.Dto.Output;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client.ServiceProxies
{
    public interface IDictionaryServiceProxy : IRefitServiceProxy
    {
        [Get("/rpc/admin/Dictionary/GetList")]
        Task<IEnumerable<GetDictionaryOutput>> GetListAsync(Guid[] ids);
    }
}
