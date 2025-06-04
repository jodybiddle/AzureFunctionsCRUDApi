using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class CreateEmployee
    {
        private readonly JobDBContext jobDBContext;
        public CreateEmployee(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("CreateEmployee")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(body);
            await jobDBContext.AddAsync(employee);
            await jobDBContext.SaveChangesAsync();
            return new OkObjectResult(employee.Id);
        }
    }
}