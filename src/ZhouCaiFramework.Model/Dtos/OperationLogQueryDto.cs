namespace ZhouCaiFramework.Model.Dtos
{
    public class OperationLogQueryDto : PaginationQuery
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int? OperatorId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 关键词(描述或操作员)
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 是否只查询错误日志
        /// </summary>
        public bool? OnlyError { get; set; }

        /// <summary>
        /// 操作结果状态
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; } = "OperationTime";

        /// <summary>
        /// 排序方式(asc/desc)
        /// </summary>
        public string SortOrder { get; set; } = "desc";

        /// <summary>
        /// 请求数据包含关键词
        /// </summary>
        public string RequestDataKeyword { get; set; }
    }
}