using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    /// <summary>
    /// 支付流水服务接口
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// 获取商家流水列表
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="amountType">金额类型(original/actual)</param>
        /// <param name="flowType">流水类型(income/expenditure)</param>
        /// <param name="search">搜索关键字</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>分页支付流水列表</returns>
        Task<(IEnumerable<PaymentFlow> Records, int TotalCount)> GetMerchantFlowsAsync(
            int merchantId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string amountType = "actual",
            string flowType = null,
            string search = null,
            int pageIndex = 1,
            int pageSize = 20);

        /// <summary>
        /// 获取流水详情
        /// </summary>
        /// <param name="id">流水ID</param>
        /// <returns>支付流水详情</returns>
        Task<PaymentFlow> GetFlowDetailAsync(int id);

        /// <summary>
        /// 导出流水数据
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="amountType">金额类型</param>
        /// <param name="flowType">流水类型</param>
        /// <param name="search">搜索关键字</param>
        /// <returns>Excel文件字节数组</returns>
        Task<byte[]> ExportFlowsAsync(
            int merchantId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string amountType = "actual",
            string flowType = null,
            string search = null);

        /// <summary>
        /// 创建支付流水记录
        /// </summary>
        /// <param name="flow">支付流水实体</param>
        /// <returns>创建后的流水记录</returns>
        Task<PaymentFlow> CreatePaymentFlowAsync(PaymentFlow flow);

        /// <summary>
        /// 更新支付流水记录
        /// </summary>
        /// <param name="flow">支付流水实体</param>
        /// <returns>是否更新成功</returns>
        Task<bool> UpdatePaymentFlowAsync(PaymentFlow flow);

        /// <summary>
        /// 查询支付流水
        /// </summary>
        Task<(IEnumerable<PaymentFlow> Records, int TotalCount)> QueryFlowsAsync(
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
            int pageSize = 20);

        Task<bool> AddPayment(PaymentCreateDto dto);

        Task<bool> UpdateSyncStatus(PaymentCreateDto dto);

        Task<PaginatedList<PaymentFlow>> GetPayments(PaymentQuery query);

        Task<byte[]> ExportPayments(PaymentQuery query);

        Task<bool> LinkInvoice(int paymentId, InvoiceLinkDto dto);
    }
}