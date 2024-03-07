namespace GPM.Contracts.Program;

public record UpsertProgramRequest(
    string Name,
    string Description,
    DateOnly W_Date,
    List<string> Exercises
);