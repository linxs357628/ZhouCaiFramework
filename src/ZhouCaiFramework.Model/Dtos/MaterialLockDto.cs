using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Model.Entities;

/// <summary>
/// 材料锁库记录数据传输对象
/// 继承自MaterialLock实体类，包含所有基础字段
/// 添加了关联实体的名称信息等扩展字段
/// </summary>
public class MaterialLockDto : MaterialLock
{
    // 重写父类属性并添加验证
    [Required(ErrorMessage = "单据编号不能为空")]
    public override string DocumentNo { get; set; }

    [Required(ErrorMessage = "类型不能为空")]
    public override string Type { get; set; }

    [Required(ErrorMessage = "状态不能为空")]
    public override string Status { get; set; }

    [Required(ErrorMessage = "项目ID不能为空")]
    public override int ProjectId { get; set; }

    [Required(ErrorMessage = "物料ID不能为空")]
    public override int MaterialId { get; set; }

    [Required(ErrorMessage = "仓库ID不能为空")]
    public override int WarehouseId { get; set; }

    [Required(ErrorMessage = "操作员ID不能为空")]
    public override int OperatorId { get; set; }

    // DTO特有属性
    [Required(ErrorMessage = "项目名称不能为空")]
    public string ProjectName { get; set; }

    [Required(ErrorMessage = "仓库名称不能为空")]
    public string WarehouseName { get; set; }

    [Required(ErrorMessage = "操作员姓名不能为空")]
    public string OperatorName { get; set; }

    [Required(ErrorMessage = "操作员电话不能为空")]
    [Phone(ErrorMessage = "请输入有效的电话号码")]
    public string OperatorPhone { get; set; }

    [Required(ErrorMessage = "物料名称不能为空")]
    public string MaterialName { get; set; }

    [Required(ErrorMessage = "物料编码不能为空")]
    public string MaterialCode { get; set; }

    public bool IsScanned { get; set; }
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

    [Required(ErrorMessage = "出入库类型不能为空")]
    [RegularExpression("^(IN|OUT)$", ErrorMessage = "出入库类型必须是IN或OUT")]
    public string Type { get; set; } // 出入库类型(IN/OUT)

    [Required(ErrorMessage = "请指定是否锁库状态")]
    public bool? IsLocked { get; set; } // 是否锁库状态
}

// 假设 PaginationQuery 类的定义
public class PaginationQuery
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}