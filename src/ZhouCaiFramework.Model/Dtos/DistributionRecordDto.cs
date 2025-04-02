using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class DistributionRecordDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "ѯ�ۼ�¼ ID ����Ϊ������")]
        public int InquiryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "�̻� ID ����Ϊ������")]
        public int MerchantId { get; set; }

        [Required(ErrorMessage = "�̻����Ʋ���Ϊ��")]
        [StringLength(100, ErrorMessage = "�̻����Ƴ��Ȳ��ܳ��� 100 ���ַ�")]
        public string MerchantName { get; set; }

        [Required(ErrorMessage = "����ʱ�䲻��Ϊ��")]
        public DateTime DistributionTime { get; set; }

        [StringLength(500, ErrorMessage = "��ע���Ȳ��ܳ��� 500 ���ַ�")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "״̬����Ϊ��")]
        [StringLength(50, ErrorMessage = "״̬���Ȳ��ܳ��� 50 ���ַ�")]
        public string Status { get; set; }

        public DateTime? ResponseTime { get; set; }

        [StringLength(1000, ErrorMessage = "��Ӧ���ݳ��Ȳ��ܳ��� 1000 ���ַ�")]
        public string ResponseContent { get; set; }
    }
}