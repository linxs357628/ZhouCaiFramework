using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Model.Dtos
{
    public class UserAccountDetailDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "用户 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过 50 个字符")]
        public string Username { get; set; }

        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "真实姓名不能为空")]
        [StringLength(50, ErrorMessage = "真实姓名长度不能超过 50 个字符")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的电话号码")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "微信 OpenId 长度不能超过 100 个字符")]
        public string WechatOpenId { get; set; }

        public bool IsMainAccount { get; set; }

        [Required(ErrorMessage = "注册时间不能为空")]
        public DateTime RegisterTime { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(50, ErrorMessage = "最后登录平台长度不能超过 50 个字符")]
        public string LastLoginPlatform { get; set; }

        [Required(ErrorMessage = "用户状态不能为空")]
        [StringLength(20, ErrorMessage = "用户状态长度不能超过 20 个字符")]
        public string Status { get; set; }

        [Required(ErrorMessage = "企业关联信息不能为空")]
        public List<EnterpriseLinkDto> EnterpriseLinks { get; set; }

        [Required(ErrorMessage = "用户日志信息不能为空")]
        public IEnumerable<UserLog> Logs { get; set; }
    }

    public class UserAccountSimpleDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "用户 ID 必须为正整数")]
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过 50 个字符")]
        public string Username { get; set; }

        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "真实姓名不能为空")]
        [StringLength(50, ErrorMessage = "真实姓名长度不能超过 50 个字符")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的电话号码")]
        public string Phone { get; set; }

        public bool IsMainAccount { get; set; }

        [Required(ErrorMessage = "用户状态不能为空")]
        [StringLength(20, ErrorMessage = "用户状态长度不能超过 20 个字符")]
        public string Status { get; set; }

        [StringLength(50, ErrorMessage = "职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        [StringLength(50, ErrorMessage = "角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }

    public class UserAccountCreateDto
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, ErrorMessage = "用户名长度不能超过 50 个字符")]
        public string Username { get; set; }

        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "真实姓名不能为空")]
        [StringLength(50, ErrorMessage = "真实姓名长度不能超过 50 个字符")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的电话号码")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在 6 到 100 个字符之间")]
        public string Password { get; set; }
    }

    public class UserAccountUpdateDto
    {
        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(50, ErrorMessage = "昵称长度不能超过 50 个字符")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "真实姓名不能为空")]
        [StringLength(50, ErrorMessage = "真实姓名长度不能超过 50 个字符")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的电话号码")]
        public string Phone { get; set; }
    }

    public class UserAccountTransferDto
    {
        [Required(ErrorMessage = "目标用户电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的目标用户电话号码")]
        public string ToUserPhone { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }
    }

    public class UserAccountUnlinkDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }
    }

    public class UserAccountLinkDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        [StringLength(50, ErrorMessage = "职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        [Required(ErrorMessage = "角色不能为空")]
        [StringLength(50, ErrorMessage = "角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }

    public class EnterpriseLinkDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        [StringLength(50, ErrorMessage = "职位长度不能超过 50 个字符")]
        public string Position { get; set; }

        [Required(ErrorMessage = "角色不能为空")]
        [StringLength(50, ErrorMessage = "角色长度不能超过 50 个字符")]
        public string Role { get; set; }
    }
}