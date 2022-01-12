using System;
using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output
{
    public class UserAndRoleOutput : SelectModel
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserModelOutput Form { get; set; }

    }

    /// <summary>
    /// 角色
    /// </summary>
    public class SelectModel
    {
        /// <summary>
        /// 角色信息
        /// </summary>
        public IEnumerable<UserRoleInfo> Select { get; set; }
    }

    public class UserRoleInfo
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

    }

}
