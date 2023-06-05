using System;
using Microsoft.AspNetCore.Mvc;
using ClimbingApi.Models;
using ClimbingApi.Services;


namespace ClimbingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClimberProfileController: ControllerBase
{

    private readonly ClimberProfileServices _climberProfileServices;

    public ClimberProfileController(ClimberProfileServices climberProfileServices) =>
        _climberProfileServices = climberProfileServices;

    [HttpGet]
    public async Task<List<ClimberProfile>> Get() =>
        await _climberProfileServices.GetAsync();

    [HttpGet("{id}")]
    public async Task<ClimberProfile?> Get(string id) =>
        await _climberProfileServices.GetAsync(id);

    [HttpPut]
    public async Task<IActionResult> Post(ClimberProfile newClimberProfile)
    {
        await _climberProfileServices.CreateAsync(newClimberProfile);

        return CreatedAtAction(nameof(Get), new { id = newClimberProfile.Id });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchNewSessionLogAsync(string id, [FromBody] SessionLog sessionLog)
    {
        await _climberProfileServices.PathNewSessionLogAsync(id, sessionLog);

        return CreatedAtAction(nameof(Get), new { id = Get(id).Id });
    }

    


    

}

