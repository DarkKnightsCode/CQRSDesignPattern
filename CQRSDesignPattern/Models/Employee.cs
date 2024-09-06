using System.ComponentModel.DataAnnotations;

namespace CQRSDesignPattern.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
