using System;
using ClimbingApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;


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

	public async Task<ClimberProfile?> GetAsync(string id) =>
		await _climberProfileCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

	public async Task CreateAsync(ClimberProfile newClimberProfile) =>
		await _climberProfileCollection.InsertOneAsync(newClimberProfile);

	// Insert new session log => append a new session log object to the existing list
	public async Task PathNewSessionLogAsync(string id, SessionLog newSessionLog) 
    {
		// Locating the document 
		var filter = Builders<ClimberProfile>.Filter.Eq(x => x.Id, id);

		var updateDefinition = Builders<ClimberProfile>.Update.Push("SessionLog", newSessionLog);

		//UpdateResult result = await _climberProfileCollection.UpdateOneAsync(filter, updateDefinition);
		await _climberProfileCollection.UpdateOneAsync(filter, updateDefinition);
    }

	public async Task UpdateAsync(string id, ClimberProfile updatedClimberProfile) =>
		await _climberProfileCollection.ReplaceOneAsync(x => x.Id == id, updatedClimberProfile);


	public async Task removeAsync(string id) =>
		await _climberProfileCollection.DeleteOneAsync(x => x.Id == id);
}

