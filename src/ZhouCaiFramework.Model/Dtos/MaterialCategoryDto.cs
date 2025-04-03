using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Common;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 材料分类数据传输对象
    /// </summary>
    public class MaterialCategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "类别名称不能为空")]
        [StringLength(50, ErrorMessage = "类别名称长度不能超过50个字符")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "描述长度不能超过500个字符")]
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public string ParentName { get; set; }

        public bool IsVisible { get; set; } = true;
        public int SortOrder { get; set; }
    }

    /// <summary>
    /// 材料分类查询DTO
    /// </summary>
    public class MaterialCategoryQueryDto : PaginationQuery
    {
        public string Keyword { get; set; }
        public int? ParentId { get; set; }
        public bool? IsVisible { get; set; }
    }
}
