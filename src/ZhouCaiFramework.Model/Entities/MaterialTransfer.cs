using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ����ת��
    /// </summary>
    public class MaterialTransfer
    {
        /// <summary>
        /// ����ת�Ƶ�Ψһ��ʶ��
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ����ת�Ʊ��
        /// </summary>
        public string TransferNo { get; set; }

        /// ���ϵ�Ψһ��ʶ��
        public int MaterialId { get; set; }

        /// <summary>
        /// ת�Ƶ�����
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// ת����Դ�ֿ��Ψһ��ʶ��
        /// </summary>
        public int FromWarehouseId { get; set; }

        /// <summary>
        /// ת��Ŀ��ֿ��Ψһ��ʶ��
        /// </summary>
        public int ToWarehouseId { get; set; }

        /// <summary>
        /// �����Ψһ��ʶ��
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// ִ��ת�Ʋ������û���ʶ��
        /// </summary>
        public int TransferredBy { get; set; }

        /// <summary>
        /// ����ת�Ƶ�ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime TransferTime { get; set; } = DateTime.Now;

        /// <summary>
        /// ����ת�Ƶ�״̬������ֵ���� InProgress, Completed, Cancelled
        /// </summary>
        public string Status { get; set; } // InProgress, Completed, Cancelled

        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }
    }
}