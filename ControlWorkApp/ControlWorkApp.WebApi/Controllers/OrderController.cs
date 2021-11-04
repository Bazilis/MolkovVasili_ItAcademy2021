using ControlWorkApp.BLL.DTO;
using ControlWorkApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControlWorkApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> _orderService;

        public OrderController(IService<OrderDto> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetAll()
        {
            return _orderService.GetAll();
        }

        [HttpGet("{id}")]
        public OrderDto GetById(int id)
        {
            return _orderService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] OrderDto order)
        {
            _orderService.Create(order);
        }

        [HttpPut()]
        public void Put([FromBody] OrderDto order)
        {
            _orderService.Update(order);
        }

        [HttpDelete()]
        public void Delete([FromBody] OrderDto order)
        {
            _orderService.Delete(order);
        }
    }
}
