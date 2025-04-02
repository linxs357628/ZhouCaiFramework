using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 发票关联信息数据传输对象
    /// </summary>
    public class InvoiceLinkDto
    {
        /// <summary>
        /// 发票ID
        /// </summary>
        [Required(ErrorMessage = "发票ID不能为空")]
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// 关联业务类型(订单/合同等)
        /// </summary>
        [Required(ErrorMessage = "关联业务类型不能为空")]
        [StringLength(50, ErrorMessage = "业务类型长度不能超过50个字符")]
        public string BusinessType { get; set; }

        /// <summary>
        /// 关联业务ID
        /// </summary>
        [Required(ErrorMessage = "关联业务ID不能为空")]
        public Guid BusinessId { get; set; }

        /// <summary>
        /// 关联时间
        /// </summary>
        [Required(ErrorMessage = "关联时间不能为空")]
        public DateTime LinkTime { get; set; }

        /// <summary>
        /// 关联人
        /// </summary>
        [Required(ErrorMessage = "关联人不能为空")]
        [StringLength(50, ErrorMessage = "关联人姓名长度不能超过50个字符")]
        public string LinkUser { get; set; }

        /// <summary>
        /// 关联备注
        /// </summary>
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string Remark { get; set; }

        public string InvoiceNumber { get; set; }
    }
}