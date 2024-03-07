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
    public Guid Id { get; set;}
    
    [BsonElement("name")]
    public string Name { get; set;}
    
    [BsonElement("description")]
    public string Description { get; set;}
    
    [BsonElement("w_date")]
    public DateOnly W_Date { get; set;}

    [BsonElement("exercises")]
    public List<string> Exercises { get; set;}
    
    private GProgram(
        Guid id,
        string name,
        string description,
        DateOnly w_date,
        List<string> exercises)
    {
        Id = id;
        Name = name;
        Description = description;
        W_Date = w_date;
        Exercises = exercises;
    }

    public static ErrorOr<GProgram> Create(
        string name,
        string description,
        DateOnly w_date,
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
            w_date,
            exercises
        );
    }
}