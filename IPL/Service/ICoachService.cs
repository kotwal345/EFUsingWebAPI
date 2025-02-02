using IPLDataModels;

namespace IPL.Service
{
    public interface ICoachService
    {
        /// <summary>
        /// This method is used to create new coach in Coaches table
        /// </summary>
        /// <param name="coachInput">The Coach to be created in the table</param>
        /// <returns>It will return the instance of creatred Coach</returns>
        public Task<Coach> CreateCoach(Coach coachInput);
    }
}
