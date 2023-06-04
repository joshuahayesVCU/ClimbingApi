using System;
using ClimbingApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace ClimbingApi.Services;

public class ClimberProfileServices
{

	private readonly IMongoCollection<ClimberProfile> _climberProfileCollection;

	public ClimberProfileServices(IOptions<ClimbingDatabaseSettings> climbingDatabaseSettings)
	{
		var mongoClient = new MongoClient(
			climbingDatabaseSettings.Value.DatabaseConnectionString);

		var mongoDatabse = mongoClient.GetDatabase(
			climbingDatabaseSettings.Value.DatabaseName);

		_climberProfileCollection = mongoDatabse.GetCollection<ClimberProfile>(
			climbingDatabaseSettings.Value.CollectionName);
	}

	public async Task<List<ClimberProfile>> GetAsync() =>
		await _climberProfileCollection.Find(_ => true).ToListAsync();
}

