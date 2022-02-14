using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using Paas.Pioneer.Information.Domain.Shared.Enum;

namespace Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input
{
    /// <summary>
    /// Slideshow分页
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
        public ESlideshowType SlideshowType { get; set; }

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