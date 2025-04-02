using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 客户ID，主键，自动递增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 50)]
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Address { get; set; }

        /// <summary>
        /// 所属行业
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 50)]
        public string Industry { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Tags { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}