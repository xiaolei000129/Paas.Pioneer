using Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output;
using System;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output
{
    public class GenerateCodeLowCodeTableOutput
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 所属节点（菜单父级Id）
        /// </summary>
        public Guid? MenuParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string LowCodeTableName { get; set; }

        /// <summary>
        /// 所属功能模块（业务场景）
        /// </summary>
        public string FunctionModule { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Taxon { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        public List<GenerateCodeLowCodeTableConfigOutPut> LowCodeTableConfigList { get; set; }
    }
}
