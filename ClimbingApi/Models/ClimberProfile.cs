using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ClimbingApi.Models;

public class ClimberProfile
{
    [BsonId]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string HomeGym { get; set; } = null!;
    public DateOnly? StartDate { get; set; }
    public SessionLog? SesionLog { get; set; }
    public Dictionary<string, string>? RedpointGrades { get; set; }
}

public class SessionLog
{ 
    public DateOnly SessionDate { get; set; } 
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public List<String>? Sends { get; set; }
}

