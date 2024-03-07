using ErrorOr;
using GPM.Models;
using GPM.ServiceErrors;
using GPM.Services.Programs;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

public class ProgramService : IProgramService{
    
    private readonly IMongoCollection<GProgram> programs;
    
    public ProgramService(IOptions<GPM.MongoDBSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.Connection_String);
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.Database_Name);
        programs = mongoDatabase.GetCollection<GProgram>(settings.Value.Collection_Name);
    }
    public ErrorOr<Created> CreateProgram(GProgram prog){
        programs.InsertOne(prog);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteProgram(Guid id)
    {
        programs.DeleteOne(program => program.Id == id);
        return Result.Deleted;
    }

    public ErrorOr<GProgram> GetProgram(Guid id){
        var program = programs.Find(program => program.Id == id).FirstOrDefault();
        //Console.WriteLine(program.Description);
        if (program == null)
        {
            return Errors.GProgram.NotFound;
        }
        return program;
    }

    public ErrorOr<List<GProgram>> GetAllPrograms(){
        var programs_got = programs.Find(_ => true).ToList();
        //Console.WriteLine(programs_got[0].Name);
        if (programs_got == null)
        {
            return Errors.GProgram.NotFound;
        }
        return programs_got;
    }

    public ErrorOr<UpsertedProgram> UpsertProgram(GProgram gprogram)
    {
        var result = programs.ReplaceOne(
            program => program.Id == gprogram.Id,
            gprogram,
            new ReplaceOptions { IsUpsert = true });
        
        var isNewlyCreated = result.UpsertedId != null;
        return new UpsertedProgram(isNewlyCreated);
    }
}