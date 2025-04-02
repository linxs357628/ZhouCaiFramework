using System;
using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class MaterialImageDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "ͼƬ��¼ ID ����Ϊ������")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "���� ID ����Ϊ������")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "ͼƬ URL ����Ϊ��")]
        [StringLength(200, ErrorMessage = "ͼƬ URL ���Ȳ��ܳ��� 200 ���ַ�")]
        public string ImageUrl { get; set; }

        [StringLength(200, ErrorMessage = "ͼƬ�������Ȳ��ܳ��� 200 ���ַ�")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "����˳����Ϊ����")]
        public int SortOrder { get; set; }

        [Required(ErrorMessage = "�ϴ�ʱ�䲻��Ϊ��")]
        public DateTime UploadTime { get; set; }
    }

    public class UploadImageDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "���� ID ����Ϊ������")]
        public int MaterialId { get; set; }

        [StringLength(200, ErrorMessage = "ͼƬ�������Ȳ��ܳ��� 200 ���ַ�")]
        public string Description { get; set; }

        public bool IsPrimary { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "����Ա ID ����Ϊ������")]
        public int OperatorId { get; set; }

        [Required(ErrorMessage = "����Ա��������Ϊ��")]
        [StringLength(50, ErrorMessage = "����Ա�������Ȳ��ܳ��� 50 ���ַ�")]
        public string OperatorName { get; set; }

        [Required(ErrorMessage = "IP ��ַ����Ϊ��")]
        [StringLength(50, ErrorMessage = "IP ��ַ���Ȳ��ܳ��� 50 ���ַ�")]
        public string IpAddress { get; set; }
    }

    public class UpdateImageDto
    {
        [StringLength(200, ErrorMessage = "ͼƬ�������Ȳ��ܳ��� 200 ���ַ�")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "����˳����Ϊ����")]
        public int SortOrder { get; set; }

        public bool IsPrimary { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "����Ա ID ����Ϊ������")]
        public int OperatorId { get; set; }

        [Required(ErrorMessage = "����Ա��������Ϊ��")]
        [StringLength(50, ErrorMessage = "����Ա�������Ȳ��ܳ��� 50 ���ַ�")]
        public string OperatorName { get; set; }

        [Required(ErrorMessage = "IP ��ַ����Ϊ��")]
        [StringLength(50, ErrorMessage = "IP ��ַ���Ȳ��ܳ��� 50 ���ַ�")]
        public string IpAddress { get; set; }
    }
}