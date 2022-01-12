using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Auditing;

namespace Paas.Pioneer.Domain
{
    public class BaseNotTenantEntity : BaseEntityNotTenantCore, IModificationAuditedObject
	{
		/// <summary>
		/// 修改人
		/// </summary>
		[Comment("修改人")]
		public Guid? LastModifierId { get; set; }
		/// <summary>
		/// 修改时间
		/// </summary>
		[Comment("修改时间")]
		public DateTime? LastModificationTime { get; set; }
	}
}
