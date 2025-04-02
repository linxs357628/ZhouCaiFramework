using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 企业创建Dto
    /// </summary>
    public class EnterpriseCreateDto
    {
        /// <summary>
        /// 省份
        /// </summary>
        [Required(ErrorMessage = "省份不能为空")]
        [StringLength(50, ErrorMessage = "省份名称长度不能超过 50 个字符")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Required(ErrorMessage = "城市不能为空")]
        [StringLength(50, ErrorMessage = "城市名称长度不能超过 50 个字符")]
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [Required(ErrorMessage = "区不能为空")]
        [StringLength(50, ErrorMessage = "区名称长度不能超过 50 个字符")]
        public string District { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        [Required(ErrorMessage = "企业类型不能为空")]
        [StringLength(50, ErrorMessage = "企业类型名称长度不能超过 50 个字符")]
        public string EnterpriseType { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Required(ErrorMessage = "企业名称不能为空")]
        [StringLength(100, ErrorMessage = "企业名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 企业简称
        /// </summary>
        [Required(ErrorMessage = "企业简称不能为空")]
        [StringLength(50, ErrorMessage = "企业简称长度不能超过 50 个字符")]
        public string ShortName { get; set; }

        /// <summary>
        /// 企业级别
        /// </summary>
        [Required(ErrorMessage = "企业级别不能为空")]
        [StringLength(50, ErrorMessage = "企业级别名称长度不能超过 50 个字符")]
        public string Level { get; set; }

        /// <summary>
        /// 上级企业Id
        /// </summary>
        public int? ParentEnterpriseId { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        [Required(ErrorMessage = "法人不能为空")]
        [StringLength(50, ErrorMessage = "法人姓名长度不能超过 50 个字符")]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人电话
        /// </summary>
        [Required(ErrorMessage = "法人电话不能为空")]
        [Phone(ErrorMessage = "请输入有效的法人电话号码")]
        public string LegalPhone { get; set; }

        /// <summary>
        /// 企业前缀
        /// </summary>
        [Required(ErrorMessage = "企业前缀不能为空")]
        [StringLength(20, ErrorMessage = "企业前缀长度不能超过 20 个字符")]
        public string EnterprisePrefix { get; set; }

        /// <summary>
        /// 业务联系人Id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "业务联系人 ID 必须为正整数")]
        public int SalesmanId { get; set; }

        /// <summary>
        /// 主账号Id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "主账号 ID 必须为正整数")]
        public int MainAccountId { get; set; }

        /// <summary>
        /// 标签Id列表
        /// </summary>
        [Required(ErrorMessage = "标签 ID 列表不能为空")]
        public List<int> TagIds { get; set; }

        /// <summary>
        /// 企业等级
        /// </summary>
        [Required(ErrorMessage = "企业等级不能为空")]
        [StringLength(50, ErrorMessage = "企业等级名称长度不能超过 50 个字符")]
        public string Grade { get; set; }
    }

    /// <summary>
    /// 企业更新Dto
    /// </summary>
    public class EnterpriseUpdateDto
    {
        [Required(ErrorMessage = "省份不能为空")]
        [StringLength(50, ErrorMessage = "省份名称长度不能超过 50 个字符")]
        public string Province { get; set; }

        [Required(ErrorMessage = "城市不能为空")]
        [StringLength(50, ErrorMessage = "城市名称长度不能超过 50 个字符")]
        public string City { get; set; }

        [Required(ErrorMessage = "区不能为空")]
        [StringLength(50, ErrorMessage = "区名称长度不能超过 50 个字符")]
        public string District { get; set; }

        [Required(ErrorMessage = "企业类型不能为空")]
        [StringLength(50, ErrorMessage = "企业类型名称长度不能超过 50 个字符")]
        public string EnterpriseType { get; set; }

        [Required(ErrorMessage = "企业名称不能为空")]
        [StringLength(100, ErrorMessage = "企业名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "企业简称不能为空")]
        [StringLength(50, ErrorMessage = "企业简称长度不能超过 50 个字符")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "企业级别不能为空")]
        [StringLength(50, ErrorMessage = "企业级别名称长度不能超过 50 个字符")]
        public string Level { get; set; }

        public int? ParentEnterpriseId { get; set; }

        [Required(ErrorMessage = "法人不能为空")]
        [StringLength(50, ErrorMessage = "法人姓名长度不能超过 50 个字符")]
        public string LegalPerson { get; set; }

        [Required(ErrorMessage = "法人电话不能为空")]
        [Phone(ErrorMessage = "请输入有效的法人电话号码")]
        public string LegalPhone { get; set; }

        [Required(ErrorMessage = "企业前缀不能为空")]
        [StringLength(20, ErrorMessage = "企业前缀长度不能超过 20 个字符")]
        public string EnterprisePrefix { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "业务联系人 ID 必须为正整数")]
        public int SalesmanId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "主账号 ID 必须为正整数")]
        public int MainAccountId { get; set; }

        [Required(ErrorMessage = "标签 ID 列表不能为空")]
        public List<int> TagIds { get; set; }

        [Required(ErrorMessage = "企业等级不能为空")]
        [StringLength(50, ErrorMessage = "企业等级名称长度不能超过 50 个字符")]
        public string Grade { get; set; }
    }

    /// <summary>
    /// 企业详情Dto
    /// </summary>
    public class EnterpriseDetailDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "省份不能为空")]
        [StringLength(50, ErrorMessage = "省份名称长度不能超过 50 个字符")]
        public string Province { get; set; }

        [Required(ErrorMessage = "城市不能为空")]
        [StringLength(50, ErrorMessage = "城市名称长度不能超过 50 个字符")]
        public string City { get; set; }

        [Required(ErrorMessage = "区不能为空")]
        [StringLength(50, ErrorMessage = "区名称长度不能超过 50 个字符")]
        public string District { get; set; }

        [Required(ErrorMessage = "企业类型不能为空")]
        [StringLength(50, ErrorMessage = "企业类型名称长度不能超过 50 个字符")]
        public string EnterpriseType { get; set; }

        [Required(ErrorMessage = "企业名称不能为空")]
        [StringLength(100, ErrorMessage = "企业名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "企业简称不能为空")]
        [StringLength(50, ErrorMessage = "企业简称长度不能超过 50 个字符")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "企业级别不能为空")]
        [StringLength(50, ErrorMessage = "企业级别名称长度不能超过 50 个字符")]
        public string Level { get; set; }

        public int? ParentEnterpriseId { get; set; }

        [Required(ErrorMessage = "法人不能为空")]
        [StringLength(50, ErrorMessage = "法人姓名长度不能超过 50 个字符")]
        public string LegalPerson { get; set; }

        [Required(ErrorMessage = "法人电话不能为空")]
        [Phone(ErrorMessage = "请输入有效的法人电话号码")]
        public string LegalPhone { get; set; }

        [Required(ErrorMessage = "企业前缀不能为空")]
        [StringLength(20, ErrorMessage = "企业前缀长度不能超过 20 个字符")]
        public string EnterprisePrefix { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "业务联系人 ID 必须为正整数")]
        public int SalesmanId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "主账号 ID 必须为正整数")]
        public int MainAccountId { get; set; }

        [Required(ErrorMessage = "标签 ID 列表不能为空")]
        public List<int> TagIds { get; set; }

        [Required(ErrorMessage = "企业等级不能为空")]
        [StringLength(50, ErrorMessage = "企业等级名称长度不能超过 50 个字符")]
        public string Grade { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "企业状态必须为非负整数")]
        public int Status { get; set; }

        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Required(ErrorMessage = "仓库列表不能为空")]
        public List<SharedWarehouse> Warehouses { get; set; }
    }

    /// <summary>
    /// 仓库创建Dto
    /// </summary>
    public class WarehouseCreateDto
    {
        [Required(ErrorMessage = "仓库名称不能为空")]
        [StringLength(100, ErrorMessage = "仓库名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "仓库位置不能为空")]
        [StringLength(100, ErrorMessage = "仓库位置长度不能超过 100 个字符")]
        public string Location { get; set; }

        [Required(ErrorMessage = "仓库地址不能为空")]
        [StringLength(200, ErrorMessage = "仓库地址长度不能超过 200 个字符")]
        public string Address { get; set; }

        [Required(ErrorMessage = "主要存储物品不能为空")]
        [StringLength(100, ErrorMessage = "主要存储物品名称长度不能超过 100 个字符")]
        public string MainStorage { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "仓库面积不能为负数")]
        public decimal Area { get; set; }

        [Required(ErrorMessage = "开放时间不能为空")]
        [StringLength(20, ErrorMessage = "开放时间格式长度不能超过 20 个字符")]
        public string OpenTime { get; set; }

        [Required(ErrorMessage = "关闭时间不能为空")]
        [StringLength(20, ErrorMessage = "关闭时间格式长度不能超过 20 个字符")]
        public string CloseTime { get; set; }

        public bool IsShared { get; set; }

        [Required(ErrorMessage = "仓库类型不能为空")]
        [StringLength(50, ErrorMessage = "仓库类型名称长度不能超过 50 个字符")]
        public string Type { get; set; }
    }

    /// <summary>
    /// 仓库更新Dto
    /// </summary>
    public class WarehouseUpdateDto
    {
        [Required(ErrorMessage = "仓库名称不能为空")]
        [StringLength(100, ErrorMessage = "仓库名称长度不能超过 100 个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "仓库位置不能为空")]
        [StringLength(100, ErrorMessage = "仓库位置长度不能超过 100 个字符")]
        public string Location { get; set; }

        [Required(ErrorMessage = "仓库地址不能为空")]
        [StringLength(200, ErrorMessage = "仓库地址长度不能超过 200 个字符")]
        public string Address { get; set; }

        [Required(ErrorMessage = "主要存储物品不能为空")]
        [StringLength(100, ErrorMessage = "主要存储物品名称长度不能超过 100 个字符")]
        public string MainStorage { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "仓库面积不能为负数")]
        public decimal Area { get; set; }

        [Required(ErrorMessage = "开放时间不能为空")]
        [StringLength(20, ErrorMessage = "开放时间格式长度不能超过 20 个字符")]
        public string OpenTime { get; set; }

        [Required(ErrorMessage = "关闭时间不能为空")]
        [StringLength(20, ErrorMessage = "关闭时间格式长度不能超过 20 个字符")]
        public string CloseTime { get; set; }

        public bool IsShared { get; set; }

        [Required(ErrorMessage = "仓库类型不能为空")]
        [StringLength(50, ErrorMessage = "仓库类型名称长度不能超过 50 个字符")]
        public string Type { get; set; }
    }
}