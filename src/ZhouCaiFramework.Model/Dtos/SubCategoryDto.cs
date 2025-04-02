using System.ComponentModel.DataAnnotations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class SubCategoryDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "����Ŀ ID ����Ϊ������")]
        public int Id { get; set; }

        [Required(ErrorMessage = "����Ŀ���Ʋ���Ϊ��")]
        [StringLength(50, ErrorMessage = "����Ŀ���Ƴ��Ȳ��ܳ��� 50 ���ַ�")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "����Ŀ�������Ȳ��ܳ��� 200 ���ַ�")]
        public string Description { get; set; }

        [Required(ErrorMessage = "��Ŀ���Ʋ���Ϊ��")]
        [StringLength(50, ErrorMessage = "��Ŀ���Ƴ��Ȳ��ܳ��� 50 ���ַ�")]
        public string CategoryName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "��Ŀ ID ����Ϊ������")]
        public int CategoryId { get; set; }
    }
}