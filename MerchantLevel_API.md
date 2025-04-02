# MerchantLevel API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/MerchantLevel | [FromBody] MerchantLevelCreateDto dto | IActionResult | 创建商户等级 |
| PUT | /api/admin/MerchantLevel/{id} | int id, [FromBody] MerchantLevelUpdateDto dto | IActionResult | 更新商户等级 |
| PUT | /api/admin/MerchantLevel/{id}/disable | int id | IActionResult | 禁用商户等级 |
| DELETE | /api/admin/MerchantLevel/{id} | int id | IActionResult | 删除商户等级 |
| GET | /api/admin/MerchantLevel/{id} | int id | IActionResult | 获取商户等级详情 |
| GET | /api/admin/MerchantLevel | 无 | IActionResult | 获取所有商户等级 |
| GET | /api/admin/MerchantLevel/by-enterprise-type/{enterpriseType} | string enterpriseType | IActionResult | 按企业类型获取商户等级 |
