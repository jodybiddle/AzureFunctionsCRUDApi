using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi
{
    public class DeleteEmployee
    {
        private readonly JobDBContext jobDBContext;
        public DeleteEmployee(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }
        [Function("DeleteEmployee")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteEmployee/{id}")] HttpRequest req, int id)
        {
            var employee = await jobDBContext.Employee.FindAsync(id);
            if (employee is null) return new NotFoundResult();
            jobDBContext.Employee.Remove(employee);
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
    
}