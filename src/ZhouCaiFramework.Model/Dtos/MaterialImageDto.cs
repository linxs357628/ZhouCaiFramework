using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialImageDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "图片记录 ID 必须为正整数")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "物料 ID 必须为正整数")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "图片 URL 不能为空")]
        [StringLength(200, ErrorMessage = "图片 URL 长度不能超过 200 个字符")]
        public string ImageUrl { get; set; }

        [StringLength(200, ErrorMessage = "图片描述长度不能超过 200 个字符")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "排序顺序不能为负数")]
        public int SortOrder { get; set; }

        [Required(ErrorMessage = "上传时间不能为空")]
        public DateTime UploadTime { get; set; }
    }

    public class UploadImageDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "物料 ID 必须为正整数")]
        public int MaterialId { get; set; }

        [StringLength(200, ErrorMessage = "图片描述长度不能超过 200 个字符")]
        public string Description { get; set; }

        public bool IsPrimary { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "操作员 ID 必须为正整数")]
        public int OperatorId { get; set; }

        [Required(ErrorMessage = "操作员姓名不能为空")]
        [StringLength(50, ErrorMessage = "操作员姓名长度不能超过 50 个字符")]
        public string OperatorName { get; set; }

        [Required(ErrorMessage = "IP 地址不能为空")]
        [StringLength(50, ErrorMessage = "IP 地址长度不能超过 50 个字符")]
        public string IpAddress { get; set; }
    }

    public class UpdateImageDto
    {
        [StringLength(200, ErrorMessage = "图片描述长度不能超过 200 个字符")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "排序顺序不能为负数")]
        public int SortOrder { get; set; }

        public bool IsPrimary { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "操作员 ID 必须为正整数")]
        public int OperatorId { get; set; }

        [Required(ErrorMessage = "操作员姓名不能为空")]
        [StringLength(50, ErrorMessage = "操作员姓名长度不能超过 50 个字符")]
        public string OperatorName { get; set; }

        [Required(ErrorMessage = "IP 地址不能为空")]
        [StringLength(50, ErrorMessage = "IP 地址长度不能超过 50 个字符")]
        public string IpAddress { get; set; }
    }
}