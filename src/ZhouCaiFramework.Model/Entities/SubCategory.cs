using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    public class SubCategory
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        [SugarColumn(DefaultValue = "0")]
        public int SortOrder { get; set; } = 0;

        [SugarColumn(DefaultValue = "1")]
        public bool IsActive { get; set; } = true;

        [Navigate(NavigateType.OneToOne, nameof(CategoryId))]
        public MaterialCategory Category { get; set; }
    }
}