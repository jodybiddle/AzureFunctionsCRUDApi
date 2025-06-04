using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class CreateProduct
    {
        private readonly JobDBContext jobDBContext;
        public CreateProduct(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("CreateProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var product = JsonConvert.DeserializeObject<Product>(body);
            await jobDBContext.AddAsync(product);
            await jobDBContext.SaveChangesAsync();
            return new OkObjectResult(product.Id);
        }
    }
}