﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Model.Dtos
{
    /// <summary>
    /// 用户账户详情DTO
    /// 包含用户详细信息及关联企业信息
    /// </summary>
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

    /// <summary>
    /// 用户账户简略信息DTO
    /// 包含用户基本信息(不含敏感信息)
    /// </summary>
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

    /// <summary>
    /// 用户账户创建DTO
    /// 包含创建用户所需的完整信息
    /// </summary>
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

    /// <summary>
    /// 用户账户更新DTO
    /// 包含更新用户信息所需的字段
    /// </summary>
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

    /// <summary>
    /// 用户账户转移DTO
    /// 包含将用户权限转移给其他用户所需的信息
    /// </summary>
    public class UserAccountTransferDto
    {
        [Required(ErrorMessage = "目标用户电话号码不能为空")]
        [Phone(ErrorMessage = "请输入有效的目标用户电话号码")]
        public string ToUserPhone { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }
    }

    /// <summary>
    /// 用户账户解绑DTO
    /// 包含解绑用户与企业关联所需的信息
    /// </summary>
    public class UserAccountUnlinkDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "企业 ID 必须为正整数")]
        public int EnterpriseId { get; set; }
    }

    /// <summary>
    /// 用户账户关联DTO
    /// 包含关联用户与企业所需的信息
    /// </summary>
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

    /// <summary>
    /// 企业关联DTO
    /// 包含用户与企业关联的详细信息
    /// </summary>
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
