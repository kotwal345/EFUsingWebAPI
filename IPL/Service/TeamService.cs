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

        /// <summary>
        /// This method will create the team details.
        /// </summary>
        /// <param name="teamsInput"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// This method will return the team details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the Team in the teams table.</param>
        /// <returns>Will return the Team details for give id.</returns>
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


        /// <summary>
        /// This method will return the teams based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will returnt he instace of IEnumerable of teams type</returns>
        public List<Team> GetAllTeams(int limit, int skip)
        {
            return dbContext.teams.Skip(skip).Take(limit).ToList();
        }


        /// <summary>
        /// This method will remove the Team from the teams table for given id.
        /// </summary>
        /// <param name="teamId">Integer instance indicating the primary key of table for coachId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public async Task RemoveTeamAsync(int teamId)
        {

            var teamToBeRemoved = await GetTeamDetailsByIdAsync(teamId);

            if (teamToBeRemoved != null)
            {
                dbContext.Remove(teamToBeRemoved);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
