using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ���
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// ����Ψһ��ʶ������Ϊ�������Զ�����
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ���ϵı�ʶ��
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// �ֿ�ı�ʶ��
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// ���õ�����
        /// </summary>
        public decimal AvailableQuantity { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public decimal LockedQuantity { get; set; }

        /// ������ʱ�䣬Ĭ��Ϊ��ǰʱ��
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// �������˵ı�ʶ��
        /// </summary>
        public int LastUpdatedBy { get; set; }
    }
}