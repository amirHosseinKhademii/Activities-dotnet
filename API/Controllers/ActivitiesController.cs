using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            // var activity = await _context.Activities.FindAsync(id);
            // if (activity == null)
            // {
            //     return NotFound();
            // }
            // return activity;
            return Ok();
        }
    }
}