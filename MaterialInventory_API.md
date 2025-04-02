# MaterialInventory API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/MaterialInventory | [FromQuery] string keyword, [FromQuery] List<string> orderTypes, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] string paymentStatus, [FromQuery] int page = 1, [FromQuery] int pageSize = 20 | IActionResult | 获取材料库存列表 |
