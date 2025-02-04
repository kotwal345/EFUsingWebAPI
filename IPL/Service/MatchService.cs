using IPLDataModels;
using IPLDbContext;
using Microsoft.EntityFrameworkCore;


namespace IPL.Service
{
    public class MatchService : IMatchService
    {
        IPLSqlDbContext dbContext;
        public MatchService(IPLSqlDbContext iPLSqlDbContext)
        {
            dbContext = iPLSqlDbContext;
        }

        /// <summary>
        /// Add Data in Match Table 
        /// </summary>
        /// <param name="matchInput"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Match> CreateMatchAsync(Match matchInput)
        {

            try
            {
                var createdResponseMatch = await dbContext.Matches.AddAsync(matchInput);
                await dbContext.SaveChangesAsync();
                return createdResponseMatch.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error While inserting data into Match Table" + ex.Message);
            }
        }


        /// <summary>
        /// This method will return the Match details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the match in the Matches table.</param>
        /// <returns>Will return the Match details for give id.</returns>
        public async Task<Match> GetMatchDetailsByIdAsync(int id)
        {
            try
            {
                var response = await dbContext.Matches.FirstOrDefaultAsync(q => q.Id == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Fetch Match data into Match Table" + ex.Message);
            }
        }


        /// <summary>
        /// This method will return the matches based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will return he instace of IEnumerable of Team type</returns>
        public List<Match> GetAllMatches(int limit, int skip)
        {
            return dbContext.Matches.Skip(skip).Take(limit).ToList();
        }


        /// <summary>
        /// This method will remove the Match from the Matches table for given id.
        /// </summary>
        /// <param name="matchId">Integer instance indicating the primary key of table for matchId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public async Task RemoveMatchAsync(int matchId)
        {

            var matchToBeRemoved = await GetMatchDetailsByIdAsync(matchId);

            if (matchToBeRemoved != null)
            {
                dbContext.Remove(matchToBeRemoved);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
