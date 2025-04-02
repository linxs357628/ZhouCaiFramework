using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 交易表
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 主键，自增标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 交易编号
        /// </summary>
        public string TransactionNo { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// 交易类型，如收入、支出
        /// </summary>
        public string Type { get; set; } // Income, Expense

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 相关类型，如合同、发票等
        /// </summary>
        public string RelatedType { get; set; } // Contract, Invoice etc.

        /// <summary>
        /// 相关ID
        /// </summary>
        public int RelatedId { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 交易时间，默认为当前时间
        /// </summary>
        public DateTime TransactionTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreatedBy { get; set; }
    }
}