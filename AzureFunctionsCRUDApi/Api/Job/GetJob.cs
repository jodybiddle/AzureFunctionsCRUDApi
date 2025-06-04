using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetJob
    {
        private readonly JobDBContext jobDBContext;
        public GetJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetJob/{id}")] HttpRequest req, string id)
        {
            var job = await jobDBContext.Job.FindAsync(int.Parse(id));
            if (job is null) return new NotFoundResult();
            return new OkObjectResult(job);
        }
    }
}