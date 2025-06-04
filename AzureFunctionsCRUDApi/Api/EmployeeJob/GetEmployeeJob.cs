using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetEmployeeJob
    {
        private readonly JobDBContext jobDBContext;
        public GetEmployeeJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }
        [Function("GetEmployeeJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetEmployeeJob/{id}")] HttpRequest req, string id)
        {
            var employeeJob = await jobDBContext.EmployeeJob.FindAsync(int.Parse(id));
            if (employeeJob is null) return new NotFoundResult();
            return new OkObjectResult(employeeJob);
        }
    }   
    
}