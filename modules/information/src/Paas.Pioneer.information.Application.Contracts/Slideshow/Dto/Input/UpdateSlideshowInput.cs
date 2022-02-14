using Paas.Pioneer.Information.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Information.Application.Contracts.Slideshow.Dto.Input
{
    /// <summary>
    /// Slideshow修改
    /// </summary>
    public class UpdateSlideshowInput
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
        /// 轮播图类型
        /// </summary>
        public ESlideshowType SlideshowType { get; set; }

        /// <summary>
        /// 拓展信息（文章id、保存外部链接）
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
    }
}