using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ���ױ�
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// ������������ʶ
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ���ױ��
        /// </summary>
        public string TransactionNo { get; set; }

        /// <summary>
        /// ��ҵID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// �������ͣ������롢֧��
        /// </summary>
        public string Type { get; set; } // Income, Expense

        /// <summary>
        /// ���׽��
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// ֧����ʽ
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// ������ͣ����ͬ����Ʊ��
        /// </summary>
        public string RelatedType { get; set; } // Contract, Invoice etc.

        /// <summary>
        /// ���ID
        /// </summary>
        public int RelatedId { get; set; }

        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime TransactionTime { get; set; } = DateTime.Now;

        /// <summary>
        /// ������ID
        /// </summary>
        public int CreatedBy { get; set; }
    }
}