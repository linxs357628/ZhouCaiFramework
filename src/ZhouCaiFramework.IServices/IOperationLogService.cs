using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IOperationLogService
    {
        // 基础日志记录方法
        Task RecordLogAsync(OperationLog log);

        Task RecordLogAsync(string module, string action, string description,
            int operatorId, string operatorName, string ipAddress, string requestData = null);

        // 批量日志记录
        Task BatchRecordLogsAsync(IEnumerable<OperationLog> logs);

        // 日志查询方法
        Task<PaginatedList<OperationLog>> QueryLogsAsync(OperationLogQueryDto query);

        Task<IEnumerable<OperationLog>> GetLogsByOperatorAsync(int operatorId, DateTime? startTime, DateTime? endTime);

        Task<IEnumerable<OperationLog>> GetLogsByModuleAsync(string module, DateTime? startTime, DateTime? endTime);

        // 日志统计方法
        Task<OperationLogStatsDto> GetLogStatisticsAsync(OperationLogQueryDto query);

        Task<IDictionary<string, int>> GetActionCountStatisticsAsync(DateTime startDate, DateTime endDate);

        // 日志维护方法
        Task<bool> ArchiveLogsAsync(DateTime archiveBeforeDate);

        Task<bool> ClearLogsAsync(DateTime clearBeforeDate);
    }
}