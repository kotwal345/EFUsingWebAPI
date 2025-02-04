using IPL.Service;
using IPLDataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchService matchService;
        public MatchController(IMatchService _matchService)
        {
            matchService = _matchService;
        }


        [HttpPost("AddMatch")]
        public async Task<IActionResult> AddMatch(Match matchRequest)
        {
            if (matchRequest == null)
            {
                return BadRequest("Invalid Argument");
            }

            try
            {

                var response = await matchService.CreateMatchAsync(matchRequest);

                return CreatedAtAction(nameof(AddMatch), "", response);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Unknown" + ex.Message);

            }
        }


        [HttpPost("GetMatchById")]
        public async Task<IActionResult> GetMatchById([FromQuery] int matchId)
        {

            if (matchId < 1)
            {
                return BadRequest("MatchId should be positive interger. Invalid matchId specified : " + matchId);
            }

            try
            {
                var response = await matchService.GetMatchDetailsByIdAsync(matchId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error occured while making get request to the GetMatchById" + ex.Message);

            }

        }


        [HttpGet("GetAllMatches")]
        public IActionResult GetAllMatches([FromQuery] int pageIndex, [FromQuery] int pageSize)
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

            var response = matchService.GetAllMatches(limit, skip);

            return Ok(response);
        }


        [HttpDelete("DeleteMatchById")]
        public async Task<IActionResult> DeleteMatchById([FromQuery] int matchId)
        {

            await matchService.RemoveMatchAsync(matchId);

            return NoContent();
        }
    }
}
