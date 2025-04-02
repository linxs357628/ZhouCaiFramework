# Tag API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Tag | [FromBody] TagCreateDto dto | IActionResult | 创建标签 |
| PUT | /api/admin/Tag/{id} | int id, [FromBody] TagUpdateDto dto | IActionResult | 更新标签 |
| DELETE | /api/admin/Tag/{id} | int id, [FromQuery] bool confirm | IActionResult | 删除标签 |
| PUT | /api/admin/Tag/{id}/disable | int id | IActionResult | 禁用标签 |
| PUT | /api/admin/Tag/{id}/visibility | int id, [FromBody] TagVisibilityDto dto | IActionResult | 设置标签可见性 |
| GET | /api/admin/Tag/{id} | int id | IActionResult | 获取标签详情 |
| GET | /api/admin/Tag | 无 | IActionResult | 获取所有标签 |
| GET | /api/admin/Tag/visible | 无 | IActionResult | 获取可见标签 |
