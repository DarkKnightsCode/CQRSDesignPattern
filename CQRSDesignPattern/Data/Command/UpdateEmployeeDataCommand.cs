using CQRSDesignPattern.DTOs.Request;
using CQRSDesignPattern.Models;
using MediatR;

namespace CQRSDesignPattern.Data.Command;
public class UpdateEmployeeDataCommand : IRequest<int>
{
    public UpdateEmployeeDataCommand
        (
            UpdateEmployeeRequestModel request
        )
    {
        EmployeeId = request.EmployeeId;
        FirstName = request.FirstName;
        LastName = request.LastName;
        Gender = request.Gender;
        DepartmentId = request.DepartmentId;
    }

    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public int DepartmentId { get; set; }
}
