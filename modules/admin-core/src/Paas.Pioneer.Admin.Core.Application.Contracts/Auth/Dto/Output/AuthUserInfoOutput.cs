using System.Collections.Generic;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output
{
    public class AuthUserInfoOutput
    {
        /// <summary>
        /// 用户个人信息
        /// </summary>
        public AuthUserProfileDto User { get; set; }

        /// <summary>
        /// 用户菜单
        /// </summary>
        public List<AuthUserMenuDto> Menus { get; set; }

        /// <summary>
        /// 用户权限点
        /// </summary>
        public IEnumerable<string> Permissions { get; set; }
    }
}