namespace CQRSDesignPattern.DTOs.Request;
public class UpdateEmployeeRequestModel
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public int DepartmentId { get; set; }
}
