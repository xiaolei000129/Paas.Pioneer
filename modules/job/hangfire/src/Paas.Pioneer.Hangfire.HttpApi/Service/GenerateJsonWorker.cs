using Hangfire;
using Paas.Pioneer.Hangfire.Application.Contracts;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Hangfire.HttpApi.Service
{
    /// <summary>
    /// 生成Json数据服务
    /// </summary>
    public class GenerateJsonWorker : HangfireBackgroundWorkerBase
    {
        private readonly IInitDataService _initDataService;
        private readonly IDataFilter _dataFilter;

        public GenerateJsonWorker(IInitDataService initDataService,
            IDataFilter dataFilter)
        {
            _initDataService = initDataService;
            RecurringJobId = nameof(GenerateJsonWorker);
            CronExpression = Cron.Yearly();
            _dataFilter = dataFilter;
        }

        public override async Task DoWorkAsync()
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                await _initDataService.GenerateDataAsync();
            }
        }
    }
}
