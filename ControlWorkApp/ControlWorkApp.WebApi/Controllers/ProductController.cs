using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlWorkApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IService<ProductDto> _productService;

        public ProductController(IService<ProductDto> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ProductDto product)
        {
            _productService.Create(product);
        }

        [HttpPut()]
        public void Put([FromBody] ProductDto product)
        {
            _productService.Update(product);
        }

        [HttpDelete()]
        public void Delete([FromBody] ProductDto product)
        {
            _productService.Delete(product);
        }
    }
}
