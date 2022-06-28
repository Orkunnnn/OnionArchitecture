using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.CQRS.Commands.DeleteProduct;
using OnionArchitecture.Application.CQRS.Commands.UpdateProduct;
using OnionArchitecture.Application.CQRS.Queries.GetAllProducts;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductViewModel createProductCommandRequest)
        {
            await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommandRequest updateProductCommandRequest)
        {
            await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var response = await _mediator.Send(deleteProductCommandRequest);
            if (!response.Result)
                return BadRequest();

            return Ok();
        }
    }
}
