using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class EcoInquiryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ѯ��ʱ�䲻��Ϊ��")]
        public DateTime InquiryTime { get; set; }

        [Required(ErrorMessage = "ѯ������������Ϊ��")]
        [StringLength(50, ErrorMessage = "ѯ�����������Ȳ��ܳ��� 50 ���ַ�")]
        public string InquirerName { get; set; }

        [Required(ErrorMessage = "��ڵ㲻��Ϊ��")]
        [StringLength(100, ErrorMessage = "��ڵ㳤�Ȳ��ܳ��� 100 ���ַ�")]
        public string EntryPoint { get; set; }

        [Required(ErrorMessage = "ѯ�����Ͳ���Ϊ��")]
        [StringLength(50, ErrorMessage = "ѯ�����ͳ��Ȳ��ܳ��� 50 ���ַ�")]
        public string InquiryType { get; set; }

        [Required(ErrorMessage = "ѯ����Ŀ�б���Ϊ��")]
        public List<InquiryItemDto> Items { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "��Ŀ��������Ϊ����")]
        public int ItemCount { get; set; }

        [StringLength(20, ErrorMessage = "��λ���Ȳ��ܳ��� 20 ���ַ�")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "��ϵ��Ϣ����Ϊ��")]
        [StringLength(100, ErrorMessage = "��ϵ��Ϣ���Ȳ��ܳ��� 100 ���ַ�")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "������ַ����Ϊ��")]
        [StringLength(200, ErrorMessage = "������ַ���Ȳ��ܳ��� 200 ���ַ�")]
        public string DeliveryAddress { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "������������Ϊ����")]
        public int DistributionCount { get; set; }

        [StringLength(100, ErrorMessage = "��ǩ���Ȳ��ܳ��� 100 ���ַ�")]
        public string Tags { get; set; }
    }

    public class InquiryItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "���� ID ����Ϊ������")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "�������Ʋ���Ϊ��")]
        [StringLength(100, ErrorMessage = "�������Ƴ��Ȳ��ܳ��� 100 ���ַ�")]
        public string MaterialName { get; set; }

        [StringLength(200, ErrorMessage = "��񳤶Ȳ��ܳ��� 200 ���ַ�")]
        public string Specification { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "��������Ϊ����")]
        public decimal Quantity { get; set; }

        [StringLength(20, ErrorMessage = "��λ���Ȳ��ܳ��� 20 ���ַ�")]
        public string Unit { get; set; }

        [StringLength(500, ErrorMessage = "��ע���Ȳ��ܳ��� 500 ���ַ�")]
        public string Remarks { get; set; }
    }
}