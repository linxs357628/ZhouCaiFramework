using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 员工创建Dto
    /// </summary>
    public class EmployeeCreateDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过 50 个字符")]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在 6 到 100 个字符之间")]
        public string Password { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required(ErrorMessage = "员工姓名不能为空")]
        [StringLength(50, ErrorMessage = "员工姓名长度不能超过 50 个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 员工职位
        /// </summary>
        [Required(ErrorMessage = "员工职位不能为空")]
        [StringLength(50, ErrorMessage = "员工职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        /// <summary>
        /// 员工角色
        /// </summary>
        [Required(ErrorMessage = "员工角色不能为空")]
        [StringLength(50, ErrorMessage = "员工角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }

    /// <summary>
    /// 员工更新Dto
    /// </summary>
    public class EmployeeUpdateDto
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required(ErrorMessage = "员工姓名不能为空")]
        [StringLength(50, ErrorMessage = "员工姓名长度不能超过 50 个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 员工职位
        /// </summary>
        [Required(ErrorMessage = "员工职位不能为空")]
        [StringLength(50, ErrorMessage = "员工职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        /// <summary>
        /// 员工角色
        /// </summary>
        [Required(ErrorMessage = "员工角色不能为空")]
        [StringLength(50, ErrorMessage = "员工角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }

    /// <summary>
    /// 角色分配Dto
    /// </summary>
    public class RoleAssignDto
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Required(ErrorMessage = "角色不能为空")]
        [StringLength(50, ErrorMessage = "角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }
}