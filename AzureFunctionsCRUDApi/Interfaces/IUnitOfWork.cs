using AzureFunctionsCRUDApi.Repositories.Interfaces;

namespace AzureFunctionsCRUDApi.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IEmployeeRepository Employees { get; }
        IJobRepository Jobs { get; }
        IProductRepository Products { get; }
        IEmployeeJobRepository EmployeeJobs { get; }
        Task<int> SaveChangesAsync();
    }
}