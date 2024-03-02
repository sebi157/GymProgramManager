namespace GPM.Contracts.Program;

public record CreateProgramRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Exercises
);