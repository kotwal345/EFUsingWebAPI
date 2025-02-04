using IPL.Service;
using IPLDataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamService teamService;
        public TeamController(ITeamService _teamService)
        {
            teamService = _teamService;
        }


        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeam(Team teamRequest)
        {
            if (teamRequest == null)
            {
                return BadRequest("Invalid Argument");
            }

            try
            {

                var response = await teamService.CreatedTeamAsync(teamRequest);

                return CreatedAtAction(nameof(AddTeam), "", response);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Unknown" + ex.Message);

            }
        }


        [HttpPost("GetTeamById")]
        public async Task<IActionResult> GetTeamById([FromQuery] int teamId)
        {

            if (teamId < 1)
            {
                return BadRequest("CoachId should be positive interger. Invalid coachId specified : " + teamId);
            }

            try
            {
                var responseTeam = await teamService.GetTeamDetailsByIdAsync(teamId);
                return Ok(responseTeam);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error occured while making get request to the GetCoachById" + ex.Message);

            }

        }

    }
}
