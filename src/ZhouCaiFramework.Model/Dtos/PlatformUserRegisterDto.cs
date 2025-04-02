using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class PlatformUserRegisterDto
    {
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(50, ErrorMessage = "姓名长度不能超过 50 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的电话号码")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        [StringLength(50, ErrorMessage = "职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }

        public bool IsMainAccount { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在 6 到 100 个字符之间")]
        public string Password { get; set; }
    }

    public class PlatformUserUpdateDto
    {
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(50, ErrorMessage = "姓名长度不能超过 50 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        [StringLength(50, ErrorMessage = "职位长度不能超过 50 个字符")]
        public string Position { get; set; }
    }

    public class WechatBindDto
    {
        [Required(ErrorMessage = "OpenId 不能为空")]
        [StringLength(100, ErrorMessage = "OpenId 长度不能超过 100 个字符")]
        public string OpenId { get; set; }
    }
}