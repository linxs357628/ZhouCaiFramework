using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// �������ڱ�ʾ�༭������ϸ��Ϣ�����ݴ������
    /// </summary>
    public class MaterialDetailEditDto
    {
        /// <summary>
        /// ���������Ψһ��ʶ��
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// �����Ĳ��ϵ�Ψһ��ʶ��������Ϊ�����
        /// </summary>
        [Required(ErrorMessage = "�����ṩ���ϵ�Ψһ��ʶ��")]
        public int MaterialId { get; set; }

        /// <summary>
        /// ����������Ψһ��ʶ��������Ϊ�����
        /// </summary>
        [Required(ErrorMessage = "�����ṩ����Ψһ��ʶ��")]
        public int LockId { get; set; }

        /// <summary>
        /// ���ϵ�������������Ϊ������������������ 0��
        /// </summary>
        [Required(ErrorMessage = "�����ṩ���ϵ�������")]
        [Range(0.01, double.MaxValue, ErrorMessage = "��������������� 0��")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// ���ϵİ�װ������������Ϊ������Ұ�װ������������Ϊ 1��
        /// </summary>
        [Required(ErrorMessage = "�����ṩ���ϵİ�װ������")]
        [Range(1, int.MaxValue, ErrorMessage = "���ϰ�װ������������Ϊ 1��")]
        public int PackageCount { get; set; }

        /// <summary>
        /// ���ϵ�������������Ϊ������������������ 0��
        /// </summary>
        [Required(ErrorMessage = "�����ṩ���ϵ�������")]
        [Range(0.01, double.MaxValue, ErrorMessage = "��������������� 0��")]
        public decimal Weight { get; set; }

        /// <summary>
        /// ���ϵ������ߣ������Կ�ѡ��
        /// </summary>
        [MaxLength(100, ErrorMessage = "���������Ʋ��ܳ��� 100 ���ַ���")]
        public string Owner { get; set; }

        /// <summary>
        /// ���ڲ��ϵı�ע��Ϣ�������Կ�ѡ��
        /// </summary>
        [MaxLength(500, ErrorMessage = "��ע��Ϣ���ܳ��� 500 ���ַ���")]
        public string Remark { get; set; }
    }
}