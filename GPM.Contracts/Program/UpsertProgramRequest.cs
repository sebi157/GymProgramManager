namespace GPM.Contracts.Program;

public record UpsertProgramRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Exercises
);