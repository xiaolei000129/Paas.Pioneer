using Hangfire;
using Paas.Pioneer.Hangfire.Application.Contracts;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Hangfire;

namespace Paas.Pioneer.Hangfire.HttpApi.Service
{
    /// <summary>
    /// 生成Json数据服务
    /// </summary>
    public class GenerateJsonWorker : HangfireBackgroundWorkerBase
    {
        private readonly IInitDataService _initDataService;

        public GenerateJsonWorker(IInitDataService initDataService)
        {
            _initDataService = initDataService;
            RecurringJobId = nameof(GenerateJsonWorker);
            CronExpression = Cron.Yearly();
        }

        public override async Task DoWorkAsync()
        {
            await _initDataService.GenerateDataAsync();
        }
    }
}
