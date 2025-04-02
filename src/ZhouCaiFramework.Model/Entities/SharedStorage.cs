using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ������
    /// </summary>
    public class SharedStorage
    {
        /// <summary>
        /// ��������Id���Զ�����
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ����Id
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// �ֿ�Id
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// ��ҵId
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public decimal AvailableQuantity { get; set; }

        /// <summary>
        /// ״̬����ѡֵΪ Active, Inactive
        /// </summary>
        public string Status { get; set; } // Active, Inactive

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// ����ʱ�䣬��Ϊ��
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}