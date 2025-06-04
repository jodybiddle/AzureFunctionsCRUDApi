using AzureFunctionsCRUDApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi
{
    public class UpdateProduct
    {
        private readonly JobDBContext jobDBContext;
        public UpdateProduct(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("UpdateProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var product = JsonConvert.DeserializeObject<Product>(body);

            var oldProduct = await jobDBContext.Product.FindAsync(product.Id);
            if (oldProduct is null) return new NotFoundResult();

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}