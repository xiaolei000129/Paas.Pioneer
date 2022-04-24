using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Api;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.Domain.Shared.Const;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Admin.Core.Domain.Shared.Helpers;
using Paas.Pioneer.Admin.Core.Domain.Shared.TextTemplatingDefinition;
using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TextTemplating;

namespace Paas.Pioneer.Admin.Core.Application.LowCodeTable
{
    public class LowCodeTableService : ApplicationService, ILowCodeTableService
    {
        /// <summary>
        /// 低代码表格仓储
        /// </summary>
        private readonly ILowCodeTableConfigRepository _lowCodeTableConfigRepository;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IApiRepository _apiRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionApiRepository _permissionApiRepository;

        private readonly ILowCodeTableRepository _lowCodeTableRepository;



        public LowCodeTableService(ILowCodeTableRepository lowCodeTableRepository,
            ITemplateRenderer templateRenderer,
            ILowCodeTableConfigRepository lowCodeTableConfigRepository,
            IApiRepository apiRepository,
            IViewRepository viewRepository,
            IPermissionRepository permissionRepository,
            IPermissionApiRepository permissionApiRepository)
        {
            _lowCodeTableRepository = lowCodeTableRepository;
            _templateRenderer = templateRenderer;
            _lowCodeTableConfigRepository = lowCodeTableConfigRepository;
            _apiRepository = apiRepository;
            _viewRepository = viewRepository;
            _permissionRepository = permissionRepository;
            _permissionApiRepository = permissionApiRepository;
        }

        public async Task<IResponseOutput> AddLowCodeTableAsync(AddLowCodeTableInput input)
        {
            // 验证是否已存在
            bool isExist = await _lowCodeTableRepository.AnyAsync(x => x.LowCodeTableName == input.LowCodeTableName);
            if (isExist)
                return ResponseOutput.Error<bool>(msg: "已经存在该表");

            var entity = ObjectMapper.Map<AddLowCodeTableInput, Ad_LowCodeTableEntity>(input);
            await _lowCodeTableRepository.InsertAsync(entity);
            return ResponseOutput.Succees(true);
        }

        public async Task<IResponseOutput> EditLowCodeTableAsync(EditLowCodeTableInput input)
        {
            // 验证除自身外是否已存在
            bool isExist = await _lowCodeTableRepository
                .AnyAsync(x => x.LowCodeTableName == input.LowCodeTableName && x.Id != input.Id);

            if (isExist)
                return ResponseOutput.Error<bool>(msg: "已经存在该表");

            var table = await _lowCodeTableRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, table);

            await _lowCodeTableRepository.UpdateAsync(table);
            return ResponseOutput.Succees(true);
        }

        public async Task<IResponseOutput> DelLowCodeTableAsync(Guid id)
        {
            await _lowCodeTableRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees(true);
        }

        public async Task<ResponseOutput<Page<LowCodeTableOutput>>> GetLowCodeTablePageListAsync(PageInput<GetLowCodeTablePadedInput> input)
        {
            var data = await _lowCodeTableRepository.GetLowCodeTablePageListAsync(input);
            return ResponseOutput.Succees(data);
        }

        public async Task<IResponseOutput<LowCodeTableOutput>> GetAsync(Guid id)
        {
            var result = await _lowCodeTableRepository.GetAsync(x => x.Id == id, x => new LowCodeTableOutput()
            {
                Id = x.Id,
                MenuParentId = x.MenuParentId,
                FunctionModule = x.FunctionModule,
                LowCodeTableName = x.LowCodeTableName,
                Description = x.Description,
                CreationTime = x.CreationTime,
                MenuName = x.MenuName,
                Taxon = x.Taxon
            });
            return ResponseOutput.Succees(result);
        }

        public async Task<IResponseOutput> BatchDeleteAsync(IEnumerable<Guid> ids)
        {
            await _lowCodeTableRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees();
        }

        public async Task<IResponseOutput<IEnumerable<LowCodeTableEntityOutput>>> GetTableEntityListAsync()
        {
            var _dbContext = await _lowCodeTableRepository.GetDbContextAsync();
            return ResponseOutput.Succees(_dbContext.Model.GetEntityTypes().Select(u =>
                {
                    var constructorArgument = ((ConstructorBinding)u.ConstructorBinding)?
                         .RuntimeType?
                         .CustomAttributes?
                         .FirstOrDefault(x => x.AttributeType == typeof(CommentAttribute))?
                         .ConstructorArguments?
                         .FirstOrDefault();
                    return new LowCodeTableEntityOutput
                    {
                        TableName = u.GetDefaultTableName(),
                        TableComment = constructorArgument?.Value?.ToString(),
                    };
                }));
        }

        public async Task<IResponseOutput<List<LowCodeTableColumnOutput>>> GetColumnListByTableNameAsync(Guid id)
        {
            var _dbContext = await _lowCodeTableRepository.GetDbContextAsync();
            var lowCodeTableName = await _lowCodeTableRepository.GetAsync(x => x.Id == id, x => x.LowCodeTableName);

            if (lowCodeTableName == null)
            {
                return ResponseOutput.Error<List<LowCodeTableColumnOutput>>("数据错误");
            }
            // 获取实体类型属性
            var entityType = _dbContext.Model.GetEntityTypes().FirstOrDefault(u => u.ClrType.Name == lowCodeTableName);
            if (entityType == null)
            {
                return ResponseOutput.Error<List<LowCodeTableColumnOutput>>("数据错误");
            }

            // 获取原始类型属性
            var type = entityType.ClrType;
            if (type == null)
            {
                return ResponseOutput.Error<List<LowCodeTableColumnOutput>>("数据错误");
            }
            // 获取实体字段列表
            List<LowCodeTableColumnOutput> lowCodeTableColumnList = type.GetProperties().Select(propertyInfo => entityType.FindProperty(propertyInfo.Name))
                       .Where(p => p != null && !CodeGenUtil.GetDefaultColumnList().Contains(p.Name))
                       .Select(p =>
                       {
                           var commentAttribute = p.PropertyInfo.GetCustomAttributes(typeof(CommentAttribute), true)?.FirstOrDefault() as CommentAttribute;
                           return new LowCodeTableColumnOutput
                           {
                               LowCodeTableId = id,
                               ColumnName = p.Name,
                               ColumnKey = p.IsKey().ToString(),
                               DataType = p.PropertyInfo.PropertyType.ToString(),
                               NetType = CodeGenUtil.ConvertDataType(p.PropertyInfo.PropertyType.ToString()),
                               ColumnComment = commentAttribute?.Comment,
                               MaxLength = p.GetMaxLength(),
                               IsNullable = p.IsColumnNullable(),
                               DefaultValue = p.GetDefaultValue(),
                           };
                       }).ToList();

            // 获取表配置列表
            var lowCodeTableConfigList = await _lowCodeTableConfigRepository.GetListAsync(x => x.LowCodeTableId == id);
            if (lowCodeTableConfigList.Any())
            {
                foreach (var item in lowCodeTableConfigList)
                {
                    var lowCodeTableColumnOutput = lowCodeTableColumnList.FirstOrDefault(x => x.ColumnName == item.ColumnName);
                    if (lowCodeTableColumnOutput != null)
                    {
                        ObjectMapper.Map(item, lowCodeTableColumnOutput);
                    }
                }
            }
            // 按原始类型的顺序获取所有实体类型属性（不包含导航属性，会返回null）
            return ResponseOutput.Succees(lowCodeTableColumnList);
        }

        public async Task<IResponseOutput> GenerateCodeAsync(Guid id)
        {
            try
            {
                var lowCodeTable = await _lowCodeTableRepository.GetAsync(id);
                if (lowCodeTable == null)
                {
                    throw new BusinessException("数据错误");
                }
                var getColumnList = await GetColumnListByTableNameAsync(id);
                if (!getColumnList.Success)
                {
                    return getColumnList;
                }
                var generateCodeLowCodeTableOutput = ObjectMapper.Map<Ad_LowCodeTableEntity, GenerateCodeLowCodeTableOutput>(lowCodeTable);
                generateCodeLowCodeTableOutput.LowCodeTableConfigList = ObjectMapper.Map<List<LowCodeTableColumnOutput>, List<GenerateCodeLowCodeTableConfigOutPut>>(getColumnList.Data);
                await GenerateCodeFileContentAsync(generateCodeLowCodeTableOutput);
                //await GeneratePermissionAsync(generateCodeLowCodeTableOutput);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ResponseOutput.Succees("生成成功");
        }

        /// <summary>
        /// 生成代码文件内容
        /// </summary>
        /// <returns></returns>
        private async Task GenerateCodeFileContentAsync(GenerateCodeLowCodeTableOutput model)
        {
            var resultController = await _templateRenderer.RenderAsync(
                RazorTestTemplatesConsts.PaasPioneerHttpApiControllers, model);

            /// 生成控制器
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerHttpApiControllers($"{model.Taxon}/{model.Taxon}Controller.cs"), resultController);

            var resultContractsService = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsService, model);

            /// 生成接口层
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsService($"{model.Taxon}/I{model.Taxon}Service.cs"), resultContractsService);

            var resultContractsAddInput = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsAddInput, model);

            /// 生成添加入参
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsAddInput($"{model.Taxon}/Dto/Input/Add{model.Taxon}Input.cs"), resultContractsAddInput);

            var resultContractsUpdateInput = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsUpdateInput, model);

            /// 生成修改入参
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsUpdateInput($"{model.Taxon}/Dto/Input/Update{model.Taxon}Input.cs"), resultContractsUpdateInput);

            var resultContractsGetPageListInput = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetPageListInput, model);

            /// 生成分页入参
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsGetPageListInput($"{model.Taxon}/Dto/Input/Get{model.Taxon}PageListInput.cs"), resultContractsGetPageListInput);

            var resultContractsGetOutput = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetOutput, model);

            /// 生成获取出参
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsGetOutput($"{model.Taxon}/Dto/Output/Get{model.Taxon}Output.cs"), resultContractsGetOutput);

            var resultContractsGetPageListOutput = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetPageListOutput, model);

            /// 生成分页出参
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationContractsGetPageListOutput($"{model.Taxon}/Dto/Output/Get{model.Taxon}PageListInput.cs"), resultContractsGetPageListOutput);

            var resultApplicationService = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationService, model);

            /// 生成服务层代码
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationService($"{model.Taxon}/{model.Taxon}Service.cs"), resultApplicationService);

            var resultApplicationMapConfig = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerApplicationMapConfig, model);

            /// 生成映射类
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerApplicationMapConfig($"{model.Taxon}/_MapConfig.cs"), resultApplicationMapConfig);

            var resultDomainIRepository = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerDomainIRepository, model);

            /// 生成仓储接口
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerDomainIRepository($"{model.Taxon}/I{model.Taxon}Repository.cs"), resultDomainIRepository);

            var resultEntityFrameworkCoreRepository = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.PaasPioneerEntityFrameworkCoreRepository, model);

            /// 生成仓储
            await GenerateCodeFileAsync(GenerateCodeFileUrl.PaasPioneerEntityFrameworkCoreRepository($"{model.Taxon}/{model.Taxon}Repository.cs"), resultEntityFrameworkCoreRepository);

            var resultVueJs = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.VueJs, model);

            /// 生成前端js
            await GenerateCodeFileAsync(GenerateCodeFileUrl.VueJs($"{model.Taxon}/{model.Taxon.ToKebabCase()}.js"), resultVueJs);

            var resultHtmlVue = await _templateRenderer.RenderAsync(
            RazorTestTemplatesConsts.HtmlVue, model);

            /// 生成前端
            await GenerateCodeFileAsync(GenerateCodeFileUrl.HtmlVue($"{model.Taxon}/{model.Taxon.ToKebabCase()}.vue"), resultHtmlVue);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        /// <returns></returns>
        private async Task GenerateCodeFileAsync(string fileName, string fileContent)
        {
            string path = $"{AppContext.BaseDirectory}{fileName}";
            var dirPath = new DirectoryInfo(path).Parent.FullName;
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            await File.WriteAllTextAsync(path, fileContent, Encoding.UTF8);
        }

        /// <summary>
        /// 生成表权限
        /// </summary>
        /// <returns></returns>
        private async Task GeneratePermissionAsync(GenerateCodeLowCodeTableOutput model)
        {
            #region 添加视图
            var view = new Ad_ViewEntity
            {
                ParentId = model.MenuParentId,
                Cache = true,
                Enabled = false,
                Description = model.Description,
                Label = model.MenuName,
                Name = model.Taxon,
                Path = $"admin/{model.Taxon}",
            };
            // 添加视图
            await _viewRepository.InsertAsync(view);
            #endregion

            #region 添加接口管理
            // 添加接口管理
            var baseApi = new Ad_ApiEntity
            {
                Enabled = true,
                Label = $"{model.MenuName}管理",
                Path = model.Taxon.ToLower(),
                CreationTime = DateTime.Now,
                Description = model.Description,
            };
            await _apiRepository.InsertAsync(baseApi);

            var getApiPageList = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"查询{model.MenuName}列表",
                Path = $"/api/admin/{model.Taxon.ToLower()}/GetPageList",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(getApiPageList);

            var getApi = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"查询{model.MenuName}",
                Path = $"/api/admin/{model.Taxon.ToLower()}/Get",
                HttpMethods = "get",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(getApi);

            var addApi = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"添加{model.MenuName}",
                Path = $"/api/admin/{model.Taxon.ToLower()}/Add",
                HttpMethods = "get",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(addApi);

            var updateApi = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"修改{model.MenuName}",
                Path = $"/api/admin/{model.Taxon.ToLower()}/Update",
                HttpMethods = "put",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(updateApi);

            var deleteApi = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"删除{model.MenuName}",
                Path = $"/api/admin/{model.Taxon.ToLower()}/Delete",
                HttpMethods = "delete",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(deleteApi);

            var batchSoftDeleteApi = new Ad_ApiEntity
            {
                ParentId = baseApi.Id,
                Description = model.Description,
                Enabled = true,
                Label = $"批量删除{model.MenuName}",
                Path = $"/api/admin/{model.Taxon.ToLower()}/BatchSoftDelete",
                HttpMethods = "delete",
                CreationTime = DateTime.Now,
            };
            await _apiRepository.InsertAsync(batchSoftDeleteApi);
            #endregion

            #region 添加权限
            #region 添加分组
            var permissionBase = new Ad_PermissionEntity
            {
                Type = EPermissionType.Group,
                ParentId = Guid.Empty,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"{model.MenuName}管理",
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(permissionBase);
            #endregion

            #region 添加菜单
            var menuPermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Menu,
                ViewId = view.Id,
                ParentId = permissionBase.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"{model.MenuName}管理",
                Path = $"/admin/{model.Taxon.ToLower()}",
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(menuPermission);
            #endregion

            #region 添加权限点
            var getPermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"获取{model.MenuName}",
                Code = getApi.Path.ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(getPermission);

            var getPermissionPageList = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"获取{model.MenuName}分页列表",
                Code = getApiPageList.Path.ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(getPermissionPageList);

            var addPermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"添加{model.MenuName}",
                Code = addApi.Path.TrimStart(':').ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(addPermission);

            var updatePermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"修改{model.MenuName}",
                Code = updateApi.Path.TrimStart(':').ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(updatePermission);

            var deletePermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"删除{model.MenuName}",
                Code = deleteApi.Path.TrimStart(':').ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(deletePermission);

            var batchSoftDeletePermission = new Ad_PermissionEntity
            {
                Type = EPermissionType.Dot,
                ParentId = menuPermission.Id,
                Closable = true,
                Hidden = false,
                Enabled = true,
                Label = $"批量删除{model.MenuName}",
                Code = batchSoftDeleteApi.Path.TrimStart(':').ToLower().Replace("/", ":"),
                Description = model.Description,
            };
            await _permissionRepository.InsertAsync(batchSoftDeletePermission);
            #endregion

            #region 添加Api中间表
            var getPermissionApi = new Ad_PermissionApiEntity
            {
                PermissionId = getPermission.Id,
                ApiId = getApi.Id
            };
            await _permissionApiRepository.InsertAsync(getPermissionApi);

            var getPermissionApiPageList = new Ad_PermissionApiEntity
            {
                PermissionId = getPermissionPageList.Id,
                ApiId = getApiPageList.Id
            };
            await _permissionApiRepository.InsertAsync(getPermissionApiPageList);

            var addPermissionApi = new Ad_PermissionApiEntity
            {
                PermissionId = addPermission.Id,
                ApiId = addApi.Id
            };
            await _permissionApiRepository.InsertAsync(addPermissionApi);

            var updatePermissionApi = new Ad_PermissionApiEntity
            {
                PermissionId = updatePermission.Id,
                ApiId = updateApi.Id
            };
            await _permissionApiRepository.InsertAsync(updatePermissionApi);

            var deletePermissionApi = new Ad_PermissionApiEntity
            {
                PermissionId = deletePermission.Id,
                ApiId = deleteApi.Id
            };
            await _permissionApiRepository.InsertAsync(deletePermissionApi);

            var batchSoftDeletePermissionApi = new Ad_PermissionApiEntity
            {
                PermissionId = batchSoftDeletePermission.Id,
                ApiId = batchSoftDeleteApi.Id
            };
            await _permissionApiRepository.InsertAsync(batchSoftDeletePermissionApi);
            #endregion
            #endregion

        }
    }
}
