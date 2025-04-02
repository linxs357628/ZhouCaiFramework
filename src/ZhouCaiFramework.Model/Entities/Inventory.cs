using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 库存
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// 库存的唯一标识符，作为主键并自动递增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 物料的标识符
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// 仓库的标识符
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 库存的总数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 可用的数量
        /// </summary>
        public decimal AvailableQuantity { get; set; }

        /// <summary>
        /// 锁定的数量
        /// </summary>
        public decimal LockedQuantity { get; set; }

        /// 最后更新时间，默认为当前时间
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后更新人的标识符
        /// </summary>
        public int LastUpdatedBy { get; set; }
    }
}