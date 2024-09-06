using CQRSDesignPattern.Models;
using MediatR;

namespace CQRSDesignPattern.Data.Query;
public class GetEmployeeListQuery : IRequest<List<Employee>>{}
