using CQRSDesignPattern.Data.Command;
using CQRSDesignPattern.Services;
using MediatR;

namespace CQRSDesignPattern.Data.Handlers;
public class DeleteEmployeeDataHandlers : IRequestHandler<DeleteEmployeeDataCommand, int>
{
    private readonly IEmployeeRepository repository;

    public DeleteEmployeeDataHandlers(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Handles the delete request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(DeleteEmployeeDataCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.getEmployeeByIdAsync(request.EmployeeId);
        if (employee == null) return default;
        return await repository.DeleteEmployeeAsync(request.EmployeeId);
    }
}
