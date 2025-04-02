using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MerchantLevelCreateDto
    {
        [Required(ErrorMessage = "企业类型不能为空")]
        [StringLength(50, ErrorMessage = "企业类型长度不能超过 50 个字符")]
        public string EnterpriseType { get; set; }

        [Required(ErrorMessage = "级别不能为空")]
        [StringLength(50, ErrorMessage = "级别长度不能超过 50 个字符")]
        public string Level { get; set; }

        [Required(ErrorMessage = "权限不能为空")]
        [StringLength(2000, ErrorMessage = "权限长度不能超过 2000 个字符")]
        public string Permissions { get; set; }
    }

    public class MerchantLevelUpdateDto
    {
        [Required(ErrorMessage = "企业类型不能为空")]
        [StringLength(50, ErrorMessage = "企业类型长度不能超过 50 个字符")]
        public string EnterpriseType { get; set; }

        [Required(ErrorMessage = "级别不能为空")]
        [StringLength(50, ErrorMessage = "级别长度不能超过 50 个字符")]
        public string Level { get; set; }

        [Required(ErrorMessage = "权限不能为空")]
        [StringLength(2000, ErrorMessage = "权限长度不能超过 2000 个字符")]
        public string Permissions { get; set; }
    }
}