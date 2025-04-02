using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class AddEmployeeRequest
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过 50 个字符")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在 6 到 100 个字符之间")]
        public string Password { get; set; }

        [Required(ErrorMessage = "角色不能为空")]
        [StringLength(50, ErrorMessage = "角色名称长度不能超过 50 个字符")]
        public string Role { get; set; }
    }
}