using ErrorOr;
using GPM.Contracts.Program;
using GPM.Models;
using GPM.Services.Programs;

public interface IProgramService{
    ErrorOr<Created> CreateProgram(GProgram request);
    ErrorOr<Deleted> DeleteProgram(Guid id);
    ErrorOr<GProgram> GetProgram(Guid id);
    ErrorOr<List<GProgram>> GetAllPrograms();
    ErrorOr<UpsertedProgram> UpsertProgram(GProgram gprogram);
}