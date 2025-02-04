using IPLDataModels;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace IPL.Service
{
    public interface ITeamService
    {
        public Task<Team> CreatedTeamAsync(Team teamsInput);

        /// <summary>
        /// This method will return the team details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the team in the teams table.</param>
        /// <returns>Will return the team details for give id.</returns>
        public Task<Team> GetTeamDetailsByIdAsync(int id);

        /// <summary>
        /// This method will return the teams based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will return he instace of IEnumerable of Team type</returns>
        public List<Team> GetAllTeams(int limit, int skip);

        /// <summary>
        /// This method will remove the Team from the teams table for given id.
        /// </summary>
        /// <param name="coachId">Integer instance indicating the primary key of table for coachId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public Task RemoveTeamAsync(int teamId);
    }
}
