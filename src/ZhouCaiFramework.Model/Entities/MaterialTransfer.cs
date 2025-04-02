using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 物料转移
    /// </summary>
    public class MaterialTransfer
    {
        /// <summary>
        /// 物料转移的唯一标识符
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 物料转移编号
        /// </summary>
        public string TransferNo { get; set; }

        /// 物料的唯一标识符
        public int MaterialId { get; set; }

        /// <summary>
        /// 转移的数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 转移来源仓库的唯一标识符
        /// </summary>
        public int FromWarehouseId { get; set; }

        /// <summary>
        /// 转移目标仓库的唯一标识符
        /// </summary>
        public int ToWarehouseId { get; set; }

        /// <summary>
        /// 请求的唯一标识符
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// 执行转移操作的用户标识符
        /// </summary>
        public int TransferredBy { get; set; }

        /// <summary>
        /// 物料转移的时间，默认为当前时间
        /// </summary>
        public DateTime TransferTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 物料转移的状态，可能值包括 InProgress, Completed, Cancelled
        /// </summary>
        public string Status { get; set; } // InProgress, Completed, Cancelled

        /// <summary>
        /// 备注信息
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }
    }
}