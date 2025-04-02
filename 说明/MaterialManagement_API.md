# MaterialManagement API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/MaterialManagement | [FromQuery] MaterialQueryDto query | IActionResult | 获取周转材料列表 |
| GET | /api/admin/MaterialManagement/{id} | int id | IActionResult | 获取材料详情 |
| GET | /api/admin/MaterialManagement/stats | [FromQuery] MaterialQueryDto query | IActionResult | 获取材料统计信息 |
| GET | /api/admin/MaterialManagement/export | [FromQuery] MaterialQueryDto query | FileResult | 导出材料数据 |
| GET | /api/admin/MaterialManagement/categories | 无 | IActionResult | 获取有材料的分类列表(用于动态生成tab) |
| GET | /api/admin/MaterialManagement/categories/{category}/subcategories | string category | IActionResult | 获取指定分类下的活跃二级分类 |
| GET | /api/admin/MaterialManagement/{materialId}/history | int materialId | IActionResult | 获取材料操作历史 |
| GET | /api/admin/MaterialManagement/{materialId}/images | int materialId | IActionResult | 获取材料图片列表 |
| POST | /api/admin/MaterialManagement/{materialId}/images | int materialId, IFormFile file, [FromForm] string description | IActionResult | 上传材料图片 |
| DELETE | /api/admin/MaterialManagement/images/{imageId} | int imageId | IActionResult | 删除材料图片 |
| PUT | /api/admin/MaterialManagement/images/{imageId} | int imageId, [FromBody] UpdateImageDto dto | IActionResult | 更新图片信息 |
