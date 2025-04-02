# Payment API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Payment | [FromBody] PaymentCreateDto dto | IActionResult | 添加支付记录 |
| GET | /api/admin/Payment | [FromQuery] PaymentQuery query | IActionResult | 获取支付记录列表 |
| GET | /api/admin/Payment/export | [FromQuery] PaymentQuery query | FileResult | 导出支付记录 |
| POST | /api/admin/Payment/{paymentId}/invoice | int paymentId, [FromBody] InvoiceLinkDto dto | IActionResult | 关联发票到支付记录 |
