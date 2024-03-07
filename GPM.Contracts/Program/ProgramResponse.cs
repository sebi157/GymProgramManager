namespace GPM.Contracts.Program;

public record ProgramResponse(
    Guid Id,
    string Name,
    string Description,
    DateOnly W_Date,
    List<string> Exercises
);