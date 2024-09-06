using System.ComponentModel.DataAnnotations;

namespace CQRSDesignPattern.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentCode { get; set; } = null!;

    public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
}
