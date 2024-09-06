using CQRSDesignPattern.Data.Command;
using CQRSDesignPattern.Data.Handlers;
using CQRSDesignPattern.Data.Query;
using CQRSDesignPattern.DTOs.Request;
using CQRSDesignPattern.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDesignPattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator mediator;

    public EmployeeController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    /// <summary>
    /// Get endpoint for getting all the list of Employee list
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<Employee>> EmployeeList()
    {
        var employeeList = await mediator.Send(new GetEmployeeListQuery());
        return employeeList;
    }


    /// <summary>
    /// Get endpoint for fetching the employee by their employee Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        var result = await mediator.Send(new GetEmployeeByIdQuery() { Id = id });
        return Ok(result);
    }

    /// <summary>
    /// Post endpoint to create new record for employee
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateNewEmployee(CreateEmployeeRequestModel request)
    {
        if (request == null)
        {
            return BadRequest();
        }

        var result = await mediator.Send(new AddEmployeeDataCommand
            (
                request
            )
        );

        return Ok(result);
    }

    /// <summary>
    /// Put endpoint to update the existing record
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateEmployeeDetails(UpdateEmployeeRequestModel request) 
    {
        if (request == null)
        {
            return BadRequest("All fields are required");
        }

        var result = await mediator.Send(new UpdateEmployeeDataCommand(request));

        return Ok(result);
    }

    /// <summary>
    /// Delete endpoint for delete the existing record  
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteEmployeeData(int Id) 
    {
        if (Id == 0) 
        {
            return BadRequest();
        }

        var result = await mediator.Send(new DeleteEmployeeDataCommand() { EmployeeId = Id });
        return Ok(result);
    }
}
