# Employee API 文档

| HTTP方法 | 路由 | 参数 | 返回值 | 描述 |
|---------|------|------|--------|------|
| POST | /api/admin/Employee | [FromBody] EmployeeCreateDto dto | IActionResult | 创建新员工 |
| PUT | /api/admin/Employee/{id} | int id, [FromBody] EmployeeUpdateDto dto | IActionResult | 更新员工信息 |
| PUT | /api/admin/Employee/{id}/disable | int id | IActionResult | 禁用员工账号 |
| DELETE | /api/admin/Employee/{id} | int id | IActionResult | 删除员工 |
| PUT | /api/admin/Employee/{id}/role | int id, [FromBody] RoleAssignDto dto | IActionResult | 分配员工角色 |
| GET | /api/admin/Employee/{id} | int id | IActionResult | 获取员工详情 |
| GET | /api/admin/Employee | [FromQuery] int page = 1, [FromQuery] int size = 10 | IActionResult | 获取员工列表 |
| GET | /api/admin/Employee/search | [FromQuery] string keyword | IActionResult | 搜索员工 |
