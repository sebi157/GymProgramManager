namespace GPM.Contracts.Program;

public record CreateProgramRequest(
    string Name,
    string Description,
    DateOnly W_Date,
    List<string> Exercises
);