using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScoreCard.Api.Dtos.CustomerSecretInformationRequest;
using ScoreCard.Api.Dtos.SubscriptionRequest;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Api.Controllers;
[Route("/api/subscription")]
[ApiController]
public class SubscriptionController: ControllerBase
{
    private readonly ILogger<SubscriptionController> _logger;
    private readonly IMediator _mediator;
    public SubscriptionController(ILogger<SubscriptionController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(List<SubscriptionResponse>))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetAll()
    {
        var request = new ReadSubscriptionsRequest();

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
    [Produces(typeof (SubscriptionResponse))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetById(Guid id)
    {
        //var queryResult = await _mediator.Send(new ReadCustomerQuery(id));
        var request = new ReadSubscriptionRequest();
        var query = request.ToApplicationRequest(id);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);

        if (response.Name == "")
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet]
    [Route("/api/subscription/CustomerId/{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(SubscriptionResponse))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetByCustomerId(Guid id)
    {
        var request = new ReadSubscriptionsByCustomerRequest();
        var query = request.ToApplicationRequest(id);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
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
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionRequest request)
    {
        if (request.SubscriptionId == "" || request.Name == "")
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
    public async Task<IActionResult> Update([FromBody] UpdateSubscriptionRequest request, Guid id)
    {
        if (request.SubscriptionId == "" || request.Name == "")
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
        var request = new DeleteSubscriptionRequest();    
        var command = request.ToApplicationRequest(id);    
        _logger.LogInformation(        "----- Sending command: {CommandName} {@Command})",nameof(command),command);    
        var response = await _mediator.Send(command);    
        if (!response.IsSuccess)    {        
            return BadRequest(response.EntityErrorResponse);    
        }    
        return Ok(response.Value);
    }
}