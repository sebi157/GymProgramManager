namespace GPM.Contracts.Program;

public record ProgramResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedTime,
    List<string> Exercises
);