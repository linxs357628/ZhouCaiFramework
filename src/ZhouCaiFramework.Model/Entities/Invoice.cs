using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 发票信息
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// 发票的唯一标识符，自增主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 发票编号
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 企业的唯一标识符
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// 发票类型，例如销售或采购
        /// </summary>
        public string Type { get; set; } // Sales, Purchase

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 发票的税额
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// 发票的状态，例如草稿、已发行、已支付、已取消
        /// </summary>
        public string Status { get; set; } // Draft, Issued, Paid, Cancelled

        /// <summary>
        /// 发票的发行日期
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// 发票的支付日期，可能为空
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? PaymentDate { get; set; }

        /// 相关类型的描述，例如合同、订单等
        public string RelatedType { get; set; } // Contract, Order etc.

        /// <summary>
        /// 相关类型的唯一标识符
        /// </summary>
        public int RelatedId { get; set; }

        /// <summary>
        /// 发票的备注信息
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }

        /// <summary>
        /// 发票的创建时间，默认为当前时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}