using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetEmployees
    {
        private readonly JobDBContext jobDBContext;
        public GetEmployees(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetEmployees")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            var employees = await jobDBContext.Employee.ToListAsync();
            return new OkObjectResult(employees);
        }
    }
}