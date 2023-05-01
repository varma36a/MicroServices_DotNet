using CommandSrvc.Commands.Interfaces;
using CommandSrvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CommandSrvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductCommand _productCommand;
        public ProductController(IProductCommand productCommand)
        {
            _productCommand = productCommand;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCommandModel model)
        {
            try
            {
                var product = await _productCommand.AddProductAsync(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductCommandModel model)
        {
            try
            {
                var status = await _productCommand.UpdateProductAsync(model);
                if (status == true)
                    return StatusCode(StatusCodes.Status200OK);
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            try
            {
                var status = await _productCommand.DeleteProductAsync(id);
                if (status == true)
                    return StatusCode(StatusCodes.Status200OK);
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
