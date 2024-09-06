using CQRSDesignPattern.Data.Command;
using CQRSDesignPattern.Models;
using CQRSDesignPattern.Services;
using MediatR;

namespace CQRSDesignPattern.Data.Handlers;
public class AddEmployeeDataHandlers : IRequestHandler<AddEmployeeDataCommand, Employee>
{
    private readonly IEmployeeRepository repository;

    public AddEmployeeDataHandlers(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Handles the add employee request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Employee> Handle(AddEmployeeDataCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Gender = request.Gender,
            DepartmentId = request.DepartmentId,
        };
        return await repository.AddEmployeeAsync(employee);
    }
}
