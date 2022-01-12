using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.LoginLog
{
    public class EfCoreLoginLogRepository : BaseExtensionsRepository<Ad_LoginLogEntity>, ILoginLogRepository
    {
        public EfCoreLoginLogRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

}
