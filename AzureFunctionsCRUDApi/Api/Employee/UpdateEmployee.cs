using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class UpdateEmployee
    {
        private readonly JobDBContext jobDBContext;
        public UpdateEmployee(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("UpdateEmployee")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(body);

            var oldEmployee = await jobDBContext.Employee.FindAsync(employee.Id);
            if (oldEmployee is null) return new NotFoundResult();

            oldEmployee.Name = employee.Name;
            oldEmployee.Salary= employee.Salary;
            oldEmployee.Comment = employee.Comment;
            oldEmployee.Skill = employee.Skill;
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}