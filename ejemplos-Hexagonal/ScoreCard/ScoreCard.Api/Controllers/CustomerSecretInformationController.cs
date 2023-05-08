using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreCard.Api.Dtos.CustomerRequest;
using ScoreCard.Api.Dtos.CustomerSecretInformationRequest;
using ScoreCard.Application.Commands.CustomerSecretInformationCommand;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Queries.CustomerSecretInformationQueries;
using ScoreCard.Domain.Models;

namespace ScoreCard.Api.Controllers;
[Route("/api/customerSecretInformation")]
[ApiController]
public class CustomerSecretInformationController: ControllerBase
{
    private readonly ILogger<CustomerSecretInformationController> _logger;
    private readonly IMediator _mediator;
    public CustomerSecretInformationController(ILogger<CustomerSecretInformationController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(List<CustomerSecretInformationResponse>))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetAll()
    {
        var request = new ReadCustomersSecretInformationRequest();
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
    [Produces(typeof(CustomerSecretInformationResponse))]
    [ProducesErrorResponseType(typeof(EntityResponse))]
    public async Task<IActionResult> GetById(Guid id)
    {
        var request = new ReadCustomerSecretInformationRequest();
        var query = request.ToApplicationRequest(id);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);
        
        if (response.ClientSecret == "")
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("/api/customerinformationbyid/{customerId}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(CustomerSecretInformationResponse))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetByCustomerId(Guid customerId)
    {
        var request = new ReadCustomerSecretInformationByIdRequest();
        var query = request.ToApplicationRequest(customerId);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);
        if (String.IsNullOrEmpty(response.ClientSecret))
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
    public async Task<IActionResult> Create([FromBody] CreateCustomerSecretInformationRequest request)
    {
        if (request.ClientSecret == "" || request.ApplicationId == "" || request.TenantId == "")
        {
            return BadRequest("No puede enviar valores nulos");
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
    public async Task<IActionResult> Update([FromBody] UpdateCustomerSecretInformationRequest request, Guid id)
    {
        if (request.ClientSecret == "" || request.ApplicationId == "" || request.TenantId == "")
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

    [HttpPut]
    [Route("/api/updatecustomer/{customerId}")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerSecretInformationByCostumerIdRequest request,
        Guid customerId)
    {
        if (request.ClientSecret == "" || request.ApplicationId == "" || request.TenantId == "")
        {
            return BadRequest("No puede enviar valores nulos");
        }
        var command = request.ToApplicationRequest(customerId);
        _logger.LogInformation(        "----- Sending command: {CommandName} {@Command})",nameof(command),command);
        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest(response.EntityErrorResponse);
        }

        return Ok(response);
    }
    

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteCustomerSecretInformationRequest();
        var command = request.ToApplicationRequest(id);    
        _logger.LogInformation(        "----- Sending command: {CommandName} {@Command})",nameof(command),command);    
        var response = await _mediator.Send(command);    
        if (!response.IsSuccess)    {        
            return BadRequest(response.EntityErrorResponse);    
        }    
        return Ok(response.Value);
    }
}