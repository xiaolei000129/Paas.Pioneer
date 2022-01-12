using Hangfire;
using Paas.Pioneer.Hangfire.Application.Contracts;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Hangfire.HttpApi.Service
{
    /// <summary>
    /// 初始化数据服务
    /// </summary>
    public class InitDataWorker : HangfireBackgroundWorkerBase
    {
        private readonly IInitDataService _initDataService;
        private readonly IDataFilter _dataFilter;

        public InitDataWorker(IInitDataService initDataService,
            IDataFilter dataFilter)
        {
            _dataFilter = dataFilter;
            _initDataService = initDataService;
            RecurringJobId = nameof(InitDataWorker);
            CronExpression = Cron.Daily();
        }

        public override async Task DoWorkAsync()
        {
            try
            {
                using (_dataFilter.Disable<IMultiTenant>())
                {
                    // 清空数据
                    await _initDataService.EmptyDataAsync();
                    // 写入数据
                    await _initDataService.WriteDataAsync();
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
