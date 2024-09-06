using CQRSDesignPattern.Models;
using MediatR;

namespace CQRSDesignPattern.Data.Query;
public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}
