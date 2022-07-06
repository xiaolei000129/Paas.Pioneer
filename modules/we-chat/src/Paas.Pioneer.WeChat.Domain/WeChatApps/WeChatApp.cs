using System;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using Paas.Pioneer.WeChat.Domain.Shared.WeChatApps;

namespace Paas.Pioneer.WeChat.Domain.WeChatApps
{
    /// <summary>
    /// 微信App
    /// </summary>
    [Comment("微信App")]
    [Table("WeChat_App")]
    [Index(nameof(AppId), Name = "IDX_AppId")]
    [Index(nameof(Name), Name = "IDX_Name")]
    public class WeChatApp : BaseEntity
    {
        /// <summary>
        /// 微信组件Id
        /// </summary>
        [Comment("微信组件Id")]
        [Column("WeChatComponentId", TypeName = "char(36)")]
        public virtual Guid? WeChatComponentId { get; set; }

        /// <summary>
        /// 微信app类型
        /// </summary>
        [Comment("微信app类型")]
        [Column("Type", TypeName = "int")]
        public virtual WeChatAppType Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        [Column("Name", TypeName = "varchar(50)")]
        [NotNull]
        public virtual string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [Comment("显示名称")]
        [Column("DisplayName", TypeName = "varchar(50)")]
        [NotNull]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 开放Id或者名称
        /// </summary>
        [Comment("开放Id或者名称")]
        [Column("OpenAppIdOrName", TypeName = "varchar(50)")]
        [NotNull]
        public virtual string OpenAppIdOrName { get; set; }

        /// <summary>
        /// 微信AppId
        /// </summary>
        [Comment("微信AppId")]
        [Column("AppId", TypeName = "varchar(50)")]
        [NotNull]
        public virtual string AppId { get; set; }

        /// <summary>
        /// AppSecret 为空时，需提供开放平台 WeChatComponentId
        /// </summary>
        [Comment("App密钥")]
        [Column("AppSecret", TypeName = "varchar(150)")]
        [CanBeNull]
        public virtual string AppSecret { get; set; }

        /// <summary>
        /// 微信Token
        /// </summary>
        [Comment("微信Token")]
        [Column("Token", TypeName = "varchar(500)")]
        [CanBeNull]
        public virtual string Token { get; set; }

        /// <summary>
        /// 微信密钥
        /// </summary>
        [Comment("微信密钥")]
        [Column("EncodingAesKey", TypeName = "varchar(500)")]
        [CanBeNull]
        public virtual string EncodingAesKey { get; set; }

        /// <summary>
        /// 是否静态
        /// </summary>
        [Comment("是否静态")]
        public virtual bool IsStatic { get; set; }

        public WeChatApp()
        {
        }

        public WeChatApp(
            Guid id,
            Guid? tenantId,
            WeChatAppType type,
            Guid? weChatComponentId,
            [NotNull] string name,
            [NotNull] string displayName,
            [NotNull] string openAppIdOrName,
            [NotNull] string appId,
            [CanBeNull] string appSecret,
            [CanBeNull] string token,
            [CanBeNull] string encodingAesKey,
            bool isStatic)
        {
            TenantId = tenantId;
            Type = type;
            WeChatComponentId = weChatComponentId;
            Name = name;
            DisplayName = displayName;
            OpenAppIdOrName = openAppIdOrName;
            AppId = appId;
            AppSecret = appSecret;
            Token = token;
            EncodingAesKey = encodingAesKey;
            IsStatic = isStatic;
        }
    }
}
