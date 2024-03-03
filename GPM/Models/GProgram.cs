using System.ComponentModel;
using ErrorOr;
using GPM.ServiceErrors;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GPM.Models;

public class GProgram{
    
    public const int minNameLen = 3;
    public const int maxNameLen = 100;
    public const int minDescLen = 10;
    public const int maxDescLen = 300;
    
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get;}
    
    [BsonElement("name")]
    public string Name { get;}
    
    [BsonElement("description")]
    public string Description { get;}
    
    [BsonElement("startDateTime")]
    public DateTime StartDateTime { get;}
    
    [BsonElement("endDateTime")]
    public DateTime EndDateTime { get;}
    
    [BsonElement("lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get;}
    
    [BsonElement("exercises")]
    public List<string> Exercises { get;}
    
    private GProgram(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> exercises)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Exercises = exercises;
    }

    public static ErrorOr<GProgram> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> exercises,
        Guid? id = null
    ){
        List<Error> errors = new();
        if(name.Length is < minNameLen or > maxNameLen){
            errors.Add(Errors.GProgram.InvalidName);
        }
        if(description.Length is < minDescLen or > maxDescLen){
            errors.Add(Errors.GProgram.InvalidDesc);
        }
        if(errors.Count>0) return errors;
        return new GProgram(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            exercises
        );
    }
}