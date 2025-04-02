using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 支付流水实体
    /// </summary>
    public class PaymentFlow
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int MerchantId { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime TransactionTime { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false)]
        public string EnterpriseName { get; set; }

        /// <summary>
        /// 企业级别(总公司/分子公司)
        /// </summary>
        [SugarColumn(Length = 20)]
        public string EnterpriseLevel { get; set; }

        /// <summary>
        /// 流水类型(income/expenditure)
        /// </summary>
        [SugarColumn(Length = 20, IsNullable = false)]
        public string FlowType { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [SugarColumn(Length = 50)]
        public string BusinessType { get; set; }

        /// <summary>
        /// 原始金额
        /// </summary>
        [SugarColumn(DecimalDigits = 2, IsNullable = false)]
        public decimal OriginalAmount { get; set; }

        /// <summary>
        /// 实际金额
        /// </summary>
        [SugarColumn(DecimalDigits = 2, IsNullable = false)]
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 交易后余额
        /// </summary>
        [SugarColumn(DecimalDigits = 2)]
        public decimal BalanceAfter { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 关联订单信息(JSON格式)
        /// </summary>
        [SugarColumn(Length = 500)]
        public string RelatedOrder { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(Length = 50)]
        public string Creator { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(Length = 50)]
        public string Updater { get; set; }

        public bool SyncStatus { get; set; }
        public Guid InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
    }
}