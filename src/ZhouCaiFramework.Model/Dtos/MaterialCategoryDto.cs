using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Common;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialCategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "类别名称不能为空")]
        [StringLength(50, ErrorMessage = "类别名称长度不能超过50个字符")]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public string ParentName { get; set; }

        public bool IsVisible { get; set; } = true;
        public int SortOrder { get; set; }
    }

    public class MaterialCategoryQueryDto : PaginationQuery
    {
        public string Keyword { get; set; }
        public int? ParentId { get; set; }
        public bool? IsVisible { get; set; }
    }
}