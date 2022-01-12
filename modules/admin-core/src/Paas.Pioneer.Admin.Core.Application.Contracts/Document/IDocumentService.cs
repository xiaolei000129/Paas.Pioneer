using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document
{
    public partial interface IDocumentService : IApplicationService
    {
        Task<ResponseOutput<DocumentGetGroupOutput>> GetGroupAsync(Guid id);

        Task<ResponseOutput<DocumentGetMenuOutput>> GetMenuAsync(Guid id);

        Task<ResponseOutput<DocumentGetContentOutput>> GetContentAsync(Guid id);

        Task<ResponseOutput<List<string>>> GetImageListAsync(Guid id);

        Task<ResponseOutput<List<DocumentGetPlainListOutput>>> GetPlainListAsync();

        Task<ResponseOutput<List<DocumentListOutput>>> GetListAsync(string key, DateTime? start, DateTime? end);

        Task<IResponseOutput> AddGroupAsync(DocumentAddGroupInput input);

        Task<IResponseOutput> AddMenuAsync(DocumentAddMenuInput input);

        Task<IResponseOutput> AddImageAsync(DocumentAddImageInput input);

        Task<IResponseOutput> UpdateGroupAsync(DocumentUpdateGroupInput input);

        Task<IResponseOutput> UpdateMenuAsync(DocumentUpdateMenuInput input);

        Task<IResponseOutput> UpdateContentAsync(DocumentUpdateContentInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> SoftDeleteAsync(Guid id);

        Task<IResponseOutput> DeleteImageAsync(Guid documentId, string url);
    }
}