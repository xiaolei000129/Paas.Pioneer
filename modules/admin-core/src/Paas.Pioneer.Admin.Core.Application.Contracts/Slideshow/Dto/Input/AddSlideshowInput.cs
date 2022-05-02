using System;
using System.ComponentModel.DataAnnotations;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Slideshow.Dto.Input
{
    /// <summary>
    /// 幻灯片管理添加
    /// </summary>
    public class AddSlideshowInput
    {

        /// <summary>
        /// 字典Id
        /// </summary>
        [Required(ErrorMessage = "请输入字典Id")]
        public Guid DictionaryId { get; set; }


        /// <summary>
        /// 轮播图类型
        /// </summary>
        [Required(ErrorMessage = "请输入轮播图类型")]
        public ESlideshowType SlideshowType { get; set; }


        /// <summary>
        /// 拓展信息
        /// </summary>
        [Required(ErrorMessage = "请输入拓展信息")]
        public string Expand { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题")]
        public string Title { get; set; }


        /// <summary>
        /// 图片
        /// </summary>
        [Required(ErrorMessage = "请输入图片")]
        public string Portrait { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        //[Required(ErrorMessage = "请输入排序")]
        public int Sort { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        //[Required(ErrorMessage = "请输入描述")]
        public string Description { get; set; }
    }
}