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
    

}

