# PaymentFlow API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/PaymentFlow | [FromBody] PaymentCreateDto dto | ActionResult<PaymentFlow> | 创建支付流水 |
| GET | /api/admin/PaymentFlow/{id} | [Range(1, int.MaxValue)] int id | ActionResult<PaymentFlow> | 获取流水详情 |
| GET | /api/admin/PaymentFlow/query | [FromQuery] PaymentQuery query | ActionResult<PaginatedList<PaymentFlow>> | 查询支付流水 |
