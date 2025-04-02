# SystemSettings API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| GET | /api/admin/SystemSettings/employee-accounts | 无 | IActionResult | 获取管理员账号列表 |
| POST | /api/admin/SystemSettings/add-employee | [FromBody] AddEmployeeRequest request | IActionResult | 添加管理员账号 |
