using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetEmployeeJobs
    {
        private readonly JobDBContext jobDBContext;
        public GetEmployeeJobs(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetEmployeeJobs")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            var employeeJobs = await jobDBContext.EmployeeJob.ToListAsync();
            return new OkObjectResult(employeeJobs);
        }
    }
}