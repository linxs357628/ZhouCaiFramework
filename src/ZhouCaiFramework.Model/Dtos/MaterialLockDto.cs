using System.ComponentModel.DataAnnotations;

public class MaterialLockDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "单据编号不能为空")]
    public string DocumentNo { get; set; }

    [Required(ErrorMessage = "项目名称不能为空")]
    public string ProjectName { get; set; }

    [Required(ErrorMessage = "类型不能为空")]
    public string Type { get; set; }

    [Required(ErrorMessage = "原因不能为空")]
    public string Reason { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "锁定天数必须大于 0")]
    public int LockDays { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "重量不能为负数")]
    public decimal Weight { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "数量不能为负数")]
    public decimal Quantity { get; set; }

    [Required(ErrorMessage = "创建时间不能为空")]
    public DateTime CreateTime { get; set; }

    [Required(ErrorMessage = "计划时间不能为空")]
    public DateTime PlanTime { get; set; }

    [Required(ErrorMessage = "租户不能为空")]
    public string Renter { get; set; }

    [Required(ErrorMessage = "仓库名称不能为空")]
    public string WarehouseName { get; set; }

    [Required(ErrorMessage = "状态不能为空")]
    public string Status { get; set; }

    [Required(ErrorMessage = "操作员姓名不能为空")]
    public string OperatorName { get; set; }

    [Required(ErrorMessage = "操作员电话不能为空")]
    [Phone(ErrorMessage = "请输入有效的电话号码")]
    public string OperatorPhone { get; set; }

    public bool IsScanned { get; set; }

    [Required(ErrorMessage = "物料名称不能为空")]
    public string MaterialName { get; set; }

    [Required(ErrorMessage = "物料编码不能为空")]
    public string MaterialCode { get; set; }
}

public class MaterialLockQueryDto : PaginationQuery
{
    public string Keyword { get; set; }
    public int? MaterialCategoryId { get; set; }
    public int? MaterialSubCategoryId { get; set; }
    public int? MaterialId { get; set; }

    public DateTime? SubmitStartTime { get; set; }
    public DateTime? SubmitEndTime { get; set; }

    [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "计划开始时间必须在有效范围内")]
    public DateTime? PlanStartTime { get; set; }

    [Range(typeof(DateTime), "01/01/1900", "12/31/9999", ErrorMessage = "计划结束时间必须在有效范围内")]
    public DateTime? PlanEndTime { get; set; }

    public string Type { get; set; } // 出入库类型
    public bool? IsLocked { get; set; } // 是否锁库状态
}

// 假设 PaginationQuery 类的定义
public class PaginationQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}