using ErrorOr;
using GPM.Models;
using GPM.ServiceErrors;
using GPM.Services.Programs;

public class ProgramService : IProgramService{
    
    private static readonly Dictionary<Guid, GProgram> programs = new();
    public ErrorOr<Created> CreateProgram(GProgram prog){
        programs.Add(prog.Id,prog);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteProgram(Guid id)
    {
        programs.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<GProgram> GetProgram(Guid id){
        if(programs.TryGetValue(id, out var program)){
            return program;
        }
        return Errors.GProgram.NotFound;
    }

    public ErrorOr<UpsertedProgram> UpsertProgram(GProgram gprogram)
    {
        var isNewlyCreated = !programs.ContainsKey(gprogram.Id);
        programs[gprogram.Id] = gprogram;
        return new UpsertedProgram(isNewlyCreated);
    }
}