using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;

namespace Paas.Pioneer.Information.Application.Contracts.News.Dto.Input
{
    /// <summary>
    /// 新闻管理分页
    /// </summary>
    public class GetNewsPageListInput
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Portrait { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PushTime { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        public string NewsContent { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

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