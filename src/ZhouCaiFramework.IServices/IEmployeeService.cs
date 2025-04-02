using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee, string password);

        Task<bool> UpdateEmployee(Employee employee);

        Task<bool> DisableEmployee(int employeeId);

        Task<bool> DeleteEmployee(int employeeId);

        Task<bool> AssignRole(int employeeId, string role);

        Task<Employee> GetEmployee(int employeeId);

        Task<IEnumerable<Employee>> GetEmployees(int pageIndex, int pageSize);

        Task<IEnumerable<Employee>> SearchEmployees(string keyword);
    }
}