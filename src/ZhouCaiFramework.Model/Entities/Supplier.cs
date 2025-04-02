using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// ��Ӧ��
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// ��Ӧ��ID���������Զ�����
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// ��Ӧ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��Ӧ�̴���
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ��Ҫ��Ʒ
        /// </summary>
        public string MainProducts { get; set; }

        /// <summary>
        /// ������ҵID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Qualification { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}