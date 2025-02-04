//using IPLDataModels;
//using System.Data.Entity;
using IPLDataModels;
using IPLDbContext;
using Microsoft.EntityFrameworkCore;


namespace IPL.Service
{
    public class TeamService : ITeamService
    {
        IPLSqlDbContext dbContext;
        public TeamService(IPLSqlDbContext iPLSqlDbContext)
        {
            dbContext = iPLSqlDbContext;
        }
        public async Task<Team> CreatedTeamAsync(Team teamsInput)
        {

            try
            {
                var createdteamResponse = await dbContext.teams.AddAsync(teamsInput);
                await dbContext.SaveChangesAsync();
                return createdteamResponse.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error While inserting data into Team Table" + ex.Message);
            }
        }

        /// <summary>
        /// This method will return the coach details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the coach in the Coaches table.</param>
        /// <returns>Will return the Coach details for give id.</returns>
        public async Task<Team> GetTeamDetailsByIdAsync(int id)
        {
            try
            {
                var responseTeam = await dbContext.teams.FirstOrDefaultAsync(q => q.Id == id);
                return responseTeam;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
