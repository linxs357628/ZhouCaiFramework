# Project API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/Project/{id} | int id | IActionResult | 获取项目详情 |
| GET | /api/admin/Project | [FromQuery] ProjectQuery query | IActionResult | 获取项目列表 |
| POST | /api/admin/Project | [FromBody] ProjectCreateDto dto | IActionResult | 创建项目 |
| PUT | /api/admin/Project/{id} | int id, [FromBody] ProjectUpdateDto dto | IActionResult | 更新项目信息 |
| DELETE | /api/admin/Project/{id} | int id | IActionResult | 删除项目 |
| POST | /api/admin/Project/{projectId}/entry | int projectId, [FromBody] ProjectOperationDto dto | IActionResult | 添加入场记录 |
| POST | /api/admin/Project/{projectId}/withdrawal | int projectId, [FromBody] ProjectOperationDto dto | IActionResult | 添加退场记录 |
| POST | /api/admin/Project/{projectId}/inventory | int projectId, [FromBody] ProjectOperationDto dto | IActionResult | 添加盘点记录 |
| POST | /api/admin/Project/{projectId}/suspension | int projectId, [FromBody] ProjectOperationDto dto | IActionResult | 添加暂停记录 |
| PUT | /api/admin/Project/{projectId}/progress | int projectId, [FromBody] string quantity | IActionResult | 更新进度数量 |
| PUT | /api/admin/Project/{projectId}/payment | int projectId, [FromBody] PaymentUpdateDto dto | IActionResult | 更新支付状态 |
