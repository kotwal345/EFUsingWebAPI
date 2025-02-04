using IPLDataModels;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace IPL.Service
{
    public interface ITeamService
    {
        public Task<Team> CreatedTeamAsync(Team teamsInput);

        /// <summary>
        /// This method will return the coach details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the coach in the Coaches table.</param>
        /// <returns>Will return the Coach details for give id.</returns>
        public Task<Team> GetTeamDetailsByIdAsync(int id);
    }
}
