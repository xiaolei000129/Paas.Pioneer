using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System.ComponentModel.DataAnnotations;
using Paas.Pioneer.Information.Domain.Shared.Enum;

namespace Paas.Pioneer.Information.Application.Contracts.Grid.Dto.Input
{
    /// <summary>
    /// 栅格管理修改
    /// </summary>
    public class UpdateGridInput
    {

        /// <summary>
        /// 字典Id
        /// </summary>
        [Required(ErrorMessage = "请输入字典Id")]
        public Guid DictionaryId { get; set; }


        /// <summary>
        /// 栅格管理类型
        /// </summary>
        [Required(ErrorMessage = "请输入栅格管理类型")]
        public EGridType GridType { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称")]
        public string Name { get; set; }


        /// <summary>
        /// 图片
        /// </summary>
        [Required(ErrorMessage = "请输入图片")]
        public string Portrait { get; set; }


        /// <summary>
        /// 拓展信息
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

        /// <summary>
        /// 
        /// </summary>
        [NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请输入Id")]
        [Required(ErrorMessage = "请输入Id")]
        public Guid Id { get; set; }

    }
}