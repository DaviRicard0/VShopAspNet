using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productsDTO = await _productService.GetProducts();
            if (productsDTO is null)
            {
                return NotFound("Products not found");
            }
            return Ok(productsDTO);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var productDTO = await _productService.GetProductById(id);
            if (productDTO is null)
            {
                return NotFound("Categories not found");
            }
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
            {
                return BadRequest("Invalid Data");
            }
            await _productService.AddProduct(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest("Invalid Id");
            }
            if (productDTO is null)
            {
                return BadRequest("Invalid Data");
            }
            await _productService.UpdateProduct(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDTO = await _productService.GetProductById(id);
            if (productDTO is null)
            {
                return NotFound("Category not found");
            }
            await _productService.RemoveProduct(id);

            return Ok(productDTO);
        }
    }
}
