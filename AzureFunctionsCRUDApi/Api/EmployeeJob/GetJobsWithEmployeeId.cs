using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product
{
    public class GetJobsWithEmployeeId
    {
        private readonly JobDBContext jobDBContext;
        public GetJobsWithEmployeeId(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetJobsWithEmployeeId")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetJobsWithEmployeeId/{Id}")] HttpRequest req, string Id)
        {
            // Get jobId from query string
            var employeeId = int.Parse(Id);

            // Join EmployeeJob and Employee, filter by jobId
            var jobs = await (
                from ej in jobDBContext.EmployeeJob
                join j in jobDBContext.Job on ej.JobId equals j.Id
                where ej.EmployeeId == employeeId
                select j
            ).ToListAsync();

            return new OkObjectResult(jobs);
        }
    }
}