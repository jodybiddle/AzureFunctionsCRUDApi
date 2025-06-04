using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetProduct
    {
        private readonly JobDBContext jobDBContext;
        public GetProduct(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetProduct/{id}")] HttpRequest req, string id)
        {
            var product = await jobDBContext.Product.FindAsync(int.Parse(id));
            if (product is null) return new NotFoundResult();
            return new OkObjectResult(product);
        }
    }
}