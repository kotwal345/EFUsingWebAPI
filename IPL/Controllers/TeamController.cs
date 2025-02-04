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
                return BadRequest("TeamId should be positive interger. Invalid teamId specified : " + teamId);
            }

            try
            {
                var responseTeam = await teamService.GetTeamDetailsByIdAsync(teamId);
                return Ok(responseTeam);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error occured while making get request to the GetTeamById" + ex.Message);

            }

        }


        [HttpGet("GetAllTeams")]
        public IActionResult GetAllTeams([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            if (pageIndex < 0)
            {
                return BadRequest("Page index must be equal or greater than 0 . Specified value : " + pageIndex);
            }

            if (pageSize < 0 || pageSize > 5)
            {
                return BadRequest("Page Size must be greater than 0 and less than 6 . Specified value : " + pageSize);
            }

            int skip = pageIndex * pageSize;
            int limit = pageSize;

            var response = teamService.GetAllTeams(limit, skip);

            return Ok(response);
        }


        [HttpDelete("DeleteTeamById")]
        public async Task<IActionResult> DeleteTeamById([FromQuery] int teamId)
        {

            await teamService.RemoveTeamAsync(teamId);

            return NoContent();
        }
    }
}
