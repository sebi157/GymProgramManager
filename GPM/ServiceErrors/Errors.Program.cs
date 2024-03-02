using ErrorOr;

namespace GPM.ServiceErrors;

public static class Errors{
    public static class GProgram{
        public static Error NotFound => Error.NotFound(
            code: "Program.NotFound",
            description: "Program not found"
        );
        public static Error InvalidName => Error.Validation(
            code: "Program.InvalidName",
            description: "Program name must be between 3 and 100 characters"
        );
        public static Error InvalidDesc => Error.Validation(
            code: "Program.InvalidDescription",
            description: "Program description must be between 10 and 300 characters"
        );
    }
}