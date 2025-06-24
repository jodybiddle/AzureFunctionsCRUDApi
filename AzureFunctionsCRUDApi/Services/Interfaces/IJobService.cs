using AzureFunctionsCRUDApi.Entities;

namespace AzureFunctionsCRUDApi.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job?> GetJobByIdAsync(int id);
        Task<int> CreateJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int id);
        Task<IEnumerable<Job>> GetJobsByBudgetRangeAsync(decimal minBudget, decimal maxBudget);
    }
}