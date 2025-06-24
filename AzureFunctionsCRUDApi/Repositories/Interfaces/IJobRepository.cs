using AzureFunctionsCRUDApi.Entities;
using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Repositories.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<Job>> GetJobsByBudgetRangeAsync(decimal minBudget, decimal maxBudget);
    }
}