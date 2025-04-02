using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 付款单
    /// </summary>
    public class Payment
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public int ContractId { get; set; }
        public int? ProgressId { get; set; } // 工程进度ID

        [SugarColumn(Length = 50)]
        public string PaymentType { get; set; } // 款项类型

        public DateTime PaymentDate { get; set; } // 收款时间

        [SugarColumn(Length = 20)]
        public string Currency { get; set; } = "人民币"; // 货币类型

        public decimal TaxExcludedAmount { get; set; } // 不含税金额
        public decimal TaxAmount { get; set; } // 税额
        public decimal TotalAmount { get; set; } // 价税合计

        // 付款方信息
        [SugarColumn(Length = 50)]
        public string PayerType { get; set; } = "客户"; // 单位类型

        [SugarColumn(Length = 100)]
        public string PayerName { get; set; } // 付款单位

        [SugarColumn(Length = 100)]
        public string PayerAccount { get; set; } // 付款账号

        [SugarColumn(Length = 100)]
        public string PayerBank { get; set; } // 付款开户行

        [SugarColumn(Length = 50)]
        public string PayerTaxId { get; set; } // 付款方税号

        // 收款方信息
        [SugarColumn(Length = 100)]
        public string ReceiverName { get; set; } // 收款单位

        [SugarColumn(Length = 100)]
        public string ReceiverAccount { get; set; } // 收款账户

        [SugarColumn(Length = 100)]
        public string ReceiverBank { get; set; } // 收款开户行

        [SugarColumn(Length = 50)]
        public string ReceiverTaxId { get; set; } // 收款方税号

        [SugarColumn(Length = 50)]
        public string PaymentMethod { get; set; } = "电汇"; // 收款方式

        [SugarColumn(Length = 50)]
        public string SerialNumber { get; set; } // 流水号

        [SugarColumn(Length = 50)]
        public string InvoiceNumber { get; set; } // 发票编号

        [SugarColumn(Length = 50)]
        public string DocumentNumber { get; set; } // 单据编号

        [SugarColumn(Length = 500)]
        public string Notes { get; set; } // 备注

        public bool SyncedToFinance { get; set; } // 是否同步财务系统
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public decimal Amount { get; set; }
    }
}