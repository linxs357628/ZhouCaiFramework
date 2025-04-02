using Microsoft.Extensions.Logging;
using SqlSugar;
using System.Security.Cryptography;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ISqlSugarClient db, ILogger<EmployeeService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Employee> CreateEmployee(Employee employee, string password)
        {
            try
            {
                // 检查用户名是否已存在
                if (await _db.Queryable<Employee>()
                    .AnyAsync(x => x.Username == employee.Username))
                {
                    throw new Exception("用户名已存在");
                }

                // 密码加密
                var salt = GenerateSalt();
                employee.Password = HashPassword(password, salt);
                employee.Salt = salt;
                employee.CreateTime = DateTime.Now;
                employee.Status = 1; // 默认启用

                return await _db.Insertable(employee).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建员工失败");
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            return await _db.Updateable(employee)
                .IgnoreColumns(x => new { x.Password, x.Salt, x.CreateTime })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DisableEmployee(int employeeId)
        {
            return await _db.Updateable<Employee>()
                .SetColumns(x => x.Status == 0)
                .Where(x => x.Id == employeeId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            return await _db.Deleteable<Employee>()
                .Where(x => x.Id == employeeId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> AssignRole(int employeeId, string role)
        {
            return await _db.Updateable<Employee>()
                .SetColumns(x => x.Role == role)
                .Where(x => x.Id == employeeId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _db.Queryable<Employee>()
                .Where(x => x.Id == employeeId)
                .FirstAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(int pageIndex, int pageSize)
        {
            return await _db.Queryable<Employee>()
                .OrderBy(x => x.CreateTime, OrderByType.Desc)
                .ToPageListAsync(pageIndex, pageSize);
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string keyword)
        {
            return await _db.Queryable<Employee>()
                .Where(x => x.Username.Contains(keyword) || x.Name.Contains(keyword))
                .ToListAsync();
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashBytes = deriveBytes.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}