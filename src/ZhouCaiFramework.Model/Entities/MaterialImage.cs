using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ŒÔ¡œÕº∆¨
    /// </summary>
    public class MaterialImage
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [SugarColumn(Length = 200)]
        public string ImageUrl { get; set; }

        [SugarColumn(Length = 200)]
        public string Description { get; set; }

        [SugarColumn(DefaultValue = "0")]
        public int SortOrder { get; set; }

        public DateTime UploadTime { get; set; }

        [SugarColumn(DefaultValue = "0")]
        public bool IsPrimary { get; set; }
    }
}