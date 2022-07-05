using System;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using Paas.Pioneer.User.Domain.Shared.UserInfos;

namespace Paas.Pioneer.User.Domain.UserInfos;

/// <summary>
/// 微信App
/// </summary>
[Comment("数据字典")]
[Table("WeChat_App")]
[Index(nameof(UserId), Name = "IX_UserId")]
public class UserInfo : BaseEntity
{
    /// <summary>
    /// 用户id
    /// </summary>
    [Comment("用户id")]
    [Column("UserId", TypeName = "char(36)")]
    public virtual Guid UserId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Comment("名称")]
    [Column("NickName", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string NickName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [Comment("性别")]
    public virtual byte Gender { get; set; }

    /// <summary>
    /// 语言
    /// </summary>
    [Comment("语言")]
    [Column("NickName", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string Language { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [Comment("城市")]
    [Column("City", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string City { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [Comment("城市")]
    [Column("Province", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string Province { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    [Comment("市")]
    [Column("Country", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string Country { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [Comment("头像")]
    [Column("Country", TypeName = "varchar(50)")]
    [CanBeNull]
    public virtual string AvatarUrl { get; set; }

    public UserInfo()
    {

    }

    public UserInfo(Guid id,
        Guid? tenantId,
        Guid userId,
        UserInfoModel model)
    {
        Id = id;
        TenantId = tenantId;
        UserId = userId;
        UpdateInfo(model);
    }

    public void UpdateInfo(UserInfoModel model)
    {
        NickName = model.NickName;
        Gender = model.Gender;
        Language = model.Language;
        City = model.City;
        Province = model.Province;
        Country = model.Country;
        AvatarUrl = model.AvatarUrl;
    }
}
