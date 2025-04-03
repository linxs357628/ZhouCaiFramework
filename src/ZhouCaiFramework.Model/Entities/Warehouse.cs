using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// �ֿ�
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// �ֿ�ID���������Զ�����
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// �ֿ����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// �ֿ�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �ֿ�λ��
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// ��ϵ������
        /// </summary>
        public string ContactPerson { get; set; }

        /// ��ϵ�˵绰
        public string ContactPhone { get; set; }

        /// <summary>
        /// ������ҵID
        /// </summary>
        public int EnterpriseId { get; set; }

        /// �ֿ�״̬��Active��ʾ��Ծ��Inactive��ʾ����Ծ
        public string Status { get; set; } //Active, Inactive

        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// ����ʱ�䣬Ĭ��Ϊ��ǰʱ��
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Address { get; set; }
    }
}