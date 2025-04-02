using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class NotificationCreateDto
    {
        [Required(ErrorMessage = "商家类型不能为空")]
        [StringLength(50, ErrorMessage = "商家类型长度不能超过 50 个字符")]
        public string MerchantType { get; set; }

        [Required(ErrorMessage = "标题不能为空")]
        [StringLength(100, ErrorMessage = "标题长度不能超过 100 个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [StringLength(2000, ErrorMessage = "内容长度不能超过 2000 个字符")]
        public string Content { get; set; }

        [Url(ErrorMessage = "链接 URL 格式不正确")]
        [StringLength(200, ErrorMessage = "链接 URL 长度不能超过 200 个字符")]
        public string LinkUrl { get; set; }

        [Required(ErrorMessage = "平台列表不能为空")]
        public List<string> Platforms { get; set; }

        [Required(ErrorMessage = "通知类型不能为空")]
        [StringLength(50, ErrorMessage = "通知类型长度不能超过 50 个字符")]
        public string NotificationType { get; set; }

        [Required(ErrorMessage = "分发规则不能为空")]
        public Dictionary<string, string> DistributionRules { get; set; }

        [Required(ErrorMessage = "标签列表不能为空")]
        public List<int> Tags { get; set; }
    }

    public class NotificationUpdateDto
    {
        [Required(ErrorMessage = "标题不能为空")]
        [StringLength(100, ErrorMessage = "标题长度不能超过 100 个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [StringLength(2000, ErrorMessage = "内容长度不能超过 2000 个字符")]
        public string Content { get; set; }

        [Url(ErrorMessage = "链接 URL 格式不正确")]
        [StringLength(200, ErrorMessage = "链接 URL 长度不能超过 200 个字符")]
        public string LinkUrl { get; set; }

        [Required(ErrorMessage = "平台列表不能为空")]
        public List<string> Platforms { get; set; }

        [Required(ErrorMessage = "通知类型不能为空")]
        [StringLength(50, ErrorMessage = "通知类型长度不能超过 50 个字符")]
        public string NotificationType { get; set; }

        [Required(ErrorMessage = "分发规则不能为空")]
        public Dictionary<string, string> DistributionRules { get; set; }

        [Required(ErrorMessage = "标签列表不能为空")]
        public List<int> Tags { get; set; }
    }

    public class NotificationDetailDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "通知 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "商家类型不能为空")]
        [StringLength(50, ErrorMessage = "商家类型长度不能超过 50 个字符")]
        public string MerchantType { get; set; }

        [Required(ErrorMessage = "标题不能为空")]
        [StringLength(100, ErrorMessage = "标题长度不能超过 100 个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [StringLength(2000, ErrorMessage = "内容长度不能超过 2000 个字符")]
        public string Content { get; set; }

        [Url(ErrorMessage = "链接 URL 格式不正确")]
        [StringLength(200, ErrorMessage = "链接 URL 长度不能超过 200 个字符")]
        public string LinkUrl { get; set; }

        [Required(ErrorMessage = "平台列表不能为空")]
        public List<string> Platforms { get; set; }

        [Required(ErrorMessage = "通知类型不能为空")]
        [StringLength(50, ErrorMessage = "通知类型长度不能超过 50 个字符")]
        public string NotificationType { get; set; }

        [Required(ErrorMessage = "分发规则不能为空")]
        public Dictionary<string, string> DistributionRules { get; set; }

        [Required(ErrorMessage = "标签列表不能为空")]
        public List<int> Tags { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "通知状态必须为非负整数")]
        public int Status { get; set; }

        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime CreateTime { get; set; }

        public DateTime? PublishTime { get; set; }

        [Required(ErrorMessage = "创建人不能为空")]
        [StringLength(50, ErrorMessage = "创建人长度不能超过 50 个字符")]
        public string Creator { get; set; }
    }
}