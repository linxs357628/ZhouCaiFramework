using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ��ͬ��
    /// </summary>

    public class ContractItem
    {
        /// <summary>
        /// ������������ʶ
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ��ͬID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// ��ͬ���ͣ��������޻���
        /// </summary>
        public string ContractType { get; set; } // Rental, Purchase

        /// <summary>
        /// ����ID
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// �ܼ�
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
    }
}