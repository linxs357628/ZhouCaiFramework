using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class OperationLogService : IOperationLogService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<OperationLogService> _logger;

        public OperationLogService(ISqlSugarClient db, ILogger<OperationLogService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task RecordLogAsync(OperationLog log)
        {
            try
            {
                log.OperationTime = DateTime.Now;
                await _db.Insertable(log).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "记录操作日志失败");
                throw;
            }
        }

        public async Task RecordLogAsync(string module, string action, string description,
            int operatorId, string operatorName, string ipAddress, string requestData = null)
        {
            await RecordLogAsync(new OperationLog
            {
                Module = module,
                Action = action,
                Description = description,
                OperatorId = operatorId,
                OperatorName = operatorName,
                IpAddress = ipAddress,
                RequestData = requestData,
                OperationTime = DateTime.Now
            });
        }

        public async Task BatchRecordLogsAsync(IEnumerable<OperationLog> logs)
        {
            try
            {
                await _db.Insertable(logs.ToList()).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "批量记录操作日志失败");
                throw;
            }
        }

        public async Task<PaginatedList<OperationLog>> QueryLogsAsync(OperationLogQueryDto query)
        {
            try
            {
                var q = BuildQueryCondition(_db.Queryable<OperationLog>(), query);
                var total = await q.CountAsync();
                var logs = await q.OrderBy(log => log.OperationTime, OrderByType.Desc)
                    .ToPageListAsync(query.PageIndex, query.PageSize);
                return new PaginatedList<OperationLog>(logs, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "查询操作日志失败");
                throw;
            }
        }

        private ISugarQueryable<OperationLog> BuildQueryCondition(
            ISugarQueryable<OperationLog> query,
            OperationLogQueryDto condition)
        {
            if (!string.IsNullOrEmpty(condition.Module))
                query = query.Where(log => log.Module.Contains(condition.Module));

            if (!string.IsNullOrEmpty(condition.Action))
                query = query.Where(log => log.Action.Contains(condition.Action));

            if (condition.OperatorId.HasValue)
                query = query.Where(log => log.OperatorId == condition.OperatorId);

            if (condition.StartTime.HasValue)
                query = query.Where(log => log.OperationTime >= condition.StartTime);

            if (condition.EndTime.HasValue)
                query = query.Where(log => log.OperationTime <= condition.EndTime);

            if (!string.IsNullOrEmpty(condition.Keyword))
                query = query.Where(log =>
                    log.Description.Contains(condition.Keyword) ||
                    log.OperatorName.Contains(condition.Keyword));

            if (!string.IsNullOrEmpty(condition.IpAddress))
                query = query.Where(log => log.IpAddress == condition.IpAddress);

            if (condition.OnlyError.HasValue && condition.OnlyError.Value)
                query = query.Where(log => log.IsError);

            return query;
        }

        public async Task<IEnumerable<OperationLog>> GetLogsByOperatorAsync(
            int operatorId, DateTime? startTime, DateTime? endTime)
        {
            try
            {
                var query = _db.Queryable<OperationLog>()
                    .Where(log => log.OperatorId == operatorId);

                if (startTime.HasValue)
                    query = query.Where(log => log.OperationTime >= startTime);

                if (endTime.HasValue)
                    query = query.Where(log => log.OperationTime <= endTime);

                return await query.OrderBy(log => log.OperationTime, OrderByType.Desc)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "按操作员查询日志失败");
                throw;
            }
        }

        public async Task<IEnumerable<OperationLog>> GetLogsByModuleAsync(
            string module, DateTime? startTime, DateTime? endTime)
        {
            try
            {
                var query = _db.Queryable<OperationLog>()
                    .Where(log => log.Module == module);

                if (startTime.HasValue)
                    query = query.Where(log => log.OperationTime >= startTime);

                if (endTime.HasValue)
                    query = query.Where(log => log.OperationTime <= endTime);

                return await query.OrderBy(log => log.OperationTime, OrderByType.Desc)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "按模块查询日志失败");
                throw;
            }
        }

        public async Task<OperationLogStatsDto> GetLogStatisticsAsync(OperationLogQueryDto query)
        {
            try
            {
                var q = BuildQueryCondition(_db.Queryable<OperationLog>(), query);

                return new OperationLogStatsDto
                {
                    TotalCount = await q.CountAsync(),
                    ErrorCount = await q.Where(log => log.IsError).CountAsync(),
                    ModuleStats = await q.GroupBy(log => log.Module)
                        .Select(log => new { log.Module, Count = SqlFunc.AggregateCount(log.Id) })
                        .ToListAsync(),
                    ActionStats = await q.GroupBy(log => log.Action)
                        .Select(log => new { log.Action, Count = SqlFunc.AggregateCount(log.Id) })
                        .ToListAsync()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取日志统计失败");
                throw;
            }
        }

        public async Task<bool> ArchiveLogsAsync(DateTime archiveBeforeDate)
        {
            try
            {
                // TODO: 实现日志归档逻辑
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "归档日志失败");
                throw;
            }
        }

        public async Task<bool> ClearLogsAsync(DateTime clearBeforeDate)
        {
            try
            {
                return await _db.Deleteable<OperationLog>()
                    .Where(log => log.OperationTime < clearBeforeDate)
                    .ExecuteCommandAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "清理日志失败");
                throw;
            }
        }

        public async Task<IDictionary<string, int>> GetActionCountStatisticsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _db.Queryable<OperationLog>()
                    .Where(log => log.OperationTime >= startDate && log.OperationTime <= endDate)
                    .GroupBy(log => log.Action)
                    .Select(log => new { 
                        Action = log.Action, 
                        Count = SqlFunc.AggregateCount(log.Id) 
                    })
                    .ToListAsync();

                return result.ToDictionary(x => x.Action, x => x.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取操作类型统计失败");
                throw;
            }
        }
    }
}
