using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialHistoryDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "记录 ID 必须为正整数")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "物料 ID 必须为正整数")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "操作类型不能为空")]
        [StringLength(50, ErrorMessage = "操作类型长度不能超过 50 个字符")]
        public string EventType { get; set; } // 操作类型

        [Required(ErrorMessage = "操作描述不能为空")]
        [StringLength(200, ErrorMessage = "操作描述长度不能超过 200 个字符")]
        public string Description { get; set; } // 操作描述

        [Required(ErrorMessage = "操作人不能为空")]
        [StringLength(50, ErrorMessage = "操作人长度不能超过 50 个字符")]
        public string Operator { get; set; } // 操作人

        [Required(ErrorMessage = "操作时间不能为空")]
        public DateTime OperationTime { get; set; } // 操作时间

        [Required(ErrorMessage = "原状态不能为空")]
        [StringLength(50, ErrorMessage = "原状态长度不能超过 50 个字符")]
        public string FromStatus { get; set; } // 原状态

        [Required(ErrorMessage = "新状态不能为空")]
        [StringLength(50, ErrorMessage = "新状态长度不能超过 50 个字符")]
        public string ToStatus { get; set; } // 新状态

        [Required(ErrorMessage = "原位置不能为空")]
        [StringLength(100, ErrorMessage = "原位置长度不能超过 100 个字符")]
        public string LocationBefore { get; set; } // 原位置

        [Required(ErrorMessage = "新位置不能为空")]
        [StringLength(100, ErrorMessage = "新位置长度不能超过 100 个字符")]
        public string LocationAfter { get; set; } // 新位置

        [StringLength(50, ErrorMessage = "关联单据 ID 长度不能超过 50 个字符")]
        public string ReferenceId { get; set; } // 关联单据ID

        [Required(ErrorMessage = "关联单据类型不能为空")]
        [StringLength(50, ErrorMessage = "关联单据类型长度不能超过 50 个字符")]
        public string ReferenceType { get; set; } // 关联单据类型
    }
}