using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly AppDBContext context;

    public ActivitiesController(AppDBContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity?>> GetActivities(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        return activity == null ? NotFound() : Ok(activity);
    }
}
