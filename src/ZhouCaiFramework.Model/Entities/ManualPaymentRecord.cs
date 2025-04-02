using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 收款记录
    /// </summary>
    public class ManualPaymentRecord
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int ProjectId { get; set; } // 关联项目ID
        public string PaymentType { get; set; } // 款项类型
        public DateTime PaymentTime { get; set; } // 收款时间
        public string CurrencyType { get; set; } // 货币类型
        public decimal Amount { get; set; } // 收款金额
        public string FlowNumber { get; set; } // 流水账号

        // 收款账户信息
        public string ReceiverName { get; set; } // 开户名称

        public string ReceiverBank { get; set; } // 开户银行
        public string ReceiverAccount { get; set; } // 银行账号
        public string ReceiverTaxId { get; set; } // 纳税人识别号

        // 付款账户信息
        public string PayerName { get; set; } // 开户名称

        public string PayerBank { get; set; } // 开户银行
        public string PayerAccount { get; set; } // 银行账号
        public string PayerTaxId { get; set; } // 纳税人识别号

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Creator { get; set; } // 创建人

        [SugarColumn(IsNullable = true, Length = 500)]
        public string Remark { get; set; } // 备注
    }
}