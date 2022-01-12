using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Domain
{
	/// <summary>
	/// 核心类
	/// </summary>
	public class BaseEntityCore : Entity<Guid>, ISoftDelete, IMultiTenant, ICreationAuditedObject
	{
		/// <summary>
		/// 是否删除
		/// </summary>
		[Comment("是否删除")]
		public bool IsDeleted { get; set; }

		/// <summary>
		/// 租户Id
		/// </summary>
		[Comment("租户Id")]
		public Guid? TenantId { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[Comment("创建时间")]
		public DateTime CreationTime { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		[Comment("创建人")]
		public Guid? CreatorId { get; set; }
	}
}
