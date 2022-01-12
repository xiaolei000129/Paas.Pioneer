using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Tenant.Dto.Input
{
    /// <summary>
    /// 添加
    /// </summary>
    public class TenantAddInput: TenantDto
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Name { get; set; }
    }
}