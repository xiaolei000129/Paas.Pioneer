﻿using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.View.Dto.Output
{
    public class ViewGetOutput
    {
        /// <summary>
        /// 视图Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 所属节点
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 视图命名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 视图名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 视图路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 缓存
        /// </summary>
        public bool Cache { get; set; } = true;

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}