using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class UpdateJob
    {
        private readonly JobDBContext jobDBContext;
        public UpdateJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("UpdateJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var job = JsonConvert.DeserializeObject<Job>(body);

            var oldJob = await jobDBContext.Job.FindAsync(job.Id);
            if (oldJob is null) return new NotFoundResult();

            oldJob.Name = job.Name;
            oldJob.Budget = job.Budget;
            oldJob.Comment = job.Comment;
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}