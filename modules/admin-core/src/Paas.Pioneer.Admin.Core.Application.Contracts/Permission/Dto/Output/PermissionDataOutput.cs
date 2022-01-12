﻿using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output
{
    public class PermissionDataOutput
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 父级节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public EPermissionType Type { get; set; }

        /// <summary>
        /// 视图
        /// </summary>
        public Guid? ViewId { get; set; }

        /// <summary>
        /// 访问地址
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 接口路径
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        /// 可关闭
        /// </summary>
        public bool? Closable { get; set; }

        /// <summary>
        /// 组打开
        /// </summary>
        public bool? Opened { get; set; }

        /// <summary>
        /// 打开新窗口
        /// </summary>
        public bool? NewWindow { get; set; }

        /// <summary>
        /// 链接外显
        /// </summary>
        public bool? External { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
		public bool Hidden { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
		public bool Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<PermissionDataOutput> Childs { get; set; }
    }
}