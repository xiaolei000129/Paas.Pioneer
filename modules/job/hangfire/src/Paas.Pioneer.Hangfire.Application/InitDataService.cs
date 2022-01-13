using Microsoft.Extensions.Logging;
using Paas.Pioneer.Admin.Core.Domain.Api;
using Paas.Pioneer.Admin.Core.Domain.Dictionary;
using Paas.Pioneer.Admin.Core.Domain.DictionaryType;
using Paas.Pioneer.Admin.Core.Domain.Document;
using Paas.Pioneer.Admin.Core.Domain.DocumentImage;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTable;
using Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig;
using Paas.Pioneer.Admin.Core.Domain.Permission;
using Paas.Pioneer.Admin.Core.Domain.PermissionApi;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Employee;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Organization;
using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.Domain.RolePermission;
using Paas.Pioneer.Admin.Core.Domain.Tenant;
using Paas.Pioneer.Admin.Core.Domain.TenantPermission;
using Paas.Pioneer.Admin.Core.Domain.User;
using Paas.Pioneer.Admin.Core.Domain.UserRole;
using Paas.Pioneer.Admin.Core.Domain.View;
using Paas.Pioneer.Domain.Shared.Extensions;
using Paas.Pioneer.Hangfire.Application.Contracts;
using Paas.Pioneer.Hangfire.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Hangfire.Application
{
    public class InitDataService : ApplicationService, IInitDataService
    {

        #region 构造函数
        private readonly string filename = "wwwroot/data/initData.josn";

        private readonly IApiRepository _apiRepository;
        private readonly IDictionaryRepository _dictionaryRepository;
        private readonly IDictionaryTypeRepository _dictionaryTypeRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentImageRepository _documentImageRepository;
        private readonly ILoginLogRepository _loginLogRepository;
        private readonly ILowCodeTableRepository _lowCodeTableRepository;
        private readonly ILowCodeTableConfigRepository _lowCodeTableConfigRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionApiRepository _permissionApiRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly ITenantPermissionRepository _tenantPermissionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IViewRepository _viewRepository;
        private readonly ILogger<InitDataService> _logger;

        public InitDataService(IApiRepository apiRepository,
            IDictionaryRepository dictionaryRepository,
            IDictionaryTypeRepository dictionaryTypeRepository,
            IDocumentRepository documentRepository,
            IDocumentImageRepository documentImageRepository,
            ILoginLogRepository loginLogRepository,
            ILowCodeTableRepository lowCodeTableRepository,
            ILowCodeTableConfigRepository lowCodeTableConfigRepository,
            IPermissionRepository permissionRepository,
            IPermissionApiRepository permissionApiRepository,
            IEmployeeRepository employeeRepository,
            IOrganizationRepository organizationRepository,
            IPositionRepository positionRepository,
            IRoleRepository roleRepository,
            IRolePermissionRepository rolePermissionRepository,
            ITenantRepository tenantRepository,
            ITenantPermissionRepository tenantPermissionRepository,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IViewRepository viewRepository,
            ILogger<InitDataService> logger)
        {
            _apiRepository = apiRepository;
            _dictionaryRepository = dictionaryRepository;
            _dictionaryTypeRepository = dictionaryTypeRepository;
            _documentRepository = documentRepository;
            _documentImageRepository = documentImageRepository;
            _loginLogRepository = loginLogRepository;
            _lowCodeTableRepository = lowCodeTableRepository;
            _lowCodeTableConfigRepository = lowCodeTableConfigRepository;
            _permissionRepository = permissionRepository;
            _permissionApiRepository = permissionApiRepository;
            _employeeRepository = employeeRepository;
            _organizationRepository = organizationRepository;
            _positionRepository = positionRepository;
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _tenantRepository = tenantRepository;
            _tenantPermissionRepository = tenantPermissionRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _viewRepository = viewRepository;
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EmptyDataAsync()
        {
            await _apiRepository.HardDeleteAsync(x => true, true);
            await _dictionaryRepository.HardDeleteAsync(x => true, true);
            await _dictionaryTypeRepository.HardDeleteAsync(x => true, true);
            await _documentRepository.HardDeleteAsync(x => true, true);
            await _documentImageRepository.HardDeleteAsync(x => true, true);
            await _loginLogRepository.HardDeleteAsync(x => true, true);
            await _lowCodeTableRepository.HardDeleteAsync(x => true, true);
            await _lowCodeTableConfigRepository.HardDeleteAsync(x => true, true);
            await _permissionRepository.HardDeleteAsync(x => true, true);
            await _permissionApiRepository.HardDeleteAsync(x => true, true);
            await _employeeRepository.HardDeleteAsync(x => true, true);
            await _organizationRepository.HardDeleteAsync(x => true, true);
            await _positionRepository.HardDeleteAsync(x => true, true);
            await _roleRepository.HardDeleteAsync(x => true, true);
            await _rolePermissionRepository.HardDeleteAsync(x => true, true);
            await _tenantPermissionRepository.HardDeleteAsync(x => true, true);
            await _userRepository.HardDeleteAsync(x => true, true);
            await _userRoleRepository.HardDeleteAsync(x => true, true);
            await _viewRepository.HardDeleteAsync(x => true, true);
            return true;
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> WriteDataAsync()
        {
            // 读取文件
            var filestring = await ReadFileAsync(filename);
            var keyValues = JsonSerializer.Deserialize<Dictionary<string, object>>(filestring);
            foreach (var item in keyValues)
            {
                if (item.Key.Equals("Api") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Api>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _apiRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_Api>, List<Ad_ApiEntity>>(model));
                    }
                }
                if (item.Key.Equals("Dictionary") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Dictionary>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _dictionaryRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_Dictionary>, List<Ad_DictionaryEntity>>(model));
                    }
                }
                if (item.Key.Equals("Document") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Document>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _documentRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_Document>, List<Ad_DocumentEntity>>(model));
                    }
                }
                if (item.Key.Equals("DictionaryType") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_DictionaryType>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _dictionaryTypeRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_DictionaryType>, List<Ad_DictionaryTypeEntity>>(model));
                    }
                }
                if (item.Key.Equals("DocumentImage") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_DocumentImage>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _documentImageRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_DocumentImage>, List<Ad_DocumentImageEntity>>(model));
                    }
                }
                if (item.Key.Equals("LoginLog") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_LoginLog>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _loginLogRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_LoginLog>, List<Ad_LoginLogEntity>>(model));
                    }
                }
                if (item.Key.Equals("LowCodeTable") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_LowCodeTable>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _lowCodeTableRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_LowCodeTable>, List<Ad_LowCodeTableEntity>>(model));
                    }
                }
                if (item.Key.Equals("LowCodeTableConfig") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_LowCodeTableConfig>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _lowCodeTableConfigRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_LowCodeTableConfig>, List<Ad_LowCodeTableConfigEntity>>(model));
                    }
                }
                if (item.Key.Equals("Permission") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Permission>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _permissionRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_Permission>, List<Ad_PermissionEntity>>(model));
                    }
                }
                if (item.Key.Equals("PermissionApi") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_PermissionApi>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _permissionApiRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_PermissionApi>, List<Ad_PermissionApiEntity>>(model));
                    }
                }
                if (item.Key.Equals("Employee") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Pe_Employee>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _employeeRepository.InsertManyAsync(ObjectMapper.Map<List<Pe_Employee>, List<Pe_EmployeeEntity>>(model));
                    }
                }
                if (item.Key.Equals("Organization") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Pe_Organization>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _organizationRepository.InsertManyAsync(ObjectMapper.Map<List<Pe_Organization>, List<Pe_OrganizationEntity>>(model));
                    }
                }
                if (item.Key.Equals("Position") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Pe_Position>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _positionRepository.InsertManyAsync(ObjectMapper.Map<List<Pe_Position>, List<Pe_PositionEntity>>(model));
                    }
                }
                if (item.Key.Equals("Role") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Role>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _roleRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_Role>, List<Ad_RoleEntity>>(model));
                    }
                }
                if (item.Key.Equals("RolePermission") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_RolePermission>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _rolePermissionRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_RolePermission>, List<Ad_RolePermissionEntity>>(model));
                    }
                }
                if (item.Key.Equals("Tenant") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_Tenant>>(item.Value.ToString());
                    if (model.Any())
                    {
                        var ids = model.Select(x => x.Id).ToList();
                        // 租户只删除演示期间添加的
                        await _tenantRepository.HardDeleteAsync(x => !ids.Contains(x.Id));
                    }
                }
                if (item.Key.Equals("TenantPermission") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_TenantPermission>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _tenantPermissionRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_TenantPermission>, List<Ad_TenantPermissionEntity>>(model));
                    }
                }
                if (item.Key.Equals("User") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_User>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _userRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_User>, List<Ad_UserEntity>>(model));
                    }
                }
                if (item.Key.Equals("UserRole") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_UserRole>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _userRoleRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_UserRole>, List<Ad_UserRoleEntity>>(model));
                    }
                }
                if (item.Key.Equals("View") && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    var model = JsonSerializer.Deserialize<List<Ad_View>>(item.Value.ToString());
                    if (model.Any())
                    {
                        await _viewRepository.InsertManyAsync(ObjectMapper.Map<List<Ad_View>, List<Ad_ViewEntity>>(model));
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 生成Json数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GenerateDataAsync()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            try
            {
                dictionary.Add("Api", await _apiRepository.GetListAsync());
                dictionary.Add("Dictionary", await _dictionaryRepository.GetListAsync());
                dictionary.Add("DictionaryType", await _dictionaryTypeRepository.GetListAsync());
                dictionary.Add("Document", await _documentRepository.GetListAsync());
                dictionary.Add("DocumentImage", await _documentImageRepository.GetListAsync());
                dictionary.Add("LoginLog", await _loginLogRepository.GetListAsync());
                dictionary.Add("LowCodeTable", await _lowCodeTableRepository.GetListAsync());
                dictionary.Add("LowCodeTableConfig", await _lowCodeTableConfigRepository.GetListAsync());
                dictionary.Add("Permission", await _permissionRepository.GetListAsync());
                dictionary.Add("PermissionApi", await _permissionApiRepository.GetListAsync());
                dictionary.Add("Employee", await _employeeRepository.GetListAsync());
                dictionary.Add("Organization", await _organizationRepository.GetListAsync());
                dictionary.Add("Position", await _positionRepository.GetListAsync());
                dictionary.Add("Role", await _roleRepository.GetListAsync());
                dictionary.Add("RolePermission", await _rolePermissionRepository.GetListAsync());
                dictionary.Add("Tenant", ObjectMapper.Map<List<Volo.Abp.TenantManagement.Tenant>, List<Ad_Tenant>>(await _tenantRepository.GetListAsync()));
                dictionary.Add("TenantPermission", await _tenantPermissionRepository.GetListAsync());
                dictionary.Add("User", await _userRepository.GetListAsync());
                dictionary.Add("UserRole", await _userRoleRepository.GetListAsync());
                dictionary.Add("View", await _viewRepository.GetListAsync());
                await GenerateFileAsync(filename, JsonSerializer.Serialize(dictionary));
            }
            catch (Exception ex)
            {
                _logger.LogError("生成Json数据", ex);
            }
            return true;
        }

        #region 私有方法
        /// <summary>
        /// 生成文件
        /// </summary>
        /// <returns></returns>
        private async Task GenerateFileAsync(string fileName, string fileContent)
        {
            string path = $"{AppContext.BaseDirectory.ToPath()}{fileName}";
            var dirPath = new DirectoryInfo(path).Parent.FullName;
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            await File.WriteAllTextAsync(path, fileContent, Encoding.UTF8);
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<string> ReadFileAsync(string fileName)
        {
            string path = $"{AppContext.BaseDirectory.ToPath()}{fileName}";
            var dirPath = new DirectoryInfo(path).Parent.FullName;
            if (!Directory.Exists(dirPath) || !File.Exists(path))
            {
                throw new Exception($"{path}文件不存在");
            }
            return await File.ReadAllTextAsync(path, Encoding.UTF8);
        }
        #endregion
    }
}