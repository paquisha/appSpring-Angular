using System.Net;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScoreCard.Api.Dtos.CustomerRequest;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Queries.CustomerQueries;
using ScoreCard.Domain.Models;

namespace ScoreCard.Api.Controllers;
[Route("/api/customer")]
[ApiController]
public class CustomerController: ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;
    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(List<CustomerResponse>))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    
    public async Task<IActionResult> GetAll()
    {
        var request = new ReadCustomersRequest();
        var query = request.ToApplicationRequest();
        
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);
        
        var response = await _mediator.Send(query);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof (CustomerResponse))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetById(Guid id)
    {
        //var queryResult = await _mediator.Send(new ReadCustomerQuery(id));
        var request = new ReadCustomerRequest();
        var query = request.ToApplicationRequest(id);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);

        if (response.Name == "")
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        if (request.Name == "")
        {
            return BadRequest("No puede enviar valores nulos");
        }

        if (request.IsActive == false)
        {
            return BadRequest("No puede crear usuarios con estado false");
        }
        
        var command = request.ToApplicationRequest();
        
        _logger.LogInformation("--Sending query {CommandName} {@Command}", nameof(command), command);
        
        var response = await _mediator.Send(command);
        
        return Ok(response);
    }
    
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]              
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request, Guid id)
    {
        if (request.Name == "")
        {
            return BadRequest("No puede enviar valores nulos");
        }
        
        var command = request.ToApplicationRequest(id);
        _logger.LogInformation(        "----- Sending command: {CommandName} {@Command})",nameof(command),command);    
        var response = await _mediator.Send(command);    
        if (!response.IsSuccess){        
            return BadRequest(response.EntityErrorResponse); 
        }
        return Ok(response);
    }
    
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    [Route("{id}")]
    public async Task<IActionResult> Delete(Guid id){    
        //var claim = HttpContext.User.Claims.FirstOrDefault(t => t.Type.Equals("id"));    
        var request = new DeleteCustomerRequest();    
        var command = request.ToApplicationRequest(id);    
        _logger.LogInformation(        "----- Sending command: {CommandName} {@Command})",nameof(command),command);    
        var response = await _mediator.Send(command);    
        if (!response.IsSuccess)    {        
            return BadRequest(response.EntityErrorResponse);    
        }    
        return Ok(response.Value);
    }
}