# Login API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Login | [FromBody] LoginRequest request | IActionResult | 管理员登录 |
| POST | /api/admin/Login/refresh | string token | IActionResult | 刷新访问令牌 |
| POST | /api/admin/Login/revoke | string token | IActionResult | 注销刷新令牌 |
| GET | /api/admin/Login/InitDatabase | 无 | IActionResult | 初始化数据库 |
