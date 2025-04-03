using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 该类用于表示编辑材料详细信息的数据传输对象。
    /// </summary>
    public class MaterialDetailEditDto
    {
        /// <summary>
        /// 材料详情的唯一标识。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 关联的材料的唯一标识，此属性为必填项。
        /// </summary>
        [Required(ErrorMessage = "必须提供材料的唯一标识。")]
        public int MaterialId { get; set; }

        /// <summary>
        /// 关联的锁的唯一标识，此属性为必填项。
        /// </summary>
        [Required(ErrorMessage = "必须提供锁的唯一标识。")]
        public int LockId { get; set; }

        /// <summary>
        /// 材料的数量，此属性为必填项，且数量必须大于 0。
        /// </summary>
        [Required(ErrorMessage = "必须提供材料的数量。")]
        [Range(0.01, double.MaxValue, ErrorMessage = "材料数量必须大于 0。")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 材料的包装数量，此属性为必填项，且包装数量必须至少为 1。
        /// </summary>
        [Required(ErrorMessage = "必须提供材料的包装数量。")]
        [Range(1, int.MaxValue, ErrorMessage = "材料包装数量必须至少为 1。")]
        public int PackageCount { get; set; }

        /// <summary>
        /// 材料的重量，此属性为必填项，且重量必须大于 0。
        /// </summary>
        [Required(ErrorMessage = "必须提供材料的重量。")]
        [Range(0.01, double.MaxValue, ErrorMessage = "材料重量必须大于 0。")]
        public decimal Weight { get; set; }

        /// <summary>
        /// 材料的所有者，该属性可选。
        /// </summary>
        [MaxLength(100, ErrorMessage = "所有者名称不能超过 100 个字符。")]
        public string Owner { get; set; }

        /// <summary>
        /// 关于材料的备注信息，该属性可选。
        /// </summary>
        [MaxLength(500, ErrorMessage = "备注信息不能超过 500 个字符。")]
        public string Remark { get; set; }
    }
}