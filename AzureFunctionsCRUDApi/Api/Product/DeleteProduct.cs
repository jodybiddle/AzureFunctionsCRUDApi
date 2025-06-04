using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

namespace AzureFunctionsCRUDApi.Api.Product
{
    public class DeleteProduct
    {
        private readonly JobDBContext jobDBContext;
        public DeleteProduct(JobDBContext jobDBContext)
        {
            this.jobDBContext = jobDBContext;
        }

        [Function("DeleteProduct")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route="DeleteProduct/{id}")] HttpRequest req, string id)
        {
            var product = await jobDBContext.Product.FindAsync(int.Parse(id));
            if (product is null) return new NotFoundResult();

            jobDBContext.Product.Remove(product);
            await jobDBContext.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}