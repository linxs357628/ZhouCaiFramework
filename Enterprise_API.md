# Enterprise API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Enterprise | [FromBody] EnterpriseCreateDto dto | IActionResult | 创建新企业 |
| PUT | /api/admin/Enterprise/{id} | int id, [FromBody] EnterpriseUpdateDto dto | IActionResult | 更新企业信息 |
| PUT | /api/admin/Enterprise/{id}/disable | int id | IActionResult | 禁用企业 |
| DELETE | /api/admin/Enterprise/{id} | int id | IActionResult | 删除企业 |
| GET | /api/admin/Enterprise/{id} | int id | IActionResult | 获取企业详情 |
| GET | /api/admin/Enterprise | 无 | IActionResult | 获取所有企业 |
| GET | /api/admin/Enterprise/validate-name | [FromQuery] string name | IActionResult | 验证企业名称 |
| POST | /api/admin/Enterprise/{enterpriseId}/warehouses | int enterpriseId, [FromBody] WarehouseCreateDto dto | IActionResult | 添加仓库 |
| PUT | /api/admin/Enterprise/{enterpriseId}/warehouses/{warehouseId} | int enterpriseId, int warehouseId, [FromBody] WarehouseUpdateDto dto | IActionResult | 更新仓库 |
| DELETE | /api/admin/Enterprise/{enterpriseId}/warehouses/{warehouseId} | int enterpriseId, int warehouseId | IActionResult | 删除仓库 |
| GET | /api/admin/Enterprise/{enterpriseId}/warehouses | int enterpriseId | IActionResult | 获取企业仓库列表 |
