using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi
{
    public class DeleteEmployeeJob
    {
        private readonly JobDBContext jobDBContext;
        public DeleteEmployeeJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }
        [Function("DeleteEmployeeJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteEmployeeJob/{id}")] HttpRequest req, int id)
        {
            var employeeJob = await jobDBContext.EmployeeJob.FindAsync(id);
            if (employeeJob is null) return new NotFoundResult();
            jobDBContext.EmployeeJob.Remove(employeeJob);
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
    
}