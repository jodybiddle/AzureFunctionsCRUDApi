using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class CreateEmployeeJob
    {
        private readonly JobDBContext jobDBContext;
        public CreateEmployeeJob(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("CreateEmployeeJob")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var employeeJob = JsonConvert.DeserializeObject<EmployeeJob>(body);
            await jobDBContext.AddAsync(employeeJob);
            await jobDBContext.SaveChangesAsync();
            return new OkObjectResult(employeeJob.Id);
        }
    }
}