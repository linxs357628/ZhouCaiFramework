# UserAccount API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/UserAccount/{id} | int id | IActionResult | 获取用户账号详情 |
| GET | /api/admin/UserAccount/enterprise/{enterpriseId} | int enterpriseId | IActionResult | 获取企业关联用户 |
| POST | /api/admin/UserAccount | [FromBody] UserAccountCreateDto dto | IActionResult | 创建用户账号 |
| PUT | /api/admin/UserAccount/{id} | int id, [FromBody] UserAccountUpdateDto dto | IActionResult | 更新用户信息 |
| PUT | /api/admin/UserAccount/{id}/disable | int id | IActionResult | 禁用用户账号 |
| PUT | /api/admin/UserAccount/{id}/transfer | int id, [FromBody] UserAccountTransferDto dto | IActionResult | 转让账号权限 |
| PUT | /api/admin/UserAccount/{id}/unlink | int id, [FromBody] UserAccountUnlinkDto dto | IActionResult | 解除企业关联 |
| PUT | /api/admin/UserAccount/{id}/link | int id, [FromBody] UserAccountLinkDto dto | IActionResult | 关联企业账号 |
| GET | /api/admin/UserAccount/{id}/logs | int id | IActionResult | 获取用户操作日志 |
