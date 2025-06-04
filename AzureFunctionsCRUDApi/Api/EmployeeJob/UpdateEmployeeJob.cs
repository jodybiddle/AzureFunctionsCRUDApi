using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class UpdateEmployeeJob
    {
        private readonly JobDBContext jobDBContext;
        public UpdateEmployeeJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("UpdateEmployeeJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var employeeJob = JsonConvert.DeserializeObject<EmployeeJob>(body);

            var oldEmployeeJob = await jobDBContext.EmployeeJob.FindAsync(employeeJob.Id);
            if (oldEmployeeJob is null) return new NotFoundResult();

            oldEmployeeJob.EmployeeId = employeeJob.EmployeeId;
            oldEmployeeJob.JobId = employeeJob.JobId;
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}