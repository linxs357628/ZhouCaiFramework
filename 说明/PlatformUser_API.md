# PlatformUser API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/PlatformUser/register | [FromBody] PlatformUserRegisterDto dto | IActionResult | 注册平台用户 |
| PUT | /api/admin/PlatformUser/{id} | int id, [FromBody] PlatformUserUpdateDto dto | IActionResult | 更新用户信息 |
| PUT | /api/admin/PlatformUser/{id}/disable | int id | IActionResult | 禁用用户账号 |
| PUT | /api/admin/PlatformUser/{id}/enable | int id | IActionResult | 启用用户账号 |
| PUT | /api/admin/PlatformUser/{id}/bind-wechat | int id, [FromBody] WechatBindDto dto | IActionResult | 绑定微信账号 |
| GET | /api/admin/PlatformUser/{id} | int id | IActionResult | 获取用户详情 |
| GET | /api/admin/PlatformUser/enterprise/{enterpriseId} | int enterpriseId | IActionResult | 获取企业下的用户 |
| GET | /api/admin/PlatformUser/search | [FromQuery] string keyword | IActionResult | 搜索用户 |
| GET | /api/admin/PlatformUser/{id}/operation-logs | int id | IActionResult | 获取用户操作日志 |
| GET | /api/admin/PlatformUser/{id}/enterprise-histories | int id | IActionResult | 获取用户企业变更历史 |
