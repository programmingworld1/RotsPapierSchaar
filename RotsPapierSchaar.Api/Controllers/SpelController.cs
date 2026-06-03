using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using RotsPapierSchaar.Application.ApplicationServices;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Application.ResultPattern;
using RotsPapierSchaar.Api.Middlewares;
using RotsPapierSchaar.Contracts.Requests;
using RotsPapierSchaar.Contracts.Responses;

namespace RotsPapierSchaar.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SpelController : ControllerBase
{
    private readonly ISpelService _spelService;
    private readonly IValidator<StartSpelRequest> _startSpelValidator;
    private readonly IValidator<SpeelRondeRequest> _speelRondeValidator;
    private readonly BusinessProblemDetailsFactory _problemDetailsFactory;

    public SpelController(
        ISpelService spelService,
        IValidator<StartSpelRequest> startSpelValidator,
        IValidator<SpeelRondeRequest> speelRondeValidator,
        BusinessProblemDetailsFactory problemDetailsFactory)
    {
        _spelService = spelService;
        _startSpelValidator = startSpelValidator;
        _speelRondeValidator = speelRondeValidator;
        _problemDetailsFactory = problemDetailsFactory;
    }

    /// <summary>
    /// Start een nieuw spel met het opgegeven aantal rondes.
    /// </summary>
    [HttpPost("start")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> StartSpel([FromBody] StartSpelRequest startSpelRequest)
    {
        await _startSpelValidator.ValidateAndThrowAsync(startSpelRequest);

        var startSpelDto = startSpelRequest.Adapt<StartSpelDto>();
        var result = _spelService.StartNieuwSpel(startSpelDto);

        if (!result.IsSuccess)
        {
            return new ObjectResult(_problemDetailsFactory.Create(HttpContext, result.Error!));
        }

        return Ok(new { bericht = $"Spel gestart! Je speelt {startSpelDto.AantalRondes} ronde(s)." });
    }

    /// <summary>
    /// Speel een ronde. SpelerZet: "Rots", "Papier" of "Schaar".
    /// </summary>
    [HttpPost("ronde")]
    [ProducesResponseType(typeof(RondeResultaatResponse), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<RondeResultaatResponse>> SpeelRonde([FromBody] SpeelRondeRequest speelRondeRequest)
    {
        await _speelRondeValidator.ValidateAndThrowAsync(speelRondeRequest);

        if (_spelService.IsSpelKlaar())
        {
            return BadRequest(new { fout = "Het spel is al klaar. Bekijk de samenvatting of start een nieuw spel." });
        }

        var speelRondeDto = speelRondeRequest.Adapt<SpeelRondeDto>();
        var result = _spelService.SpeelRonde(speelRondeDto);

        if (!result.IsSuccess)
        {
            return new ObjectResult(_problemDetailsFactory.Create(HttpContext, result.Error!));
        }

        return Ok(result.Value!.Adapt<RondeResultaatResponse>());
    }

    /// <summary>
    /// Haal de samenvatting op van het huidige of laatste spel.
    /// </summary>
    [HttpGet("samenvatting")]
    [ProducesResponseType(typeof(SpelSamenvattingResponse), 200)]
    public ActionResult<SpelSamenvattingResponse> HaalSamenvattingOp()
    {
        return Ok(_spelService.HaalSamenvattingOp().Adapt<SpelSamenvattingResponse>());
    }
}
