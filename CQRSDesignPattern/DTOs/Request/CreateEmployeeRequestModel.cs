namespace CQRSDesignPattern.DTOs.Request;
public class CreateEmployeeRequestModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int DepartmentId { get; set; }
}
