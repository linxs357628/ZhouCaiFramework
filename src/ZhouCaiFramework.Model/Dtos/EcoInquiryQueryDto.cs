using System;
using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Common.Validations;

namespace ZhouCaiFramework.Model.Dtos
{
    public class EcoInquiryQueryDto : PaginationQuery
    {
        [StringLength(50, ErrorMessage = "关键词长度不能超过50个字符")]
        public string Keyword { get; set; }

        [RegularExpression("租赁|购买", ErrorMessage = "询价方式必须是'租赁'或'购买'")]
        public string InquiryType { get; set; }

        [DateLessThan(nameof(EndTime), ErrorMessage = "开始时间不能晚于结束时间")]
        public DateTime? StartTime { get; set; }

        [DateGreaterThan(nameof(StartTime), ErrorMessage = "结束时间不能早于开始时间")]
        public DateTime? EndTime { get; set; }

        [StringLength(20, ErrorMessage = "省份长度不能超过20个字符")]
        public string Province { get; set; }

        [StringLength(20, ErrorMessage = "城市长度不能超过20个字符")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "区县长度不能超过20个字符")]
        public string District { get; set; }

        [RegularExpression("InquiryTime|InquirerName|DistributionCount",
            ErrorMessage = "排序字段不合法")]
        public string SortField { get; set; } = "InquiryTime";

        [RegularExpression("desc|asc", ErrorMessage = "排序方式必须是desc或asc")]
        public string SortOrder { get; set; } = "desc";
    }
}