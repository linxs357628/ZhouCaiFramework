# ManualPayment API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/ManualPayment | [FromBody] CreateManualPaymentRecordDto dto | IActionResult | 创建手动支付记录 |
| PUT | /api/admin/ManualPayment/{id} | int id, [FromBody] UpdateManualPaymentRecordDto dto | IActionResult | 更新支付记录 |
| DELETE | /api/admin/ManualPayment/{id} | int id | IActionResult | 删除支付记录 |
| GET | /api/admin/ManualPayment/{id} | int id | IActionResult | 获取支付记录详情 |
| GET | /api/admin/ManualPayment/project/{projectId} | int projectId | IActionResult | 获取项目支付记录 |
