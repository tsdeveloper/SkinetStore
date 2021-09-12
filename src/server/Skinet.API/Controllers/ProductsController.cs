using Microsoft.AspNetCore.Mvc;
using Skinet.Core.Entities.Product;

namespace Skinet.API.Controllers
{
    
    public class ProductsController : BaseController
    {
        [HttpGet("test")]
        public IActionResult GetInforResultAction()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Teste1"
            };
            
            /*var result = GetProduct(product)
                .Match<Result<BaseResponses, Product>> 
                (
                    failure: falha => falha,
                    success: sucesso => product 
                );*/
            return Ok(product);
        }

        /*private Result<BaseResponses, Product> GetProduct(Product product)
        {
            return new ValidateRequest<BaseResponses, Product>()
                .ReturnInfo(info => info)
                .ReturnFailure(info, req => info )
                    .Validate(product);

        }*/
    }
}