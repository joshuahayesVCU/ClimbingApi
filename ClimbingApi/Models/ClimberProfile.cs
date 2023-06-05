using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ClimbingApi.Models;

public class ClimberProfile
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    public string HomeGym { get; set; } = null!;

    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateOnly? StartDate { get; set; }

    public List<SessionLog>? SesionLog { get; set; }

    public Dictionary<string, string>? RedpointGrades { get; set; }
}

public class SessionLog
{
    [BsonRepresentation(BsonType.DateTime)]
    public DateOnly SessionDate { get; set; } 

    public int StartTime { get; set; }

    public int EndTime { get; set; }

    public List<String>? Sends { get; set; }
}

