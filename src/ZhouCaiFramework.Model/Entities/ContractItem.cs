using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 合同项
    /// </summary>

    public class ContractItem
    {
        /// <summary>
        /// 主键，自增标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同类型，例如租赁或购买
        /// </summary>
        public string ContractType { get; set; } // Rental, Purchase

        /// <summary>
        /// 材料ID
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}