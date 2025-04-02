using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(ISqlSugarClient db, ILogger<PaymentService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<PaymentFlow> Records, int TotalCount)> GetMerchantFlowsAsync(
            int merchantId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string amountType = "actual",
            string flowType = null,
            string search = null,
            int pageIndex = 1,
            int pageSize = 20)
        {
            try
            {
                var query = _db.Queryable<PaymentFlow>()
                    .Where(p => p.MerchantId == merchantId);

                // 日期范围筛选
                if (startDate.HasValue)
                {
                    query = query.Where(p => p.TransactionTime >= startDate.Value);
                }
                if (endDate.HasValue)
                {
                    query = query.Where(p => p.TransactionTime <= endDate.Value);
                }

                // 流水类型筛选
                if (!string.IsNullOrEmpty(flowType) && flowType != "all")
                {
                    query = query.Where(p => p.FlowType == flowType);
                }

                // 关键字搜索
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p =>
                        p.EnterpriseName.Contains(search) ||
                        p.FlowNumber.Contains(search) ||
                        p.RelatedOrder.Contains(search));
                }

                // 获取总数
                var totalCount = await query.CountAsync();

                // 分页查询
                var records = await query.OrderBy(p => p.TransactionTime, OrderByType.Desc)
                    .ToPageListAsync(pageIndex, pageSize);

                return (records, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取商家流水列表失败 MerchantId:{MerchantId}", merchantId);
                throw;
            }
        }

        public async Task<PaymentFlow> GetFlowDetailAsync(int id)
        {
            try
            {
                return await _db.Queryable<PaymentFlow>()
                    .FirstAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取流水详情失败 FlowId:{FlowId}", id);
                throw;
            }
        }

        public async Task<byte[]> ExportFlowsAsync(
            int merchantId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string amountType = "actual",
            string flowType = null,
            string search = null)
        {
            try
            {
                var (records, _) = await GetMerchantFlowsAsync(
                    merchantId, startDate, endDate, amountType, flowType, search, 1, int.MaxValue);

                // TODO: 使用NPOI或EPPlus实现Excel导出
                // 这里返回空数组作为示例
                return [];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "导出流水数据失败 MerchantId:{MerchantId}", merchantId);
                throw;
            }
        }

        public async Task<PaymentFlow> CreatePaymentFlowAsync(PaymentFlow flow)
        {
            try
            {
                return await _db.Insertable(flow).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建支付流水记录失败");
                throw;
            }
        }

        public async Task<bool> UpdatePaymentFlowAsync(PaymentFlow flow)
        {
            try
            {
                return await _db.Updateable(flow).ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新支付流水记录失败 FlowId:{FlowId}", flow.Id);
                throw;
            }
        }

        public async Task<bool> AddPayment(PaymentCreateDto dto)
        {
            try
            {
                var payment = new PaymentFlow
                {
                    MerchantId = dto.MerchantId,
                    TransactionTime = dto.TransactionTime,
                    EnterpriseName = dto.EnterpriseName,
                    FlowType = dto.FlowType,
                    OriginalAmount = dto.OriginalAmount,
                    ActualAmount = dto.ActualAmount,
                    FlowNumber = dto.FlowNumber,
                    Creator = "System",
                    CreateTime = DateTime.Now
                };

                await _db.Insertable(payment).ExecuteCommandAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "添加支付记录失败");
                return false;
            }
        }

        public async Task<bool> UpdateSyncStatus(PaymentCreateDto dto)
        {
            try
            {
                var payment = await _db.Queryable<PaymentFlow>()
                    .FirstAsync(p => p.FlowNumber == dto.FlowNumber);

                if (payment == null) return false;

                payment.SyncStatus = true;
                payment.UpdateTime = DateTime.Now;
                return await _db.Updateable(payment).ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新支付同步状态失败");
                return false;
            }
        }

        public async Task<PaginatedList<PaymentFlow>> GetPayments(PaymentQuery query)
        {
            try
            {
                var q = _db.Queryable<PaymentFlow>();

                if (query.MerchantId.HasValue)
                    q = q.Where(p => p.MerchantId == query.MerchantId);

                if (!string.IsNullOrEmpty(query.FlowType))
                    q = q.Where(p => p.FlowType == query.FlowType);

                var total = await q.CountAsync();
                var data = await q.ToPageListAsync(query.PageIndex, query.PageSize);

                return new PaginatedList<PaymentFlow>(data, total, query.PageIndex, query.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取支付列表失败");
                throw;
            }
        }

        public async Task<byte[]> ExportPayments(PaymentQuery query)
        {
            try
            {
                var payments = await GetPayments(query);
                // TODO: 使用NPOI或EPPlus实现Excel导出
                return Array.Empty<byte>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "导出支付数据失败");
                throw;
            }
        }

        public async Task<bool> LinkInvoice(int paymentId, InvoiceLinkDto dto)
        {
            try
            {
                var payment = await _db.Queryable<PaymentFlow>()
                    .FirstAsync(p => p.Id == paymentId);

                if (payment == null) return false;

                payment.InvoiceId = dto.InvoiceId;
                payment.InvoiceNumber = dto.InvoiceNumber;
                return await _db.Updateable(payment).ExecuteCommandHasChangeAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "关联发票失败");
                return false;
            }
        }

        public async Task<(IEnumerable<PaymentFlow> Records, int TotalCount)> QueryFlowsAsync(
            int? merchantId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string flowType = null,
            string businessType = null,
            string enterpriseName = null,
            string flowNumber = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            int pageIndex = 1,
            int pageSize = 20)
        {
            try
            {
                var query = _db.Queryable<PaymentFlow>();

                // 构建动态查询条件
                if (merchantId.HasValue)
                {
                    query = query.Where(p => p.MerchantId == merchantId.Value);
                }

                if (startTime.HasValue)
                {
                    query = query.Where(p => p.TransactionTime >= startTime.Value);
                }

                if (endTime.HasValue)
                {
                    query = query.Where(p => p.TransactionTime <= endTime.Value);
                }

                if (!string.IsNullOrEmpty(flowType))
                {
                    query = query.Where(p => p.FlowType == flowType);
                }

                if (!string.IsNullOrEmpty(businessType))
                {
                    query = query.Where(p => p.BusinessType.Contains(businessType));
                }

                if (!string.IsNullOrEmpty(enterpriseName))
                {
                    query = query.Where(p => p.EnterpriseName.Contains(enterpriseName));
                }

                if (!string.IsNullOrEmpty(flowNumber))
                {
                    query = query.Where(p => p.FlowNumber == flowNumber);
                }

                if (minAmount.HasValue)
                {
                    query = query.Where(p => p.ActualAmount >= minAmount.Value);
                }

                if (maxAmount.HasValue)
                {
                    query = query.Where(p => p.ActualAmount <= maxAmount.Value);
                }

                // 获取总数
                var totalCount = await query.CountAsync();

                // 分页查询
                var records = await query.OrderBy(p => p.TransactionTime, OrderByType.Desc)
                    .ToPageListAsync(pageIndex, pageSize);

                return (records, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "查询支付流水失败");
                throw;
            }
        }
    }
}