using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 物料请求
    /// </summary>
    public class MaterialRequest
    {
        /// <summary>
        /// 主键，自增标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 请求编号
        /// </summary>
        public string RequestNo { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 来源仓库ID
        /// </summary>
        public int FromWarehouseId { get; set; }

        /// <summary>
        /// 目标仓库ID
        /// </summary>
        public int ToWarehouseId { get; set; }

        /// <summary>
        /// 请求人ID
        /// </summary>
        public int RequestedBy { get; set; }

        /// <summary>
        /// 请求时间，默认为当前时间
        /// </summary>
        public DateTime RequestTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 状态：Pending, Approved, Rejected, Completed
        /// </summary>
        public string Status { get; set; } // Pending, Approved, Rejected, Completed

        /// <summary>
        /// 审批人ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ApprovedBy { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ApprovedTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }
    }
}