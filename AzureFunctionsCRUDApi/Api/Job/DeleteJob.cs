using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class DeleteJob
    {
        private readonly JobDBContext jobDBContext;
        public DeleteJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("DeleteJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route="DeleteJob/{id}")] HttpRequest req, string id)
        {
            var job = await jobDBContext.Job.FindAsync(int.Parse(id));
            if (job is null) return new NotFoundResult();

            jobDBContext.Job.Remove(job);
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}