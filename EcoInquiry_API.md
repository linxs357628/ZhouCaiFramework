# EcoInquiry API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/EcoInquiry | [FromQuery] EcoInquiryQueryDto query | IActionResult | 获取环保询价列表 |
| GET | /api/admin/EcoInquiry/{id} | int id | IActionResult | 获取询价详情 |
| GET | /api/admin/EcoInquiry/{inquiryId}/distributions | int inquiryId | IActionResult | 获取分配记录 |
