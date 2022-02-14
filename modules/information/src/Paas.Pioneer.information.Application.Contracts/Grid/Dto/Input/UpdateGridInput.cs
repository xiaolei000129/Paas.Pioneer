using Paas.Pioneer.Information.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input
{
    /// <summary>
    /// Grid修改
    /// </summary>
    public class UpdateGridInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 字典Id
        /// </summary>
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 栅格管理类型
        /// </summary>
        public EGridType GridType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Portrait { get; set; }

        /// <summary>
        /// 拓展信息（文章id、保存外部链接）
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}