using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Entities
{
    public class MaterialCategory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [SugarColumn(DefaultValue = "0")]
        public int SortOrder { get; set; } = 0;

        [SugarColumn(DefaultValue = "1")]
        public bool IsActive { get; set; } = true;

        [Navigate(NavigateType.OneToMany, nameof(SubCategory.CategoryId))]
        public List<SubCategory> SubCategories { get; set; }

        [SugarColumn(IsNullable = true)]
        public int? ParentId { get; set; }

        public bool? IsVisible { get; set; } = true;
    }
}