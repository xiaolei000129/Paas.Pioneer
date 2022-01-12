namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output
{
    /// <summary>
    /// 数据库表列表参数
    /// </summary>
    public class LowCodeTableEntityOutput
    {
        /// <summary>
        /// 表名（字母形式的）
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表名称描述（注释）（功能名）
        /// </summary>
        public string TableComment { get; set; }
    }
}
