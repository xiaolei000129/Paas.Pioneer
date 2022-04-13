using Paas.Pioneer.Admin.Core.Application.Contracts.Document;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Document.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.Domain.DocumentImage;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Document
{
    public class DocumentService : ApplicationService, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentImageRepository _documentImageRepository;

        public DocumentService(
            IDocumentRepository DocumentRepository,
            IDocumentImageRepository documentImageRepository
        )
        {
            _documentRepository = DocumentRepository;
            _documentImageRepository = documentImageRepository;
        }
        public async Task<ResponseOutput<List<DocumentListOutput>>> GetListAsync(string key, DateTime? start, DateTime? end)
        {
            if (end.HasValue)
            {
                end = end.Value.AddDays(1);
            }
            Expression<Func<Ad_DocumentEntity, bool>> predicate = x => true;
            if (!key.IsNullOrEmpty())
            {
                predicate = predicate.And(a => a.Name.Contains(key) || a.Label.Contains(key));
            }
            if (start.HasValue && end.HasValue)
            {
                predicate = predicate.And(a => a.CreationTime.IsBetween(start.Value, end.Value));
            }
            return await _documentRepository.GetResponseOutputListAsync(expression: predicate,
                selector: x => new DocumentListOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    Label = x.Label,
                    Type = x.Type,
                    Opened = x.Opened,
                    ParentId = x.ParentId,
                    Description = x.Description,
                }, x => x.OrderBy(p => p.Sort));
        }

        /// <summary>
        /// 获取Image集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseOutput<List<string>>> GetImageListAsync(Guid id)
        {
            return await _documentImageRepository.GetResponseOutputListAsync(a => a.DocumentId == id,
                a => a.Url,
                x => x.OrderByDescending(a => a.CreationTime));
        }

        public async Task<IResponseOutput> AddGroupAsync(DocumentAddGroupInput input)
        {
            var entity = ObjectMapper.Map<DocumentAddGroupInput, Ad_DocumentEntity>(input);
            await _documentRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> AddMenuAsync(DocumentAddMenuInput input)
        {
            var entity = ObjectMapper.Map<DocumentAddMenuInput, Ad_DocumentEntity>(input);
            await _documentRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> AddImageAsync(DocumentAddImageInput input)
        {
            var entity = ObjectMapper.Map<DocumentAddImageInput, Ad_DocumentImageEntity>(input);
            await _documentImageRepository.InsertAsync(entity);

            return ResponseOutput.Succees("添加成功！");
        }

        public async Task<IResponseOutput> UpdateGroupAsync(DocumentUpdateGroupInput input)
        {
            var entity = await _documentRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _documentRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> UpdateMenuAsync(DocumentUpdateMenuInput input)
        {
            var entity = await _documentRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _documentRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> UpdateContentAsync(DocumentUpdateContentInput input)
        {
            var entity = await _documentRepository.GetAsync(input.Id);
            entity = ObjectMapper.Map(input, entity);
            await _documentRepository.UpdateAsync(entity);

            return ResponseOutput.Succees("修改成功！");
        }

        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _documentRepository.DeleteAsync(m => m.Id == id);

            return ResponseOutput.Succees("删除成功！");
        }

        public async Task<IResponseOutput> DeleteImageAsync(Guid documentId, string url)
        {
            if (documentId != Guid.Empty && !url.IsNullOrEmpty())
            {
                await _documentImageRepository.DeleteAsync(m => m.DocumentId == documentId && m.Url == url);
            }
            return ResponseOutput.Succees("删除成功！");
        }

        public async Task<ResponseOutput<List<DocumentGetPlainListOutput>>> GetPlainListAsync()
        {
            return await _documentRepository.GetResponseOutputListAsync(expression: a => (new[] { EDocumentType.Group, EDocumentType.Markdown }).Contains(a.Type),
                selector: a => new DocumentGetPlainListOutput
                {
                    Id = a.Id,
                    ParentId = a.ParentId,
                    Label = a.Label,
                    Type = a.Type,
                    Opened = a.Opened
                },
                x => x.OrderByDescending(x => x.Sort));
        }

        public async Task<IResponseOutput> SoftDeleteAsync(Guid id)
        {
            await _documentRepository.DeleteAsync(id);
            return ResponseOutput.Succees("操作成功");
        }

        public async Task<ResponseOutput<DocumentGetGroupOutput>> GetGroupAsync(Guid id)
        {
            var result = await _documentRepository.GetAsync(x => x.Id == id, x => new DocumentGetGroupOutput()
            {
                Id = x.Id,
                Label = x.Label,
                Name = x.Name,
                Opened = x.Opened.Value,
                ParentId = x.ParentId,
                Type = x.Type,
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<DocumentGetMenuOutput>> GetMenuAsync(Guid id)
        {
            var result = await _documentRepository.GetAsync(x => x.Id == id, x => new DocumentGetMenuOutput()
            {
                Id = x.Id,
                Description = x.Description,
                Label = x.Label,
                Name = x.Name,
                ParentId = x.ParentId,
                Type = x.Type,
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<ResponseOutput<DocumentGetContentOutput>> GetContentAsync(Guid id)
        {
            var result = await _documentRepository.GetAsync(x => x.Id == id, x => new DocumentGetContentOutput()
            {
                Id = x.Id,
                Content = x.Content,
                Label = x.Label,
            });
            return ResponseOutput.Succees(result);
        }
    }
}