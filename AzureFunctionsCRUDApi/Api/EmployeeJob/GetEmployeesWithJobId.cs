using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product
{
    public class GetEmployeesWithJobId
    {
        private readonly JobDBContext jobDBContext;
        public GetEmployeesWithJobId(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetEmployeesWithJobId")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetEmployeesWithJobId/{Id}")] HttpRequest req, string Id)
        {
            // Get jobId from query string
            var jobId = int.Parse(Id);

            // Join EmployeeJob and Employee, filter by jobId
            var employees = await (
                from ej in jobDBContext.EmployeeJob
                join e in jobDBContext.Employee on ej.EmployeeId equals e.Id
                where ej.JobId == jobId
                select new
                {
                    EmployeeJobId = ej.Id,
                    EmployeeId = e.Id,
                    e.Name,
                    e.Salary,
                    e.Skill,
                    e.Comment
                }
            ).OrderBy(e => e.Name).ToListAsync();

            return new OkObjectResult(employees);
        }
    }
}