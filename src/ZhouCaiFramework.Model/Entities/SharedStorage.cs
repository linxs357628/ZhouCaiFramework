using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 共享库存
    /// </summary>
    public class SharedStorage
    {
        /// <summary>
        /// 定义主键Id，自动递增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 物料Id
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 企业Id
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 可用数量
        /// </summary>
        public decimal AvailableQuantity { get; set; }

        /// <summary>
        /// 状态，可选值为 Active, Inactive
        /// </summary>
        public string Status { get; set; } // Active, Inactive

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间，可为空
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}