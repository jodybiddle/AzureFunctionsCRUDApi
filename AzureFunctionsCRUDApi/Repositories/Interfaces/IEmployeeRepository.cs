using AzureFunctionsCRUDApi.Entities;
using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesBySkillAsync(string skill);
    }
}