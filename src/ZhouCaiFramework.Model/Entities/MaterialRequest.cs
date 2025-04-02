using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ��������
    /// </summary>
    public class MaterialRequest
    {
        /// <summary>
        /// ������������ʶ
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string RequestNo { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// ��Դ�ֿ�ID
        /// </summary>
        public int FromWarehouseId { get; set; }

        /// <summary>
        /// Ŀ��ֿ�ID
        /// </summary>
        public int ToWarehouseId { get; set; }

        /// <summary>
        /// ������ID
        /// </summary>
        public int RequestedBy { get; set; }

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime RequestTime { get; set; } = DateTime.Now;

        /// <summary>
        /// ״̬��Pending, Approved, Rejected, Completed
        /// </summary>
        public string Status { get; set; } // Pending, Approved, Rejected, Completed

        /// <summary>
        /// ������ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ApprovedBy { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ApprovedTime { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 300)]
        public string Remark { get; set; }
    }
}