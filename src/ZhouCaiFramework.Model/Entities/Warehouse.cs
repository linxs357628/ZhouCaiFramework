using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 仓库
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// 仓库ID，主键，自动递增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 仓库位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactPerson { get; set; }

        /// 联系人电话
        public string ContactPhone { get; set; }

        /// <summary>
        /// 所属企业ID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// 仓库状态，Active表示活跃，Inactive表示不活跃
        public string Status { get; set; } //Active, Inactive

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间，默认为当前时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Address { get; set; }
    }
}