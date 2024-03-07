using ErrorOr;
using GPM.Contracts.Program;
using GPM.Models;
using GPM.ServiceErrors;
using GPM.Services.Programs;
using Microsoft.AspNetCore.Mvc;

namespace GPM.Controllers;

public class ProgramsController : ApiController
{
    private readonly IProgramService _programService;

    public ProgramsController(IProgramService programService)
    {
        _programService = programService;
    }

    [HttpPost]
    public IActionResult CreateProgram(CreateProgramRequest request)
    {
        ErrorOr<GProgram> requestToProgramResult = GProgram.Create(
            request.Name,
            request.Description,
            request.W_Date,
            request.Exercises
        );
        if(requestToProgramResult.IsError)
        {
            return Problem(requestToProgramResult.Errors);
        }
        var gprogram = requestToProgramResult.Value;
        ErrorOr<Created> createProgramResult = _programService.CreateProgram(gprogram);
        return createProgramResult.Match(
            created => CreatedAtGetProgram(gprogram),
            errors => Problem(errors)
        );
    }


    [HttpGet("{id:guid}")]
    public IActionResult GetProgram(Guid id)
    {
        ErrorOr<GProgram> getProgResult = _programService.GetProgram(id);
        return getProgResult.Match(
            program => Ok(MapProgramResponse(program)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public IActionResult GetAllPrograms()
    {
        ErrorOr<List<GProgram>> getProgResult = _programService.GetAllPrograms();
        return getProgResult.Match(
            programs=> Ok(programs.Select(p => MapProgramResponse(p)).ToList()),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertProgram(Guid id, UpsertProgramRequest request){
        ErrorOr<GProgram> requestToProgramResult = GProgram.Create(
            request.Name,
            request.Description,
            request.W_Date,
            request.Exercises,
            id
        );
        if(requestToProgramResult.IsError)
        {
            return Problem(requestToProgramResult.Errors);
        }
        var gprogram = requestToProgramResult.Value;
        ErrorOr<UpsertedProgram> upsertedResult = _programService.UpsertProgram(gprogram);
        //201 daca a fost creat program nou
        return upsertedResult.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetProgram(gprogram) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteProgram(Guid id){
        ErrorOr<Deleted> deletedResult = _programService.DeleteProgram(id);
        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
   
    private static ProgramResponse MapProgramResponse(GProgram prog)
    {
        return new ProgramResponse(
                    prog.Id,
                    prog.Name,
                    prog.Description,
                    prog.W_Date,
                    prog.Exercises
                );
    }

    private IActionResult CreatedAtGetProgram(GProgram gprogram)
    {
        return CreatedAtAction(
                    actionName: nameof(GetProgram),
                    routeValues: new { id = gprogram.Id },
                    value: MapProgramResponse(gprogram)
                );
    }
}