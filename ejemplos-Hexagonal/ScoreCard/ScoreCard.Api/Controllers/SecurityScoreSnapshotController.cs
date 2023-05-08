using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScoreCard.Api.Dtos.SecurityScoreSnapshotRequest;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;
using ScoreCard.Domain.Models;

namespace ScoreCard.Api.Controllers;
[Route("/api/securityscoresnapshot")]
[ApiController]
public class SecurityScoreSnapshotController : ControllerBase
{
    private readonly ILogger<SecurityScoreSnapshotController> _logger;
    private readonly IMediator _mediator;

    public SecurityScoreSnapshotController(ILogger<SecurityScoreSnapshotController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [Produces(typeof(List<SecurityScoreSnapshotResponse>))]
    [ProducesErrorResponseType(typeof(EntityErrorResponse))]
    public async Task<IActionResult> GetAll()
    {
        var request = new ReadSecurityScoreSnapshotsRequest();
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
        var request = new ReadSecurityScoreSnapshotRequest();
        var query = request.ToApplicationRequest(id);
        _logger.LogInformation("--Sending query {QueryName} {@Query}", nameof(query), query);

        var response = await _mediator.Send(query);
        
        return Ok(response);
    }
}