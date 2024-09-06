using CQRSDesignPattern.Data.Query;
using CQRSDesignPattern.Models;
using CQRSDesignPattern.Services;
using MediatR;

namespace CQRSDesignPattern.Data.Handlers;
public class GetEmployeeByIdHandlers : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IEmployeeRepository repository;

    public GetEmployeeByIdHandlers(IEmployeeRepository repository)
    {
        this.repository = repository;
    }
    /// <summary>
    /// Handles the get request for fetching employee by their employee Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.getEmployeeByIdAsync(request.Id);
    }
}
