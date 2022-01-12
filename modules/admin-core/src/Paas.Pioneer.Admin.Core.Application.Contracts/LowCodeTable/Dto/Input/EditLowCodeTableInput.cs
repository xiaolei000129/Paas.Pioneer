using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input
{
    /// <summary>
    /// 编辑低代码表格
    /// </summary>
    public class EditLowCodeTableInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// 所属节点（菜单父级Id）
        /// </summary>
        public Guid? MenuParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string MenuName { get; set; }

        /// <summary>
        /// 代码类名
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Taxon { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string LowCodeTableName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 所属功能模块（业务场景）
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string FunctionModule { get; set; }
    }
}