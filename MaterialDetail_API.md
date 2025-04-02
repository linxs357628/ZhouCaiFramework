# MaterialDetail API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/MaterialDetail | int materialId, [FromQuery] string keyword, [FromQuery] List<string> categories, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] List<string> statuses, [FromQuery] int? minDays, [FromQuery] int? maxDays, [FromQuery] int page = 1, [FromQuery] int pageSize = 20 | IActionResult | 获取材料详情列表 |
| GET | /api/admin/MaterialDetail/{materialCode}/history | string materialCode | IActionResult | 获取材料历史记录 |
