
using IPLDataModels;

namespace IPL.Service
{
    public interface IMatchService
    {
        /// <summary>
        /// This method is used to create new match in Match table
        /// </summary>
        /// <param name="matchInput">The Match to be created in the table</param>
        /// <returns>It will return the instance of creatred Match</returns>
        public Task<Match> CreateMatchAsync(Match matchInput);

        /// <summary>
        /// This method will return the match details if successfully invoked with id.
        /// </summary>
        /// <param name="id">Instance of Integer; indicating the id of the match in the Match table.</param>
        /// <returns>Will return the Match details for give id.</returns>
        public Task<Match> GetMatchDetailsByIdAsync(int id);

        /// <summary>
        /// This method will return the matches based on the limit and skip value 
        /// </summary>
        /// <param name="limit">Integer property indicating the how many records want to fetch.</param>
        /// <param name="skip">Integer property indicating the records to be skipped.</param>
        /// <returns>Will return he instace of IEnumerable of Match type</returns>
        public List<Match> GetAllMatches(int limit, int skip);

        /// <summary>
        /// This method will remove the Match from the matches table for given id.
        /// </summary>
        /// <param name="matchId">Integer instance indicating the primary key of table for matchId</param>
        /// <returns>will return async Task of void if deleted successfully</returns>
        public Task RemoveMatchAsync(int matchId);
    }
}
