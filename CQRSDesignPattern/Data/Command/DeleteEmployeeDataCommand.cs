using MediatR;

namespace CQRSDesignPattern.Data.Command;
public class DeleteEmployeeDataCommand : IRequest<int>
{   
    public int EmployeeId { get; set; } 
}
