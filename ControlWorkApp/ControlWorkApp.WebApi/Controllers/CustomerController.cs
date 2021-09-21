using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlWorkApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IService<CustomerDto> _customerService;

        public CustomerController(IService<CustomerDto> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetAll()
        {
            return _customerService.GetAll();
        }

        [HttpGet("{id}")]
        public CustomerDto GetById(int id)
        {
            return _customerService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] CustomerDto customer)
        {
            _customerService.Create(customer);
        }

        [HttpPut()]
        public void Put([FromBody] CustomerDto customer)
        {
            _customerService.Update(customer);
        }

        [HttpDelete()]
        public void Delete([FromBody] CustomerDto customer)
        {
            _customerService.Delete(customer);
        }
    }
}
