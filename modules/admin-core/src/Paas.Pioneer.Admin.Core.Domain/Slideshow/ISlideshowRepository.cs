using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Slideshow
{
    public interface ISlideshowRepository : IRepository<Information_SlideshowEntity, Guid>, IBaseExtensionRepository<Information_SlideshowEntity>
    {
        Task<Page<GetSlideshowPageListOutput>> GetPageListAsync(PageInput<GetSlideshowPageListInput> input);
    }
}
