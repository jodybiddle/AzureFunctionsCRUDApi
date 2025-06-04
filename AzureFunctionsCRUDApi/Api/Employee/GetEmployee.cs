using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetEmployee
    {
        private readonly JobDBContext jobDBContext;
        public GetEmployee(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }
        [Function("GetEmployee")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetEmployee/{id}")] HttpRequest req, string id)
        {
            var employee = await jobDBContext.Employee.FindAsync(int.Parse(id));
            if (employee is null) return new NotFoundResult();
            return new OkObjectResult(employee);
        }
    }   
    
}