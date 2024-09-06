using CQRSDesignPattern.Data.Query;
using CQRSDesignPattern.Models;
using CQRSDesignPattern.Services;
using MediatR;

namespace CQRSDesignPattern.Data.Handlers;
public class GetEmployeeListHandlers : IRequestHandler<GetEmployeeListQuery, List<Employee>>
{
    private readonly IEmployeeRepository repository;

    public GetEmployeeListHandlers(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Handles the get request for getting the employee list
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        return await repository.getAllEmployeesListAsync();
    }
}
