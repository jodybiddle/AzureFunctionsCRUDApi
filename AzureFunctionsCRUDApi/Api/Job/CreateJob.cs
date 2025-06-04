using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class CreateJob
    {
        private readonly JobDBContext jobDBContext;
        public CreateJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("CreateJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var job = JsonConvert.DeserializeObject<Job>(body);
            await jobDBContext.AddAsync(job);
            await jobDBContext.SaveChangesAsync();
            return new OkObjectResult(job.Id);
        }
    }
}