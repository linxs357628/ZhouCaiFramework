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
    public class EcoInquiryService : IEcoInquiryService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<EcoInquiryService> _logger;

        public EcoInquiryService(ISqlSugarClient db, ILogger<EcoInquiryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<PaginatedList<EcoInquiryDto>> GetInquiriesAsync(EcoInquiryQueryDto query)
        {
            try
            {
                var q = _db.Queryable<EcoInquiry>();

                // 关键词搜索
                if (!string.IsNullOrEmpty(query.Keyword))
                {
                    q = q.Where(x => x.InquirerName.Contains(query.Keyword) ||
                                   x.EntryPoint.Contains(query.Keyword) ||
                                   x.ContactName.Contains(query.Keyword) ||
                                   x.ContactPhone.Contains(query.Keyword) ||
                                   x.DeliveryAddress.Contains(query.Keyword));
                }

                // 询价方式筛选
                if (!string.IsNullOrEmpty(query.InquiryType))
                {
                    q = q.Where(x => x.InquiryType == query.InquiryType);
                }

                // 时间范围筛选
                if (query.StartTime.HasValue)
                {
                    q = q.Where(x => x.InquiryTime >= query.StartTime);
                }
                if (query.EndTime.HasValue)
                {
                    q = q.Where(x => x.InquiryTime <= query.EndTime);
                }

                // 地区筛选
                if (!string.IsNullOrEmpty(query.Province))
                {
                    q = q.Where(x => x.DeliveryAddress.Contains(query.Province));
                }
                if (!string.IsNullOrEmpty(query.City))
                {
                    q = q.Where(x => x.DeliveryAddress.Contains(query.City));
                }
                if (!string.IsNullOrEmpty(query.District))
                {
                    q = q.Where(x => x.DeliveryAddress.Contains(query.District));
                }

                // 排序
                q = query.SortOrder == "desc" ? 
                    q.OrderBy($"{query.SortField} desc") : 
                    q.OrderBy(query.SortField);

                // 分页查询
                var total = await q.CountAsync();
                var items = await q.Select<EcoInquiryDto>()
                    .ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<EcoInquiryDto>(items, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取生态询价单列表失败");
                throw;
            }
        }

        public async Task<EcoInquiryDto> GetInquiryDetailAsync(int id)
        {
            try
            {
                return await _db.Queryable<EcoInquiry>()
                    .Where(x => x.Id == id)
                    .Select<EcoInquiryDto>()
                    .FirstAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取生态询价单详情失败 ID:{Id}", id);
                throw;
            }
        }

        public async Task<List<DistributionRecordDto>> GetDistributionRecordsAsync(int inquiryId)
        {
            try
            {
                return await _db.Queryable<DistributionRecord>()
                    .Where(dr => dr.InquiryId == inquiryId)
                    .OrderBy(dr => dr.DistributionTime, OrderByType.Desc)
                    .Select<DistributionRecordDto>()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取分发记录失败 InquiryId:{InquiryId}", inquiryId);
                throw;
            }
        }
    }
}
