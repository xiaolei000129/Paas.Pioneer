using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input
{
    /// <summary>
    /// 幻灯片管理分页
    /// </summary>
    public class GetSlideshowPageListInput
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 轮播图类型
        /// </summary>
        public Paas.Pioneer.Admin.Core.Domain.Shared.Enum.ESlideshowType SlideshowType { get; set; }

        /// <summary>
        /// 拓展信息
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Portrait { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

    }
}