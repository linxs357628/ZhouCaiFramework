using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class SubCategoryDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "子类目 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "子类目名称不能为空")]
        [StringLength(50, ErrorMessage = "子类目名称长度不能超过 50 个字符")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "子类目描述长度不能超过 200 个字符")]
        public string Description { get; set; }

        [Required(ErrorMessage = "类目名称不能为空")]
        [StringLength(50, ErrorMessage = "类目名称长度不能超过 50 个字符")]
        public string CategoryName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "类目 ID 必须为正整数")]
        public int CategoryId { get; set; }
    }
}