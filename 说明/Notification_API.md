# Notification API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Notification/draft | [FromBody] NotificationCreateDto dto | IActionResult | 创建通知草稿 |
| PUT | /api/admin/Notification/{id}/publish | int id | IActionResult | 发布通知 |
| PUT | /api/admin/Notification/{id} | int id, [FromBody] NotificationUpdateDto dto | IActionResult | 更新通知 |
| DELETE | /api/admin/Notification/{id} | int id | IActionResult | 删除通知 |
| GET | /api/admin/Notification/{id} | int id | IActionResult | 获取通知详情 |
| GET | /api/admin/Notification/drafts | 无 | IActionResult | 获取所有草稿通知 |
| GET | /api/admin/Notification/published | 无 | IActionResult | 获取所有已发布通知 |
| GET | /api/admin/Notification/merchant-types | 无 | IActionResult | 获取可用商户类型 |
| GET | /api/admin/Notification/validate-enterprise | [FromQuery] string name | IActionResult | 验证企业名称 |
