using SqlSugar;

namespace ZhouCaiFramework.Model.Entities
{
    /// <summary>
    /// 通知
    /// </summary>
    public class Notification
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50)]
        public string MerchantType { get; set; }

        [SugarColumn(Length = 200)]
        public string Title { get; set; }

        [SugarColumn(Length = 500)]
        public string Content { get; set; }

        [SugarColumn(Length = 500)]
        public string LinkUrl { get; set; }

        [SugarColumn(ColumnDataType = "text")]
        public string Platforms { get; set; } // JSON数组存储发布端口

        [SugarColumn(Length = 20)]
        public string NotificationType { get; set; } // 弹窗/跑马灯

        [SugarColumn(ColumnDataType = "text")]
        public string DistributionRules { get; set; } // JSON存储分发规则

        [SugarColumn(ColumnDataType = "text")]
        public string Tags { get; set; } // JSON数组存储关联标签

        [SugarColumn(DefaultValue = "0")]
        public int Status { get; set; } // 0-草稿 1-已发布

        [SugarColumn]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [SugarColumn]
        public DateTime? PublishTime { get; set; }

        [SugarColumn(Length = 50)]
        public string Creator { get; set; }
    }
}