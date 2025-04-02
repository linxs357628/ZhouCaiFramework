using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperationLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Module { get; set; } // 模块名称

        [Required]
        [StringLength(50)]
        public string Action { get; set; } // 操作类型

        [StringLength(500)]
        public string Description { get; set; } // 操作描述

        [Required]
        public int OperatorId { get; set; } // 操作人ID

        [StringLength(50)]
        public string OperatorName { get; set; } // 操作人姓名

        [Required]
        public DateTime OperationTime { get; set; } // 操作时间

        [StringLength(50)]
        public string IpAddress { get; set; } // IP地址

        [StringLength(2000)]
        public string RequestData { get; set; } // 请求数据

        public bool IsError { get; set; }
        public int UserId { get; set; }
    }
}