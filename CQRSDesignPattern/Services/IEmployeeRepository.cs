using CQRSDesignPattern.Models;

namespace CQRSDesignPattern.Services
{
    public interface IEmployeeRepository
    {
        public Task<Employee> getEmployeeByIdAsync(int Id);
        public Task<List<Employee>> getAllEmployeesListAsync();
        public Task<Employee> AddEmployeeAsync(Employee request);
        public Task<int> UpdateEmployeeAsync(Employee request);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
