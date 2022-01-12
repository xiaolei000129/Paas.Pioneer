namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Input
{
    public class GetLowCodeTablePadedInput
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 所属功能模块（业务场景）
        /// </summary>
        public string FunctionModule { get; set; }
    }
}
