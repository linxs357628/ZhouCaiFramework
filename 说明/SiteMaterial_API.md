# SiteMaterial API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/SiteMaterial | [FromQuery] SiteMaterialQuery query | IActionResult | 获取现场材料列表 |
| GET | /api/admin/SiteMaterial/project | [FromQuery] ProjectMaterialQuery query | IActionResult | 获取项目材料列表 |
| GET | /api/admin/SiteMaterial/{materialCode}/history | string materialCode | IActionResult | 获取材料历史记录 |
| PUT | /api/admin/SiteMaterial/{id} | int id, [FromBody] SiteMaterialUpdateDto dto | IActionResult | 更新材料信息 |
| DELETE | /api/admin/SiteMaterial/{id} | int id | IActionResult | 删除材料记录 |
