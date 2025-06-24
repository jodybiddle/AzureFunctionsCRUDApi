using AzureFunctionsCRUDApi.Entities;
using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Repositories.Interfaces
{
    public interface IEmployeeJobRepository : IRepository<EmployeeJob>
    {
        Task<IEnumerable<Employee>> GetEmployeesByJobIdAsync(int jobId);
        Task<IEnumerable<Job>> GetJobsByEmployeeIdAsync(int employeeId);
    }
}