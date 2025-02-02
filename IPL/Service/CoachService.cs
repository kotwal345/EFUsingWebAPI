using IPLDataModels;
using IPLDbContext;

namespace IPL.Service
{
    public class CoachService : ICoachService
    {
        public async Task<Coach> CreateCoach(Coach coachInput)
        {
            IPLSqlDbContext dbContext = new IPLSqlDbContext();

            try
            {
                var createdResponse = await dbContext.Coaches.AddAsync(coachInput);

                return createdResponse.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error While inserting data into Coaches Table" + ex.Message);
            }


        }
    }
}
