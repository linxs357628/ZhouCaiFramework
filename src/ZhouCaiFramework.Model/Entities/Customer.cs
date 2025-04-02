using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// �ͻ���Ϣ
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// �ͻ�ID���������Զ�����
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 50)]
        public string ContactPerson { get; set; }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Address { get; set; }

        /// <summary>
        /// ������ҵ
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 50)]
        public string Industry { get; set; }

        /// <summary>
        /// ��ҵID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// ��ǩ
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Tags { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 200)]
        public string Remark { get; set; }

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}