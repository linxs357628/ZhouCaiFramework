using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class TagCreateDto
    {
        [Required(ErrorMessage = "标签名称不能为空")]
        [StringLength(50, ErrorMessage = "标签名称长度不能超过 50 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "标签颜色不能为空")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "请输入有效的十六进制颜色代码，如 #RRGGBB 或 #RGB")]
        public string Color { get; set; }
    }

    public class TagUpdateDto
    {
        [Required(ErrorMessage = "标签名称不能为空")]
        [StringLength(50, ErrorMessage = "标签名称长度不能超过 50 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "标签颜色不能为空")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "请输入有效的十六进制颜色代码，如 #RRGGBB 或 #RGB")]
        public string Color { get; set; }
    }

    public class TagVisibilityDto
    {
        public bool IsHidden { get; set; }
    }
}