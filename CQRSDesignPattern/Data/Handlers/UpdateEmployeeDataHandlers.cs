using CQRSDesignPattern.Data.Command;
using CQRSDesignPattern.Services;
using MediatR;

namespace CQRSDesignPattern.Data.Handlers;
public class UpdateEmployeeDataHandlers : IRequestHandler<UpdateEmployeeDataCommand, int>
{
    private readonly IEmployeeRepository repository;

    public UpdateEmployeeDataHandlers(IEmployeeRepository repository)
    {
        this.repository = repository;
    }
    /// <summary>
    /// Handles the put request for update the employee data
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(UpdateEmployeeDataCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.getEmployeeByIdAsync(request.EmployeeId);
        if (employee == null) return default;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Gender = request.Gender;
        employee.DepartmentId = request.DepartmentId;        
        return await repository.UpdateEmployeeAsync(employee);  
    }
}
