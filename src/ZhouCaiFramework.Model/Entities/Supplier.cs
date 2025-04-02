using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// 供应商ID，主键，自动递增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 主要产品
        /// </summary>
        public string MainProducts { get; set; }

        /// <summary>
        /// 所属企业ID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// 资质信息
        /// </summary>
        public string Qualification { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}