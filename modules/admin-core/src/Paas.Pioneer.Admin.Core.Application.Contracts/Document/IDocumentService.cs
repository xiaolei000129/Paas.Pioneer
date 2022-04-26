using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Document
{
    public partial interface IDocumentService : IApplicationService
    {
        Task<DocumentGetGroupOutput> GetGroupAsync(Guid id);

        Task<DocumentGetMenuOutput> GetMenuAsync(Guid id);

        Task<DocumentGetContentOutput> GetContentAsync(Guid id);

        Task<List<string>> GetImageListAsync(Guid id);

        Task<List<DocumentGetPlainListOutput>> GetPlainListAsync();

        Task<List<DocumentListOutput>> GetListAsync(string key, DateTime? start, DateTime? end);

        Task AddGroupAsync(DocumentAddGroupInput input);

        Task AddMenuAsync(DocumentAddMenuInput input);

        Task AddImageAsync(DocumentAddImageInput input);

        Task UpdateGroupAsync(DocumentUpdateGroupInput input);

        Task UpdateMenuAsync(DocumentUpdateMenuInput input);

        Task UpdateContentAsync(DocumentUpdateContentInput input);

        Task DeleteAsync(Guid id);

        Task SoftDeleteAsync(Guid id);

        Task DeleteImageAsync(Guid documentId, string url);
    }
}