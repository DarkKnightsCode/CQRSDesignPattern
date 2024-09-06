using CQRSDesignPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDesignPattern.Services;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly CfdbContext context;

    public EmployeeRepository(CfdbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Returns list of employee with department details by using joins
    /// </summary>
    /// <returns>List<Employee></Employee></returns>
    public async Task<List<Employee>> getAllEmployeesListAsync()
    {
        var employeeList = (from employee in context.Employees
                            join department in context.Departments
                            on employee.DepartmentId equals department.DepartmentId
                            select new Employee
                            {
                                EmployeeId = employee.EmployeeId,
                                DepartmentId = department.DepartmentId,
                                FirstName = employee.FirstName,
                                LastName = employee.LastName,
                                Gender = employee.Gender,
                                Department = department,
                            }).ToListAsync();
        return await employeeList;
    }

    /// <summary>
    /// returns the employee data fetching by employee id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Employee object</returns>
    public async Task<Employee> getEmployeeByIdAsync(int id)
    {
        var employeeData = await (from employee in context.Employees
                                  join department in context.Departments
                                  on employee.DepartmentId equals department.DepartmentId
                                  where employee.EmployeeId == id
                                  select new Employee
                                  {
                                      EmployeeId = employee.EmployeeId,
                                      DepartmentId = department.DepartmentId,
                                      FirstName = employee.FirstName,
                                      LastName = employee.LastName,
                                      Gender = employee.Gender,
                                      Department = department,
                                  }).FirstOrDefaultAsync();
        if (employeeData == null)
        {
            return null;
        }

        return employeeData;
    }

    /// <summary>
    /// Creates the new entry to the employee table
    /// </summary>
    /// <param name="request"></param>
    /// <returns>employee request</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Employee> AddEmployeeAsync(Employee request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        await context.Employees.AddAsync(request);
        await context.SaveChangesAsync();
        return request;

    }

    /// <summary>
    /// Update the existing employee details
    /// </summary>
    /// <param name="request"></param>
    /// <returns>int</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> UpdateEmployeeAsync(Employee request)
    {
        if (request == null)
        {
            throw new NotImplementedException();
        }

        var resultRequest = context.Employees.FirstOrDefault(x => x.EmployeeId == request.EmployeeId);

        if (resultRequest == null)
        {
            return 0;
        }

        resultRequest.DepartmentId = request.DepartmentId;
        resultRequest.FirstName = request.FirstName;
        resultRequest.LastName = request.LastName;
        resultRequest.Gender = request.Gender;
        resultRequest.DepartmentId = request.DepartmentId;
        return await context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete the employee data from the table
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>int</returns>
    public async Task<int> DeleteEmployeeAsync(int Id)
    {
        var filterData = context.Employees.Find(Id);
        context.Remove(filterData);
        return await context.SaveChangesAsync();
    }
}
