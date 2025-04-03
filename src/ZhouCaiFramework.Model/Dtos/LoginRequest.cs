using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 登录请求DTO
    /// 包含用户登录所需的凭证信息
    /// </summary>
    public class LoginRequest
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "用户名长度必须在4-50个字符之间")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空")] 
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在6-100个字符之间")]
        public string Password { get; set; }
    }
}
