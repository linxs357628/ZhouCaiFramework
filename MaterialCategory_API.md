# MaterialCategory API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/MaterialCategory | [FromQuery] MaterialCategoryQueryDto query | IActionResult | 获取材料分类列表 |
| GET | /api/admin/MaterialCategory/{id} | int id | IActionResult | 获取分类详情 |
| GET | /api/admin/MaterialCategory/parents | 无 | IActionResult | 获取父级分类 |
| POST | /api/admin/MaterialCategory | [FromBody] MaterialCategoryDto dto | IActionResult | 创建材料分类 |
| PUT | /api/admin/MaterialCategory/{id} | int id, [FromBody] MaterialCategoryDto dto | IActionResult | 更新分类信息 |
| PATCH | /api/admin/MaterialCategory/{id}/toggle-visibility | int id | IActionResult | 切换分类可见性 |
| DELETE | /api/admin/MaterialCategory/{id} | int id | IActionResult | 删除分类 |
