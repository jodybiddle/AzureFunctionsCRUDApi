using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi.Api.Product 
{ 
    public class GetProducts
    {
        private readonly JobDBContext jobDBContext;
        public GetProducts(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("GetProducts")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            var products = await jobDBContext.Product.ToListAsync();
            return new OkObjectResult(products);
        }
    }
}