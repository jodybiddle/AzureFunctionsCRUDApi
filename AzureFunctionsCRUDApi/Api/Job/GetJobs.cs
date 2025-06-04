using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetJobs
    {
        private readonly JobDBContext jobDBContext;
        public GetJobs(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetJobs")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            var jobs= await jobDBContext.Job.ToListAsync();
            return new OkObjectResult(jobs);
        }
    }
}