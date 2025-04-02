using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ��Ʊ��Ϣ
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// ��Ʊ��Ψһ��ʶ������������
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ��Ʊ���
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// ��ҵ��Ψһ��ʶ��
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// ��Ʊ���ͣ��������ۻ�ɹ�
        /// </summary>
        public string Type { get; set; } // Sales, Purchase

        /// <summary>
        /// ��Ʊ���
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// ��Ʊ��˰��
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// ��Ʊ��״̬������ݸ塢�ѷ��С���֧������ȡ��
        /// </summary>
        public string Status { get; set; } // Draft, Issued, Paid, Cancelled

        /// <summary>
        /// ��Ʊ�ķ�������
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// ��Ʊ��֧�����ڣ�����Ϊ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? PaymentDate { get; set; }

        /// ������͵������������ͬ��������
        public string RelatedType { get; set; } // Contract, Order etc.

        /// <summary>
        /// ������͵�Ψһ��ʶ��
        /// </summary>
        public int RelatedId { get; set; }

        /// <summary>
        /// ��Ʊ�ı�ע��Ϣ
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }

        /// <summary>
        /// ��Ʊ�Ĵ���ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}